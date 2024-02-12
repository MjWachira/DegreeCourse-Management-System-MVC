using DAL.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Modules.StudentR
{

    public class StudentRepositories
    {

        #region Initialize
        CrudMvcContext context;

        public StudentRepositories(CrudMvcContext _context)

        {
            context = _context;
        }
        #endregion

        #region Designation
        public async Task<List<Student>> GetAllStudents()
        {
            List<Student> lstStudent = (from S in context.Students
                                        orderby S.StudentName
                                        select S).ToList<Student>();
            return lstStudent;
        }

        public async Task<Student> GetStudentByID(Int64 ID)
        {
            Student StudentVar = (from d in context.Students
                                  where d.StudentId == ID
                                  select d).FirstOrDefault<Student>();
            return StudentVar;
        }

        #endregion


    }
}