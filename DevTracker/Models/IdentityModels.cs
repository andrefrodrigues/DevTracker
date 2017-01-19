using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTracker.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public bool admin { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class User_Lang
    {
        [ForeignKey("userID")]
        public virtual ApplicationUser user { get; set; }
        [ForeignKey("langName")]
        public virtual Language lang { get; set; }

        [Key,Column(Order =0)]
        public virtual string userID { get; set; }
        [Key,Column(Order =1)]
        public virtual string langName { get; set; }
    }

    public class Language
    {
        [Key]
        public string name { get; set; }

    }

    public class Lang_Paradigm
    {
        [ForeignKey("langName")]
        public virtual Language LANG { get; set; }

        [ForeignKey("paradID")]
        public virtual Paradigm PARAD { get; set; }

        [Key,Column(Order =0)]
        public virtual string langName { get; set; }
        [Key,Column(Order =1)]
        public virtual int paradID { get; set; }
    }

    public class Paradigm
    {
        [Key]
        public int paradigm_id { get; set; }
        public string name { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //need to add here the tables to the context
        public DbSet<Language> Languages { get; set; }
        public DbSet<Paradigm> Paradigms { get; set; }
        public DbSet<Lang_Paradigm> Lang_Paradigms { get; set; }
        public DbSet<User_Lang> User_Langs { get; set; }
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