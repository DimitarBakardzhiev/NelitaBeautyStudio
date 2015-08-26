namespace NelitaBeautyStudio.Web.Controllers
{
    using System.Web.Mvc;

    using NelitaBeautyStudio.Data.Unit_of_Work;

    public class ErrorController : BaseController
    {
        public ErrorController(IApplicationData data)
            : base(data)
        {
        }

        public ViewResult NotFound()
        {
            Response.StatusCode = 404;
            return this.View();
        }
    }
}