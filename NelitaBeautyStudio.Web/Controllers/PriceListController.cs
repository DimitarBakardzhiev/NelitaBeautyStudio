namespace NelitaBeautyStudio.Web.Controllers
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
    public class PriceListController : BaseController
    {
        public PriceListController(IApplicationData data)
            : base(data)
        {
        }

        [ChildActionOnly]
        [AllowAnonymous]
        public ActionResult PriceListDropDown()
        {
            var priceLists = this.Data.PriceLists.All().ToList();

            return this.PartialView(priceLists);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var priceList = this.Data.PriceLists.GetById(id);

            return this.View(priceList);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PriceListViewModel priceList)
        {
            var titleAlreadyExists = this.Data.PriceLists.All().FirstOrDefault(p => p.Title == priceList.Title) != null;

            if (titleAlreadyExists)
            {
                ModelState.AddModelError("Title", "Не може да се добави втори ценоразпис с това име!");

                return this.View(priceList);
            }

            if (ModelState.IsValid)
            {
                var priceListModel = Mapper.Map<PriceList>(priceList);

                this.Data.PriceLists.Add(priceListModel);
                this.Data.SaveChanges();

                this.Notify(GlobalConstants.AddPriceList, NotificationType.success);

                return this.RedirectToAction("Details", new { id = priceListModel.Id });
            }

            return this.View(priceList);
        }

        public ActionResult Edit(int id)
        {
            var priceList = this.Data.PriceLists.GetById(id);
            var priceListViewModel = Mapper.Map<PriceListViewModel>(priceList);

            return this.View(priceListViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PriceListViewModel priceList)
        {
            var titleAlreadyExists = this.Data.PriceLists.All().FirstOrDefault(p => p.Title == priceList.Title) != null;

            if (titleAlreadyExists)
            {
                ModelState.AddModelError("Title", "Не може да се добави втори ценоразпис с това име!");

                return this.View(priceList);
            }

            if (ModelState.IsValid)
            {
                var priceListModel = Mapper.Map<PriceList>(priceList);
                priceListModel.Id = id;

                this.Data.PriceLists.Update(priceListModel);
                this.Data.SaveChanges();

                this.Notify(GlobalConstants.EditPriceList, NotificationType.success);

                return this.RedirectToAction("Details", new { id = priceListModel.Id });
            }

            return this.View(priceList);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var priceList = this.Data.PriceLists.GetById(id);
            var priceListViewModel = Mapper.Map<PriceListViewModel>(priceList);

            return this.View(priceListViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var priceList = this.Data.PriceLists.GetById(id);

            this.Data.PriceLists.Delete(priceList);
            this.Data.SaveChanges();

            this.Notify(GlobalConstants.DeletePriceList, NotificationType.warning);

            return this.RedirectToAction("Index", "Home");
        }
    }
}