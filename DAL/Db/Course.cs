using System;
using System.Collections.Generic;

namespace DAL.Db;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public string? CourseDescription { get; set; }

    public int? CreditHours { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
