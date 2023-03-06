create table if not exists api_objects (
	id text,
	type text not null,
	value text not null,
	constraint pk_api_objects primary key (id)
);