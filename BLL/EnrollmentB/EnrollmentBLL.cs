using DAL.Db;
using DAL.Modules.EnrollmentM;
using Model.ModelEnrollmentM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EnrollmentB
{
    public class EnrollmentBLL
    {
        #region Enrollment
        public async Task<List<ModelEnrollment>> GetAllEnrollments()
        {
            List<ModelEnrollment> enrollmentModelList = new List<ModelEnrollment>();
            List<Enrollment> enrollmentList = await new EnrollmentDal().GetAllEnrollments();
            if (enrollmentList.Count > 0)
            {
                foreach (var item in enrollmentList)
                {
                    ModelEnrollment model = new ModelEnrollment();
                    model.EnrollmentId = item.EnrollmentId;
                    model.StudentId = item.StudentId;
                    model.CourseId = item.CourseId;
                    model.EnrollmentDate = item.EnrollmentDate;
                    enrollmentModelList.Add(model);
                }
            }
            return enrollmentModelList;
        }

        public async Task<ModelEnrollment> GetEnrollmentByID(Int64 ID)
        {
            ModelEnrollment model = new ModelEnrollment();
            Enrollment enrollment = await new EnrollmentDal().GetEnrollmentByID(ID);
            if (enrollment != null)
            {
                model.EnrollmentId = enrollment.EnrollmentId;
                model.StudentId = enrollment.StudentId;
                model.CourseId = enrollment.CourseId;
                model.EnrollmentDate = enrollment.EnrollmentDate;
            }
            return model;
        }

        public async Task<int> SaveEnrollment(ModelEnrollment model)
        {
            int res = 0;
            Enrollment enrollmentData = new Enrollment();
            enrollmentData.EnrollmentId = model.EnrollmentId;
            enrollmentData.StudentId = model.StudentId;
            enrollmentData.CourseId = model.CourseId;
            enrollmentData.EnrollmentDate = model.EnrollmentDate;

            res = await new EnrollmentDal().SaveEnrollment(enrollmentData);
            return res;
        }

        public async Task<bool> DeleteEnrollment(Int32 _ID)
        {
            return await new EnrollmentDal().DeleteEnrollment(_ID);
        }
        #endregion
    }
}