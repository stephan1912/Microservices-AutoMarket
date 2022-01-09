using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DalLibrary.Models
{
    public partial class AutoMarketContext : IdentityDbContext<User>
    {
        public AutoMarketContext()
        {
        }

        public AutoMarketContext(DbContextOptions<AutoMarketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advert> Adverts { get; set; }
        public virtual DbSet<AdvertFeature> AdvertFeatures { get; set; }
        public virtual DbSet<BodyStyle> BodyStyles { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(
                "server=automarket-db.c85nbo1h0jkt.us-east-1.rds.amazonaws.com;uid=admin;pwd=automarket;database=AutoMarket",
                new MySqlServerVersion(new Version(8, 0, 27)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advert>(entity =>
            {
                entity.ToTable("advert");

                entity.HasIndex(e => e.BodyStyleId, "FK5hkqc8fc6ms7rwflvrn19dfhx");

                entity.HasIndex(e => e.CountryId, "FK8dvdoawhjaf882jxx4o9ab4a8");

                entity.HasIndex(e => e.ModelId, "FK9tatnvtavtuucjl0hkd7bnff1");

                entity.HasIndex(e => e.UserId, "FKjds5rnsjbg4gr45pmn8bgd7dj");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BodyStyleId).HasColumnName("body_style_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(3000)
                    .HasColumnName("description");

                entity.Property(e => e.Drivetrain)
                    .HasMaxLength(255)
                    .HasColumnName("drivetrain");

                entity.Property(e => e.EngineCap).HasColumnName("engine_cap");

                entity.Property(e => e.Fuel)
                    .HasMaxLength(255)
                    .HasColumnName("fuel");

                entity.Property(e => e.GearboxType)
                    .HasMaxLength(255)
                    .HasColumnName("gearbox_type");

                entity.Property(e => e.HorsePower).HasColumnName("horse_power");

                entity.Property(e => e.Km).HasColumnName("km");

                entity.Property(e => e.ModelId).HasColumnName("model_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Registered)
                    .HasColumnType("bit(1)")
                    .HasColumnName("registered");

                entity.Property(e => e.ServiceDocs)
                    .HasColumnType("bit(1)")
                    .HasColumnName("service_docs");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Vin)
                    .HasMaxLength(255)
                    .HasColumnName("vin");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<AdvertFeature>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("advert_features");

                entity.HasIndex(e => e.FeatureId, "FK9syg4onaa4l5ms94chv3efy4s");

                entity.HasIndex(e => e.AdvertId, "FKi0w3bxv0f8v8j4ooicsrhjchp");

                entity.Property(e => e.AdvertId).HasColumnName("advert_id");

                entity.Property(e => e.FeatureId).HasColumnName("feature_id");
            });

            modelBuilder.Entity<BodyStyle>(entity =>
            {
                entity.ToTable("body_style");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("code");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.HasIndex(e => e.AdvertId, "FK3uy78yort0pira8rwup9oeibt");

                entity.HasIndex(e => e.UserId, "FK8kcum44fvpupyw6f5baccx25c");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdvertId).HasColumnName("advert_id");

                entity.Property(e => e.Comment1)
                    .HasMaxLength(255)
                    .HasColumnName("comment");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.ToTable("feature");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("images");

                entity.HasIndex(e => e.AdvertId, "FKpr3xbu7a7bx3osujvrw4yfj6l");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdvertId).HasColumnName("advert_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("model");

                entity.HasIndex(e => e.BrandId, "FKhbgv4j3vpt308sepyq9q79mhu");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.FinalYear).HasColumnName("final_year");

                entity.Property(e => e.Generation)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("generation");

                entity.Property(e => e.LaunchYear).HasColumnName("launch_year");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasColumnName("active");

                entity.Property(e => e.Birthdate).HasColumnName("birthdate");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("password");

                entity.Property(e => e.Roles)
                    .HasMaxLength(255)
                    .HasColumnName("roles");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
