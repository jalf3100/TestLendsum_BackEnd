//-----------------------------------------------------------------------
// <copyright file = "LendsumContext.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace Infrestructure.Lendsum.Persistences.Contexts
{
    using Domain.Lendsum.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    /// <summary>Clase que representa el contexto de base de datos para la aplicación Lendsum.</summary>
    public partial class LendsumContext : DbContext
    {
        #region [Variables]
        /// <summary>Obtiene o establece el conjunto de entidades para laberintos en la base de datos.</summary>
        public virtual DbSet<Maze> Mazes { get; set; }

        /// <summary>Obtiene o establece el conjunto de entidades para juegos de laberinto en la base de datos.</summary>
        public virtual DbSet<MazeGame> MazeGames { get; set; }

        /// <summary>Obtiene o establece el conjunto de entidades para movimientos de juegos de laberinto en la base de datos.</summary>
        public virtual DbSet<MovesMazeGame> MovesMazeGames { get; set; }
        #endregion [Variables]

        #region [Constructor]
        /// <summary>Constructor predeterminado de la clase LendsumContext.</summary>
        public LendsumContext()
        {
        }
        /// <summary>Constructor de la clase LendsumContext que recibe opciones de configuración.</summary>
        /// <param name="options">Opciones de configuración del contexto.</param>
        public LendsumContext(DbContextOptions<LendsumContext> options) : base(options)
        {
        }
        #endregion [Constructor]

        #region [Methods]
        /// <summary>Configura el modelo de datos que se utilizará para mapear las entidades a la base de datos.</summary>
        /// <param name="modelBuilder">Constructor de modelos utilizado para configurar las entidades y relaciones.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            OnModelCreatingPartial(modelBuilder);
        }

        /// <summary>Método parcial que permite implementaciones personalizadas en archivos separados para configuraciones adicionales del modelo.</summary>
        /// <param name="modelBuilder">Constructor de modelos utilizado para configurar las entidades y relaciones.</param>
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion [Methods]
    }
}