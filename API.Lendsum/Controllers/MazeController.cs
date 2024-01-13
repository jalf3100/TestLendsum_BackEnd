//-----------------------------------------------------------------------
// <copyright file = "MazeController.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace API.Lendsum.Controllers
{
    using Application.Lendsum.Commons.Bases;
    using Application.Lendsum.Dtos.Request;
    using Application.Lendsum.Dtos.Response;
    using Application.Lendsum.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>Controlador para la gestión de laberintos.</summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MazeController : ControllerBase
    {
        #region [Variables]
        /// <summary>Variable global de la interfaz para acceder a los métodos de IMazeApplication.</summary>
        private readonly IMazeApplication _MazeApplication;
        #endregion [Variables]

        #region [Constructor]
        /// <summary>Constructor de la clase MazeController.</summary>
        /// <param name="mazeApplication">Instancia de la interfaz IMazeApplication.</param>
        public MazeController(IMazeApplication mazeApplication)
        {
            _MazeApplication = mazeApplication;
        }
        #endregion [Constructor]

        #region [Methods]
        /// <summary>Endpoint para la creación de un nuevo laberinto.</summary>
        /// <param name="mazeDto">DTO con los detalles del nuevo laberinto.</param>
        /// <returns>ActionResult que indica el resultado de la operación.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateMaze([FromBody] BuildNewMazeDto mazeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            BaseResponse<ReplyBuildNewMazeDto> response =
                await _MazeApplication.RegisterMaze(mazeDto);
            return Ok(response);
        }
        #endregion [Methods]
    }
}