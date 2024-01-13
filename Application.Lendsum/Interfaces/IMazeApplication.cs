//-----------------------------------------------------------------------
// <copyright file = "IMazeApplication.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Lendsum.Interfaces
{
    using Application.Lendsum.Commons.Bases;
    using Application.Lendsum.Dtos.Request;
    using Application.Lendsum.Dtos.Response;

    /// <summary>Interfaz para la clase MazeApplication</summary>
    public interface IMazeApplication
    {
        #region [Methods]
        Task<BaseResponse<ReplyBuildNewMazeDto>> RegisterMaze(BuildNewMazeDto requestDto);
        #endregion [Methods]
    }
}