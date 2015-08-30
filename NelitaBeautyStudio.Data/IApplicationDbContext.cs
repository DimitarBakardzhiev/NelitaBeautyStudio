namespace NelitaBeautyStudio.Data
{
    using System;
    using System.Data.Entity;

    using NelitaBeautyStudio.Models;

    public interface IApplicationDbContext
    {
        IDbSet<Contact> Contacts { get; set; }

        IDbSet<PriceList> PriceLists { get; set; }

        IDbSet<Service> Services { get; set; }

        IDbSet<News> News { get; set; }
    }
}
