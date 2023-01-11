drop table UserActivity;
drop table ConnectedUsers;
drop table ConversationInvitations;
drop table Messages;
drop table RoomsAccounts;
drop table AccountsIdentifiers;
drop table Rooms;


create table Rooms
(
	id serial primary key,
	--roomId text not null unique,
	ownerId text not null,
	roomName text,
	createdat timestamp default now()
);

create table AccountsIdentifiers -- rooms for account
(
	id serial primary key,
	idRoom int references Rooms(id) not null,
	Email text not null,
	createdat timestamp default now()
);

create table RoomsAccounts
(
	id serial primary key,
	memberEmail text not null,
	idRoom int references Rooms(id) not null,
	isApproved bool default false,
	createdat timestamp default now()
);
--select * from Messages;
create table Messages
(
	id serial primary key,
	AuthorEmail text not null,
	idRoom int references Rooms(id) not null,
	message text not null,
	createdat timestamp default now()
);

create table ConversationInvitations
(
	id serial primary key,
	email text not null,
	emailInvited text not null,
	idRoom int references Rooms(id) not null,
	createdat timestamp default now()
);

create table ConnectedUsers
(
	id serial primary key,
	email text not null,
	createdat timestamp default now()
);

create table UserActivity
(
	id serial primary key,
	email text not null,
	connectedFrom timestamp,
	connectedTo timestamp,
	createdat timestamp default now()
);