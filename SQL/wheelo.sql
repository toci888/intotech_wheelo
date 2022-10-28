drop view VFriends;
drop view VInvitations;
drop view VUsersCollocations;
drop view VFriendSuggestions;

drop table Cars;
drop table CarsModels;
drop table CarsBrands;
drop table UsersCollocations;
drop table UsersWorkTime;
drop table FriendSuggestions;
drop table Friends;
drop table Invitations;
drop table UsersLocations;
drop table Users;
drop table GeographicRegion;

create table GeographicRegion
(
	Id serial primary key,
	IdParent int references GeographicRegion(Id),
	IdShit int,
	Name text
);

create table Users
(
	Id serial primary key,
	Name text not null,
	Surname text not null,
	Phone text not null,
	Email text not null,
	Login text not null,
	Password text not null,
	IdGeographicRegion int references GeographicRegion(Id),
	DateWhen timestamp default now()
);

create table UsersLocations
(
	Id serial primary key,
	IdUsers int references Users(Id) not null,
	CoordinatesFrom text,
	CoordinatesTo text,
	StreetFrom text,
	StreetTo text,
	CityFrom text,
	CityTo text,
	DateWhen timestamp default now()
);

create table UsersWorkTime
(
	Id serial primary key,
	IdUsers int references Users(Id) not null,
	WorkStartHour text,
	WorkEndHour text
);

create table FriendSuggestions
(
	Id serial primary key,
	IdUser int references Users(Id) not null,
	IdSuggested int references Users(Id) not null,
	DateWhen timestamp default now()
);

create or replace view VFriendSuggestions as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, U1.Id as UserId, U2.Id as SuggestedUserId
from FriendSuggestions 
join Users U1 on U1.Id = FriendSuggestions.IdUser 
join Users U2 on U2.Id = FriendSuggestions.IdSuggested ;

select * from VFriendSuggestions;

create table Invitations
(
	Id serial primary key,
	IdUser int references Users(Id) not null,
	IdInvited int references Users(Id) not null,
	DateWhen timestamp default now()
);

-- todo poprawic do zaproszen
create or replace view VInvitations as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, U1.Id as UserId, U2.Id as SuggestedUserId
from FriendSuggestions 
join Users U1 on U1.Id = FriendSuggestions.IdUser 
join Users U2 on U2.Id = FriendSuggestions.IdSuggested ;

--friends
create table Friends
(
	Id serial primary key,
	IdUser int references Users(Id) not null,
	IdFriend int references Users(Id) not null,
	DateWhen timestamp default now()
);

-- todo poprawic do Friends
create or replace view VFriends as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, U1.Id as UserId, U2.Id as SuggestedUserId
from FriendSuggestions 
join Users U1 on U1.Id = FriendSuggestions.IdUser 
join Users U2 on U2.Id = FriendSuggestions.IdSuggested ;

create table UsersCollocations
(
	Id serial primary key,
	IdUser int references Users(Id) not null,
	IdCollocated int references Users(Id) not null,
	DateWhen timestamp default now()
);

-- todo poprawic do UsersCollocations
create or replace view VUsersCollocations as
select U1.Name, U1.Surname, U2.Name as SuggestedName, U2.Surname as SuggestedSurname, U1.Id as UserId, U2.Id as SuggestedUserId
from FriendSuggestions 
join Users U1 on U1.Id = FriendSuggestions.IdUser 
join Users U2 on U2.Id = FriendSuggestions.IdSuggested ;

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
	IdUsers int references Users(Id) not null,
	IdCarsBrands int references CarsBrands(Id) not null,
	IdCarsModels int references CarsModels(Id) not null,
    AvailableSeats int not null,
	DateWhen timestamp default now()
);

create table WorkTrip
(
	id serial primary key,
    IdUser int references users (id),
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