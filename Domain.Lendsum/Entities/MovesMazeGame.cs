//-----------------------------------------------------------------------
// <copyright file = "MovesMazeGame.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Domain.Lendsum.Entities
{
    /// <summary>Clase parcial que representa un movimiento de juego de laberinto en el dominio.</summary>
    public partial class MovesMazeGame : BaseEntity
    {
        /// <summary>Obtiene o establece el identificador único del juego de laberinto asociado al movimiento.</summary>
        public int? IdMazeGame { get; set; }
        /// <summary>Obtiene o establece la posición X actual en el laberinto.</summary>
        public int? CurrentPositionX { get; set; }
        /// <summary>Obtiene o establece la posición Y actual en el laberinto.</summary>
        public int? CurrentPositionY { get; set; }
        /// <summary>Obtiene o establece un valor que indica si la dirección norte está bloqueada.</summary>
        public bool? NorthBlocked { get; set; }
        /// <summary>Obtiene o establece un valor que indica si la dirección sur está bloqueada.</summary>
        public bool? SouthBlocked { get; set; }
        /// <summary>Obtiene o establece un valor que indica si la dirección oeste está bloqueada.</summary>
        public bool? WestBlocked { get; set; }
        /// <summary>Obtiene o establece un valor que indica si la dirección este está bloqueada.</summary>
        public bool? EastBlocked { get; set; }

        /// <summary>Obtiene o establece la navegación a la entidad MazeGame asociada al movimiento.</summary>
        public virtual MazeGame? IdMazeGameNavigation { get; set; }
        /// <summary>Constructor predeterminado de la clase MovesMazeGame. Inicializa valores por defecto.</summary>
        public MovesMazeGame()
        {
            CurrentPositionX = 0;
            CurrentPositionY = 0;
            EastBlocked = false;
            NorthBlocked = true;
            SouthBlocked = false;
            WestBlocked = true;
            IdMazeGame = 0;
        }
        /// <summary>Constructor de la clase MovesMazeGame que permite especificar el identificador del juego de laberinto asociado.</summary>
        /// <param name="MazeGameId">El identificador del juego de laberinto asociado.</param>
        public MovesMazeGame(int MazeGameId)
        {
            CurrentPositionX = 0;
            CurrentPositionY = 0;
            EastBlocked = false;
            NorthBlocked = true;
            SouthBlocked = false;
            WestBlocked = true;
            IdMazeGame = MazeGameId;
        }
    }
}