namespace NelitaBeautyStudio.Tests.ControllerTests.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NelitaBeautyStudio.Data.Repositories;
    using NelitaBeautyStudio.Models;

    public class FakeContactsRepository : IRepository<Contact>, IFakeRepository<Contact>
    {
        public FakeContactsRepository()
        {
            this.PopulateData();
        }

        public ICollection<Contact> Data { get; set; }

        public void PopulateData()
        {
            this.Data = new List<Contact>()
            {
                new Contact() { Id = 1, Priority = Priority.Normal, Type = "Telefon", Value = "1234567890" },
                new Contact() { Id = 2, Priority = Priority.Low, Type = "Telefon", Value = "6354225645" },
                new Contact() { Id = 3, Priority = Priority.High, Type = "Adres", Value = "ul. gosho 1" },
                new Contact() { Id = 1, Priority = Priority.Normal, Type = "Rabotno vreme", Value = "10 - 18" }
            };
        }

        public IQueryable<Contact> All()
        {
            return this.Data.AsQueryable();
        }

        public Contact GetById(object id)
        {
            return this.Data.FirstOrDefault(c => c.Id == (int)id);
        }

        public void Add(Contact entity)
        {
            this.Data.Add(entity);
        }

        public void Update(Contact entity)
        {
            var contact = this.Data.FirstOrDefault(c => c.Id == entity.Id);

            contact = entity;
        }

        public void Delete(Contact entity)
        {
            this.Data.Remove(entity);
        }

        public void Delete(object id)
        {
            var contact = this.Data.FirstOrDefault(c => c.Id == (int)id);

            this.Data.Remove(contact);
        }

        public void Detach(Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}
