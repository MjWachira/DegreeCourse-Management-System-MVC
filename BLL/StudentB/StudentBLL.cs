using DAL.Db;
using DAL.Modules.StudentM;
using Model.ModelStudentM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.StudentB
{
    public class StudentBLL
    {

        #region Student
        public async Task<List<ModelStudent>> GetAllStudents()
        {
            List<ModelStudent> studentModelList = new List<ModelStudent>();
            List<Student> studentList = await new StudentDal().GetAllStudents();
            if (studentList.Count > 0)
            {
                foreach (var item in studentList)
                {
                    ModelStudent model = new ModelStudent();
                    model.StudentId = item.StudentId;
                    model.StudentName = item.StudentName;
                    model.DateOfBirth = item.DateOfBirth;
                    model.Email = item.Email;
                    model.PhoneNumber = item.PhoneNumber;

                    studentModelList.Add(model);
                }
            }
            return studentModelList;
        }

        public async Task<ModelStudent> GetStudentByID(Int64 ID)
        {
            ModelStudent model = new ModelStudent();
            Student student = await new StudentDal().GetStudentByID(ID);
            if (student != null)
            {
                model.StudentId = student.StudentId;
                model.StudentName = student.StudentName;
                model.DateOfBirth = student.DateOfBirth;
                model.Email = student.Email;
                model.PhoneNumber = student.PhoneNumber;
            }
            return model;
        }

        public async Task<int> SaveStudent(ModelStudent model)
        {
            int res = 0;
            Student studentData = new Student();
            studentData.StudentId = model.StudentId;
            studentData.StudentName = model.StudentName;
            studentData.DateOfBirth = model.DateOfBirth;
            studentData.Email = model.Email;
            studentData.PhoneNumber = model.PhoneNumber;

            res = await new StudentDal().SaveStudent(studentData);
            return res;
        }

        public async Task<bool> DeleteStudent(Int32 _ID)
        {
            return await new StudentDal().DeleteStudent(_ID);
        }
        #endregion
    }
}