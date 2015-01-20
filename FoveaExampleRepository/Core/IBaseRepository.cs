using System.Collections.Generic;

namespace FoveaExampleRepository.Core
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        ///     Retrieve a single item using it's primary key, exception if not found
        /// </summary>
        /// <param name="primaryKey">The primary key of the record</param>
        /// <returns>T</returns>
        T Single(object primaryKey);

        /// <summary>
        ///     Retrieve a single item by it's primary key or return null if not found
        /// </summary>
        /// <param name="primaryKey">Primary key to find</param>
        /// <returns>T</returns>
        T SingleOrDefault(object primaryKey);

        /// <summary>
        ///     Returns all the rows for type T
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        ///     Does this item exist by it's primary key
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        bool Exists(object primaryKey);

        /// <summary>
        ///     Inserts the data into the table
        /// </summary>
        /// <param name="entity">The entity to insert</param>
        /// <returns></returns>
        int Insert(T entity);

        /// <summary>
        ///     Updates this entity in the database using it's primary key
        /// </summary>
        /// <param name="entity">The entity to update</param>
        void Update(T entity);

        /// <summary>
        ///     Deletes this entry fro the database
        ///     ** WARNING - Most items should be marked inactive and Updated, not deleted
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        /// <returns></returns>
        int Delete(T entity);
    }
}