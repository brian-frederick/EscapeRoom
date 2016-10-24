create procedure sp_basketPlayers 

@basketid int null 

as
begin

Select playerId from BasketPlayers where BasketID = @basketid

end