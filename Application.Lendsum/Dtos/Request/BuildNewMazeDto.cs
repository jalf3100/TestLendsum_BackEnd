//-----------------------------------------------------------------------
// <copyright file = "BuildNewMazeDto.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Lendsum.Dtos.Request
{
    using System.ComponentModel.DataAnnotations;
    using Utilities.Lendsum.Statics;

    /// <summary>Clase que representa la solicitud para construir un nuevo laberinto.</summary>
    public class BuildNewMazeDto : IValidatableObject
    {
        /// <summary>Obtiene o establece el ancho del laberinto.</summary>
        public int Anchura { get; set; }
        /// <summary>Obtiene o establece la altura del laberinto.</summary>
        public int Altura { get; set; }

        /// <summary>Valida las dimensiones del laberinto para asegurarse de que son válidas.</summary>
        /// <param name="validationContext">Contexto de validación.</param>
        /// <returns>Lista de resultados de validación.</returns>

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult>? results = new List<ValidationResult>();
            if (Anchura < 5 || Anchura > 150)
                results.Add(new ValidationResult(string.Format(
                    ReplyMessage.Message_Validate_Dimension, nameof(Anchura)),
                    new[] { nameof(Anchura) }));
            if (Altura < 5 || Altura > 150)
                results.Add(new ValidationResult(string.Format(
                    ReplyMessage.Message_Validate_Dimension, nameof(Altura)),
                    new[] { nameof(Altura) }));
            return results;
        }
    }
}