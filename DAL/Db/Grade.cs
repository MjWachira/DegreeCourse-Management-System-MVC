using System;
using System.Collections.Generic;

namespace DAL.Db;

public partial class Grade
{
    public int GradeId { get; set; }

    public int? EnrollmentId { get; set; }

    public string? Grade1 { get; set; }

    public virtual Enrollment? Enrollment { get; set; }
}
