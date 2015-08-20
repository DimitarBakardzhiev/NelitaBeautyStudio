namespace NelitaBeautyStudio.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

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
    }
}