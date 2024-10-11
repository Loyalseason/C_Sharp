using System;

namespace MyFirstrestFulApi.Models.Domain;

public class Student
{
    public Guid ID { get; set; }
    public string LastName { get; set; }

    public string FirstName { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }

}
