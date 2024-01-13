//-----------------------------------------------------------------------
// <copyright file = "ReplyBuildNewGameMazeDto.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Lendsum.Dtos.Response
{
    /// <summary>Clase que representa la respuesta de la construcción de un nuevo juego de laberinto.</summary>
    public class ReplyBuildNewGameMazeDto
    {
        /// <summary>Obtiene o establece el identificador único del laberinto.</summary>
        public Guid MazeUid { get; set; }
        /// <summary>Obtiene o establece el identificador único del juego.</summary>
        public Guid GameUid { get; set; }
        /// <summary>Obtiene o establece un valor que indica si el juego se ha completado.</summary>
        public bool Completed { get; set; }
        /// <summary>Obtiene o establece la posición actual en el eje X.</summary>
        public int CurrentPositionX { get; set; }
        /// <summary>Obtiene o establece la posición actual en el eje Y.</summary>
        public int CurrentPositionY { get; set; }
    }
}