namespace NelitaBeautyStudio.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using NelitaBeautyStudio.Data.Unit_of_Work;

    public class NewsController : BaseController
    {
        public NewsController(IApplicationData data)
            : base(data)
        {
        }

        [ChildActionOnly]
        [AllowAnonymous]
        public ActionResult LatestNews()
        {
            var latestNews = this.Data.News.All()
                .OrderByDescending(n => n.CreatedOn)
                .Take(6)
                .ToList();

            latestNews = latestNews.Where(n => n.CreatedOn > DateTime.Now.AddMonths(-1)).ToList();

            return this.PartialView(latestNews);
        }
    }
}