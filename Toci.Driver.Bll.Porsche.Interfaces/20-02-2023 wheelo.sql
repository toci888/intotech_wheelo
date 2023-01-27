drop view VInvitations;

create or replace view VInvitations as
select U1.Name as FirstName, U1.Surname as LastName, U2.Name as InvitedFirstName, U2.Surname as InvitedLastName, 
U1.Id as IdAccount, U2.Id as IdAccountInvited, Invitations.CreatedAt
from Invitations 
join Accounts U1 on U1.Id = Invitations.IdAccount 
join Accounts U2 on U2.Id = Invitations.IdInvited ;



create or replace view StatsProvider as
select Tr.tripdate, count (Tr.id) as countCars, 
(select count (id) from tripparticipants where idtrip in 
 (select id from trips where tripdate = Tr.tripdate)) as countPeople
from trips Tr group by Tr.tripdate;