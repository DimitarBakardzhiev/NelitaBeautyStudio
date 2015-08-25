namespace NelitaBeautyStudio.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using NelitaBeautyStudio.Common;
    using NelitaBeautyStudio.Data.Unit_of_Work;
    using NelitaBeautyStudio.Models;
    using NelitaBeautyStudio.Web.ViewModels;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class PriceListController : BaseController
    {
        public PriceListController(IApplicationData data)
            : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var priceLists = this.Data.PriceLists.All().ToList();

            return View(priceLists);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PriceListViewModel priceList)
        {
            if (ModelState.IsValid)
            {
                var priceListModel = Mapper.Map<PriceList>(priceList);

                this.Data.PriceLists.Add(priceListModel);
                this.Data.SaveChanges();

                return this.RedirectToAction("Index");
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
            if (ModelState.IsValid)
            {
                var priceListModel = Mapper.Map<PriceList>(priceList);
                priceListModel.Id = id;

                this.Data.PriceLists.Update(priceListModel);
                this.Data.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(priceList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var priceList = this.Data.PriceLists.GetById(id);

            this.Data.PriceLists.Delete(priceList);
            this.Data.SaveChanges();

            return this.RedirectToAction("Index");
        }
    }
}