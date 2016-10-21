using DataLayer.Context;
using DataLayer.Migrations;
using EFSecondLevelCache;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private Dictionary<Type, object> repositories;
        private ShopDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            repositories = new Dictionary<Type, object>();
        }

        public ShopDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }

        //public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        //{

        //    // If our repositories have a matching repository, return it
        //    if (repositories.Keys.Contains(typeof(TEntity)))
        //        return repositories[typeof(TEntity)] as IRepository<TEntity>;

        //    // Create a new repository for our entity
        //    var repository = new Repository<TEntity>(context);

        //    // Add to our list of repositories
        //    repositories.Add(typeof(TEntity), repository);

        //    // Return our repository
        //    return repository;
        //}        
       

        #region UnitOfWork
        //public void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class
        //{
        //    Entry(entity).State = EntityState.Deleted;
        //}
        //public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        //{
        //    return base.Set<TEntity>();
        //}
        //public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        //{
        //    Entry(entity).State = EntityState.Modified;
        //}

        //public IList<T> GetRows<T>(string sql, params object[] parameters) where T : class
        //{
        //    return Database.SqlQuery<T>(sql, parameters).ToList();
        //}

        //public void ForceDatabaseInitialize()
        //{
        //    Database.Initialize(true);
        //}

        //public override int SaveChanges()
        //{
        //    return SaveAllChanges();
        //}

        //public int SaveAllChanges(bool invalidateCacheDependencies = true)
        //{
        //    var changedEntityNames = GetChangedEntityNames();
        //    var result = base.SaveChanges();
        //    if (invalidateCacheDependencies)
        //    {
        //        new EFCacheServiceProvider().InvalidateCacheDependencies(changedEntityNames);
        //    }
        //    return result;
        //}

        //private string[] GetChangedEntityNames()
        //{
        //    return ChangeTracker.Entries()
        //        .Where(x => x.State == EntityState.Added ||
        //                    x.State == EntityState.Modified ||
        //                    x.State == EntityState.Deleted)
        //        .Select(x => ObjectContext.GetObjectType(x.Entity.GetType()).FullName)
        //        .Distinct()
        //        .ToArray();
        //}
        //public override Task<int> SaveChangesAsync()
        //{
        //    return SaveAllChangesAsync();
        //}

        //public Task<int> SaveAllChangesAsync(bool invalidateCacheDependencies = true)
        //{
        //    var changedEntityNames = GetChangedEntityNames();
        //    var result = base.SaveChangesAsync();
        //    if (invalidateCacheDependencies)
        //    {
        //        new EFCacheServiceProvider().InvalidateCacheDependencies(changedEntityNames);
        //    }
        //    return result;
        //}

        //public void AutoDetectChangesEnabled(bool flag = true)
        //{
        //    Configuration.AutoDetectChangesEnabled = flag;
        //}
        #endregion //UnitOfWork
    }
}
