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
drop table WorkTrip;
drop table Cars;
drop table Colours;
drop table CarsModels;
drop table CarsBrands;
drop table AccountsCollocations;
drop table AccountsWorkTime;
drop table FriendSuggestions;
drop table Friends;
drop table Invitations;
drop table AccountsLocations;
drop table Accounts;
drop table Roles;
drop table GeographicRegion;
--select * from Accounts;

create table GeographicRegion
(
	Id serial primary key,
	IdParent int references GeographicRegion(Id),
	IdShit int,
	Name text
);

create table Roles
(
	id serial primary key,
	name text
);

create table Accounts
(
	Id serial primary key,
	Name text not null,
	Surname text not null,
	Phone text not null,
	Email text not null,
	Login text not null,
	Password text not null,
	EmailConfirmed int default 0,
	IdGeographicRegion int references GeographicRegion(Id),
	CreatedAt timestamp default now(),
	IdRole int references roles(id) default 1 not null,
	Token text
);

-- 50.05463180727613, 17.80014622135593
create table AccountsLocations
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
	CreatedAt timestamp default now()
);

create or replace view VFriendSuggestions as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, U1.Id as AccountId, U2.Id as SuggestedAccountId
from FriendSuggestions 
join Accounts U1 on U1.Id = FriendSuggestions.IdAccount 
join Accounts U2 on U2.Id = FriendSuggestions.IdSuggested ;

select * from VFriendSuggestions;

create table Invitations
(
	Id serial primary key,
	IdAccount int references Accounts(Id) not null,
	IdInvited int references Accounts(Id) not null,
	CreatedAt timestamp default now()
);

-- todo poprawic do zaproszen
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
	CreatedAt timestamp default now()
);

-- todo poprawic do Friends
create or replace view VFriends as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, U1.Id as AccountId, U2.Id as SuggestedAccountId
from FriendSuggestions 
join Accounts U1 on U1.Id = FriendSuggestions.IdAccount 
join Accounts U2 on U2.Id = FriendSuggestions.IdSuggested ;

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

create or replace view VAccountsCollocations as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, U1.Id as AccountId, 
U2.Id as SuggestedAccountId, ac.DistanceFrom, ac.DistanceTo
from AccountsCollocations ac
join Accounts U1 on U1.Id = ac.IdAccount 
join Accounts U2 on U2.Id = ac.IdCollocated ;


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

select * from colours;

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



create table WorkTrip
(
	id serial primary key,
    IdAccount int references Accounts (id),
    LatitudeFrom double precision,
	LongitudeFrom double precision,
	LatitudeTo double precision,
	LongitudeTo double precision,
	StreetFrom text,
	StreetTo text,
	CityFrom text,
	CityTo text,
    FromHour time, -- 0 60 -> 1 
    ToHour time,
    AcceptableDistance double precision,
	
	CreatedAt timestamp default now()
);

create or replace view AccountsCarsLocations as 
select acc.id as accountId, acc.name, acc.surname, acc.phone, acc.email, acl.streetfrom, acl.streetto, acl.cityfrom, acl.cityto,
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
select Accounts.id, Accounts.Name, Accounts.Surname, Accounts.email, Accounts.password, Accounts.emailConfirmed, Accounts.token , Roles.name as RoleName
from Accounts
join Roles on Roles.id = Accounts.idRole;

--select * from accounts;
--select * from AccountRoles

create table Trips
(
	id serial primary key,
    IdInitiatorAccount int references Accounts (id), -- person, who initiated the trip, who drives his/her car
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

--select * from VTripsParticipants;

--select * from colours;

--delete from CarsBrands;

--select * from CarsBrands;

--select * from CarsModels;
