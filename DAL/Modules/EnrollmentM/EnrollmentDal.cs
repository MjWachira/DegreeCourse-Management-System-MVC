using DAL.Db;
using System;
using DAL.Repository.Modules.EnrollmentR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Modules.EnrollmentM
{
    public class EnrollmentDal

    {

        #region Initialize
        CrudMvcContext db;
        public EnrollmentDal()
        {
            db = new CrudMvcContext();
        }

        #endregion

        #region Enrollment
        //Read
        public async Task<List<Enrollment>> GetAllEnrollments()
        {
            return await new EnrollmentRepositories(db).GetAllEnrollments();
        }

        public async Task<Enrollment> GetEnrollmentByID(Int64 ID)
        {
            return await new EnrollmentRepositories(db).GetEnrollmentByID(ID);
        }

        //Create and update
        public async Task<int> SaveEnrollment(Enrollment _EnrollmentModel)
        {
            bool saveSuccessfully = false;
            int isSaved = 0;

            if (_EnrollmentModel.EnrollmentId > 0)
            {
                db.Add<Enrollment>(_EnrollmentModel);
                db.SaveChangesAsync();
                isSaved = 1;
            }
            else
            {
                db.Update<Enrollment>(_EnrollmentModel);
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
        public async Task<bool> DeleteEnrollment(Int32 _ID)
        {
            db.Remove<Enrollment>(db.Find<Enrollment>(_ID));
            db.SaveChangesAsync();
            return true;

        }

        #endregion

    }
}