create table if not exists show
(
	id bigint not null
		constraint show_pkey
			primary key,
	added timestamp,
	data jsonb
);

alter table show owner to tvcast;

create table if not exists person
(
	id bigint not null
		constraint person_pkey
			primary key,
	added timestamp,
	data jsonb
);

alter table person owner to tvcast;

create table if not exists character
(
	id bigint not null
		constraint character_pkey
			primary key,
	added timestamp,
	data jsonb
);

alter table character owner to tvcast;

create table if not exists casting
(
	id bigint generated always as identity
		constraint casting_pkey
			primary key,
	show_id bigint not null
		constraint casting_show_id_fkey
			references show,
	person_id bigint not null
		constraint casting_person_id_fkey
			references person,
	character_id bigint not null
		constraint casting_character_id_fkey
			references character
);

alter table casting owner to tvcast;