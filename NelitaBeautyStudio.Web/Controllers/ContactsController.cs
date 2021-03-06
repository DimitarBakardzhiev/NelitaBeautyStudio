﻿namespace NelitaBeautyStudio.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using NelitaBeautyStudio.Common;
    using NelitaBeautyStudio.Data.Unit_of_Work;
    using NelitaBeautyStudio.Models;
    using NelitaBeautyStudio.Web.Infrastructure;
    using NelitaBeautyStudio.Web.ViewModels;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class ContactsController : BaseController
    {
        public ContactsController(IApplicationData data)
            : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var contacts = this.Data.Contacts.All()
                .OrderByDescending(c => c.Priority)
                .ThenBy(c => c.Type)
                .ToList();

            return this.View("Index", contacts);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                var contactEntity = Mapper.Map<Contact>(contact);
                this.Data.Contacts.Add(contactEntity);
                this.Data.SaveChanges();

                this.Notify(GlobalConstants.AddContact, NotificationType.success);

                return this.RedirectToAction("Index");
            }

            return this.View(contact);
        }

        public ActionResult Edit(int id)
        {
            var contact = this.Data.Contacts.GetById(id);
            var contactViewModel = Mapper.Map<ContactViewModel>(contact);

            return this.View(contactViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                var updatedContact = Mapper.Map<Contact>(contact);
                updatedContact.Id = id;
                this.Data.Contacts.Update(updatedContact);
                this.Data.SaveChanges();

                this.Notify(GlobalConstants.EditContact, NotificationType.success);

                return this.RedirectToAction("Index");
            }

            return this.View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var contact = this.Data.Contacts.GetById(id);

            this.Data.Contacts.Delete(contact);
            this.Data.SaveChanges();

            this.Notify(GlobalConstants.DeleteContact, NotificationType.info);

            return this.RedirectToAction("Index");
        }
    }
}