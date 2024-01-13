//-----------------------------------------------------------------------
// <copyright file = "MazeGame.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Domain.Lendsum.Entities
{
    /// <summary>Clase parcial que representa un juego de laberinto en el dominio.</summary>
    public partial class MazeGame : BaseEntity
    {
        /// <summary>Obtiene o establece el identificador único del laberinto asociado al juego.</summary>
        public int? IdMaze { get; set; }
        /// <summary>Obtiene o establece el identificador único del juego de laberinto.</summary>
        public Guid? GuidmazeGame { get; set; }
        /// <summary>Obtiene o establece un valor que indica si el juego está completo.</summary>
        public bool? Complete { get; set; }
        /// <summary>Obtiene o establece un valor que indica si el juego está activo.</summary>
        public bool? Activo { get; set; }

        /// <summary>Obtiene o establece la navegación a la entidad Maze asociada al juego.</summary>
        public virtual Maze? IdMazeNavigation { get; set; }
        /// <summary>Obtiene la colección de movimientos asociados a este juego de laberinto.</summary>
        public virtual ICollection<MovesMazeGame> MovesMazeGames { get; } = new List<MovesMazeGame>();
        /// <summary>Constructor predeterminado de la clase MazeGame. Inicializa valores por defecto.</summary>
        public MazeGame()
        {
            Activo = true;
            Complete = false;
            GuidmazeGame = Guid.NewGuid();
        }
        /// <summary>Constructor de la clase MazeGame que permite especificar el identificador del laberinto asociado.</summary>
        /// <param name="MazeId">El identificador del laberinto asociado.</param>
        public MazeGame(int MazeId)
        {
            Activo = true;
            Complete = false;
            GuidmazeGame = Guid.NewGuid();
            IdMaze = MazeId;
        }
    }
}