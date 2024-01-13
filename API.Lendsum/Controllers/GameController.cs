//-----------------------------------------------------------------------
// <copyright file = "GameController.cs" company="Lendsum">
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

    /// <summary>Controlador para la gestión de juegos.</summary>
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        #region [Variables]
        /// <summary>Variable global de la Interfaz para poder acceder a los métodos de IMazeGameApplication</summary>
        private readonly IMazeGameApplication _MazeGameApplication;
        #endregion [Variables]

        #region [Constructor]
        /// <summary>Constructor de la clase GameController.</summary>
        /// <param name="mazeGameApplication">Instancia de la interfaz IMazeGameApplication.</param>
        public GameController(IMazeGameApplication mazeGameApplication)
        {
            _MazeGameApplication = mazeGameApplication;
        }
        #endregion [Constructor]

        #region [Methods]
        /// <summary>Endpoint para la creación de un nuevo juego en un laberinto.</summary>
        /// <param name="mazeUid">Identificador único del laberinto.</param>
        /// <param name="requestDto">DTO con detalles para la creación del juego.</param>
        /// <returns>ActionResult que indica el resultado de la operación.</returns>
        [HttpPost("{mazeUid}")]
        public async Task<IActionResult> CreateMazeGame(Guid mazeUid,
            [FromBody] BuildNewGameMazeDto requestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            BaseResponse<ReplyBuildNewGameMazeDto> response =
                await _MazeGameApplication.CreateMazeGame(mazeUid);
            return Ok(response);
        }
        /// <summary>Endpoint para obtener la vista actual de un juego en un laberinto.</summary>
        /// <param name="mazeUid">Identificador único del laberinto.</param>
        /// <param name="gameUid">Identificador único del juego.</param>
        /// <returns>ActionResult que indica el resultado de la operación.</returns>
        [HttpGet("{mazeUid}/{gameUid}")]
        public async Task<IActionResult> GetView(Guid mazeUid, Guid gameUid)
        {
            BaseResponse<ReplyGetView> response = await _MazeGameApplication.GetView(mazeUid,
                gameUid);
            return Ok(response);
        }
        /// <summary>Endpoint para realizar un movimiento o reiniciar un juego en un laberinto.</summary>
        /// <param name="mazeUid">Identificador único del laberinto.</param>
        /// <param name="gameUid">Identificador único del juego.</param>
        /// <param name="requestDto">DTO con detalles para el movimiento o reinicio del juego.</param>
        /// <returns>ActionResult que indica el resultado de la operación.</returns>
        [HttpPost("{mazeUid}/{gameUid}")]
        public async Task<IActionResult> MoveOrReStart(Guid mazeUid, Guid gameUid,
            [FromBody] BuildMoveOrReStart requestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            BaseResponse<ReplyGetView> response = await _MazeGameApplication.MoveOrReStart(mazeUid,
                gameUid, requestDto);
            return Ok(response);
        }
        #endregion [Methods]
    }
}