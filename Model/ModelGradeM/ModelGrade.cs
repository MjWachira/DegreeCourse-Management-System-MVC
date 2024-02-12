using Model; // Or whatever namespace contains your ModelGrade class

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelGradeM
{
    public class ModelGrade
    {
        [Key]
        public int GradeId { get; set; }
        [Required]
        public int? EnrollmentId { get; set; }
        [Required]
        public string? Grade1 { get; set; }
    }
}