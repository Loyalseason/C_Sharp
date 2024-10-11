using System;

namespace MyFirstrestFulApi.Models.Domain;

public class Course
{
    public Guid ID { get; set; }

    public string Title { get; set; }

    public int Credit { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }
}
