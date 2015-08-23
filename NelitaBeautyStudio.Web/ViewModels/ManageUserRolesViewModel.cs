namespace NelitaBeautyStudio.Web.ViewModels
{
    using System.Collections;
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity.EntityFramework;

    using NelitaBeautyStudio.Models;

    public class ManageUserRolesViewModel
    {
        public IdentityRole AdminRole { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}