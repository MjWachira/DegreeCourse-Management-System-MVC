using DAL.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Modules.EnrollmentR
{
    public class EnrollmentRepositories
    {

        #region Initialize
        CrudMvcContext context;

        public EnrollmentRepositories(CrudMvcContext _context)

        {
            context = _context;
        }
        #endregion

        #region Enrollment
        public async Task<List<Enrollment>> GetAllEnrollments()
        {
            List<Enrollment> lstEnrollment = (from E in context.Enrollments
                                              orderby E.EnrollmentDate
                                              select E).ToList<Enrollment>();
            return lstEnrollment;
        }

        public async Task<Enrollment> GetEnrollmentByID(Int64 ID)
        {
            Enrollment EnrollmentVar = (from d in context.Enrollments
                                        where d.EnrollmentId == ID
                                        select d).FirstOrDefault<Enrollment>();
            return EnrollmentVar;
        }

        #endregion

    }
}