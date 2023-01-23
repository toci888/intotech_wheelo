

create or replace view VCollocationsGeoLocations as --select hosts of collocations
select distinct a.id as idAccount, a.name, a.surname, wt.LatitudeFrom, wt.LongitudeFrom,
wt.LatitudeTo, wt.LongitudeTo, wt.FromHour, wt.ToHour, wt.searchid, wt.DriverPassenger, a.image  
from AccountsCollocations acc 
join WorkTripGen wt on acc.IdAccount = wt.IdAccount
join Accounts a on a.id = wt.IdAccount;


create or replace view VAWorkTripGenGeoLocations as --select hosts of collocations
select distinct a.id as accountId, a.name, a.surname, wt.LatitudeFrom, wt.LongitudeFrom,
wt.LatitudeTo, wt.LongitudeTo, wt.FromHour, wt.ToHour, wt.searchid, wt.DriverPassenger as IsDriver, a.image
from AccountsCollocations acc 
join WorkTripGen wt on acc.IdAccount = wt.IdAccount
join Accounts a on a.id = wt.IdAccount;

create or replace view VACollocationsGeoLocations as --select people, who belong to the group collocated
select acc.idaccount, acc.idcollocated as accountIdCollocated, a.name, a.surname, wt.LatitudeFrom, wt.LongitudeFrom,
wt.LatitudeTo, wt.LongitudeTo, wt.FromHour, wt.ToHour, wt.searchId, wt.DriverPassenger as IsDriver, a.image
from AccountsCollocations acc 
join WorkTripGen wt on acc.idcollocated = wt.IdAccount
join Accounts a on a.id = wt.IdAccount;