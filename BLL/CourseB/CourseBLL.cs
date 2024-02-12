using DAL.Db;
using DAL.Modules.CourseM;
using Model.ModelCourseM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CourseB
{
    public class CourseBLL
    {
        #region Course
        public async Task<List<ModelCourse>> GetAllCourses()
        {
            List<ModelCourse> courseModelList = new List<ModelCourse>();
            List<Course> courseList = await new CourseDal().GetAllCourses();
            if (courseList.Count > 0)
            {
                foreach (var item in courseList)
                {
                    ModelCourse model = new ModelCourse();
                    model.CourseId = item.CourseId;
                    model.CourseName = item.CourseName;
                    model.CourseDescription = item.CourseDescription;
                    model.CreditHours = item.CreditHours;
                    courseModelList.Add(model);
                }
            }
            return courseModelList;
        }

        public async Task<ModelCourse> GetCourseByID(Int64 ID)
        {
            ModelCourse model = new ModelCourse();
            Course course = await new CourseDal().GetCourseID(ID);
            if (course != null)
            {
                model.CourseId = course.CourseId;
                model.CourseName = course.CourseName;
                model.CourseDescription = course.CourseDescription;
                model.CreditHours = course.CreditHours;
            }
            return model;
        }

        public async Task<int> SaveCourse(ModelCourse model)
        {
            int res = 0;
            Course courseData = new Course();
            courseData.CourseId = model.CourseId;
            courseData.CourseName = model.CourseName;
            courseData.CourseDescription = model.CourseDescription;
            courseData.CreditHours = model.CreditHours;

            res = await new CourseDal().SaveCourse(courseData);
            return res;
        }

        public async Task<bool> DeleteCourse(Int32 _ID)
        {
            return await new CourseDal().DeleteCourse(_ID);
        }
        #endregion
    }
}