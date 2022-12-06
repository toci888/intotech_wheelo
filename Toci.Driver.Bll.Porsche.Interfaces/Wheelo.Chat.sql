drop table Messages;
drop table RoomsAccounts;
drop table Rooms;

create table Rooms
(
	id serial primary key,
	name text not null unique,
	type int not null default 1, -- 1 - two people chat, 2 - more people chat
	createdat timestamp default now()
);

create table RoomsAccounts
(
	id serial primary key,
	idMember int not null,
	idRoom int references Rooms(id)
);

create table Messages
(
	id serial primary key,
	idAuthor int not null,
	idRoom int references Rooms(id),
	message text not null,
	createdat timestamp default now()
);