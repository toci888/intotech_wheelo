drop table UserActivity;
drop table ConnectedUsers;
drop table ConversationInvitations;
drop table Messages;
drop table RoomsAccounts;
drop table AccountsIdentifiers;
drop table Rooms;
drop table AccountChat;

create table AccountChat
(
	id serial primary key,
	memberEmail text not null,
	idAccount int not null,
	firstname text,
	lastname text,
	pushToken text,
	hasManyAccount bool
);

create table Rooms
(
	id serial primary key,
	roomId text not null unique,
	ownerEmail text not null,
	ownerIdAccount int not null,
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
	memberIdAccount int not null,
	idRoom int references Rooms(id) not null,
	isApproved bool default false,
	createdat timestamp default now()
);
--select * from Messages;
create table Messages
(
	id serial primary key,
	AuthorEmail text not null,
	idAccount int not null,
	idRoom int references Rooms(id) not null,
	message text not null,
	createdat timestamp default now()
);

create table ConversationInvitations
(
	id serial primary key,
	email text not null,
	emailInvited text not null,
	idAcount int not null,
	idAccountInvited int not null,
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
	idAccount int not null,
	connectedFrom timestamp,
	connectedTo timestamp,
	createdat timestamp default now()
);