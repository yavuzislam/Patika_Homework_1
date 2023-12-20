using Customer_management.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer_management.DbOperation;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context =
               new CustomerManagementDbContext(serviceProvider
                   .GetRequiredService<DbContextOptions<CustomerManagementDbContext>>()))
        {
            if (context.Customers.Any())
            {
                return;
            }

            context.Customers.AddRange(new Customer()
                {
                    Name = "Ahmet",
                    Surname = "Yılmaz",
                    BirthDate = new DateTime(1990, 1, 1),
                    Job = "Engineer",
                    Country = "Turkey",
                    IncomeLevelId = 1,
                    MartialStatusId = 1
                },
                new Customer()
                {
                    Name = "Ayşe",
                    Surname = "Yılmaz",
                    BirthDate = new DateTime(1991, 4, 2),
                    Job = "Software Developer",
                    Country = "Turkey",
                    IncomeLevelId = 2,
                    MartialStatusId = 2
                }, new Customer()
                {
                    Name = "Ingrid",
                    Surname = "Larsen",
                    BirthDate = new DateTime(1997, 7, 29),
                    Job = "Doctor",
                    Country = "Norway",
                    IncomeLevelId = 2,
                    MartialStatusId = 1
                });
            context.SaveChanges();
        }
    }
}