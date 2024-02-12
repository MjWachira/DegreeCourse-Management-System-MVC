using DAL.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Modules.GradeR
{
    public class GradeRepositories
    {

        #region Initialize
        CrudMvcContext context;

        public GradeRepositories(CrudMvcContext _context)

        {
            context = _context;
        }
        #endregion

        #region Designation
        public async Task<List<Grade>> GetAllGrades()
        {
            List<Grade> lstDesignation = (from G in context.Grades
                                          orderby G.GradeId
                                          select G).ToList<Grade>();
            return lstDesignation;
        }

        public async Task<Grade> GetGradebyID(Int64 ID)
        {
            Grade GradeVar = (from d in context.Grades
                              where d.GradeId == ID
                              select d).FirstOrDefault<Grade>();
            return GradeVar;
        }

        #endregion


    }
}