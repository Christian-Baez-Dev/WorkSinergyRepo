using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkSynergy.Infrastucture.Identity.Models;

namespace WorkSynergy.Infrastucture.Identity.Contexts
{
    public class IdentityContext : IdentityDbContext<WorkSynergyUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WorkSynergyUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("User_Roles");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("User_Logins");


        }
    }
}
