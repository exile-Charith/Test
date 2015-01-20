using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FoveaExampleRepository.Core;

namespace FoveaExampleRepository
{
    /// <summary>
    ///     Base class for all SQL based service classes
    /// </summary>
    /// <typeparam name="T">The domain object type</typeparam>
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, IIdentifier
    {
        private readonly IUnitOfWork _unitOfWork;
        internal DbSet<T> DbSet;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            DbSet = _unitOfWork.Db.Set<T>();
        }

        internal DbContext Database
        {
            get { return _unitOfWork.Db; }
        }

        /// <summary>
        ///     Returns the object with the primary key specifies or throws
        /// </summary>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The result mapped to the specified type</returns>
        public T Single(object primaryKey)
        {
            var dbResult = DbSet.Find(primaryKey);
            return dbResult;
        }

        /// <summary>
        ///     Returns the object with the primary key specifies or the default for the type
        /// </summary>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The result mapped to the specified type</returns>
        public T SingleOrDefault(object primaryKey)
        {
            return DbSet.Find(primaryKey);
        }

        /// <summary>
        ///     Does this item exist by it's primary key
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public bool Exists(object primaryKey)
        {
            return (DbSet.Find(primaryKey) != null);
        }

        /// <summary>
        ///     Inserts the data into the table
        /// </summary>
        /// <param name="entity">The entity to insert</param>
        /// <returns></returns>
        public virtual int Insert(T entity)
        {
            dynamic obj = DbSet.Add(entity);
            _unitOfWork.Db.SaveChanges();
            return obj.Id;
        }

        /// <summary>
        ///     Updates this entity in the database using it's primary key
        /// </summary>
        /// <param name="entity">The entity to update</param>
        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Db.SaveChanges();
        }

        /// <summary>
        ///     Deletes this entry fro the database
        ///     ** WARNING - Most items should be marked inactive and Updated, not deleted
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        /// <returns></returns>
        public int Delete(T entity)
        {
            if (_unitOfWork.Db.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dynamic obj = DbSet.Remove(entity);
            _unitOfWork.Db.SaveChanges();
            return obj.Id;
        }

        /// <summary>
        ///     Returns all the rows for type T
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return DbSet.AsEnumerable().ToList();
        }
    }
}