create procedure sp_willCallPlayers

@paramId int null

as

begin

select p.Id

from Session s 

join Basket b 
on b.SessionID = s.Id

join BasketPlayers bp
on bp.BasketID = b.ID

join Player p
on bp.PlayerId = p.id

where s.Id = @paramId

end