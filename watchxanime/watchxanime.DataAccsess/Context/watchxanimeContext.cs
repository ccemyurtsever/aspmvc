using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using watchxanime.API.Services.UserServices;
using watchxanime.Entity.Entites;



namespace watchxanime.DataAccsess.Context
{
    public class watchxanimeContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public watchxanimeContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<AboutUs> AboutUss { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PrivacyPolicy> PrivacyPolicies { get; set; }
        public DbSet<Anime> Animes { get; set; }

    }
}
