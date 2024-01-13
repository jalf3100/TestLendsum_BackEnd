//-----------------------------------------------------------------------
// <copyright file = "BaseResponse.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Lendsum.Commons.Bases
{
    using FluentValidation.Results;

    /// <summary>Entidad Base usada para responder los llamados de los controladores</summary>
    /// <typeparam name="T">Entidad generica para devolver la información</typeparam>
    public class BaseResponse<T>
    {
        /// <summary>Exitoso o no exitoso</summary>
        public bool IsSuccess { get; set; }
        /// <summary>Entidad generica para devolver la información</summary>
        public T? Data { get; set; }
        /// <summary>Mensaje de éxito o no éxito</summary>
        public string? Message { get; set; }
        /// <summary>Conglomerado de errores</summary>
        public IEnumerable<ValidationFailure>? Errors { get; set; }
    }
}