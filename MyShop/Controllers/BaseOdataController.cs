using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;

namespace MyShop.Controllers
{
    public class BaseOdataController<TRepository, TEntity> : EntitySetController<TEntity, int>
        where TRepository : IRepository<TEntity>
        where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TRepository _repository;

        public BaseOdataController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_repository = _unitOfWork.GetRepository<TRepository>();
        }

        public override System.Linq.IQueryable<TEntity> Get()
        {
            return _repository.Get();
        }

        protected override TEntity GetEntityByKey(int key)
        {
            return _repository.Get(key);
        }

        protected override TEntity CreateEntity(TEntity entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        protected override TEntity UpdateEntity(int key, TEntity update)
        {
            var exists = _repository.Get(key) != null;
            if (!exists)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _repository.Update(update);
            _unitOfWork.Commit();
            return update;
        }

        protected override TEntity PatchEntity(int key, Delta<TEntity> patch)
        {
            var entity = _repository.Get(key);
            if (entity == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            patch.Patch(entity);
            _unitOfWork.Commit();
            return entity;
        }

        public override void Delete([FromODataUri]int key)
        {
            var entity = _repository.Get(key);
            if (entity == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }
    }
}