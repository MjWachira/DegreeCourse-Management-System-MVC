using BLL.EnrollmentB;
using Microsoft.AspNetCore.Mvc;
using Model.ModelEnrollmentM;
using System;
using System.Threading.Tasks;

namespace CRUD_WEB.Controllers
{
    public class EnrollmentController : Controller
    {
        #region Enrollment

        #region Designation

        [HttpGet]
        [Route("/Enrollment/Designation")]
        public async Task<IActionResult> DesignationIndex()
        {
            return View(await new EnrollmentBLL().GetAllEnrollments());
        }

        [HttpGet]
        public async Task<IActionResult> DesignationForm(Int64 ID = 0)
        {
            ModelEnrollment model = new ModelEnrollment();
            if (ID == 0)
            {
                model.EnrollmentId = 0;
                model.StudentId = null;
                model.CourseId = null;

                return View(model);
            }
            else
            {
                model = await new EnrollmentBLL().GetEnrollmentByID(ID);
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DesignationForm(ModelEnrollment model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int res = await new EnrollmentBLL().SaveEnrollment(model);
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
                bool res = await new EnrollmentBLL().DeleteEnrollment(ID);
                if (res)
                {
                    //?????????????
                }
                else
                {
                    //????????????????
                }
                return Redirect("/Enrollment/Designation");

            }
            return NotFound();
        }
        #endregion


        #endregion
    }
}