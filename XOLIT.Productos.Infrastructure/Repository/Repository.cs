﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XOLIT.ShoppingCart.Infrastructure.DBContext;

namespace XOLIT.ShoppingCart.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The dbcontext
        /// </summary>
        private readonly XolitDbContext _dbcontext;
        /// <summary>
        /// The entities
        /// </summary>
        private readonly DbSet<TEntity> _entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbcontext">The dbcontext.</param>
        public Repository(XolitDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
            this._entities = dbcontext.Set<TEntity>();
        }

        // Include lambda expressions in queries      
        /// <summary>
        /// Performs the inclusions.
        /// </summary>
        /// <param name="includeProperties">The include properties.</param>
        /// <param name="query">The query.</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        private IQueryable<TEntity> PerformInclusions(IEnumerable<Expression<Func<TEntity, object>>> includeProperties,
                                                IQueryable<TEntity> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }


        #region IRepository<TEntity> Members

        /// <summary>
        /// Ases the queryable.
        /// </summary>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        /// Retorna un objeto del tipo AsQueryable
        public IQueryable<TEntity> AsQueryable()
        {
            return _entities.AsQueryable<TEntity>();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>IEnumerable&lt;TEntity&gt;.</returns>
        /// Retorna un objeto del tipo AsQueryable y acepta como parámetro las relaciones a incluir
        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            return PerformInclusions(includeProperties, query);
        }



        /// <summary>
        /// Finds the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>TEntity.</returns>
        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = AsQueryable();
            return query.FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        /// <summary>
        /// Finds the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>IEnumerable&lt;TEntity&gt;.</returns>
        /// Función que retorna una entidad, a partir de una consulta.
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = AsQueryable();
            return await query.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Firsts the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>TEntity.</returns>
        /// Retorna la ultima entidad encontrada bajo una condición especificada
        public TEntity First(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.First(where);
        }

        /// <summary>
        /// Lasts the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>TEntity.</returns>
        /// Retorna la primera entidad encontrada bajo una condición especificada
        public TEntity Last(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Last(where);
        }

        /// <summary>
        /// Firsts the or default.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>TEntity.</returns>
        /// Retorna la primera entidad encontrada bajo una condición especificada o null sino encontrara registros
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.FirstOrDefault(where);
        }

        /// <summary>
        /// Lasts the or default.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>TEntity.</returns>
        /// Retorna la ultima entidad encontrada bajo una condición especificada o null sino encontrara registros
        public TEntity LastOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.LastOrDefault(where);
        }

        /// <summary>
        /// Singles the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>TEntity.</returns>
        /// Retorna una entidad bajo una condición especificada
        public TEntity Single(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Single(where);
        }

        /// <summary>
        /// Singles the or default.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>TEntity.</returns>
        /// Retorna una entidad bajo una condición especificada o null sino encontrara registros
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.SingleOrDefault(where);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// Registra una entidad
        public void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }

        /// <summary>
        /// Inserts the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// Registra varias entidades
        public void Insert(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dbcontext.Entry(e).State = EntityState.Added;
            }
        }

        /// <summary>
        /// Inserts the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// Registra varias entidades
        public async Task InsertAsync(List<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        /// <summary>
        /// insert as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task.</returns>
        public async Task InsertAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        /// <summary>
        /// insert as an asynchronous operation.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>Task.</returns>
        public async Task InsertAsync(IEnumerable<TEntity> entities)
        {

            foreach (var e in entities)
            {
                await _entities.AddAsync(e);
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// Actualiza una entidad
        public void Update(TEntity entity)
        {
            _entities.Attach(entity);
            _dbcontext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Updates the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// Actualiza varias entidades
        public void Update(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dbcontext.Entry(e).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// Elimina por Id
        public void Delete(object id)
        {
            TEntity entityToDelete = _entities.Find(id);
            _entities.Remove(entityToDelete);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// Elimina una entidad
        public void Delete(TEntity entity)
        {
            if (_dbcontext.Entry(entity).State == EntityState.Detached)
            {
                _entities.Attach(entity);
            }
            _entities.Remove(entity);
        }

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// Elimina un conjuto de entidades
        public void Delete(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dbcontext.Entry(e).State = EntityState.Deleted;
            }
        }

        #endregion

       
    }
}
