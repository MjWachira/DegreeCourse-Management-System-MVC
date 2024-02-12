using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelStudentM
{
    public class ModelStudent
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string? StudentName { get; set; }
        [Required]
        public DateOnly? DateOfBirth { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
    }
}