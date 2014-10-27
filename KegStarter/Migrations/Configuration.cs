namespace KegStarter.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using KegStarter.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<KegStarter.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "KegStarter.Models.ApplicationDbContext";
        }

        protected override void Seed(KegStarter.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context);

            context.BeerHistories.AddOrUpdate(p => p.Name,

                new BeerHistory
                {
                    Name = "Lazy Boy IPA",
                    Brewery = "Lazy Boy Brewing",
                    Current = false,
                    DateTapped = DateTime.Parse("2014-10-06"),
                },
                new BeerHistory
                {
                    Name = "Apocalypse IPA",
                    Brewery = "10 Barrel Brewing Company",
                    Current = true,
                    DateTapped = DateTime.Parse("2014-10-22"),
                }     
                
            );
        }

        bool AddUserAndRole(KegStarter.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "testuser@contoso.com",
            };
            ir = um.Create(user, "Passw0rd!");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }
    }
}
