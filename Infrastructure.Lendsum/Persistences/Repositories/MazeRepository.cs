//-----------------------------------------------------------------------
// <copyright file = "MazeRepository.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Lendsum.Persistences.Repositories
{
    using Domain.Lendsum.Entities;
    using Infrestructure.Lendsum.Persistences.Contexts;
    using Infrestructure.Lendsum.Persistences.Interfaces;

    /// <summary>Clase que implementa la lógica para operaciones de acceso a datos de la entidad Maze</summary>
    public class MazeRepository : GenericRepository<Maze>, IMazeRepository
    {
        #region [Constructor]
        /// <summary>Inicializa una nueva instancia de la clase MazeRepository</summary>
        /// <param name="context">El DbContext utilizado para acceder a las Maze</param>
        public MazeRepository(LendsumContext context) : base(context)
        {
        }
        #endregion [Constructor]
    }
}