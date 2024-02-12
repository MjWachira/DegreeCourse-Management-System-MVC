using DAL.Db;
using System;
using DAL.Repository.Modules.StudentR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Modules.StudentM
{
    public class StudentDal
    {

        #region Initialize
        CrudMvcContext db;
        public StudentDal()
        {
            db = new CrudMvcContext();
        }

        #endregion

        #region Student
        //Read
        public async Task<List<Student>> GetAllStudents()
        {
            return await new StudentRepositories(db).GetAllStudents();
        }

        public async Task<Student> GetStudentByID(Int64 ID)
        {
            return await new StudentRepositories(db).GetStudentByID(ID);
        }

        //Create and update
        public async Task<int> SaveStudent(Student _studentModel)
        {
            try
            {
                if (_studentModel.StudentId > 0)
                {
                    db.Update<Student>(_studentModel);
                    await db.SaveChangesAsync();
                    return 2; 
                }
                else
                {
                    //Count +1 For Id
                    int maxId = await db.Students.MaxAsync(s => (int?)s.StudentId) ?? 0;
                    _studentModel.StudentId = maxId + 1;
                    db.Add<Student>(_studentModel);
                    await db.SaveChangesAsync();
                    return 1; 
                }
            }
            catch (Exception ex)
            {
             
                Console.WriteLine(ex.Message);
                return 0; // Failed to save
            }
        }


        //Delete
        public async Task<bool> DeleteStudent(Int32 _ID)
        {
            db.Remove<Student>(db.Find<Student>(_ID));
            db.SaveChangesAsync();
            return true;

        }

        #endregion

    }
}