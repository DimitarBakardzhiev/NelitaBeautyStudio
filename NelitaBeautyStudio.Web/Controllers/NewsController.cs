namespace NelitaBeautyStudio.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using NelitaBeautyStudio.Common;
    using NelitaBeautyStudio.Data.Unit_of_Work;
    using NelitaBeautyStudio.Models;
    using NelitaBeautyStudio.Web.Infrastructure;
    using NelitaBeautyStudio.Web.ViewModels;

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

        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            var allNews = this.Data.News.All().OrderByDescending(n => n.CreatedOn).ToList();
            var currentPage = allNews.Skip((page - 1) * GlobalConstants.NewsIndexPageSize).Take(GlobalConstants.NewsIndexPageSize);

            this.ViewData["currentPage"] = page;
            var pagesCount = allNews.Count / GlobalConstants.NewsIndexPageSize;

            if (allNews.Count % GlobalConstants.NewsIndexPageSize != 0)
            {
                pagesCount++;
            }

            this.ViewData["pagesCount"] = pagesCount;

            return this.View(currentPage);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsViewModel news)
        {
            if (ModelState.IsValid)
            {
                var newsModel = Mapper.Map<News>(news);
                newsModel.CreatedOn = DateTime.Now;

                this.Data.News.Add(newsModel);
                this.Data.SaveChanges();

                this.Notify(GlobalConstants.AddNews, NotificationType.success);

                return this.RedirectToAction("Details", "News", new { id = newsModel.Id });
            }

            return this.View(news);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Details(int id)
        {
            var news = this.Data.News.GetById(id);

            return this.View("Details", news);
        }

        public ActionResult Edit(int id)
        {
            var news = this.Data.News.GetById(id);
            var newsViewModel = Mapper.Map<NewsViewModel>(news);

            return this.View(newsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NewsViewModel news)
        {
            if (ModelState.IsValid)
            {
                var newsModel = this.Data.News.GetById(id);
                newsModel.Title = news.Title;
                newsModel.Content = news.Content;

                this.Data.News.Update(newsModel);
                this.Data.SaveChanges();

                this.Notify(GlobalConstants.EditNews, NotificationType.info);

                return this.RedirectToAction("Details", "News", new { id = id });
            }

            return this.View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var news = this.Data.News.GetById(id);

            this.Data.News.Delete(news);
            this.Data.SaveChanges();

            this.Notify(GlobalConstants.DeleteNews, NotificationType.warning);

            return this.RedirectToAction("Index", "Home");
        }
    }
}