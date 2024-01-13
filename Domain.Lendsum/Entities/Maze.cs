//-----------------------------------------------------------------------
// <copyright file = "Maze.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Domain.Lendsum.Entities
{
    /// <summary>Clase parcial que representa un laberinto en el dominio.</summary>
    public partial class Maze : BaseEntity
    {
        /// <summary>Obtiene o establece el identificador único del laberinto.</summary>
        public Guid? Guidmaze { get; set; }
        /// <summary>Obtiene o establece el ancho del laberinto.</summary>
        public int? Ancho { get; set; }
        /// <summary>Obtiene o establece la altura del laberinto.</summary>
        public int? Altura { get; set; }

        /// <summary>Obtiene la colección de juegos asociados a este laberinto.</summary>
        public virtual ICollection<MazeGame> MazeGames { get; } = new List<MazeGame>();
        /// <summary>Constructor predeterminado de la clase Maze. Inicializa valores por defecto.</summary>
        public Maze()
        {
            Guidmaze = Guid.NewGuid();
            Ancho = 5;
            Altura = 5;
        }
        /// <summary>Constructor de la clase Maze que permite especificar la altura y el ancho del laberinto.</summary>
        /// <param name="Altura">La altura del laberinto.</param>
        /// <param name="Anchura">El ancho del laberinto.</param>
        public Maze(int Altura, int Anchura)
        {
            Guidmaze = Guid.NewGuid();
            Altura = (int)Altura;
            Anchura = (int)Anchura;
        }
    }
}