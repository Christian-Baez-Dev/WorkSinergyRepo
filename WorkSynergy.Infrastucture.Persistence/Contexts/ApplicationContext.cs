using Microsoft.EntityFrameworkCore;
using WorkSynergy.Core.Domain.Common;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Infrastucture.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<JobApplications> JobApplications { get; set; }
        public DbSet<JobRating> JobRatings { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTags> PostTags { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<UserAbilities> UserAbilities { get; set; }
        public DbSet<PostAbilities> PostAbilities { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tables and keys
            modelBuilder.Entity<JobApplications>(opt =>
            {
                opt.ToTable("Job_Applications");
                opt.HasKey(x => new {x.PostId, x.ApplicantId});
            });
            modelBuilder.Entity<JobRating>(opt =>
            {
                opt.ToTable("Job_Rating");
                opt.HasKey(x => new { x.PostId, x.ApplicantId });
            });
            modelBuilder.Entity<Post>(opt =>
            {
                opt.ToTable("Post");
                opt.HasKey(x => x.Id);
            });
            modelBuilder.Entity<PostTags>(opt =>
            {
                opt.ToTable("Post_Tags");
                opt.HasKey(x => new { x.PostId, x.TagId });
            });
            modelBuilder.Entity<Tag>(opt =>
            {
                opt.ToTable("Tag");
                opt.HasKey(x => x.Id);
            });
            modelBuilder.Entity<Ability>(opt =>
            {
                opt.ToTable("Ability");
                opt.HasKey(x => x.Id);
            });
            modelBuilder.Entity<UserAbilities>(opt =>
            {
                opt.ToTable("User_Abilities");
                opt.HasKey(x => x.Id);

            });
            modelBuilder.Entity<PostAbilities>(opt =>
            {
                opt.ToTable("User_Abilitis");
                opt.HasKey(x => x.Id);
            });
            #endregion

            #region Relationships

            modelBuilder.Entity<JobApplications>()
                .HasOne(x => x.Post)
                .WithMany(x => x.Applications)
                .HasForeignKey(x => x.PostId);

            modelBuilder.Entity<JobRating>()
                .HasOne(x => x.Post)
                .WithMany(x => x.Ratings)
                .HasForeignKey(x => x.PostId);


            modelBuilder.Entity<PostTags>()
                .HasOne(x => x.Post)
                .WithMany(x => x.Tags)
                .HasForeignKey(x => x.PostId);


            modelBuilder.Entity<PostTags>()
                .HasOne(x => x.Tag)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.TagId);


            modelBuilder.Entity<PostAbilities>()
                .HasOne(x => x.Ability)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.AbilityId);


            modelBuilder.Entity<PostAbilities>()
                .HasOne(x => x.Post)
                .WithMany(x => x.Abilities)
                .HasForeignKey(x => x.PostId);

            modelBuilder.Entity<UserAbilities>()
                .HasOne(x => x.Ability)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.AbilityId);
            #endregion





        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
