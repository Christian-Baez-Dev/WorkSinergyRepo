using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Domain.Common;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Infrastucture.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobRating> JobRatings { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ContractOption> ContractOptions { get; set; }

        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<UserAbility> UserAbilities { get; set; }
        public DbSet<PostAbility> PostAbilities { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tables and keys
            modelBuilder.Entity<JobApplication>(opt =>
            {
                opt.ToTable("Job_Applications");
                opt.HasKey(x => x.Id);
            });
            modelBuilder.Entity<JobRating>(opt =>
            {
                opt.ToTable("Job_Rating");
                opt.HasKey(x => x.Id);
            });
            modelBuilder.Entity<Post>(opt =>
            {
                opt.ToTable("Post");
                opt.HasKey(x => x.Id);
            });
            modelBuilder.Entity<PostTag>(opt =>
            {
                opt.ToTable("Post_Tags");
                opt.HasKey(x => x.Id);
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
            modelBuilder.Entity<UserAbility>(opt =>
            {
                opt.ToTable("User_Abilities");
                opt.HasKey(x => x.Id);

            });
            modelBuilder.Entity<PostAbility>(opt =>
            {
                opt.ToTable("Post_Abilities");
                opt.HasKey(x => x.Id);
            });
            modelBuilder.Entity<ContractOption>(opt =>
            {
                opt.ToTable("Contract_Options");
                opt.HasKey(x => x.Id);
            });
            #endregion


            #region Filters
            modelBuilder.Entity<JobApplication>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<JobRating>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Post>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<PostTag>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Tag>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Ability>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<UserAbility>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<PostAbility>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ContractOption>().HasQueryFilter(x => !x.IsDeleted);
            #endregion

            #region Filters
            modelBuilder.Entity<PostAbility>().Navigation(x => x.Ability).AutoInclude();
            modelBuilder.Entity<PostAbility>().Navigation(x => x.Post).AutoInclude();
            modelBuilder.Entity<UserAbility>().Navigation(x => x.Ability).AutoInclude();
            modelBuilder.Entity<PostTag>().Navigation(x => x.Post).AutoInclude();
            modelBuilder.Entity<PostTag>().Navigation(x => x.Tag).AutoInclude();


            #endregion



            #region Relationships

            modelBuilder.Entity<JobApplication>()
                .HasOne(x => x.Post)
                .WithMany(x => x.Applications)
                .HasForeignKey(x => x.PostId);

            modelBuilder.Entity<JobRating>()
                .HasOne(x => x.Post)
                .WithMany(x => x.Ratings)
                .HasForeignKey(x => x.PostId);

            modelBuilder.Entity<Post>()
                .HasOne(x => x.ContractOption)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.ContractOptionId);

            modelBuilder.Entity<PostTag>()
                .HasOne(x => x.Post)
                .WithMany(x => x.Tags)
                .HasForeignKey(x => x.PostId);


            modelBuilder.Entity<PostTag>()
                .HasOne(x => x.Tag)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.TagId);


            modelBuilder.Entity<PostAbility>()
                .HasOne(x => x.Ability)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.AbilityId);


            modelBuilder.Entity<PostAbility>()
                .HasOne(x => x.Post)
                .WithMany(x => x.Abilities)
                .HasForeignKey(x => x.PostId);

            modelBuilder.Entity<UserAbility>()
                .HasOne(x => x.Ability)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.AbilityId);
            #endregion

            modelBuilder.Entity<ContractOption>().HasData(
            Enum.GetValues(typeof(ContractOptions))
                .Cast<ContractOptions>()
                .Select(e => new ContractOption
                {
                    Id = (int)e, // Valor numérico del enum
                    Name = e.ToString() // Nombre de la propiedad del enum
                })
            );



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
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.DeletedAt = DateTime.Now;
                        entry.Entity.IsDeleted = true;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
