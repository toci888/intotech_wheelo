
create or replace view VAWorkTripGenGeoLocations as --select hosts of collocations
select distinct wt.idaccount as accountId, a.name, a.surname, wt.LatitudeFrom, wt.LongitudeFrom,
wt.LatitudeTo, wt.LongitudeTo, wt.FromHour, wt.ToHour, wt.searchid, wt.DriverPassenger as IsDriver, a.image
from WorkTripGen wt 
join Accounts a on a.id = wt.IdAccount;


drop view VACollocationsGeoLocations;

create or replace view VACollocationsGeoLocations as --select people, who belong to the group collocated
select acc.idaccount, a.id as accountIdCollocated, ac1.name, ac1.surname, a.name as nameCollocated, 
a.surname as surnameCollocated, wt.LatitudeFrom, wt.LongitudeFrom,
wt.LatitudeTo, wt.LongitudeTo, wt.FromHour, wt.ToHour, wt.searchId, wt.DriverPassenger as IsDriver, a.image
from AccountsCollocations acc 
join Accounts ac1 on ac1.id = acc.idaccount 
join WorkTripGen wt on acc.idcollocated = wt.IdAccount
join Accounts a on a.id = wt.IdAccount;
