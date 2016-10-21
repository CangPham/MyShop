using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using DataLayer.Context;
using DomainClasses.Entities;

namespace MyShop.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using DomainClasses.Entities;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Product>("Products");
    builder.EntitySet<Category>("Categories"); 
    builder.EntitySet<Comment>("Comments"); 
    builder.EntitySet<ProductImage>("Images"); 
    builder.EntitySet<User>("Users"); 
    builder.EntitySet<OrderDetail>("OrderDetails"); 
    builder.EntitySet<ShoppingCart>("ShoppingCarts"); 
    builder.EntitySet<Value>("SpecificationValues"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ProductsController : ODataController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: odata/Products
        [EnableQuery]
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
         }

        // GET: odata/Products(5)
        [EnableQuery]
        public SingleResult<Product> GetProduct([FromODataUri] long key)
        {
            return SingleResult.Create(db.Products.Where(product => product.Id == key));
        }

        // PUT: odata/Products(5)
        public async Task<IHttpActionResult> Put([FromODataUri] long key, Delta<Product> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = await db.Products.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }

            patch.Put(product);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(product);
        }

        // POST: odata/Products
        public async Task<IHttpActionResult> Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return Created(product);
        }

        // PATCH: odata/Products(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] long key, Delta<Product> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = await db.Products.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }

            patch.Patch(product);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(product);
        }

        // DELETE: odata/Products(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] long key)
        {
            Product product = await db.Products.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Products(5)/Category
        [EnableQuery]
        public SingleResult<Category> GetCategory([FromODataUri] long key)
        {
            return SingleResult.Create(db.Products.Where(m => m.Id == key).Select(m => m.Category));
        }

        // GET: odata/Products(5)/Comments
        [EnableQuery]
        public IQueryable<Comment> GetComments([FromODataUri] long key)
        {
            return db.Products.Where(m => m.Id == key).SelectMany(m => m.Comments);
        }

        // GET: odata/Products(5)/Images
        [EnableQuery]
        public IQueryable<ProductImage> GetImages([FromODataUri] long key)
        {
            return db.Products.Where(m => m.Id == key).SelectMany(m => m.Images);
        }

        // GET: odata/Products(5)/LikedUsers
        [EnableQuery]
        public IQueryable<User> GetLikedUsers([FromODataUri] long key)
        {
            return db.Products.Where(m => m.Id == key).SelectMany(m => m.LikedUsers);
        }

        // GET: odata/Products(5)/OrderDetails
        [EnableQuery]
        public IQueryable<OrderDetail> GetOrderDetails([FromODataUri] long key)
        {
            return db.Products.Where(m => m.Id == key).SelectMany(m => m.OrderDetails);
        }

        // GET: odata/Products(5)/ShoppingCarts
        [EnableQuery]
        public IQueryable<ShoppingCart> GetShoppingCarts([FromODataUri] long key)
        {
            return db.Products.Where(m => m.Id == key).SelectMany(m => m.ShoppingCarts);
        }

        // GET: odata/Products(5)/UsersFavorite
        [EnableQuery]
        public IQueryable<User> GetUsersFavorite([FromODataUri] long key)
        {
            return db.Products.Where(m => m.Id == key).SelectMany(m => m.UsersFavorite);
        }

        // GET: odata/Products(5)/Values
        [EnableQuery]
        public IQueryable<Value> GetValues([FromODataUri] long key)
        {
            return db.Products.Where(m => m.Id == key).SelectMany(m => m.Values);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(long key)
        {
            return db.Products.Count(e => e.Id == key) > 0;
        }
    }
}
