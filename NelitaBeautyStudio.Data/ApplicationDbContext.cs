namespace NelitaBeautyStudio.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using NelitaBeautyStudio.Data.Migrations;
    using NelitaBeautyStudio.Models;

    public class ApplicationDbContext : IdentityDbContext<User>, NelitaBeautyStudio.Data.IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public virtual IDbSet<Contact> Contacts { get; set; }

        public virtual IDbSet<PriceList> PriceLists { get; set; }

        public virtual IDbSet<Service> Services { get; set; }

        public virtual IDbSet<News> News { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
