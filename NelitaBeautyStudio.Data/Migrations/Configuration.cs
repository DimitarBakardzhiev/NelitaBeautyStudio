namespace NelitaBeautyStudio.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    using NelitaBeautyStudio.Common;
    using NelitaBeautyStudio.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            ////  This method will be called after migrating to the latest version.
            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            ////  to avoid creating duplicate seed data. E.g.
            ////
            ////    context.People.AddOrUpdate(
            ////      p => p.FullName,
            ////      new Person { FullName = "Andrew Peters" },
            ////      new Person { FullName = "Brice Lambson" },
            ////      new Person { FullName = "Rowan Miller" }
            ////    );

            context.Contacts.AddOrUpdate(
                c => c.Type,
                new Contact { Type = "Нели - фризьор", Value = "0898 911 870", Priority = Priority.High },
                new Contact { Type = "Радо - фризьор", Value = "0988 830 711", Priority = Priority.High },
                new Contact { Type = "Мъри - маникюрист и педикюрист", Value = "0877 802 323", Priority = Priority.Normal },
                new Contact { Type = "Изабел - козметика и масажи", Value = "0889 471 288", Priority = Priority.Low },
                new Contact { Type = "Лили - масажи", Value = "0878 705 186", Priority = Priority.Low });

            context.Roles.AddOrUpdate(
                r => r.Name,
                new IdentityRole { Name = GlobalConstants.AdminRole });

            if (context.Users.FirstOrDefault(u => u.Email == "admin@admin.com") == null)
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);

                manager.Create(new User() { Email = "admin@admin.com", UserName = "admin@admin.com" }, "123456");

                var admin = context.Users.FirstOrDefault(u => u.Email == "admin@admin.com");

                manager.AddToRole(admin.Id, GlobalConstants.AdminRole);
            }
        }
    }
}
