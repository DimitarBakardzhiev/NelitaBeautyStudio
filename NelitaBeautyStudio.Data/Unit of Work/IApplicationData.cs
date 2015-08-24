namespace NelitaBeautyStudio.Data.Unit_of_Work
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;
    
    using NelitaBeautyStudio.Data.Repositories;
    using NelitaBeautyStudio.Models;

    public interface IApplicationData
    {
        DbContext Context { get; }

        IRepository<Contact> Contacts { get; }

        IRepository<IdentityRole> Roles { get; }

        IRepository<IdentityUserRole> UserRoles { get; }

        IRepository<User> Users { get; }

        IRepository<PriceList> PriceLists { get; }

        IRepository<Service> Services { get; }

        void Dispose();

        int SaveChanges();
    }
}
