using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DevTracker.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() :base() {
            this.Languages = new HashSet<Language>();
        }
        public bool admin { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Language> Languages { get; set; }
    }

    public class Language
    {
        public Language()
        {
            this.Paradigms = new HashSet<Paradigm>();
            this.Users = new HashSet<ApplicationUser>();
        }
        [Key]
        public string name { get; set; }
        
        public virtual ICollection<Paradigm> Paradigms { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }

    public class Paradigm
    {
        public Paradigm()
        {
            this.Languages = new HashSet<Language>();
        }
        [Key]
        public int paradigmId { get; set; }
        public string name { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //need to add here the tables to the context
        public DbSet<Language> Languages { get; set; }
        public DbSet<Paradigm> Paradigms { get; set; }
        public ApplicationDbContext()
            : base("DevTrackerLocal", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}