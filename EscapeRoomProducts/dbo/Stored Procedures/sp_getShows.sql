create procedure sp_getShows
@gamename nvarchar(250)

as


 SELECT * from Game

where @gamename = Title