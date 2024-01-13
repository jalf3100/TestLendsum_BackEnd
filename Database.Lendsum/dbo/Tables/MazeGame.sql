CREATE TABLE [dbo].[MazeGame] (
    [IdMazeGame]   INT              IDENTITY (1, 1) NOT NULL,
    [IdMaze]       INT              NULL,
    [GUIDMazeGame] UNIQUEIDENTIFIER NULL,
    [Complete]     BIT              NULL,
    [Activo]       BIT              NULL,
    PRIMARY KEY CLUSTERED ([IdMazeGame] ASC),
    FOREIGN KEY ([IdMaze]) REFERENCES [dbo].[Maze] ([IdMaze])
);



