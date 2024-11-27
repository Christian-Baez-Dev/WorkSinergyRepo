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

        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractOption> ContractOptions { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<FixedPriceMilestone> FixedPriceMilestones { get; set; }
        public DbSet<HourlyMilestone> HourlyMilestones { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<JobRating> JobRatings { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostAbility> PostAbilities { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserAbility> UserAbilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tables and keys
            modelBuilder.Entity<Ability>(opt =>
            {
                opt.ToTable("Ability");
                opt.HasKey(x => x.Id);
            });
            modelBuilder.Entity<Contract>(opt =>
            {
                opt.ToTable("Contracts");
                opt.HasKey(x => x.Id);
            });
            modelBuilder.Entity<ContractOption>(opt =>
            {
                opt.ToTable("Contract_Options");
                opt.HasKey(x => x.Id);
            });
            modelBuilder.Entity<Currency>(opt =>
            {
                opt.ToTable("Currencies");
                opt.HasKey(x => x.Id);
            });
            modelBuilder.Entity<FixedPriceMilestone>(opt =>
            {
                opt.ToTable("Fixed_Price_Milestones");
                opt.HasKey(x => x.Id);
            });

            modelBuilder.Entity<HourlyMilestone>(opt =>
            {
                opt.ToTable("Hourly_Milestone");
                opt.HasKey(x => x.Id);
            });
            modelBuilder.Entity<JobApplication>(opt =>
            {
                opt.ToTable("Job_Applications");
                opt.HasKey(x => x.Id);
            });
            modelBuilder.Entity<JobOffer>(opt =>
            {
                opt.ToTable("Job_Offers");
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
            modelBuilder.Entity<PostAbility>(opt =>
            {
                opt.ToTable("Post_Abilities");
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
            modelBuilder.Entity<UserAbility>(opt =>
            {
                opt.ToTable("User_Abilities");
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
            modelBuilder.Entity<JobOffer>().HasQueryFilter(x => !x.IsDeleted);

            #endregion

            #region Includes
            modelBuilder.Entity<PostAbility>().Navigation(x => x.Ability).AutoInclude();
            modelBuilder.Entity<PostAbility>().Navigation(x => x.Post).AutoInclude();
            modelBuilder.Entity<UserAbility>().Navigation(x => x.Ability).AutoInclude();
            modelBuilder.Entity<PostTag>().Navigation(x => x.Post).AutoInclude();
            modelBuilder.Entity<PostTag>().Navigation(x => x.Tag).AutoInclude();


            #endregion



            #region Relationships


            modelBuilder.Entity<Contract>()
                .HasOne(x => x.Currency)
                .WithMany(x => x.Contracts)
                .HasForeignKey(x => x.CurrencyId);

            modelBuilder.Entity<Contract>()
                .HasOne(x => x.ContractOption)
                .WithMany(x => x.Contracts)
                .HasForeignKey(x => x.ContractOptionId);

            modelBuilder.Entity<FixedPriceMilestone>()
                .HasOne(x => x.Contract)
                .WithMany(x => x.FixedPriceMilestones)
                .HasForeignKey(x => x.ContractId);

            modelBuilder.Entity<HourlyMilestone>()
                .HasOne(x => x.Contract)
                .WithMany(x => x.HourlyMilestones)
                .HasForeignKey(x => x.ContractId);

            modelBuilder.Entity<JobApplication>()
                .HasOne(x => x.Post)
                .WithMany(x => x.Applications)
                .HasForeignKey(x => x.PostId);


            modelBuilder.Entity<JobOffer>()
                .HasOne(x => x.Currency)
                .WithMany(x => x.JobOffers)
                .HasForeignKey(x => x.CurrencyId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<JobOffer>()
                .HasOne(x => x.ContractOption)
                .WithMany(x => x.JobOffers)
                .HasForeignKey(x => x.ContractOptionId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<JobOffer>()
                .HasOne(x => x.Post)
                .WithMany(x => x.JobOffers)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<JobRating>()
                .HasOne(x => x.Post)
                .WithMany(x => x.Ratings)
                .HasForeignKey(x => x.PostId);

            modelBuilder.Entity<Post>()
                .HasOne(x => x.ContractOption)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.ContractOptionId);

            modelBuilder.Entity<Post>()
                .HasOne(x => x.Currency)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.CurrencyId);

            modelBuilder.Entity<PostAbility>()
                .HasOne(x => x.Post)
                .WithMany(x => x.Abilities)
                .HasForeignKey(x => x.PostId);

            modelBuilder.Entity<PostAbility>()
                .HasOne(x => x.Ability)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.AbilityId);

            modelBuilder.Entity<PostTag>()
                .HasOne(x => x.Post)
                .WithMany(x => x.Tags)
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
