using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TheChamber.Models;
using Microsoft.AspNetCore.Identity;

namespace TheChamber.Data;
public class TheChamberDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    
    public DbSet<UserProfile> UserProfiles { get; set; }

    public TheChamberDbContext(DbContextOptions<TheChamberDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //rolls available
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {

            Id = "a601c402-545f-4ba8-869d-6f0968774d58",
            Name = "User",
            NormalizedName = "user"
        });
        //User info with login credentials
        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admin@RasketsRime.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });
        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "b0751254-3a0d-46a2-8b2b-2798a80edafc",
            UserName = "DarlingJupes",
            Email = "Darlingjupes@RasketsRime.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["DarlingJupesPassword"])
        });
        //join table of user roles with users
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "a601c402-545f-4ba8-869d-6f0968774d58",
            UserId = "b0751254-3a0d-46a2-8b2b-2798a80edafc"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile
            {
              Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street"  
            },
            new UserProfile
            {
               Id = 2,
            IdentityUserId = "b0751254-3a0d-46a2-8b2b-2798a80edafc",
            FirstName = "Darlington",
            LastName = "Juniper",
            Address = "3482 Corringer Route" 
            }
        });
            
        modelBuilder.Entity<Order>().HasData(new Order
        {
            Id = 1,
            UserId = 2,
            Name = "Rabbit Shanks",
            Quantity = 3,
            Notes = "Please no stringy bits",
            Purchased = false
        });
        modelBuilder.Entity<Score>().HasData(new Score
        {
            Id = 1,
            UserId = 2,
            Power = 200
        });
        //create data models

        
    }
}