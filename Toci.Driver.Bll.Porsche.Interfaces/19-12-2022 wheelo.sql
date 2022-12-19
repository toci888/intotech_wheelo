
create or replace view VACollocationsGeoLocations as --select people, who belong to the group collocated
select acc.idaccount, a.id as accountIdCollocated, a.name, a.surname, wt.LatitudeFrom, wt.LongitudeFrom,
wt.LatitudeTo, wt.LongitudeTo, wt.FromHour, wt.ToHour, wt.searchId, wt.DriverPassenger as IsDriver, a.image
from AccountsCollocations acc 
join WorkTripGen wt on acc.idcollocated = wt.IdAccount
join Accounts a on a.id = wt.IdAccount;