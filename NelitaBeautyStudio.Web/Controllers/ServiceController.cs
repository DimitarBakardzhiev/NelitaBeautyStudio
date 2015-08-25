namespace NelitaBeautyStudio.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using NelitaBeautyStudio.Data.Unit_of_Work;
    using NelitaBeautyStudio.Web.ViewModels;

    public class ServiceController : BaseController
    {
        public ServiceController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceViewModel service)
        {
            if (ModelState.IsValid)
            {
                var serviceModel = Mapper.Map<NelitaBeautyStudio.Models.Service>(service);

                this.Data.Services.Add(serviceModel);
                this.Data.SaveChanges();

                return this.RedirectToAction("Index", "PriceList");
            }

            return this.View(service);
        }

        public ActionResult Edit(int id)
        {
            var service = this.Data.Services.GetById(id);
            var serviceViewModel = Mapper.Map<ServiceViewModel>(service);

            return this.View(serviceViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceViewModel service)
        {
            if (ModelState.IsValid)
            {
                var serviceModel = Mapper.Map<NelitaBeautyStudio.Models.Service>(service);
                serviceModel.Id = id;

                this.Data.Services.Update(serviceModel);
                this.Data.SaveChanges();

                return this.RedirectToAction("Index", "PriceList");
            }

            return this.View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = this.Data.Services.GetById(id);

            this.Data.Services.Delete(service);
            this.Data.SaveChanges();

            return this.RedirectToAction("Index", "PriceList");
        }
    }
}