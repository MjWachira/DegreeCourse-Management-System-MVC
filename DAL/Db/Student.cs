using System;
using System.Collections.Generic;

namespace DAL.Db;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
