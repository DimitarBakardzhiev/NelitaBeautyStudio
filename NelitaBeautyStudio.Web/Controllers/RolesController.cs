namespace NelitaBeautyStudio.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    using NelitaBeautyStudio.Common;
    using NelitaBeautyStudio.Data.Unit_of_Work;
    using NelitaBeautyStudio.Models;
    using NelitaBeautyStudio.Web.Infrastructure;
    using NelitaBeautyStudio.Web.ViewModels;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class RolesController : BaseController
    {
        public RolesController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult Manage()
        {
            var users = this.Data.Users.All()
                .OrderBy(u => u.Email)
                .ToList();
            var adminRole = this.Data.Roles.All().First(r => r.Name == GlobalConstants.AdminRole);
            var model = new ManageUserRolesViewModel() { AdminRole = adminRole, Users = users };

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Promote(string id)
        {
            var store = new UserStore<User>(this.Data.Context);
            var manager = new UserManager<User>(store);

            manager.AddToRoleAsync(id, GlobalConstants.AdminRole);

            this.Notify(GlobalConstants.PromoteUser, NotificationType.success);

            return this.RedirectToAction("Manage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Demote(string id)
        {
            var currentUser = this.Data.Users.All().First(u => u.UserName == User.Identity.Name);
            var isSameUser = id == currentUser.Id;

            if (!isSameUser)
            {
                var store = new UserStore<User>(this.Data.Context);
                var manager = new UserManager<User>(store);

                manager.RemoveFromRoleAsync(id, GlobalConstants.AdminRole);

                this.Notify(GlobalConstants.DemoteUserSuccess, NotificationType.success);
            }
            else
            {
                this.Notify(GlobalConstants.DemoteUserFail, NotificationType.error);
            }

            return this.RedirectToAction("Manage");
        }
    }
}