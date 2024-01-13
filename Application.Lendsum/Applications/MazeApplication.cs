//-----------------------------------------------------------------------
// <copyright file = "MazeApplication.cs" company="Lendsum">
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

    /// <summary>Clase para la entidad Maze donde se manejan los diversos procesos</summary>
    public class MazeApplication : IMazeApplication
    {
        #region [Variables]
        /// <summary>Variable global de la Interfaz para poder acceder a los métodos de UnitOfWork</summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>Variable global de la Interfaz para poder acceder a los métodos de Mapper</summary>
        private readonly IMapper _mapper;
        #endregion [Variables]

        #region [Constructor]
        /// <summary>Constructor de la clase MazeApplication</summary>
        /// <param name="unitOfWork">Interfaz para poder acceder a los métodos de UnitOfWork<</param>
        /// <param name="mapper">Interfaz para poder acceder a los métodos de Mapper</param>
        public MazeApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion [Constructor]

        #region [Methods]
        /// <summary>Registra un nuevo laberinto.</summary>
        /// <param name="requestDto">Datos del laberinto a registrar.</param>
        /// <returns>Respuesta que indica si el laberinto fue creado correctamente.</returns>
        public async Task<BaseResponse<ReplyBuildNewMazeDto>> RegisterMaze(
            BuildNewMazeDto requestDto)
        {
            BaseResponse<ReplyBuildNewMazeDto> response = new BaseResponse<ReplyBuildNewMazeDto>();
            try
            {
                Maze maze = new Maze(requestDto.Altura, requestDto.Anchura);
                bool Save = await _unitOfWork.Maze.RegisterAsync(maze);
                if (Save)
                {
                    response.Data = new ReplyBuildNewMazeDto()
                    {
                        Altura = (int)maze.Altura,
                        Anchura = (int)maze.Ancho,
                        MazeUid = (Guid)maze.Guidmaze
                    };
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.Message_Create_New_Maze;
                }
                else
                {
                    response.Message = ReplyMessage.Message_Wrong;
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
        #endregion [Methods]
    }
}