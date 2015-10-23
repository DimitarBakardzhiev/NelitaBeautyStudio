namespace NelitaBeautyStudio.Data.Migrations
{
    using System;
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

            if (context.Contacts.Count() == 0)
            {
                this.SeedContacts(context);
            }

            this.SeedAdmin(context);

            if (context.News.Count() == 0)
            {
                this.SeedNews(context);
            }
        }

        private void SeedContacts(ApplicationDbContext context)
        {
            context.Contacts.AddOrUpdate(
                c => c.Type,
                new Contact { Type = "Нели - фризьор", Value = "0898 911 870", Priority = Priority.High },
                new Contact { Type = "Радо - фризьор", Value = "0988 830 711", Priority = Priority.High },
                new Contact { Type = "Мъри - маникюрист и педикюрист", Value = "0877 802 323", Priority = Priority.Normal });
        }

        private void SeedAdmin(ApplicationDbContext context)
        {
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

        private void SeedNews(ApplicationDbContext context)
        {
            context.News.AddOrUpdate(
                n => n.Title,
                new News()
                {
                    Title = "asdwqefwew",
                    Content = "qwertyuiopolkjhgfdsazxcvbnm",
                    CreatedOn = new DateTime(2015, 08, 28, 12, 30, 0)
                },
                new News()
                {
                    Title = "asdfaf",
                    Content = "arhrewjnsajhsdjcsjnajkanwaeceuaesuifaekjnakejnniuaesfiaeufie",
                    CreatedOn = new DateTime(2015, 08, 26, 16, 0, 0)
                },
                new News()
                {
                    Title = "asgsht",
                    Content = "aeijaiuaasefaefqwfthydyumdsrysfewiuqwieou289732acfiumiacwfeaweuiausiefaiweufy8q723y7axnifchicofhayi",
                    CreatedOn = new DateTime(2015, 08, 15, 14, 0, 0)
                },
                new News()
                {
                    Title = "dfasjkds",
                    Content = "afdslafseoijafseoijaewfoiupq3uq89aeoiaxfmioewjaojxeif",
                    CreatedOn = new DateTime(2015, 08, 30, 10, 15, 0)
                });
        }
    }
}
