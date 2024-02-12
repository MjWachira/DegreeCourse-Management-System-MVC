using DAL.Db;
using DAL.Modules.GradeM;
using Model.ModelGradeM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GradeB
{
    public class GradeB
    {
        #region Grade
        public async Task<List<ModelGrade>> GetAllGrades()
        {
            List<ModelGrade> gradeModelList = new List<ModelGrade>();
            List<Grade> gradeList = await new GradeDal().GetAllGrades();
            if (gradeList.Count > 0)
            {
                foreach (var item in gradeList)
                {
                    ModelGrade model = new ModelGrade();
                    model.GradeId = item.GradeId;
                    model.EnrollmentId = item.EnrollmentId;
                    model.Grade1 = item.Grade1;
                    gradeModelList.Add(model);
                }
            }
            return gradeModelList;
        }

        public async Task<ModelGrade> GetGradeByID(Int64 ID)
        {
            ModelGrade model = new ModelGrade();
            Grade grade = await new GradeDal().GetGradeByID(ID);
            if (grade != null)
            {
                model.GradeId = grade.GradeId;
                model.EnrollmentId = grade.EnrollmentId;
                model.Grade1 = grade.Grade1;
            }
            return model;
        }

        public async Task<int> SaveGrade(ModelGrade model)
        {
            int res = 0;
            Grade gradeData = new Grade();
            gradeData.GradeId = model.GradeId;
            gradeData.EnrollmentId = model.EnrollmentId;
            gradeData.Grade1 = model.Grade1;

            res = await new GradeDal().SaveGrade(gradeData);
            return res;
        }

        public async Task<bool> DeleteGrade(Int32 _ID)
        {
            return await new GradeDal().DeleteGrade(_ID);
        }
        #endregion
    }
}