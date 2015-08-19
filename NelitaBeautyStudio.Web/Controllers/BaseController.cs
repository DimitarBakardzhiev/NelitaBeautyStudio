namespace NelitaBeautyStudio.Web.Controllers
{
    using System.Web.Mvc;

    using NelitaBeautyStudio.Data.Unit_of_Work;
    using NelitaBeautyStudio.Models;

    public abstract class BaseController : Controller
    {
        public BaseController(IApplicationData data)
        {
            this.Data = data;
        }

        protected IApplicationData Data { get; private set; }

        protected User UserProfile { get; private set; }
    }
}