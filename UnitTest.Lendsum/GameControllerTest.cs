//-----------------------------------------------------------------------
// <copyright file = "GameControllerTest.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
namespace UnitTest.Lendsum
{
    /// <summary>Clase de pruebas para el controlador GameController.</summary>
    public class GameControllerTest
    {
        #region [CreateMazeGame]
        /// <summary>Caso de prueba para CreateMazeGame con una solicitud válida que debe devolver un OkResult.</summary>
        [Fact]
        public async Task CreateMazeGame_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var mockMazeGameApplication = new Mock<IMazeGameApplication>();
            var controller = new GameController(mockMazeGameApplication.Object);
            var mazeUid = Guid.NewGuid();
            var requestDto = new BuildNewGameMazeDto();

            // Configure the mock behavior for CreateMazeGame
            mockMazeGameApplication.Setup(app => app.CreateMazeGame(It.IsAny<Guid>()))
                .ReturnsAsync(new BaseResponse<ReplyBuildNewGameMazeDto>
                {
                    IsSuccess = true,
                    Data = It.IsAny<ReplyBuildNewGameMazeDto>(),
                    Message = "Game created successfully"
                });

            // Act
            var result = await controller.CreateMazeGame(mazeUid, requestDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<ReplyBuildNewGameMazeDto>>(okResult.Value);
            Assert.True(model.IsSuccess);
            Assert.Equal("Game created successfully", model.Message);
        }
        /// <summary>Caso de prueba para CreateMazeGame con una solicitud no válida que debe devolver un BadRequest.</summary>
        [Fact]
        public async Task CreateMazeGame_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var mockMazeGameApplication = new Mock<IMazeGameApplication>();
            var controller = new GameController(mockMazeGameApplication.Object);
            var mazeUid = Guid.NewGuid();
            var requestDto = new BuildNewGameMazeDto();

            // Configure the mock behavior for CreateMazeGame
            mockMazeGameApplication.Setup(app => app.CreateMazeGame(It.IsAny<Guid>()))
                .ReturnsAsync(new BaseResponse<ReplyBuildNewGameMazeDto>
                {
                    IsSuccess = false,
                    Message = "Invalid request"
                });

            // Add ModelState error for invalid request
            controller.ModelState.AddModelError("Operation", "Invalid Operation");

            // Act
            var result = await controller.CreateMazeGame(mazeUid, requestDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var modelState = Assert.IsAssignableFrom<SerializableError>(badRequestResult.Value);
            Assert.True(modelState.ContainsKey("Operation"));
            Assert.Equal(new[] { "Invalid Operation" }, (string[])modelState["Operation"]);
        }
        #endregion [CreateMazeGame]

        #region [GetView]
        /// <summary>Caso de prueba para GetView con una solicitud válida que debe devolver un OkResult.</summary>
        [Fact]
        public async Task GetView_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var mockMazeGameApplication = new Mock<IMazeGameApplication>();
            var controller = new GameController(mockMazeGameApplication.Object);
            var mazeUid = Guid.NewGuid();
            var gameUid = Guid.NewGuid();

            // Configure the mock behavior for GetView
            mockMazeGameApplication.Setup(app => app.GetView(It.IsAny<Guid>(), It.IsAny<Guid>()))
                .ReturnsAsync(new BaseResponse<ReplyGetView>
                {
                    IsSuccess = true,
                    Data = It.IsAny<ReplyGetView>(),
                    Message = "View retrieved successfully"
                });

            // Act
            var result = await controller.GetView(mazeUid, gameUid);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<ReplyGetView>>(okResult.Value);
            Assert.True(model.IsSuccess);
            Assert.Equal("View retrieved successfully", model.Message);
        }
        #endregion [GetView]

        #region [MoveOrReStart]
        /// <summary>Caso de prueba para MoveOrReStart con una solicitud válida que debe devolver un OkResult.</summary>
        [Fact]
        public async Task MoveOrReStart_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var mockMazeGameApplication = new Mock<IMazeGameApplication>();
            var controller = new GameController(mockMazeGameApplication.Object);
            var mazeUid = Guid.NewGuid();
            var gameUid = Guid.NewGuid();
            var requestDto = new BuildMoveOrReStart();

            // Configure the mock behavior for MoveOrReStart
            mockMazeGameApplication.Setup(app => app.MoveOrReStart(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<BuildMoveOrReStart>()))
                .ReturnsAsync(new BaseResponse<ReplyGetView>
                {
                    IsSuccess = true,
                    Data = It.IsAny<ReplyGetView>(),
                    Message = "Move or Restart processed successfully"
                });

            // Act
            var result = await controller.MoveOrReStart(mazeUid, gameUid, requestDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<BaseResponse<ReplyGetView>>(okResult.Value);
            Assert.True(model.IsSuccess);
            Assert.Equal("Move or Restart processed successfully", model.Message);
        }
        /// <summary>Caso de prueba para MoveOrReStart con una solicitud no válida que debe devolver un BadRequest.</summary>
        [Fact]
        public async Task MoveOrReStart_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var mockMazeGameApplication = new Mock<IMazeGameApplication>();
            var controller = new GameController(mockMazeGameApplication.Object);
            var mazeUid = Guid.NewGuid();
            var gameUid = Guid.NewGuid();
            var requestDto = new BuildMoveOrReStart();

            // Configure the mock behavior for MoveOrReStart
            mockMazeGameApplication.Setup(app => app.MoveOrReStart(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<BuildMoveOrReStart>()))
                .ReturnsAsync(new BaseResponse<ReplyGetView>
                {
                    IsSuccess = false,
                    Message = "Invalid request"
                });

            // Add ModelState error for invalid request
            controller.ModelState.AddModelError("SomeField", "Invalid Field");

            // Act
            var result = await controller.MoveOrReStart(mazeUid, gameUid, requestDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var modelState = Assert.IsAssignableFrom<SerializableError>(badRequestResult.Value);
            Assert.True(modelState.ContainsKey("SomeField"));
            Assert.Equal(new[] { "Invalid Field" }, (string[])modelState["SomeField"]);
        }
        #endregion [MoveOrReStart]
    }
}