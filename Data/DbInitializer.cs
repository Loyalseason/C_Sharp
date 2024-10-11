using System;
using MyFirstrestFulApi.Models.Domain;

namespace MyFirstrestFulApi.Data;

public static class DbInitializer
{
    public static void Initializer(NZWalksDbContext context)
    {
        if (context.Students.Any())
        {
            return;
        }

        var students = new Student[]
        {
            new Student {FirstName = "Emmanuel", LastName = "Asante", EnrollmentDate = DateTime.Today},
            new Student {FirstName = "Loyal", LastName = "Season", EnrollmentDate = DateTime.Today},
            new Student {FirstName = "John", LastName = "Doe", EnrollmentDate = DateTime.Today},
        };

        context.Students.AddRange(students);
        context.SaveChanges();

    }
}
