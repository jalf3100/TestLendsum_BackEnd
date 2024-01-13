//-----------------------------------------------------------------------
// <copyright file = "MazeGameApplication.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Lendsum.Applications
{
    using Application.Lendsum.Commons.Bases;
    using Application.Lendsum.Dtos.Request;
    using Application.Lendsum.Dtos.Response;
    using Application.Lendsum.Interfaces;
    using AutoMapper;
    using Domain.Lendsum.Entities;
    using Infrestructure.Lendsum.Persistences.Interfaces;
    using Utilities.Lendsum.Statics;

    /// <summary>Clase para la entidad MazeGame donde se manejan los diversos procesos</summary>
    public class MazeGameApplication : IMazeGameApplication
    {
        #region [Variables]
        /// <summary>Variable global de la Interfaz para poder acceder a los métodos de UnitOfWork</summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>Variable global de la Interfaz para poder acceder a los métodos de Mapper</summary>
        private readonly IMapper _mapper;
        #endregion [Variables]

        #region [Constructor]
        /// <summary>Constructor de la clase MazeGameApplication</summary>
        /// <param name="unitOfWork">Interfaz para poder acceder a los métodos de UnitOfWork<</param>
        /// <param name="mapper">Interfaz para poder acceder a los métodos de Mapper</param>
        public MazeGameApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion [Constructor]

        #region [Methods]
        /// /// <summary>Crea un nuevo juego de laberinto.</summary>
        /// <param name="mazeUid">Identificador único del laberinto.</param>
        /// <returns>Respuesta que indica si el juego fue creado correctamente.</returns>
        public async Task<BaseResponse<ReplyBuildNewGameMazeDto>> CreateMazeGame(Guid mazeUid)
        {
            BaseResponse<ReplyBuildNewGameMazeDto> response =
                new BaseResponse<ReplyBuildNewGameMazeDto>();
            try
            {
                Maze maze = _unitOfWork.Maze.GetEntityQuery(x => x.Guidmaze.Equals(mazeUid)).FirstOrDefault();
                if (!(maze is null))
                {
                    MazeGame mazeGame = _unitOfWork.MazeGame.GetEntityQuery(
                        x => x.IdMaze.Equals(maze.Id) && x.Activo == true).FirstOrDefault();
                    if (mazeGame is null)
                    {
                        MazeGame _NewMazeGame = new MazeGame(maze.Id);
                        bool Save = await _unitOfWork.MazeGame.RegisterAsync(_NewMazeGame);
                        if (Save)
                        {
                            MovesMazeGame _movesMazeGame = new MovesMazeGame(_NewMazeGame.Id);
                            await _unitOfWork.MovesMazeGame.RegisterAsync(_movesMazeGame);
                            response.Data = Build_ReplyBuildNewGameMazeDto(maze, _NewMazeGame,
                                _movesMazeGame);
                            response.Message = ReplyMessage.Message_Create_New_GameMaze;
                            response.IsSuccess = true;
                        }
                        else
                        {
                            response.Message = ReplyMessage.Message_Wrong;
                            response.IsSuccess = false;
                        }
                    }
                    else
                    {
                        MovesMazeGame movesMazeGame = await GetLastMove(mazeGame.Id);
                        response.Data = Build_ReplyBuildNewGameMazeDto(maze, mazeGame,
                            movesMazeGame);
                        response.Message = ReplyMessage.Message_GameMaze_HasOne;
                        response.IsSuccess = false;
                    }
                }
                else
                {
                    response.Message = ReplyMessage.Message_Not_Exist_Maze;
                    response.IsSuccess = false;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message + " " + ReplyMessage.Message_Wrong;
                return response;
            }
        }
        /// <summary>Obtiene la vista del juego para un laberinto y su juego.</summary>
        /// <param name="mazeUid">Identificador único del laberinto.</param>
        /// <param name="gameUid">Identificador único del juego.</param>
        /// <returns>Respuesta que contiene la vista del juego.</returns>
        public async Task<BaseResponse<ReplyGetView>> GetView(Guid mazeUid, Guid gameUid)
        {
            BaseResponse<ReplyGetView> response = new BaseResponse<ReplyGetView>();
            Maze maze = _unitOfWork.Maze.GetEntityQuery(x => x.Guidmaze.Equals(mazeUid)).FirstOrDefault();
            if (!(maze is null))
            {
                MazeGame mazeGame = _unitOfWork.MazeGame.GetEntityQuery(
                        x => x.IdMaze.Equals(maze.Id) && x.Activo == true).FirstOrDefault();
                if (!(mazeGame is null))
                {
                    MovesMazeGame movesMazeGame = await GetLastMove(mazeGame.Id);
                    ReplyGetView replyGetView = new ReplyGetView();
                    replyGetView.Juego = Build_ReplyBuildNewGameMazeDto(maze, mazeGame,
                            movesMazeGame);
                    replyGetView.MazeBlockView = Build_ReplyMazeBlockView(movesMazeGame);
                    response.Data=replyGetView;
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.Message_GameMaze_HasOne;
                }
                else
                {
                    response.Message = ReplyMessage.Message_Not_Exist_MazeGame;
                    response.IsSuccess = false;
                }
            }
            else
            {
                response.Message = ReplyMessage.Message_Not_Exist_Maze;
                response.IsSuccess = false;
            }
            return response;
        }
        /// <summary>Realiza un movimiento o reinicia el juego según la operación proporcionada.</summary>
        /// <param name="mazeUid">Identificador único del laberinto.</param>
        /// <param name="gameUid">Identificador único del juego.</param>
        /// <param name="requestDto">Datos de la operación a realizar.</param>
        /// <returns>Respuesta que indica el resultado de la operación.</returns>
        public async Task<BaseResponse<ReplyGetView>> MoveOrReStart(Guid mazeUid, Guid gameUid,
            BuildMoveOrReStart requestDto)
        {
            if (string.Equals(requestDto.Operation, ReplyMessage.ExpectedValueStarOrRestart,
                StringComparison.OrdinalIgnoreCase))
                return await ReStart(mazeUid, gameUid);
            else
                return await Move(mazeUid, gameUid, requestDto);
        }

        #region [Privates]
        /// <summary>Construye un objeto ReplyBuildNewGameMazeDto a partir de instancias de Maze, MazeGame y MovesMazeGame.</summary>
        /// <param name="maze">Instancia del laberinto.</param>
        /// <param name="mazeGame">Instancia del juego de laberinto.</param>
        /// <param name="movesMazeGame">Instancia del movimiento de juego de laberinto.</param>
        /// <returns>Objeto ReplyBuildNewGameMazeDto construido.</returns>
        private ReplyBuildNewGameMazeDto Build_ReplyBuildNewGameMazeDto(Maze maze, MazeGame mazeGame,
            MovesMazeGame movesMazeGame)
        {
            return new ReplyBuildNewGameMazeDto()
            {
                Completed = (bool)mazeGame.Complete,
                CurrentPositionX = (int)movesMazeGame.CurrentPositionX,
                CurrentPositionY = (int)movesMazeGame.CurrentPositionY,
                GameUid = (Guid)mazeGame.GuidmazeGame,
                MazeUid = (Guid)maze.Guidmaze
            };
        }
        /// <summary>Obtiene el último movimiento registrado para un juego de laberinto.</summary>
        /// <param name="MazeGameId">Identificador único del juego de laberinto.</param>
        /// <returns>Instancia de MovesMazeGame correspondiente al último movimiento.</returns>
        private async Task<MovesMazeGame> GetLastMove(int MazeGameId)
        {
            int IdMaxmovesMazeGame = _unitOfWork.MovesMazeGame.GetEntityQuery(
                        x => x.IdMazeGame.Equals(MazeGameId)).Max(x => x.Id);
            return await _unitOfWork.MovesMazeGame.GetByIdAsync(IdMaxmovesMazeGame);
        }
        /// <summary>Construye un objeto ReplyMazeBlockView a partir de un movimiento de juego de laberinto.</summary>
        /// <param name="movesMazeGame">Instancia del movimiento de juego de laberinto.</param>
        /// <returns>Objeto ReplyMazeBlockView construido.</returns>
        private ReplyMazeBlockView Build_ReplyMazeBlockView(MovesMazeGame movesMazeGame)
        {
            return new ReplyMazeBlockView()
            {
                CoordX = (int)movesMazeGame.CurrentPositionX,
                CoordY = (int)movesMazeGame.CurrentPositionY,
                EastBlocked = (bool)movesMazeGame.EastBlocked,
                NorthBlocked = (bool)movesMazeGame.NorthBlocked,
                SouthBlocked = (bool)movesMazeGame.SouthBlocked,
                WestBlocked = (bool)movesMazeGame.WestBlocked
            };
        }
        /// <summary>Reinicia el juego de laberinto, restableciendo su estado y posición.</summary>
        /// <param name="mazeUid">Identificador único del laberinto.</param>
        /// <param name="gameUid">Identificador único del juego.</param>
        /// <returns>Respuesta que contiene la vista reiniciada del juego.</returns>
        private async Task<BaseResponse<ReplyGetView>> ReStart(Guid mazeUid, Guid gameUid)
        {
            BaseResponse<ReplyGetView> response = new BaseResponse<ReplyGetView>();
            Maze maze = _unitOfWork.Maze.GetEntityQuery(x => x.Guidmaze.Equals(mazeUid)).
                FirstOrDefault();
            MazeGame mazeGame = _unitOfWork.MazeGame.GetEntityQuery(
                        x => x.IdMaze.Equals(maze.Id) && x.Activo == true).FirstOrDefault();
            MovesMazeGame movesMazeGame = await GetLastMove(mazeGame.Id);
            mazeGame.Complete = false;
            movesMazeGame.CurrentPositionX = 0;
            movesMazeGame.CurrentPositionY = 0;
            movesMazeGame.NorthBlocked = false;
            movesMazeGame.SouthBlocked = true;
            movesMazeGame.WestBlocked = true;
            movesMazeGame.EastBlocked = false;
            await _unitOfWork.MovesMazeGame.EditAsync(movesMazeGame);
            await _unitOfWork.MazeGame.EditAsync(mazeGame);
            response.IsSuccess = true;
            response.Message = ReplyMessage.MessageReStart;
            ReplyGetView replyGetView = new ReplyGetView();
            replyGetView.Juego = Build_ReplyBuildNewGameMazeDto(maze, mazeGame, movesMazeGame);
            response.Data = replyGetView;
            return response;
        }
        /// <summary>Realiza un movimiento en el juego de laberinto o reinicia según la operación proporcionada.</summary>
        /// <param name="mazeUid">Identificador único del laberinto.</param>
        /// <param name="gameUid">Identificador único del juego.</param>
        /// <param name="requestDto">Datos de la operación a realizar.</param>
        /// <returns>Respuesta que indica el resultado de la operación.</returns>
        private async Task<BaseResponse<ReplyGetView>> Move(Guid mazeUid, Guid gameUid,
            BuildMoveOrReStart requestDto)
        {
            BaseResponse<ReplyGetView> response = await GetView(mazeUid, gameUid);
            if (!response.IsSuccess)
                return response;
            Maze maze = _unitOfWork.Maze.GetEntityQuery(x => x.Guidmaze.Equals(mazeUid)).FirstOrDefault();
            MazeGame mazeGame = _unitOfWork.MazeGame.GetEntityQuery(
                        x => x.IdMaze.Equals(maze.Id) && x.Activo == true).FirstOrDefault();
            MovesMazeGame movesMazeGame = await GetLastMove(mazeGame.Id);
            if((maze.Altura.Equals(movesMazeGame.CurrentPositionY) &&
                maze.Ancho.Equals(movesMazeGame.CurrentPositionX)) || ((bool)mazeGame.Complete))
            {
                response.Message = ReplyMessage.GameOver;
                return response;
            }
            if(movesMazeGame.CurrentPositionY.Equals(0) &&
                string.Equals(requestDto.Operation, ReplyMessage.GoSouth,
                StringComparison.OrdinalIgnoreCase))
            {
                response.Message = ReplyMessage.Error;
                return response;
            }
            if(maze.Altura.Equals(movesMazeGame.CurrentPositionY) &&
                string.Equals(requestDto.Operation, ReplyMessage.GoNorth,
                StringComparison.OrdinalIgnoreCase))
            {
                response.Message = ReplyMessage.Error;
                return response;
            }
            if (movesMazeGame.CurrentPositionX.Equals(0) &&
                string.Equals(requestDto.Operation, ReplyMessage.GoWest,
                StringComparison.OrdinalIgnoreCase))
            {
                response.Message = ReplyMessage.Error;
                return response;
            }
            if (maze.Ancho.Equals(movesMazeGame.CurrentPositionX) &&
                string.Equals(requestDto.Operation, ReplyMessage.GoEast,
                StringComparison.OrdinalIgnoreCase))
            {
                response.Message = ReplyMessage.Error;
                return response;
            }
            switch (requestDto.Operation.ToLower())
            {
                case ReplyMessage.GoNorth:
                    movesMazeGame.CurrentPositionY = movesMazeGame.CurrentPositionY + 1;
                    break;
                case ReplyMessage.GoEast:
                    movesMazeGame.CurrentPositionX = movesMazeGame.CurrentPositionX + 1;
                    break;
                case ReplyMessage.GoSouth:
                    movesMazeGame.CurrentPositionY = movesMazeGame.CurrentPositionY - 1;
                    break;
                case ReplyMessage.GoWest:
                    movesMazeGame.CurrentPositionX = movesMazeGame.CurrentPositionX - 1;
                    break;
                default:
                    break;
            }
            if(movesMazeGame.CurrentPositionY.Equals(0))
            {
                movesMazeGame.SouthBlocked = true;
                movesMazeGame.NorthBlocked = false;
            }
            else if(movesMazeGame.CurrentPositionY.Equals(maze.Altura))
            {
                movesMazeGame.SouthBlocked = false;
                movesMazeGame.NorthBlocked = true;
            }
            else
            {
                movesMazeGame.SouthBlocked = false;
                movesMazeGame.NorthBlocked = false;
            }
            if (movesMazeGame.CurrentPositionX.Equals(0))
            {
                movesMazeGame.WestBlocked = true;
                movesMazeGame.EastBlocked = false;
            }
            else if (movesMazeGame.CurrentPositionY.Equals(maze.Altura))
            {
                movesMazeGame.WestBlocked = false;
                movesMazeGame.EastBlocked = true;
            }
            else
            {
                movesMazeGame.WestBlocked = false;
                movesMazeGame.EastBlocked = false;
            }
            if (maze.Altura.Equals(movesMazeGame.CurrentPositionY) &&
                maze.Ancho.Equals(movesMazeGame.CurrentPositionX))
                mazeGame.Complete = true;

            await _unitOfWork.MovesMazeGame.EditAsync(movesMazeGame);
            await _unitOfWork.MazeGame.EditAsync(mazeGame);

            ReplyGetView replyGetView = new ReplyGetView();
            replyGetView.Juego = Build_ReplyBuildNewGameMazeDto(maze, mazeGame,
                    movesMazeGame);
            replyGetView.MazeBlockView = Build_ReplyMazeBlockView(movesMazeGame);
            response.Data = replyGetView;
            response.Message = string.Format(ReplyMessage.MessageMoveOk, requestDto.Operation);
            return response;
        }
        #endregion [Privates]

        #endregion [Methods]
    }
}