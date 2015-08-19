namespace NelitaBeautyStudio.Data.Unit_of_Work
{
    using System.Data.Entity;

    using NelitaBeautyStudio.Data.Repositories;
    using NelitaBeautyStudio.Models;

    public interface IApplicationData
    {
        DbContext Context { get; }

        IRepository<Contact> Contacts { get; }

        void Dispose();

        int SaveChanges();
    }
}
