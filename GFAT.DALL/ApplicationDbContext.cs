using GFAT.Domain.Enum;
using GFAT.Domain.Helpers;
using GFAT.Domain.Models;
using GFAT.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GFAT.DALL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

      public DbSet<Food> Foods { get; set; }
        
        public DbSet<Profile> Profiles { get; set; }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Basket> Baskets { get; set; }
        
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("Users").HasKey(x => x.id);
                builder.HasData(new User
                {
                    id = 1,
                    Name = "admin",
                    Password = HashPasswordHelper.HashPassowrd("admin"),
                    Role = Role.Admin
                });

                builder.Property(x => x.id).ValueGeneratedOnAdd();

                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

                builder.HasOne(x => x.Profile)
                    .WithOne(x => x.User)
                    .HasPrincipalKey<User>(x => x.id)
                    .OnDelete(DeleteBehavior.Cascade);
                
                builder.HasOne(x => x.Basket)
                    .WithOne(x => x.User)
                    .HasPrincipalKey<User>(x => x.id)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<Food>(builder =>
            {
                builder.ToTable("Foods").HasKey(x => x.id);
                
                builder.HasData(new Food
                {
                    id = 1,
                    name = "GTPO",
                    description = new string('A', 50),
                    price = new decimal(),
                    Avatar = null,
                    CatagoryFood = CatagoryFood.Pizza
                });
            });

            modelBuilder.Entity<Profile>(builder =>
            {
                builder.ToTable("Profiles").HasKey(x => x.id);
                
                builder.Property(x => x.id).ValueGeneratedOnAdd();
                builder.Property(x => x.Age);
                builder.Property(x => x.Address).HasMaxLength(200).IsRequired(false);
                
                builder.HasData(new Profile()
                {
                    id = 1,
                    UserId = 1
                });
            });
            
            modelBuilder.Entity<Basket>(builder =>
            {
                builder.ToTable("Baskets").HasKey(x => x.id);
                
                builder.HasData(new Basket() 
                {
                    id = 1,
                    UserId = 1
                });
            });
            
            modelBuilder.Entity<Order>(builder =>
            {
                builder.ToTable("Orders").HasKey(x => x.id);

                builder.HasOne(r => r.Basket).WithMany(t => t.Orders)
                    .HasForeignKey(r => r.BasketId);
            });
        }
    }



