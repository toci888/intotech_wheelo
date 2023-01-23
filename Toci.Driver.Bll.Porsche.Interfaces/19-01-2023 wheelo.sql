drop view VFriends ;

create or replace view VFriends as
select U1.Name, U1.Surname, U2.Name as FriendName, U2.Surname as FriendSurname, U1.Id as idAccount, 
U2.Id as FriendIdAccount, fr1.method, wt.LatitudeFrom, wt.LongitudeFrom,
wt.LatitudeTo, wt.LongitudeTo, wt.FromHour, wt.ToHour, wt.searchid, wt.DriverPassenger 
from Friends fr1
join Accounts U1 on U1.Id = fr1.IdAccount 
join Accounts U2 on U2.Id = fr1.IdFriend 
left join WorkTripGen wt on fr1.idAccount = wt.IdAccount;