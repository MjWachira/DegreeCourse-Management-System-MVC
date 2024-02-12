using BLL.CourseB;
using DAL.Modules.CourseM;
using Microsoft.AspNetCore.Mvc;
using Model.ModelCourseM;
using System;
using System.Threading.Tasks;

namespace CRUD_WEB.Controllers
{
    public class CourseController : Controller
    {
        #region Enrollment

        #region Designation

        [HttpGet]
        [Route("/Course/Designation")]
        public async Task<IActionResult> DesignationIndex()
        {
            return View(await new CourseBLL().GetAllCourses());
        }

        [HttpGet]
        public async Task<IActionResult> DesignationForm(Int64 ID = 0)
        {
            ModelCourse model = new ModelCourse();
            if (ID == 0)
            {
                model.CourseId = 0;
                model.CourseName = "";
                model.CourseDescription = "";
                model.CreditHours = 0;

                return View(model);
            }
            else
            {
                model = await new CourseBLL().GetCourseByID(ID);
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DesignationForm(ModelCourse model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int res = await new CourseBLL().SaveCourse(model);
                    //??????????
                }
                return View(model);
            }
            catch (Exception exp)
            {
                string errorMessage = exp.Message;
                return NotFound();
            }

        }

        [HttpGet, ActionName("DeleteDesignation")]
        public async Task<IActionResult> DeleteDesignationConfirm(Int32 ID)
        {
            if (ID != 0)
            {
                bool res = await new CourseBLL().DeleteCourse(ID);
                if (res)
                {
                    //?????????????
                }
                else
                {
                    //????????????????
                }
                return Redirect("/CourseBLL/Designation");

            }
            return NotFound();
        }
        #endregion


        #endregion
    }
}