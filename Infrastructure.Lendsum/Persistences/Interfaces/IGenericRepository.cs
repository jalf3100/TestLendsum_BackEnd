//-----------------------------------------------------------------------
// <copyright file = "IGenericRepository.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Lendsum.Persistences.Interfaces
{
    using Domain.Lendsum.Entities;
    using System.Linq.Expressions;

    /// <summary>Interfaz que define las operaciones básicas para un repositorio de entidades</summary>
    /// <typeparam name="T">El tipo de entidad con la que trabaja el repositorio</typeparam>
    public interface IGenericRepository<T> where T : BaseEntity
    {
        #region [Methods]
        /// <summary>Obtiene todas las entidades</summary>
        /// <returns>Una colección de todas las entidades</returns>
        Task<IEnumerable<T>> GetAllAsync();
        /// <summary>Encuentra una entidad por su identificador</summary>
        /// <param name="id">El identificador de la entidad a buscar</param>
        /// <returns>La entidad encontrada, o nulo si no se encuentra/returns>
        Task<T> GetByIdAsync(int id);
        /// <summary>Agrega una nueva entidad</summary>
        /// <param name="entity">La entidad a agregar</param>
        /// <returns>True Si la Entidad pudo ser agregada o False si no</returns>
        Task<bool> RegisterAsync(T entity);
        /// <summary>Edita una entidad</summary>
        /// <param name="entity">Entidad a editar</param>
        /// <returns>True Si la Entidad pudo ser editada o False si no</returns>
        Task<bool> EditAsync(T entity);
        /// <summary>Elimina una entidad</summary>
        /// <param name="id">El identificador de la entidad a eliminar</param>
        /// <returns>True Si la Entidad pudo ser eliminada o False si no</returns>
        Task<bool> RemoveAsync(int id);
        /// <summary>Obtiene todas las entidades según el filtro que se envíe</summary>
        /// <param name="filter">Filtro para consultar las entidades</param>
        /// <returns>Una colección de todas las entidades según el filtro que se envíe</returns>
        IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null);
        #endregion [Methods]
    }
}