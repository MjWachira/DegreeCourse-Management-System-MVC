using DAL.Db;
using System;
using DAL.Repository.Modules.CourseR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Modules.CourseM
{
    public class CourseDal

    {

        #region Initialize
        CrudMvcContext db;
        public CourseDal()
        {
            db = new CrudMvcContext();
        }

        #endregion

        #region Designation
        //Read
        public async Task<List<Course>> GetAllCourses()
        {
            return await new CourseRepositories(db).GetAllCourses();
        }

        public async Task<Course> GetCourseID(Int64 ID)
        {
            return await new CourseRepositories(db).GetCourseID(ID);
        }

        //Create and update
        public async Task<int> SaveCourse(Course _CourseModel)
        {
            bool saveSuccessfully = false;
            int isSaved = 0;

            if (_CourseModel.CourseId == 0)
            {
                db.Add<Course>(_CourseModel);
                db.SaveChangesAsync();
                isSaved = 1;
            }
            else
            {
                db.Update<Course>(_CourseModel);
                db.SaveChangesAsync();
                isSaved = 2;
            }

        
            saveSuccessfully = true;

            if (saveSuccessfully)
            {
                return isSaved;
            }
            else
            {
                return 0;
            }
        }

        //Delete
        public async Task<bool> DeleteCourse(Int32 _ID)
        {
            db.Remove<Course>(db.Find<Course>(_ID));
            db.SaveChangesAsync();
            return true;

        }

        #endregion

    }
}