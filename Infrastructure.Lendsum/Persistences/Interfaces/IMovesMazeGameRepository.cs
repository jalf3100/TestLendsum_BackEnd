//-----------------------------------------------------------------------
// <copyright file = "IMovesMazeGameRepository.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Lendsum.Persistences.Interfaces
{
    using Domain.Lendsum.Entities;

    /// <summary>Interfaz que define las operaciones básicas para un repositorio de MovesMazeGame</summary>
    public interface IMovesMazeGameRepository : IGenericRepository<MovesMazeGame>
    {
    }
}