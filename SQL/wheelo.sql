drop view AccountRoles;
drop view VFriends;
drop view VInvitations;
drop view VAccountsCollocations;
drop view VFriendSuggestions;

drop table Cars;
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
	DateWhen timestamp default now(),
	IdRole int references roles(id) default 1 not null,
	Token text
);

create table AccountsLocations
(
	Id serial primary key,
	IdAccounts int references Accounts(Id) not null,
	CoordinatesFrom text,
	CoordinatesTo text,
	StreetFrom text,
	StreetTo text,
	CityFrom text,
	CityTo text,
	DateWhen timestamp default now()
);

create table AccountsWorkTime
(
	Id serial primary key,
	IdAccounts int references Accounts(Id) not null,
	WorkStartHour text,
	WorkEndHour text
);

create table FriendSuggestions
(
	Id serial primary key,
	IdAccount int references Accounts(Id) not null,
	IdSuggested int references Accounts(Id) not null,
	DateWhen timestamp default now()
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
	DateWhen timestamp default now()
);

-- todo poprawic do zaproszen
create or replace view VInvitations as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, U1.Id as AccountId, U2.Id as SuggestedAccountId
from FriendSuggestions 
join Accounts U1 on U1.Id = FriendSuggestions.IdAccount 
join Accounts U2 on U2.Id = FriendSuggestions.IdSuggested ;

--friends
create table Friends
(
	Id serial primary key,
	IdAccount int references Accounts(Id) not null,
	IdFriend int references Accounts(Id) not null,
	DateWhen timestamp default now()
);

-- todo poprawic do Friends
create or replace view VFriends as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, U1.Id as AccountId, U2.Id as SuggestedAccountId
from FriendSuggestions 
join Accounts U1 on U1.Id = FriendSuggestions.IdAccount 
join Accounts U2 on U2.Id = FriendSuggestions.IdSuggested ;

create table AccountsCollocations
(
	Id serial primary key,
	IdAccount int references Accounts(Id) not null,
	IdCollocated int references Accounts(Id) not null,
	DateWhen timestamp default now()
);

-- todo poprawic do AccountsCollocations
create or replace view VAccountsCollocations as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, U1.Id as AccountId, U2.Id as SuggestedAccountId
from FriendSuggestions 
join Accounts U1 on U1.Id = FriendSuggestions.IdAccount 
join Accounts U2 on U2.Id = FriendSuggestions.IdSuggested ;

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

create table Cars
(
    Id serial primary key,
	IdAccounts int references Accounts(Id) not null,
	IdCarsBrands int references CarsBrands(Id) not null,
	IdCarsModels int references CarsModels(Id) not null,
    AvailableSeats int not null,
	DateWhen timestamp default now()
);

create table WorkTrip
(
	id serial primary key,
    IdAccount int references Accounts (id),
    FromLongitude decimal,
    FromLatitude decimal,
    FromStreet text,
    ToLongitude decimal,
    ToLatitude decimal,
    ToStreet text,
    FromHour time, -- 0 60 -> 1 
    ToHour time,
    AcceptableDistance decimal
);

create or replace view AccountRoles as
select Accounts.id, Accounts.Name, Accounts.Surname, Accounts.email, Accounts.password, Accounts.emailConfirmed, Accounts.token , Roles.name as RoleName
from Accounts
join Roles on Roles.id = Accounts.idRole;

select * from AccountRoles
