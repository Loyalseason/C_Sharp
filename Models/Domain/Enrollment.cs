
namespace MyFirstrestFulApi.Models.Domain;

public enum Grade
{
    A, B, C, D, E, F
}
public class Enrollment
{
    public Guid ID { get; set; }

    public int CourseID { get; set; }

    public Guid StudentID { get; set; }

    public Grade? Grade { get; set; }

    public Course course { get; set; }

    public Student Student { get; set; }
}
