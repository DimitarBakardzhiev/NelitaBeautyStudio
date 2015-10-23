namespace NelitaBeautyStudio.Web.Controllers
{
    using System.Web.Mvc;

    using NelitaBeautyStudio.Data.Unit_of_Work;
    
    public class HomeController : BaseController
    {
        public HomeController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}