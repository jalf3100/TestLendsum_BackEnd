//-----------------------------------------------------------------------
// <copyright file = "GenericRepository.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Lendsum.Persistences.Repositories
{
    using Domain.Lendsum.Entities;
    using Infrestructure.Lendsum.Persistences.Contexts;
    using Infrestructure.Lendsum.Persistences.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    /// <summary>Clase genérica que implementa la lógica para operaciones de acceso a datos de entidades genéricas</summary>
    /// <typeparam name="T">El tipo de entidad con el que trabaja el repositorio</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        #region [Variables]
        /// <summary>Variable global que representa el DbContext utilizado para acceder a las entidades</summary>
        private readonly LendsumContext _context;
        /// <summary>Variable global que representa el tipo de entidad con el que trabaja el repositorio</summary>
        private readonly DbSet<T> _entity;
        #endregion [Variables]

        #region [Constructor]
        /// <summary>Inicializa una nueva instancia de la clase GenericRepository</summary>
        /// <param name="context">El DbContext utilizado para acceder a las entidades</param>
        public GenericRepository(LendsumContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        #endregion [Constructor]

        #region [Methods]
        /// <summary>Obtiene todas las entidades</summary>
        /// <returns>Una colección de todas las entidades</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<T> getAll = await _entity.AsNoTracking().ToListAsync();
            return getAll;
        }

        /// <summary>Encuentra una entidad por su identificador</summary>
        /// <param name="id">El identificador de la entidad a buscar</param>
        /// <returns>La entidad encontrada, o nulo si no se encuentra/returns>
        public async Task<T> GetByIdAsync(int id)
        {
            T? getById = await _entity!.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
            return getById!;
        }

        /// <summary>Agrega una nueva entidad</summary>
        /// <param name="entity">La entidad a agregar</param>
        /// <returns>True Si la Entidad pudo ser agregada o False si no</returns>
        public async Task<bool> RegisterAsync(T entity)
        {
            await _context.AddAsync(entity);
            int recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }

        /// <summary>Edita una entidad</summary>
        /// <param name="entity">Entidad a editar</param>
        /// <returns>True Si la Entidad pudo ser editada o False si no</returns>
        public async Task<bool> EditAsync(T entity)
        {
            _context.Update(entity);
            int recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }

        /// <summary>Elimina una entidad</summary>
        /// <param name="id">El identificador de la entidad a eliminar</param>
        /// <returns>True Si la Entidad pudo ser eliminada o False si no</returns>
        public async Task<bool> RemoveAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            _context.Remove(entity);
            int recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }

        /// <summary>Obtiene todas las entidades según el filtro que se envíe</summary>
        /// <param name="filter">Filtro para consultar las entidades</param>
        /// <returns>Una colección de todas las entidades según el filtro que se envíe</returns>
        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;
            if (filter != null) query = query.Where(filter);
            return query;
        }
        #endregion [Methods]
    }
}