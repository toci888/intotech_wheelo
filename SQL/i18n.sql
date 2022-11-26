

create table tags
(
	id serial primary key,
	tag text
);

create table languages
(
	id serial primary key,
	language text
);

create table translations
(
	id serial primary key,
	idlanguages int references languages(id),
	idtag int references tags(id),
	content text
);