using System.Data.Entity;
using Domain.Entities.Breeding;
using Domain.Entities.Growing;
using Domain.Entities.Identity;
using Domain.Entities.User;

namespace Domain.Context
{
    public class DatabaseContext : DbContext
    {

        public virtual IDbSet<FarmerUser> Users { get; set; }
        public virtual IDbSet<Profile> Profiles { get; set; }
        public virtual IDbSet<Role> Roles { get; set; }
        public virtual IDbSet<Photo> Photos { get; set; }
        public virtual IDbSet<Reminding> Remindings { get; set; }

        #region GrowingEntities

        public virtual IDbSet<GrowingType> GrowingTypes { get; set; }
        public virtual IDbSet<GrowingCultures> GrowingCultureses { get; set; }
        public virtual IDbSet<GrowingFieldComings> GrowingFieldComingses { get; set; }
        public virtual IDbSet<GrowingFruitComings> GrowingFruitComingses { get; set; }
        public virtual IDbSet<GrowingCharges> GrowingChargeses { get; set; }
        public virtual IDbSet<GrowingFieldProfits> GrowingFieldProfitses { get; set; }
        public virtual IDbSet<GrowingFruitProfits> GrowingFruitProfitses { get; set; }
        #endregion

        #region BreedingEntities

        public virtual IDbSet<BreedingType> BreedingTypes { get; set; }
        public virtual IDbSet<BreedingCultures> BreedingCultureses { get; set; }
        public virtual IDbSet<YoungBreeding> YoungBreedings { get; set; }
        public virtual IDbSet<BreedingComings> BreedingComingses { get; set; }
        public virtual IDbSet<BeeComings> BeeComingses { get; set; }
        public virtual IDbSet<FishComings> FishComingses { get; set; }
        public virtual IDbSet<BreedingCharges> BreedingChargeses { get; set; }
        public virtual IDbSet<BreedingDailyProfit> BreedingDailyProfits { get; set; }
        public virtual IDbSet<BeeHoney> BeeHoneys { get; set; }
        public virtual IDbSet<BreedingProfits> BreedingProfitses { get; set; }
        public virtual IDbSet<FishProfits> FishProfitses { get; set; }
        public virtual IDbSet<BreedingReminder> BreedingReminders { get; set; }
        public virtual IDbSet<HoneyType> HoneyTypes { get; set; }
        #endregion


        #region Ctors

        public DatabaseContext()
            : base("DefaultConnection")
        {
        }

        #endregion

        #region FluentAPI

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between User and Profile
            modelBuilder.Entity<FarmerUser>()
                .HasKey<int>(user => user.Id)
                .HasRequired(user => user.Profile)
                .WithRequiredPrincipal();

            // Configure the relationship between User and Photo
            modelBuilder.Entity<FarmerUser>()
                .HasKey<int>(user => user.Id)
                .HasRequired(user => user.Photo)
                .WithRequiredPrincipal();

            //GROWING:
            //Configure the relationship between GrowingType and GrowingCultures
            modelBuilder.Entity<GrowingType>()
                .HasKey<int>(grow => grow.Id)
                .HasMany(grow => grow.GrowingCultureses)
                .WithRequired(grow => grow.GrowingType);

            //Configure the relationship between GrowingType and GrowingFieldComings
            modelBuilder.Entity<GrowingType>()
                .HasKey<int>(grow => grow.Id)
                .HasMany(grow => grow.GrowingFieldComingses)
                .WithRequired(grow => grow.GrowingType);

            //Configure the relationship between GrowingType and GrowingFruitComings
            modelBuilder.Entity<GrowingType>()
                .HasKey<int>(grow => grow.Id)
                .HasMany(grow => grow.GrowingFruitComingses)
                .WithRequired(grow => grow.GrowingType);

            //Configure the relationship between GrowingType and GrowingCharges
            modelBuilder.Entity<GrowingType>()
                .HasKey<int>(grow => grow.Id)
                .HasMany(grow => grow.GrowingChargeses)
                .WithRequired(grow => grow.GrowingType);

            //Configure the relationship between GrowingType and GrowingFieldProfits
            modelBuilder.Entity<GrowingType>()
                .HasKey<int>(grow => grow.Id)
                .HasMany(grow => grow.GrowingFieldProfitses)
                .WithRequired(grow => grow.GrowingType);

            //Configure the relationship between GrowingType and GrowingFruitProfits
            modelBuilder.Entity<GrowingType>()
                .HasKey<int>(grow => grow.Id)
                .HasMany(grow => grow.GrowingFruitProfitses)
                .WithRequired(grow => grow.GrowingType);

            //Configure the relationship between User and GrowingFieldComings
            modelBuilder.Entity<FarmerUser>()
                .HasKey<int>(user => user.Id)
                .HasMany(user => user.GrowingFieldComingses)
                .WithRequired(user => user.User);

            //Configure the relationship between User and GrowingFruitComings
            modelBuilder.Entity<FarmerUser>()
                .HasKey<int>(user => user.Id)
                .HasMany(user => user.GrowingFruitComingses)
                .WithRequired(user => user.User);

            //Configure the relationship between User and GrowingCharges
            modelBuilder.Entity<FarmerUser>()
                .HasKey<int>(user => user.Id)
                .HasMany(user => user.GrowingChargeses)
                .WithRequired(user => user.User);

            // Configure the relationship between GrowingFieldComings and GrowingFieldProfits
            modelBuilder.Entity<GrowingFieldComings>()
                .HasKey<int>(grow => grow.Id)
                .HasRequired(grow => grow.GrowingFieldProfits)
                .WithRequiredPrincipal();

            // Configure the relationship between GrowingFruitComings and GrowingFruitProfits
            modelBuilder.Entity<GrowingFruitComings>()
                .HasKey<int>(grow => grow.Id)
                .HasRequired(grow => grow.GrowingFruitProfits)
                .WithRequiredPrincipal();

            //BREEDING:
            //Configure the relationship between BreedingType and BreedingCultures
            modelBuilder.Entity<BreedingType>()
                .HasKey<int>(breed => breed.Id)
                .HasMany(breed => breed.BreedingCultureses)
                .WithRequired(breed => breed.BreedingType);

            //Configure the relationship between BreedingType and YoungBreeding
            modelBuilder.Entity<BreedingType>()
                .HasKey<int>(breed => breed.Id)
                .HasMany(breed => breed.YoungBreedings)
                .WithRequired(breed => breed.BreedingType);


            //Configure the relationship between BreedingType and BreedingComings
            modelBuilder.Entity<BreedingType>()
                .HasKey<int>(breed => breed.Id)
                .HasMany(breed => breed.BreedingComingses)
                .WithRequired(breed => breed.BreedingType);

            //Configure the relationship between BreedingType and FishComings
            modelBuilder.Entity<BreedingType>()
                .HasKey<int>(breed => breed.Id)
                .HasMany(breed => breed.FishComingses)
                .WithRequired(breed => breed.BreedingType);

            //Configure the relationship between BreedingType and BeeComings
            modelBuilder.Entity<BreedingType>()
                .HasKey<int>(breed => breed.Id)
                .HasMany(breed => breed.BeeComingses)
                .WithRequired(breed => breed.BreedingType);


            //Configure the relationship between BreedingType and BreedingCharges
            modelBuilder.Entity<BreedingType>()
                .HasKey<int>(breed => breed.Id)
                .HasMany(breed => breed.BreedingChargeses)
                .WithRequired(breed => breed.BreedingType);

            //Configure the relationship between BreedingType and BreedingDailyProfit
            modelBuilder.Entity<BreedingType>()
                .HasKey<int>(breed => breed.Id)
                .HasMany(breed => breed.BreedingDailyProfits)
                .WithRequired(breed => breed.BreedingType);

            //Configure the relationship between BreedingType and BeeHoney
            modelBuilder.Entity<BreedingType>()
                .HasKey<int>(breed => breed.Id)
                .HasMany(breed => breed.BeeHoneys)
                .WithRequired(breed => breed.BreedingType);

            //Configure the relationship between BreedingType and BreedingProfits
            modelBuilder.Entity<BreedingType>()
                .HasKey<int>(breed => breed.Id)
                .HasMany(breed => breed.BreedingProfitses)
                .WithRequired(breed => breed.BreedingType);

            //Configure the relationship between BreedingType and FishProfits
            modelBuilder.Entity<BreedingType>()
                .HasKey<int>(breed => breed.Id)
                .HasMany(breed => breed.FishProfitses)
                .WithRequired(breed => breed.BreedingType);

            //Configure the relationship between BreedingType and BreedingReminder
            modelBuilder.Entity<BreedingType>()
                .HasKey<int>(breed => breed.Id)
                .HasMany(breed => breed.BreedingReminders)
                .WithRequired(breed => breed.BreedingType);

            //Configure the relationship between User and BreedingComings
            modelBuilder.Entity<FarmerUser>()
                .HasKey<int>(user => user.Id)
                .HasMany(user => user.BreedingComingses)
                .WithRequired(user => user.User);

            //Configure the relationship between User and BeeComings
            modelBuilder.Entity<FarmerUser>()
                .HasKey<int>(user => user.Id)
                .HasMany(user => user.BeeComingses)
                .WithRequired(user => user.User);

            //Configure the relationship between User and FishComings
            modelBuilder.Entity<FarmerUser>()
                .HasKey<int>(user => user.Id)
                .HasMany(user => user.FishComingses)
                .WithRequired(user => user.User);

            //Configure the relationship between User and BreedingCharges
            modelBuilder.Entity<FarmerUser>()
                .HasKey<int>(user => user.Id)
                .HasMany(user => user.BreedingChargeses)
                .WithRequired(user => user.User);

            // Configure the relationship between BreedingComings and BreedingProfits
            modelBuilder.Entity<BreedingComings>()
                .HasKey<int>(breed => breed.Id)
                .HasRequired(breed => breed.BreedingProfits)
                .WithRequiredPrincipal();

            // Configure the relationship between FishComings and FishProfits
            modelBuilder.Entity<FishComings>()
                .HasKey<int>(fish => fish.Id)
                .HasRequired(fish => fish.FishProfits)
                .WithRequiredPrincipal();

            modelBuilder.Entity<ApplicationUserLogin>().HasKey<int>(login => login.UserId);
            modelBuilder.Entity<ApplicationUserRole>().HasKey(role => new { role.UserId, role.RoleId });

        }

        #endregion

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }
    }
}
