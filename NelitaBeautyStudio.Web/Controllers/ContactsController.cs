namespace NelitaBeautyStudio.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using NelitaBeautyStudio.Data.Unit_of_Work;
    using NelitaBeautyStudio.Models;
    using NelitaBeautyStudio.Web.ViewModels;

    public class ContactsController : BaseController
    {
        public ContactsController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var contacts = this.Data.Contacts.All()
                .AsQueryable()
                .Project().To<ContactViewModel>()
                .OrderByDescending(c => c.Priority)
                .ThenBy(c => c.Type)
                .ToList();

            return this.View(contacts);
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

                return this.RedirectToAction("Index");
            }

            return this.View(contact);
        }
    }
}