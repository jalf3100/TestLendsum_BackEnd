//-----------------------------------------------------------------------
// <copyright file = "ReplyGetView.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Lendsum.Dtos.Response
{
    /// <summary>Clase que representa la respuesta de obtener la vista.</summary>
    public class ReplyGetView
    {
        /// <summary>Obtiene o establece la información del juego.</summary>
        public ReplyBuildNewGameMazeDto Juego { get; set; }
        /// <summary>Obtiene o establece la vista del bloque del laberinto.</summary>
        public ReplyMazeBlockView MazeBlockView { get; set; }
    }
}