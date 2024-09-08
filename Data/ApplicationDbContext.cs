using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShearwellExercise.Models;

namespace ShearwellExercise.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<AnimalForGroup> AnimalForGroups { get; set; }
    }
}
