//-----------------------------------------------------------------------
// <copyright file = "ReplyMessage.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Utilities.Lendsum.Statics
{
    public class ReplyMessage
    {
        public const string Message_Validate_Dimension = "El valor para {0} debe estar entre 5 y 150.";
        public const string Message_CreateNewGame = "El valor esperado en {0}, no es el correcto.";
        public const string ExpectedValueStarOrRestart = "Start";
        public const string Message_Create_New_Maze = "Laberinto Creado Con éxito.";
        public const string Message_Create_New_GameMaze = "Nuevo Juego Creado con éxito.";
        public const string Message_Not_Exist_Maze = "Ese laberinto no existe.";
        public const string Message_GameMaze_HasOne = "El Laberinto ya tiene creado un juego.";
        public const string Message_Not_Exist_MazeGame = "El laberinto no tiene creado el juego que se indica.";
        public const string Message_Wrong = "Operación sin éxito.";
        public static readonly List<string> miLista = new List<string>
        { "GoNorth", "GoSouth", "GoEast", "GoWest", "Start" };
        public const string GoNorth = "gonorth";
        public const string GoSouth = "gosouth";
        public const string GoEast = "goeast";
        public const string GoWest = "gowest";
        public const string GameOver = "El juego ha sido terminado.";
        public const string Error = "Error";
        public const string MessageReStart = "El juego se ha reiniciado";
        public const string MessageMoveOk = "El movimiento {0}, se realizó correctamente.";
    }
}