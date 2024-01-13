//-----------------------------------------------------------------------
// <copyright file = "ReplyMazeBlockView.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Lendsum.Dtos.Response
{
    /// <summary>Clase que representa la respuesta de la vista de bloque del laberinto.</summary>
    public class ReplyMazeBlockView
    {
        /// <summary>Obtiene o establece la coordenada X.</summary>
        public int CoordX { get; set; }
        /// <summary>Obtiene o establece la coordenada Y.</summary>
        public int CoordY { get; set; }
        /// <summary>Obtiene o establece un valor que indica si el norte está bloqueado.</summary>
        public bool NorthBlocked { get; set; }
        /// <summary>Obtiene o establece un valor que indica si el sur está bloqueado.</summary>
        public bool SouthBlocked { get; set; }
        /// <summary>Obtiene o establece un valor que indica si el oeste está bloqueado.</summary>
        public bool WestBlocked { get; set; }
        /// <summary>Obtiene o establece un valor que indica si el este está bloqueado.</summary>
        public bool EastBlocked { get; set; }
    }
}