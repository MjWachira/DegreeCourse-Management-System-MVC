using BLL.GradeB;
using Microsoft.AspNetCore.Mvc;
using Model.ModelGradeM;
using System.Threading.Tasks;

namespace CRUD_WEB.Controllers
{
    public class GradeController : Controller
    {
        #region Enrollment

        #region Designation

        [HttpGet]
        [Route("/Grade/Designation")]
        public async Task<IActionResult> DesignationIndex()
        {
            return View(await new GradeB().GetAllGrades());
        }

        [HttpGet]
        public async Task<IActionResult> DesignationForm(Int64 ID = 0)
        {
            ModelGrade model = new ModelGrade();
            if (ID == 0)
            {
                model.GradeId = 0;
                model.EnrollmentId = null;
                model.Grade1 = null;

                return View(model);
            }
            else
            {
                model = await new GradeB().GetGradeByID(ID);
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DesignationForm(ModelGrade model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int res = await new GradeB().SaveGrade(model);
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
                bool res = await new GradeB().DeleteGrade(ID);
                if (res)
                {
                    //?????????????
                }
                else
                {
                    //????????????????
                }
                return Redirect("/Grade/Designation");

            }
            return NotFound();
        }
        #endregion


        #endregion
    }
}