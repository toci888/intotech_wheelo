create or replace view VCollocationsGeoLocations as --select hosts of collocations
select distinct a.id as accountId, a.name, a.surname, wt.LatitudeFrom, wt.LongitudeFrom,
wt.LatitudeTo, wt.LongitudeTo, wt.FromHour, wt.ToHour, wt.searchid
from AccountsCollocations acc 
join WorkTripGen wt on acc.IdAccount = wt.IdAccount
join Accounts a on a.id = wt.IdAccount;

