using DAL.Db;
using System;
using DAL.Repository.Modules.GradeR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Modules.GradeM
{
    public class GradeDal
    {

        #region Initialize
        CrudMvcContext db;
        public GradeDal()
        {
            db = new CrudMvcContext();
        }

        #endregion

        #region Grade
        //Read
        public async Task<List<Grade>> GetAllGrades()
        {
            return await new GradeRepositories(db).GetAllGrades();
        }

        public async Task<Grade> GetGradeByID(Int64 ID)
        {
            return await new GradeRepositories(db).GetGradebyID(ID);
        }

        //Create and update
        public async Task<int> SaveGrade(Grade _gradeModel)
        {
            bool saveSuccessfully = false;
            int isSaved = 0;

            if (_gradeModel.GradeId == 0)
            {
                db.Add<Grade>(_gradeModel);
                db.SaveChangesAsync();

                isSaved = 1;
            }
            else
            {
                db.Update<Grade>(_gradeModel);
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
        public async Task<bool> DeleteGrade(Int32 _ID)
        {
            db.Remove<Grade>(db.Find<Grade>(_ID));
            db.SaveChangesAsync();
            return true;

        }

        #endregion

    }
}