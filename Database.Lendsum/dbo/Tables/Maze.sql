CREATE TABLE [dbo].[Maze] (
    [IdMaze]   INT              IDENTITY (1, 1) NOT NULL,
    [GUIDMaze] UNIQUEIDENTIFIER NULL,
    [Ancho]    INT              NULL,
    [Altura]   INT              NULL,
    PRIMARY KEY CLUSTERED ([IdMaze] ASC),
    CHECK ([Altura]>=(5) AND [Altura]<=(150)),
    CHECK ([Ancho]>=(5) AND [Ancho]<=(150))
);



