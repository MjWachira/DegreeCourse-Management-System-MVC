using DAL.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Modules.CourseR
{
    public class CourseRepositories
    {
        #region Initialize
        CrudMvcContext context;

        public CourseRepositories(CrudMvcContext _context)

        {
            context = _context;
        }
        #endregion

        #region Course
        public async Task<List<Course>> GetAllCourses()
        {
            List<Course> lstCourse = (from C in context.Courses
                                      orderby C.CourseName
                                      select C).ToList<Course>();
            return lstCourse;
        }

        public async Task<Course> GetCourseID(Int64 ID)
        {
            Course CourseVar = (from d in context.Courses
                                where d.CourseId == ID
                                select d).FirstOrDefault<Course>();
            return CourseVar;
        }

        #endregion


    }
}