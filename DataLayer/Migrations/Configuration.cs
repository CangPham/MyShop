namespace DataLayer.Migrations
{
    using DomainClasses.Entities;
    using DomainClasses.Enums;
    using MockData;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataLayer.Context.ShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataLayer.Context.ShopDbContext context)
        {
            // users
            GetUser().ForEach(a => context.Users.Add(a));

            // categories
            GetCategories().ForEach(e => context.Categories.AddOrUpdate(e));
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Users.AddOrUpdate(u => u.UserName, new User
            {
                IsBaned = false,
                PhoneNumber = "0973781781",
                PasswordHash = "123456",
                UserName = "admin"
            });
            context.SaveChanges();
            base.Seed(context);
        }


        private static List<User> GetUser()
        {
            List<User> _users = new List<User>();

            for (int i = 1; i <= 10; i++)
            {
                _users.Add(new User()
                {
                    PhoneNumber = "0900000" + i,
                    UserName = MockData.Internet.UserName(),
                    IsBaned = false,
                    PasswordHash = "123456"
                });
            }

            return _users;
        }

        private static List<Category> GetCategories()
        {
            List<Category> _categories = new List<Category>();

            for (int i = 1; i <= 200; i++)
            {
                _categories.Add(new Category()
                {
                    Name = MockData.Company.Name(),
                    Description = MockData.Company.BS(),
                    KeyWords = MockData.Address.ZipCode()
                });
            }

            return _categories;
        }
    }
}
