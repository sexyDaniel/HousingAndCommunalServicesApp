create table Owner(
	personal_account SERIAL PRIMARY KEY,
	first_name varchar(30) not null,
	last_name varchar(30) not null,
	patronymic varchar(30) not null
)

create table Cities(
	id SERIAL PRIMARY KEY,
	name varchar(30) not null
)

create table Property(
	id SERIAL PRIMARY KEY,
	owner_id int not null REFERENCES Owner (personal_account),
	square decimal not null,
	building_id int not null REFERENCES Building (id)
)

create table Building(
	id serial primary key,
	street varchar(40) not null,
	building_number int not null,
	city_id int not null references Cities (id)
)

create table Service(
	id serial primary key,
	name varchar(50) not null,
	service_company_id int not null references ServiceCompany (id)
)

create table ServiceCompany(
	id serial primary key,
	name varchar(50) not null,
	phone varchar(11) not null,
	email varchar(30) not null
)

create table Tariff(
	service_id int not null REFERENCES Service (id),
	building_id int not null REFERENCES Building (id),
	begin_month date not null,
	finish_month date not null,
	Primary key(service_id,building_id)
)

create table Charge(
	service_id int not null REFERENCES Service (id),
	building_id int not null REFERENCES Building (id),
	charge_date date not null,
	volume decimal not null,
	Primary key(service_id,building_id)
)


