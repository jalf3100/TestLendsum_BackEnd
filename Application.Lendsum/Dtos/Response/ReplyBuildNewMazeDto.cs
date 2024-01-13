//-----------------------------------------------------------------------
// <copyright file = "ReplyBuildNewMazeDto.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Lendsum.Dtos.Response
{
    /// <summary>Clase que representa la respuesta de la construcción de un nuevo laberinto.</summary>
    public class ReplyBuildNewMazeDto
    {
        /// <summary>Obtiene o establece el identificador único del laberinto.</summary>
        public Guid MazeUid { get; set; }
        /// <summary>Obtiene o establece la anchura del laberinto.</summary>
        public int Anchura { get; set; }
        /// <summary>Obtiene o establece la altura del laberinto.</summary>
        public int Altura { get; set; }
    }
}