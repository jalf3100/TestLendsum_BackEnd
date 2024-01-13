//-----------------------------------------------------------------------
// <copyright file = "IMazeGameApplication.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Lendsum.Interfaces
{
    using Application.Lendsum.Commons.Bases;
    using Application.Lendsum.Dtos.Request;
    using Application.Lendsum.Dtos.Response;

    /// <summary>Interfaz para la clase MazeGameApplication</summary>
    public interface IMazeGameApplication
    {
        #region [Methods]
        Task<BaseResponse<ReplyBuildNewGameMazeDto>> CreateMazeGame(Guid mazeUid);
        Task<BaseResponse<ReplyGetView>> GetView(Guid mazeUid, Guid gameUid);
        Task<BaseResponse<ReplyGetView>> MoveOrReStart(Guid mazeUid, Guid gameUid,
            BuildMoveOrReStart requestDto);
        #endregion [Methods]
    }
}