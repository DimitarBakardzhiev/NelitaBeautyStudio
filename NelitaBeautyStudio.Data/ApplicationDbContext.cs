namespace NelitaBeautyStudio.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using NelitaBeautyStudio.Models;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
