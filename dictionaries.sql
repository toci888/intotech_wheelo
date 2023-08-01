drop table if exists Colours;
drop table if exists CarsModels;
drop table if exists CarsBrands;

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