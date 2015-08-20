namespace NelitaBeautyStudio.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using NelitaBeautyStudio.Data.Unit_of_Work;
    using NelitaBeautyStudio.Models;
    using NelitaBeautyStudio.Web.ViewModels;

    public class ContactController : BaseController
    {
        public ContactController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var list = new Contact[3];
            var contact = new Contact { Type = "asd", Value = "dsa", Priority = Priority.Normal };
            list[0] = contact;
            var viewmodel = list.AsQueryable().Project().To<ContactViewModel>().FirstOrDefault();
            return this.View();
        }
    }
}