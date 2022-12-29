drop table ConversationInvitations;
drop table Messages;
drop table RoomsAccounts;
drop table Rooms;
drop table AccountsIdentifiers;

create table AccountsIdentifiers -- rooms for account
(
	id serial primary key,
	roomId text not null,
	idAccount int not null,
	createdat timestamp default now()
);

create table Rooms
(
	id serial primary key,
	roomId text not null unique,
	type int not null default 1, -- 1 - two people chat, 2 - more people chat
	createdat timestamp default now()
);

create table RoomsAccounts
(
	id serial primary key,
	idMember int not null,
	roomId text not null,
	createdat timestamp default now()
);

create table Messages
(
	id serial primary key,
	idAuthor int not null,
	roomId text not null,
	message text not null,
	createdat timestamp default now()
);

create table ConversationInvitations
(
	id serial primary key,
	idAccount int not null,
	idAccountInvited int not null,
	roomId text not null,
	createdat timestamp default now()
);