namespace NelitaBeautyStudio.Web.Controllers
{
    using System.Web.Mvc;

    using NelitaBeautyStudio.Data.Unit_of_Work;
    using NelitaBeautyStudio.Models;
    using NelitaBeautyStudio.Web.Infrastructure;

    public abstract class BaseController : Controller
    {
        public BaseController(IApplicationData data)
        {
            this.Data = data;
        }

        protected IApplicationData Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected void Notify(string message, NotificationType type)
        {
            this.TempData["message"] = message;
            this.TempData["type"] = type.ToString();
        }
    }
}