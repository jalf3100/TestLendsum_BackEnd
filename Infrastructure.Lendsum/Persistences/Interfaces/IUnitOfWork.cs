//-----------------------------------------------------------------------
// <copyright file = "IUnitOfWork.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Lendsum.Persistences.Interfaces
{
    /// <summary>Interfaz que define la unidad de trabajo para manejar transacciones y operaciones relacionadas con múltiples entidades</summary>
    public interface IUnitOfWork : IDisposable
    {
        #region [Methods]
        /// <summary>Obtiene el repositorio específico para Category</summary>
        IMazeRepository Maze { get; }
        /// <summary>Obtiene el repositorio específico para Tasks</summary>
        IMazeGameRepository MazeGame { get; }
        IMovesMazeGameRepository MovesMazeGame { get; }
        /// <summary>Guarda los cambios en la base de datos y confirma la transacción</summary>
        void SaveChanges();
        /// <summary>Guarda los cambios asincrónicamente en la base de datos y confirma la transacción</summary>
        Task SaveChangesAsync();
        #endregion [Methods]
    }
}