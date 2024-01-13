//-----------------------------------------------------------------------
// <copyright file = "UnitOfWork.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Lendsum.Persistences.Repositories
{
    using Infrestructure.Lendsum.Persistences.Contexts;
    using Infrestructure.Lendsum.Persistences.Interfaces;

    /// <summary>Clase que define la unidad de trabajo para manejar transacciones y operaciones relacionadas con múltiples entidades</summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region [Variables]
        /// <summary></summary>
        private readonly LendsumContext _context;
        /// <summary>Variable Global que representa el repositorio específico para Maze</summary>
        public IMazeRepository Maze { get; set; }
        /// <summary>Variable Global que representa el repositorio específico para MazeGame</summary>
        public IMazeGameRepository MazeGame { get; set; }
        /// <summary>Variable Global que representa el repositorio específico para MovesMazeGame</summary>
        public IMovesMazeGameRepository MovesMazeGame { get; set; }
        #endregion [Variables]

        #region [Constructor]
        /// <summary>Inicializa una nueva instancia de la clase UnitOfWork</summary>
        /// <param name="context">El DbContext utilizado para acceder a las entidades</param>
        public UnitOfWork(LendsumContext context)
        {
            _context = context;
            Maze = new MazeRepository(_context);
            MazeGame = new MazeGameRepository(_context);
            MovesMazeGame = new MovesMazeGameRepository(_context);
        }
        #endregion [Constructor]

        #region [Methods]
        /// <summary>Libera los recursos no administrados utilizados por la clase UnitOfWork</summary>
        public void Dispose()
        {
            _context.Dispose();
        }

        /// <summary>Guarda los cambios en la base de datos y confirma la transacción</summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>Guarda los cambios asincrónicamente en la base de datos y confirma la transacción</summary>
        /// <returns>Una tarea que representa la operación asincrónica</returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        #endregion [Methods]
    }
}