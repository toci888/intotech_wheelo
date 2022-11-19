-- komentarze, grupy, chodzmy na piwo

-- run once for migration
drop table Comments;
--drop table UserComments;
--drop table MeetingSkippedAccounts;
drop table OrganizeMeeting;
--drop table GroupsPosts;
drop table CommentTypes;
drop table GroupMembers;
drop table Groups;

drop table UserComments;
drop table MeetingSkippedAccounts;
drop table OrganizeMeeting;
drop table GroupsPostsComments;
drop table CommentTypes;
drop table GroupsPosts;
drop table GroupMembers;
drop table Groups;

create table Groups
(
	id serial primary key,
	name text not null,
	privacy int not null,
	IdAccountCreated int not null,
	CreatedAt timestamp default now()
);

create table GroupMembers
(
	id serial primary key,
	IdGroups int references Groups(id) not null,
	IdAccount int not null,
	Level int not null,
	CreatedAt timestamp default now()
);

create table GroupsPosts
(
	id serial primary key,
	IdGroups int references Groups(id) not null,
	IdAccount int not null,
	Content text not null,
	CreatedAt timestamp default now()
);

create table CommentTypes -- comment about a user, comment about a trip, 
(
	id serial primary key,
	type text
);

create table GroupsPostsComments
(
	id serial primary key,
	IdGroupsPostsComments int references GroupsPostsComments(id),
	IdPostCommented int references GroupsPosts(id) not null,
	IdAccountCommenting int not null,
	Comment text not null,
	IdCommentTypes int references CommentTypes(id) not null,
	CreatedAt timestamp default now()
);

create table OrganizeMeeting
(
	id serial primary key,
	IdGroups int references Groups(id) not null,
	IdAccount int not null,
	MeetingDate timestamp not null,
	IsOver bool default false,
	Name text not null,
	CreatedAt timestamp default now()
);

create table MeetingSkippedAccounts
(
	id serial primary key,
	IdGroups int references Groups(id) not null,
	IdOrganizeMeeting int references OrganizeMeeting(id) not null,
	IdAccount int not null,
	CreatedAt timestamp default now()
);

create table UserComments
(
	id serial primary key,
	IdUserComments int references UserComments(id),
	IdAccountCommented int not null,
	IdAccountCommenting int not null,
	Comment text not null,
	IdCommentTypes int references CommentTypes(id) not null,
	CreatedAt timestamp default now()
);