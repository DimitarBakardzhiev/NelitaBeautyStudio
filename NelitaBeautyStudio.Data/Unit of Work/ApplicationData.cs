namespace NelitaBeautyStudio.Data.Unit_of_Work
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using NelitaBeautyStudio.Data.Repositories;
    using NelitaBeautyStudio.Models;

    public class ApplicationData : IApplicationData
    {
        private readonly DbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public ApplicationData()
            : this(new ApplicationDbContext())
        {
        }

        public ApplicationData(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IRepository<Contact> Contacts
        {
            get { return this.GetRepository<Contact>(); }
        }

        public IRepository<IdentityRole> Roles
        {
            get { return this.GetRepository<IdentityRole>(); }
        }

        public IRepository<IdentityUserRole> UserRoles
        {
            get { return this.GetRepository<IdentityUserRole>(); }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<PriceList> PriceLists
        {
            get { return this.GetRepository<PriceList>(); }
        }

        public IRepository<Service> Services
        {
            get { return this.GetRepository<Service>(); }
        }

        public IRepository<News> News
        {
            get { return this.GetRepository<News>(); }
        }

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
