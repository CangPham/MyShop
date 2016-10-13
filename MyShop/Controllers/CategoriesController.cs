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
    builder.EntitySet<Category>("Categories");
    builder.EntitySet<Attribute>("Attributes"); 
    builder.EntitySet<Product>("Products"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CategoriesController : ODataController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: odata/Categories
        [EnableQuery]
        public IQueryable<Category> GetCategories()
        {
            return db.Categories;
        }

        // GET: odata/Categories(5)
        [EnableQuery]
        public SingleResult<Category> GetCategory([FromODataUri] long key)
        {
            return SingleResult.Create(db.Categories.Where(category => category.Id == key));
        }

        // PUT: odata/Categories(5)
        public async Task<IHttpActionResult> Put([FromODataUri] long key, Delta<Category> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = await db.Categories.FindAsync(key);
            if (category == null)
            {
                return NotFound();
            }

            patch.Put(category);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(category);
        }

        // POST: odata/Categories
        public async Task<IHttpActionResult> Post(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(category);
            await db.SaveChangesAsync();

            return Created(category);
        }

        // PATCH: odata/Categories(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] long key, Delta<Category> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = await db.Categories.FindAsync(key);
            if (category == null)
            {
                return NotFound();
            }

            patch.Patch(category);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(category);
        }

        // DELETE: odata/Categories(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] long key)
        {
            Category category = await db.Categories.FindAsync(key);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Categories(5)/Attributes
        [EnableQuery]
        public IQueryable<DomainClasses.Entities.Attribute> GetAttributes([FromODataUri] long key)
        {
            return db.Categories.Where(m => m.Id == key).SelectMany(m => m.Attributes);
        }

        // GET: odata/Categories(5)/Children
        [EnableQuery]
        public IQueryable<Category> GetChildren([FromODataUri] long key)
        {
            return db.Categories.Where(m => m.Id == key).SelectMany(m => m.Children);
        }

        // GET: odata/Categories(5)/Parent
        [EnableQuery]
        public SingleResult<Category> GetParent([FromODataUri] long key)
        {
            return SingleResult.Create(db.Categories.Where(m => m.Id == key).Select(m => m.Parent));
        }

        // GET: odata/Categories(5)/Products
        [EnableQuery]
        public IQueryable<Product> GetProducts([FromODataUri] long key)
        {
            return db.Categories.Where(m => m.Id == key).SelectMany(m => m.Products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(long key)
        {
            return db.Categories.Count(e => e.Id == key) > 0;
        }
    }
}
