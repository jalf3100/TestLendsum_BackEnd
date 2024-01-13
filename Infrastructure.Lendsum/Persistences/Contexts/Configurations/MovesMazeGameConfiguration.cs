//-----------------------------------------------------------------------
// <copyright file = "MovesMazeGameConfiguration.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrastructure.Lendsum.Persistences.Contexts.Configurations
{
    using Domain.Lendsum.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>Clase de Mapeo para la entidad MovesMazeGame y sus respectivos campos</summary>
    public class MovesMazeGameConfiguration : IEntityTypeConfiguration<MovesMazeGame>
    {
        #region [Methods]
        /// <summary>Método de configuración para la entidad MovesMazeGame y sus respectivos campos</summary>
        /// <param name="builder">Objeto para construir la Entidad MovesMazeGame</param>
        public void Configure(EntityTypeBuilder<MovesMazeGame> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasKey(e => e.Id).HasName("PK__MovesMaz__2CAF3CC25466DAE8");

            builder.ToTable("MovesMazeGame", "dbo");

            builder.Property(e => e.Id).HasColumnName("IdMovesMazeGame");

            builder.ToTable("MovesMazeGame");

            builder.HasOne(d => d.IdMazeGameNavigation).WithMany(p => p.MovesMazeGames)
                .HasForeignKey(d => d.IdMazeGame)
                .HasConstraintName("FK__MovesMaze__IdMaz__52593CB8");
        }
        #endregion [Methods]
    }
}