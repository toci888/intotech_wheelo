drop table AssociatedGroupWall;
drop table AssociatedGroupUsers;
drop table AssociatedGroups;
drop table UsersReferences;
drop table TravelToWork;
drop table GroupUsers;
drop table Groups;
drop table TravelToWork;
drop table Friends;
drop table WorkTrip;
drop table UsersLocations;
drop table City;
drop table CarsUsers;
drop table Users;
drop table CarsPictures;
drop table Cars;
drop  table Colours;
drop table CarTypeDictionary;
drop table CarDictionary;
drop table UserTypes;
drop table Translations;
drop table Phrases;
drop table Languages;

create table Languages
(
	Id bigint identity primary key,
	Name text
);

create table Phrases
(
	Id bigint identity primary key,
	Phrase text
);

insert into Languages (name) values ('_polish');

insert into Phrases (Phrase) values ('_unknown_database_error');

create table Translations
(
	Id bigint identity primary key,
	IdLanguages bigint references Languages(Id),
	IdPhrases bigint references Phrases(Id),
	Translation text
);

create table UserTypes
(
	Id bigint identity primary key,
	UserType text
);

create table CarDictionary (
	Id bigint identity primary key,
	CarType text);

create table CarTypeDictionary 
(
	Id bigint identity primary key,
	IdCarDictionary bigint references CarDictionary(Id),
	CarType text);

create table Colours
(
	Id bigint identity primary key,
	Name text
);

create table Cars
(
	Id bigint identity primary key,
	LicensePlate text,
	IdCarTypeDictionary bigint references CarTypeDictionary(Id),
	IdColour bigint references Colours(Id),
	Seats int
);

create table CarsPictures
(
	Id bigint identity primary key,
	IdCars bigint references Cars(Id),
	Picture text -- base 64
);
select * from users;
create table Users
(
	Id bigint identity primary key,
	IdLanguages bigint references Languages(Id),
	UserName text,
	Password text,
	IdUserType bigint references UserTypes(id),
	Phone text,
	Email text
);

insert into Users (UserName, password, phone, email) values ('warrior', 'beatka', '731282311', 'bzapart@gmail.com');

create table CarsUsers
(
	Id bigint identity primary key,
	IdUsers bigint references Users(Id),
	IdCars bigint references Cars(Id),
	MaxSeats int
);

create table City
(
	Id bigint identity primary key,
	Name text,
	PostCode text
);

create table UsersLocations
(
	Id bigint identity primary key,
	IdUsers bigint references Users(Id),
	IdCity bigint references City(Id),
	Street text,
	Longitude decimal,
	Latitude decimal,
	Kind int
);

create table WorkTrip
(
	Id bigint identity primary key,
	IdUser bigint references Users(Id),
	IdCityFrom bigint references City(Id),
	IdCityTo bigint references City(Id),
	FromLongitude decimal,
	FromLatitude decimal,
	FromStreet text,
	ToLongitude decimal,
	ToLatitude decimal,
	ToStreet text,
	FromHour decimal,
	ToHour decimal,
	AcceptableDistance decimal
);

create table Friends
(
	Id bigint identity primary key,
	IdUser bigint references Users(id),
	IdUserFriend bigint references Users(id)
);
select * from friends;
create table Groups
(
	Id bigint identity primary key,
	Name text
);

create table GroupUsers
(
	Id bigint identity primary key,
	IdGroups bigint references Groups(Id),
	IdUser bigint references Users(Id)
);

create table TravelToWork
(
	Id bigint identity primary key,
	IdGroups bigint references Groups(Id),
	IdUsers bigint references Users(Id), -- driver
	IdCars bigint references Cars(Id)
);

create table UsersReferences
(
	Id bigint identity primary key,
	IdUsers bigint references Users(Id),
	IdUsersReferences bigint references Users(Id),
	Rank decimal,
	Opinion text
);

create table AssociatedGroups
(
	Id bigint identity primary key,
	Name text
);

create table AssociatedGroupUsers
(
	Id bigint identity primary key,
	IdUsers bigint references Users(Id),
	IdAssociatedGroups bigint references AssociatedGroups(Id)
);

select * from users;

create table AssociatedGroupWall
(
	Id bigint identity primary key,
	IdUsers bigint references Users(Id),
	IdAssociatedGroups bigint references AssociatedGroups(Id),
	Post text,
	Date datetime default current_timestamp
);

create table Wall
(
	Id bigint identity primary key,
);

create table Users
(
	Id bigint identity primary key,
);

create table Users
(
	Id bigint identity primary key,
);