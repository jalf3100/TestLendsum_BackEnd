//-----------------------------------------------------------------------
// <copyright file = "MazeControllerTest.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace UnitTest.Lendsum
{
    /// <summary>Clase de pruebas para el controlador MazeController.</summary>
    public class MazeControllerTest
    {
        /// <summary>Caso de prueba para CreateMaze con un DTO válido que debe devolver un OkResult.</summary>
        [Fact]
        public async Task CreateMaze_ValidDto_ReturnsOkResult()
        {
            // Arrange
            Mock<IMazeApplication> mockTasksApplication = new Mock<IMazeApplication>();
            mockTasksApplication.Setup(app => app.RegisterMaze(It.IsAny<BuildNewMazeDto>()))
                .ReturnsAsync(new BaseResponse<ReplyBuildNewMazeDto>
                {
                    IsSuccess = true,
                    Data = It.IsAny<ReplyBuildNewMazeDto>(),
                    Message = ReplyMessage.Message_Create_New_Maze
                });
            MazeController controller = new MazeController(mockTasksApplication.Object);

            // Act
            var result = await controller.CreateMaze(new BuildNewMazeDto());

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<ReplyBuildNewMazeDto>>(okResult.Value);
            Assert.True(model.IsSuccess);
            Assert.Equal(ReplyMessage.Message_Create_New_Maze, model.Message);
        }
        /// <summary>Caso de prueba para CreateMaze con un DTO no válido que debe devolver un BadRequest.</summary>
        [Fact]
        public async Task CreateMaze_InvalidDto_ReturnsBadRequest()
        {
            // Arrange
            Mock<IMazeApplication> mockMazeApplication = new Mock<IMazeApplication>();
            MazeController controller = new MazeController(mockMazeApplication.Object);

            controller.ModelState.AddModelError("Anchura", "El campo Anchura es requerido.");

            // Act
            var result = await controller.CreateMaze(new BuildNewMazeDto());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}