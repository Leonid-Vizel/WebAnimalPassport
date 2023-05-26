using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAnimalPassport.Models.Data;
using WebAnimalPassport.Models.Data.Animal;
using WebAnimalPassport.Models.Data.Treatment;
using WebAnimalPassport.Models.Data.Vaccination;

namespace WebAnimalPassport.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<CustomUser> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
    }
}
