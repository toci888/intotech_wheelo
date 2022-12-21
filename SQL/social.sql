-- 9.12.2022 13:12
drop table Expenses;

-- run once for migration
drop table Comments;
--drop table UserComments;
--drop table MeetingSkippedAccounts;
drop table OrganizeMeeting;
--drop table GroupsPosts;
drop table CommentTypes;
drop table GroupMembers;
drop table Groups;

----------
-- 9.12.2022 13:12
drop table Expenses;
---
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
	IdGroups int references Groups(id),
	IdAccount int not null,
	IdAccountWhoAdded int not null,
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

create table Expenses
(
	id serial primary key,
	idAccount int not null,
	kind int not null, -- 1 monthly, 2 weekly, 3 daily; 
	amount double precision not null,
	CreatedAt timestamp default now()
);

---?????