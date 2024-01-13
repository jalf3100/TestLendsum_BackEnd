//-----------------------------------------------------------------------
// <copyright file = "MazeConfiguration.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrastructure.Lendsum.Persistences.Contexts.Configurations
{
    using Domain.Lendsum.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>Clase de Mapeo para la entidad Maze y sus respectivos campos</summary>
    public class MazeConfiguration : IEntityTypeConfiguration<Maze>
    {
        #region [Methods]
        /// <summary>Método de configuración para la entidad Maze y sus respectivos campos</summary>
        /// <param name="builder">Objeto para construir la Entidad Maze</param>
        public void Configure(EntityTypeBuilder<Maze> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasKey(e => e.Id).HasName("PK__Maze__4E6565429235EDCD");

            builder.ToTable("Maze", "dbo");

            builder.Property(e => e.Id).HasColumnName("IdMaze");

            builder.Property(e => e.Guidmaze).HasColumnName("GUIDMaze");
        }
        #endregion [Methods]
    }
}