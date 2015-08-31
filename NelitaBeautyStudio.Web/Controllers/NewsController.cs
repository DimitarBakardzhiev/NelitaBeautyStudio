namespace NelitaBeautyStudio.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using NelitaBeautyStudio.Common;
    using NelitaBeautyStudio.Data.Unit_of_Work;

    [Authorize(Roles = GlobalConstants.AdminRole)]
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

        //[AllowAnonymous]
        //public ActionResult Index()
        //{
        //    var allNews = this.Data.News.All().OrderByDescending(n => n.CreatedOn).ToList();
        //    var latestTen = allNews.Take(GlobalConstants.NewsIndexPageSize);

        //    return this.View(latestTen);
        //}

        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            var allNews = this.Data.News.All().OrderByDescending(n => n.CreatedOn).ToList();
            var currentPage = allNews.Skip((page - 1)* GlobalConstants.NewsIndexPageSize).Take(GlobalConstants.NewsIndexPageSize);

            this.ViewData["currentPage"] = page;
            var pagesCount = allNews.Count / GlobalConstants.NewsIndexPageSize;

            if (allNews.Count % GlobalConstants.NewsIndexPageSize != 0)
            {
                pagesCount++;
            }

            this.ViewData["pagesCount"] = pagesCount;

            return this.View(currentPage);
        }
    }
}