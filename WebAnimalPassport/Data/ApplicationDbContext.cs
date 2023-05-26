using Microsoft.EntityFrameworkCore;
using WebAnimalPassport.Models.Data.Animal;
using WebAnimalPassport.Models.Data.Treatment;
using WebAnimalPassport.Models.Data.User;
using WebAnimalPassport.Models.Data.Vaccination;

namespace WebAnimalPassport.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
    }
}
