//-----------------------------------------------------------------------
// <copyright file = "MazeGameConfiguration.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrastructure.Lendsum.Persistences.Contexts.Configurations
{
    using Domain.Lendsum.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>Clase de Mapeo para la entidad MazeGame y sus respectivos campos</summary>
    public class MazeGameConfiguration : IEntityTypeConfiguration<MazeGame>
    {
        #region [Methods]
        /// <summary>Método de configuración para la entidad MazeGame y sus respectivos campos</summary>
        /// <param name="builder">Objeto para construir la Entidad MazeGame</param>
        public void Configure(EntityTypeBuilder<MazeGame> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasKey(e => e.Id).HasName("PK__MazeGame__24DA9E5DFC10F466");

            builder.ToTable("MazeGame", "dbo");

            builder.Property(e => e.Id).HasColumnName("IdMazeGame");

            builder.Property(e => e.GuidmazeGame).HasColumnName("GUIDMazeGame");

            builder.HasOne(d => d.IdMazeNavigation).WithMany(p => p.MazeGames)
                .HasForeignKey(d => d.IdMaze)
                .HasConstraintName("FK__MazeGame__IdMaze__4F7CD00D");
        }
        #endregion [Methods]
    }
}