
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using DomainClasses.Configuraion;
using DomainClasses.Entities;
using EFSecondLevelCache;
using Microsoft.AspNet.Identity.EntityFramework;
using DataLayer.Migrations;

namespace DataLayer.Context
{
    public class ShopDbContext : IdentityDbContext<User>
    {
        public ShopDbContext()
            : base("MyShop")
        {
            Database.SetInitializer<ShopDbContext>(null);
        }
        #region Entity set
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SiteOption> SiteOptions { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Value> SpecificationValues { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<ProductImage> Images { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<SlideShow> SlideShows { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Configurations.Add(new CommentConfig());
            modelBuilder.Configurations.Add(new SlideShowConfig());
            modelBuilder.Configurations.Add(new ProductConfig());
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new ShoppingCartConfig());
            modelBuilder.Configurations.Add(new OrderConfig());
            modelBuilder.Configurations.Add(new OrderDetailConfig());
            modelBuilder.Configurations.Add(new ImageConfig());
            modelBuilder.Configurations.Add(new AttributeConfig());
            modelBuilder.Configurations.Add(new FolderConfig());
            modelBuilder.Configurations.Add(new CategoryConfig());
            modelBuilder.Configurations.Add(new ValueConfig());
            modelBuilder.Configurations.Add(new ContactConfig());
            modelBuilder.Configurations.Add(new PageConfig());
            modelBuilder.Configurations.Add(new SiteOptionConfig());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        public static ShopDbContext Create()
        {
            return new ShopDbContext();
        }
    }
}
