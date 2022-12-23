using Microsoft.EntityFrameworkCore;
using Showroom.Entities;

namespace Showroom.Repositories
{
    public class ShowroomDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Car> Cars { get; set; }

       
        public ShowroomDbContext()
            {
            this.Users = this.Set<User>();
            this.Cars= this.Set<Car>(); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
             .UseSqlServer(@"Server=localhost;Database=ShowroomDb;User Id=viktorD;Password=123456v;")
             .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin",
                    FirstName = "Admini",
                    LastName = "Strator"
                });
        }
    }
}
