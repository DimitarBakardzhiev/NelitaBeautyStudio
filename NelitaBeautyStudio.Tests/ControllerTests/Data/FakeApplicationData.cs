namespace NelitaBeautyStudio.Tests.ControllerTests.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;
    
    using NelitaBeautyStudio.Data.Repositories;
    using NelitaBeautyStudio.Data.Unit_of_Work;
    using NelitaBeautyStudio.Models;

    public class FakeApplicationData : IApplicationData
    {
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public DbContext Context
        {
            get { throw new NotImplementedException(); }
        }

        public IRepository<Contact> Contacts
        {
            get 
            {
                if (!this.repositories.ContainsKey(typeof(FakeContactsRepository)))
                {
                    var type = typeof(FakeContactsRepository);

                    this.repositories.Add(typeof(FakeContactsRepository), Activator.CreateInstance(type));
                }

                return (FakeContactsRepository)this.repositories[typeof(FakeContactsRepository)];
            }
        }

        public IRepository<IdentityRole> Roles
        {
            get { throw new NotImplementedException(); }
        }

        public IRepository<IdentityUserRole> UserRoles
        {
            get { throw new NotImplementedException(); }
        }

        public IRepository<User> Users
        {
            get { throw new NotImplementedException(); }
        }

        public IRepository<PriceList> PriceLists
        {
            get { throw new NotImplementedException(); }
        }

        public IRepository<Service> Services
        {
            get { throw new NotImplementedException(); }
        }

        public IRepository<News> News
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
