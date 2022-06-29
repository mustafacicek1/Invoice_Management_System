using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Concrete
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Users.Where(x => x.Role == "Admin").Any())
                {
                    return;
                }

                context.Users.Add(new User()
                {
                    Name = "Mustafa Çiçek",
                    IdentificationNumber = "12345678910",
                    Email = "mustafa@gmail.com",
                    Phone = "5301231122",
                    CarNumberPlate = "16 AB 123",
                    Role = "Admin",
                    Password = "123456"
                });

                context.SaveChanges();
            }
        }
    }
}
