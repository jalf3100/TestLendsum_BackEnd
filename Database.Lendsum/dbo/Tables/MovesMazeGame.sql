CREATE TABLE [dbo].[MovesMazeGame] (
    [IdMovesMazeGame]  INT IDENTITY (1, 1) NOT NULL,
    [IdMazeGame]       INT NULL,
    [CurrentPositionX] INT NULL,
    [CurrentPositionY] INT NULL,
    [NorthBlocked]     BIT NULL,
    [SouthBlocked]     BIT NULL,
    [WestBlocked]      BIT NULL,
    [EastBlocked]      BIT NULL,
    PRIMARY KEY CLUSTERED ([IdMovesMazeGame] ASC),
    FOREIGN KEY ([IdMazeGame]) REFERENCES [dbo].[MazeGame] ([IdMazeGame])
);



