using BLL.StudentB;

using DAL.Db;
using Microsoft.AspNetCore.Mvc;
using Model.ModelStudentM;
using System.Threading.Tasks;

namespace CRUD_WEB.Controllers
{
    public class StudentController : Controller
    {
        #region Enrollment

        #region Designation

        [HttpGet]
        [Route("/Student/Designation")]
        public async Task<IActionResult> DesignationIndex()
        {
            return View(await new StudentBLL().GetAllStudents());
        }

        [HttpGet]
        public async Task<IActionResult> DesignationForm(Int64 ID = 0)
        {
            ModelStudent model = new ModelStudent();
            if (ID == 0)
            {
                model.StudentId = 0;
                model.StudentName = null;
                model.DateOfBirth = null;
                model.Email = null;
                model.PhoneNumber = null;

                return View(model);
            }
            else
            {
                model = await new StudentBLL().GetStudentByID(ID);
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DesignationForm(ModelStudent model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int res = await new StudentBLL().SaveStudent(model);
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
                bool res = await new StudentBLL().DeleteStudent(ID);
                if (res)
                {
                    //?????????????
                }
                else
                {
                    //????????????????
                }
                return Redirect("/Student/Designation");

            }
            return NotFound();
        }
        #endregion


        #endregion
    }
}