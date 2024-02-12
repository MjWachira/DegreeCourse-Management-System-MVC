using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.ModelCourseM
{
    public class ModelCourse
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string? CourseName { get; set; }
        [Required]
        public string? CourseDescription { get; set; }
        [Required]
        public int? CreditHours { get; set; }

    }
}