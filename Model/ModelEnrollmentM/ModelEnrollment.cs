using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelEnrollmentM
{
    public class ModelEnrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        [Required]
        public int? StudentId { get; set; }
        [Required]
        public int? CourseId { get; set; }
        [Required]
        public DateOnly? EnrollmentDate { get; set; }

    }
}