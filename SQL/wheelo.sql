drop table AccountModes;

drop view VAWorkTripGenGeoLocations;
drop view VWorkTripGenGeoLocations;

drop table WorkTripGen;
drop table NotUser;
----
drop table AccountMetadata;
drop table Occupations;
drop table StatisticsTrips;
drop view VTripsParticipants;
drop table TripParticipants;
drop table Trips;
drop view AccountRoles;
drop view VFriends;
drop view VInvitations;
drop view VAccountsCollocations;
drop view VFriendSuggestions;
--select * from  WorkTrip;
--select * from  Accounts;
--select * from AccountsCollocations;
drop view AccountsCarsLocations;
drop view VCollocationsGeoLocations;
drop view VACollocationsGeoLocations;
drop view VAccountsCollocationsWorkTrip;
drop table WorkTrip;
drop view VCarOwner;
drop table Cars;
drop table Colours;
drop table CarsModels;
drop table CarsBrands;
drop table AccountsCollocations;
drop table AccountsWorkTime;
drop table FriendSuggestions;
drop table Friends;
drop table Invitations cascade;
drop table AccountsLocations cascade;
drop table UserExtraData;
drop table Accounts cascade;
drop table Roles cascade;
--drop table Occupations;
drop table GeographicRegion;

drop table EmailsRegister;
--select * from Accounts;
--select * from Cars;

create table EmailsRegister
(
	Id serial primary key,
	email text not null,
	verificationCode int,
	isVerified bool default false
);



create table GeographicRegion
(
	Id serial primary key,
	IdParent int references GeographicRegion(Id),
	IdShit int,
	Name text
);

alter table GeographicRegion add column nestLevel int;


create table Roles
(
	id serial primary key,
	name text
);

create table Accounts
(
	Id serial primary key not null,
	email text not null,
	name text,
	surname text,
	password text,
	verificationCode int,
	IdRole int references roles(id) default 1,
	emailconfirmed bool default false,
	image text,
	phoneNumber text,
	refreshToken text,
	refreshTokenValid timestamp
);

select setval('accounts_id_seq', 1000000000);

create table UserExtraData -- for fb, google, apple
(
	id serial primary key,
	idAccount int references Accounts(id),
	token text,
	method text,
	tokenDataJson text,
	createdat timestamp default now()
);

-- 50.05463180727613, 17.80014622135593
create table AccountsLocations -- deprecated ? 
(
	Id serial primary key,
	IdAccounts int references Accounts(Id) not null,
	LatitudeFrom decimal,
	LongitudeFrom decimal,
	LatitudeTo decimal,
	LongitudeTo decimal,
	StreetFrom text,
	StreetTo text,
	CityFrom text,
	CityTo text,
	CreatedAt timestamp default now()
);

create table AccountsWorkTime
(
	Id serial primary key,
	IdAccounts int references Accounts(Id) not null,
	WorkStartHour time,
	WorkEndHour time
);

create table FriendSuggestions
(
	Id serial primary key,
	IdAccount int references Accounts(Id) not null,
	IdSuggested int references Accounts(Id) not null,
	IdSuggestedFriend int references Accounts(Id) not null,
	CreatedAt timestamp default now()
);

create or replace view VFriendSuggestions as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, U1.Id as AccountId, 
U2.Id as SuggestedAccountId, U3.Name as SuggestedFriendName, U3.Surname as SuggestedFriendSurname, U3.Id as SuggestedFriendId
from FriendSuggestions 
join Accounts U1 on U1.Id = FriendSuggestions.IdAccount 
join Accounts U2 on U2.Id = FriendSuggestions.IdSuggested
join Accounts U3 on U3.Id = FriendSuggestions.IdSuggestedFriend ;

--select * from VFriendSuggestions where accountid = 2;

create table Invitations
(
	Id serial primary key,
	IdAccount int references Accounts(Id) not null,
	IdInvited int references Accounts(Id) not null,
	origin int,
	CreatedAt timestamp default now()
);

--select * from VInvitations;

create or replace view VInvitations as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, 
U1.Id as AccountId, U2.Id as SuggestedAccountId, Invitations.CreatedAt
from Invitations 
join Accounts U1 on U1.Id = Invitations.IdAccount 
join Accounts U2 on U2.Id = Invitations.IdInvited ;

--friends
create table Friends
(
	Id serial primary key,
	IdAccount int references Accounts(Id) not null,
	IdFriend int references Accounts(Id) not null,
	method int,
	CreatedAt timestamp default now()
);


create or replace view VFriends as
select U1.Name, U1.Surname, U2.Name as FriendName, U2.Surname as FriendSurname, U1.Id as AccountId, 
U2.Id as FriendAccountId, Friends.method 
from Friends 
join Accounts U1 on U1.Id = Friends.IdAccount 
join Accounts U2 on U2.Id = Friends.IdFriend ;

--select * from VFriends;

--select * from AccountsCollocations;

create table AccountsCollocations
(
	Id serial primary key,
	IdAccount int references Accounts(Id) not null,
	IdCollocated int references Accounts(Id) not null,
	DistanceFrom numeric,
	DistanceTo numeric,
	CreatedAt timestamp default now()
);

--select * from VAccountsCollocations;
--select * from worktrip;
--update worktrip set acceptabledistance = 500;


create table CarsBrands
(
    Id serial primary key,
    Brand text
);

create table CarsModels
(
    Id serial primary key,
	IdCarsBrands int references CarsBrands(Id) not null,
    Model text
);

create table Colours
(
	id serial primary key,
	Name text,
	Rgb text
);
--select * from carsbrands;
--select * from carsmodels where idcarsbrands = 6;
--select * from colours;

create table Cars
(
    Id serial primary key,
	IdAccounts int references Accounts(Id) not null,
	IdCarsBrands int references CarsBrands(Id) not null,
	IdCarsModels int references CarsModels(Id) not null,
	IdColours int references Colours(id) not null,
	RegistrationPlate text,
    AvailableSeats int not null,
	CreatedAt timestamp default now()
);

create or replace view VCarOwner as
select ac.name, ac.surname, cr.registrationplate, crb.brand, crm.model, cr.AvailableSeats, co.name as colour, co.rgb
from Accounts ac join Cars cr on ac.id = cr.idaccounts
join CarsBrands crb on cr.IdCarsBrands = crb.id
join CarsModels crm on cr.IdCarsModels = crm.id
join Colours co on co.id = cr.IdColours;

--select * from VCarOwner;

create table WorkTrip
(
	id serial primary key,
    IdAccount int references Accounts (id),
	searchId text, -- not null,
    LatitudeFrom double precision, --+
	LongitudeFrom double precision,-- +
	LatitudeTo double precision,
	LongitudeTo double precision,
	IdGeographicLocationFrom int references GeographicRegion(id),
	IdGeographicLocationTo int references GeographicRegion(id),
	StreetFrom text,
	StreetTo text,
	CityFrom text,
	CityTo text,
    FromHour time, -- 0 60 -> 1 
    ToHour time,
    AcceptableDistance double precision,
	CreatedAt timestamp default now()
);

--select * from VAccountsCollocations;
create or replace view VAccountsCollocations as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, U1.Id as AccountId, 
U2.Id as SuggestedAccountId, ac.DistanceFrom, ac.DistanceTo
from AccountsCollocations ac
join Accounts U1 on U1.Id = ac.IdAccount 
join Accounts U2 on U2.Id = ac.IdCollocated ;

--select * from VAccountsCollocationsWorkTrip;
create or replace view VAccountsCollocationsWorkTrip as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, U1.Id as AccountId, 
U2.Id as SuggestedAccountId, ac.DistanceFrom, ac.DistanceTo, wt.LatitudeFrom, wt.LongitudeFrom, wt.LatitudeTo,
wt.LongitudeTo, wt.FromHour, wt.ToHour 
from AccountsCollocations ac
join Accounts U1 on U1.Id = ac.IdAccount 
join Accounts U2 on U2.Id = ac.IdCollocated
join WorkTrip wt on U2.id = wt.idaccount ;

--select * from VCollocationsGeoLocations;
create or replace view VCollocationsGeoLocations as --select hosts of collocations
select distinct a.id as accountId, a.name, a.surname, wt.LatitudeFrom, wt.LongitudeFrom,
wt.LatitudeTo, wt.LongitudeTo, wt.FromHour, wt.ToHour, wt.searchid
from AccountsCollocations acc 
join WorkTrip wt on acc.IdAccount = wt.IdAccount
join Accounts a on a.id = wt.IdAccount;


--select * from VACollocationsGeoLocations;

--select * from VACollocationsGeoLocations where idaccount = 1;
--select * from VCollocationsGeoLocations;
--select * from AccountsCollocations;

create or replace view AccountsCarsLocations as 
select acc.id as accountId, acc.name, acc.surname, acc.email, acl.streetfrom, acl.streetto, acl.cityfrom, acl.cityto,
c.RegistrationPlate, c.AvailableSeats, cb.Brand, cm.Model, col.name as colour, col.rgb
from Accounts acc join WorkTrip acl on acc.id = acl.IdAccount
join cars c on acc.id = c.IdAccounts
join Colours col on c.IdColours = col.id 
join CarsBrands cb on c.IdCarsBrands = cb.id
join CarsModels cm on c.IdCarsModels = cm.id;

select * from AccountsCarsLocations;
-- drop table TestCoordinates;
--create table TestCoordinates
--(
	--FromLongitude decimal,
	--FromLatitude decimal
--);

--insert into TestCoordinates(FromLongitude, FromLatitude) values (50.05463180727613, 17.80014622135593);
--select * from TestCoordinates;
create or replace view AccountRoles as
select Accounts.id, Accounts.Name, Accounts.Surname, Accounts.email, Accounts.password, Accounts.emailConfirmed, 
Accounts.refreshtoken , Roles.name as RoleName, Accounts.refreshTokenValid
from Accounts
join Roles on Roles.id = Accounts.idRole;

--select * from accounts;
--select * from AccountRoles

create table Trips
(
	id serial primary key,
    IdInitiatorAccount int references Accounts (id), -- person, who initiated the trip, who drives his/her car
	IdWorkTrip int references WorkTrip(id),
	TripDate date,
	IsCurrent bool default false,
	FromHour time, -- 0 60 -> 1 
    ToHour time,
	Summary text,
	CreatedAt Timestamp default now(),
	LeftSeats int
);

create table TripParticipants
(
	id serial primary key,
	IdTrip int references Trips (id), --1 => 2
	IdAccount int references Accounts (id),
	IsOccasion bool default false,
	CreatedAt Timestamp default now()
);

create or replace view VTripsParticipants as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, U1.Id as AccountId, 
U2.Id as SuggestedAccountId, tr.TripDate, tr.Summary, tr.id as tripId, tr.IsCurrent, tr.FromHour, tr.ToHour,
tr.LeftSeats, tp.IsOccasion
from Trips tr join TripParticipants tp on tr.id = tp.IdTrip
join Accounts U1 on U1.Id = tr.IdInitiatorAccount 
join Accounts U2 on U2.Id = tp.IdAccount ;



create table StatisticsTrips
(
	id serial primary key,
	TripDate date unique,
	TripCars int not null,
	TripPeople int not null,
	IdGeographicRegion int references GeographicRegion(Id)
);
--alter table GeographicRegion add column nestLevel int;

create table Occupations
(
	id serial primary key,
	name text
);

--create table Accounts
--(
--	Id serial primary key,
--	Name text not null,
--	Surname text not null,
--	Token text,
--	method text not null
--);

create table AccountMetadata
(
	id serial primary key,
	IdAccount int references Accounts(id),
	Gender int not null,
	Pesel text,
	Phone text,
	IdGeographicRegion int references GeographicRegion(Id),
	IdOccupation int references Occupations(id),
	IsSmoker bool default false,
	IsWithAnimals bool default false,
	metaJson text,
	CreatedAt timestamp default now()
);

create table NotUser
(
	id serial primary key not null,
	searchId text not null
);

create table WorkTripGen
(
	id serial primary key,
    IdAccount int not null, --references Accounts (id), NotUser
	searchId text not null,
	isUser bool not null default false,
    LatitudeFrom double precision not null, --+
	LongitudeFrom double precision not null,-- +
	LatitudeTo double precision not null,
	LongitudeTo double precision not null,
	IdGeographicLocationFrom int references GeographicRegion(id),
	IdGeographicLocationTo int references GeographicRegion(id),
	StreetFrom text,
	StreetTo text,
	CityFrom text,
	CityTo text,
	PostCodeFrom text,
	PostCodeTo text,
    FromHour time, -- 0 60 -> 1 
    ToHour time,
    AcceptableDistance double precision,
	CreatedAt timestamp default now()
);

create or replace view VWorkTripGenGeoLocations as --select people, who belong to the group collocated
select acc.idaccount, a.id as accountIdCollocated, a.name, a.surname, wt.LatitudeFrom, wt.LongitudeFrom,
wt.LatitudeTo, wt.LongitudeTo, wt.FromHour, wt.ToHour, wt.searchId
from AccountsCollocations acc 
join WorkTripGen wt on acc.idcollocated = wt.IdAccount
join Accounts a on a.id = wt.IdAccount;

create or replace view VAWorkTripGenGeoLocations as --select hosts of collocations
select distinct a.id as accountId, a.name, a.surname, wt.LatitudeFrom, wt.LongitudeFrom,
wt.LatitudeTo, wt.LongitudeTo, wt.FromHour, wt.ToHour, wt.searchid
from AccountsCollocations acc 
join WorkTripGen wt on acc.IdAccount = wt.IdAccount
join Accounts a on a.id = wt.IdAccount;

create or replace view VACollocationsGeoLocations as --select people, who belong to the group collocated
select acc.idaccount, a.id as accountIdCollocated, a.name, a.surname, wt.LatitudeFrom, wt.LongitudeFrom,
wt.LatitudeTo, wt.LongitudeTo, wt.FromHour, wt.ToHour, wt.searchId
from AccountsCollocations acc 
join WorkTripGen wt on acc.idcollocated = wt.IdAccount
join Accounts a on a.id = wt.IdAccount;

create table AccountModes
(
	IdAccount int references Accounts(id) primary key,
	mode int not null
);
--TABELA 1:
create table FailedLoginAttempts
(
	id serial primary key,
	IdAccount int not null,
	ts1 timestamp not null,
);
--TABEL 2:
create table SimplePasswords
(
	id serial primary key,
	IdAccount int not null,
	
);
--INSERTY:
insert into FailedLoginAttempts (IdAccount, ts1) values (AcountIndentifiers, timestamps)
insert into SimplePasswords (IdAccount) values (AcountIndentifiers)
--ew. blokada jeśli gdzieś damy boolean np czy simple password czy nie
--bolakada1:
select IdAccount
from FailedLoginAttempts
where count(TIMESTAMP DEFAULT)>=3 AND IdAccount IN SimplePasswords

--blokada2:
select IdAccount
from FailedLoginAttempts
where count(TIMESTAMP DEFAULT)>=5 AND IdAccount NOT IN SimplePassword;





--select * from VTripsParticipants;
--select * from Friends;
--select * from trips;
--select * from colours;

--delete from CarsBrands;

--select * from CarsBrands;

--select * from CarsModels;
