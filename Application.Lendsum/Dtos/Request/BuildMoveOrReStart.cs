//-----------------------------------------------------------------------
// <copyright file = "BuildMoveOrReStart.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Application.Lendsum.Dtos.Request
{
    using System.ComponentModel.DataAnnotations;
    using Utilities.Lendsum.Statics;

    /// <summary>Clase que representa la solicitud de movimiento o reinicio del juego.</summary>
    public class BuildMoveOrReStart : IValidatableObject
    {
        /// <summary>Obtiene o establece la operación a realizar (por ejemplo, "Start").</summary>
        public string Operation { get; set; }

        /// <summary>Valida la operación para asegurarse de que es válida.</summary>
        /// <param name="validationContext">Contexto de validación.</param>
        /// <returns>Lista de resultados de validación.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!ReplyMessage.miLista.Any(valor => string.Equals
            (Operation, valor, StringComparison.OrdinalIgnoreCase)))
                yield return new ValidationResult(string.Format(ReplyMessage.
                    Message_CreateNewGame, nameof(Operation)), new[] { nameof(Operation) });
        }
    }
}