-- komentarze, grupy, chodzmy na piwo

drop table Comments;
drop table OrganizeMeeting;
drop table CommentTypes;
drop table GroupMembers;
drop table Groups;

create table Groups
(
	id serial primary key,
	name text not null,
	IdAccountCreated int not null,
	CreatedAt timestamp default now()
);

create table GroupMembers
(
	id serial primary key,
	IdGroups int references Groups(id) not null,
	IdAccount int not null,
	CreatedAt timestamp default now()
);

create table CommentTypes -- comment about a user, comment about a trip, 
(
	id serial primary key,
	type text
);

create table OrganizeMeeting
(
	id serial primary key,
	IdGroups int references Groups(id) not null,
	MeetingDate timestamp not null,
	Name text not null,
	CreatedAt timestamp default now()
);

create table Comments
(
	id serial primary key,
	IdCommentTypes int references CommentTypes(id) not null
);