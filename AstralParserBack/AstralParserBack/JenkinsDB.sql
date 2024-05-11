-- Database: AstralJEnkins

-- DROP DATABASE IF EXISTS "AstralJEnkins";

CREATE DATABASE "AstralJEnkins"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_United States.1251'
    LC_CTYPE = 'English_United States.1251'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
CREATE TABLE statuses(
	id serial primary key not null,
	name varchar(255) not null
);	
create table developers(
	id serial primary key not null,
	nickname varchar(255) not null,
	passwd varchar(255) not null,
	firstname varchar(255) not null,
	surename varchar(255) not null,
	fathername varchar(255),
	havepermission bool not null
);
create table admins(
	id serial primary key not null,
	nickname varchar(255) not null,
	passwd varchar(255) not null,
	firstname varchar(255) not null,
	surename varchar(255) not null,
	fathername varchar(255)
);
create table jobs(
	id serial primary key not null,
	jobname varchar(255) not null
);
create table history(
	id serial primary key not null,
	developerid int not null,
	buildtime DATE not null,
	job int not null,
	status int not null,
	Foreign key(developer) REFERENCES developers(id),
	Foreign key(job) REFERENCES jobs(id),
	Foreign key(status) REFERENCES statuses(id)
);