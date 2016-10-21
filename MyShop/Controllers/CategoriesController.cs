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
using DataLayer.Repositories;

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
    //[Authorize(Roles = "Admin")]
    //[RoutePrefix("api/categories")]
    public class CategoriesController : ApiBaseController
    {        
        private readonly IEntityBaseRepository<Category> _categoryRepository;
        public CategoriesController(IEntityBaseRepository<Category> categoryRepository,
            IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: odata/Categories
        [EnableQuery]
        public IQueryable<Category> GetCategories()
        {
            return _categoryRepository.GetAll();
        }

        // GET: odata/Categories(5)
        [EnableQuery]
        public SingleResult<Category> GetCategory([FromODataUri] int key)
        {
            var category = _categoryRepository.FindBy(p => p.Id == key);
            return SingleResult.Create(category);
        }

        // PUT: odata/Categories(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Category> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = await _categoryRepository.FindAsync(p => p.Id == key);
            if (category == null)
            {
                return NotFound();
            }

            patch.Put(category);

            try
            {
                await _categoryRepository.UpdateAsync(category, key);
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

            await _categoryRepository.AddAsync(category);

            return Created(category);
        }

        // PATCH: odata/Categories(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Category> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = await _categoryRepository.FindAsync(p => p.Id == key);
            if (category == null)
            {
                return NotFound();
            }

            patch.Patch(category);

            try
            {
                await _categoryRepository.UpdateAsync(category, key);
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
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Category category = await _categoryRepository.FindAsync(p => p.Id == key);
            if (category == null)
            {
                return NotFound();
            }
            await _categoryRepository.DeleteAsync(category);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Categories(5)/Attributes
        //[EnableQuery]
        //public IQueryable<DomainClasses.Entities.Attribute> GetAttributes([FromODataUri] long key)
        //{
        //    return db.Categories.Where(m => m.Id == key).SelectMany(m => m.Attributes);
        //}

        //// GET: odata/Categories(5)/Children
        //[EnableQuery]
        //public IQueryable<Category> GetChildren([FromODataUri] long key)
        //{
        //    return db.Categories.Where(m => m.Id == key).SelectMany(m => m.Children);
        //}

        //// GET: odata/Categories(5)/Parent
        //[EnableQuery]
        //public SingleResult<Category> GetParent([FromODataUri] long key)
        //{
        //    return SingleResult.Create(db.Categories.Where(m => m.Id == key).Select(m => m.Parent));
        //}

        //// GET: odata/Categories(5)/Products
        //[EnableQuery]
        //public IQueryable<Product> GetProducts([FromODataUri] long key)
        //{
        //    return db.Categories.Where(m => m.Id == key).SelectMany(m => m.Products);
        //}        

        private bool CategoryExists(int key)
        {
            return _categoryRepository.Count(key) > 0;
        }
    }
}
