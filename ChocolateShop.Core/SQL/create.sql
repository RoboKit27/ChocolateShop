/* Создание всех табличек */

create table "Client"(
	"Id" serial primary key,
	"FirstName" character varying(50) null,
	"LastName" character varying(50) null,
	"Phone" character varying(50) not null,
	"Password" character varying(50) not null,
	"Email" character varying(50) null
);

create table "Role"(
	"Id" serial primary key,
	"Name" character varying(50) null
);

create table "User"(
	"Id" serial primary key,
	"FirstName" character varying(50) null,
	"LastName" character varying(50) null,
	"Phone" character varying(50) not null,
	"Password" character varying(50) not null,
	"RoleId" integer not null,
	foreign key ("RoleId") references "Role"("Id")
);

create table "Order"(
	"Id" serial primary key,
	"Date" character varying(50) not null,
	"ClientId" integer not null,
	foreign key ("ClientId") references "Client"("Id")
);

create table "Company"(
	"Id" serial primary key,
	"Name" character varying(50) not null,
	"Country" character varying(50) not null
);

create table "Type"(
	"Id" serial primary key,
	"Name" character varying(50)
);

create table "Chocolate"(
	"Id" serial primary key,
	"Name" character varying(50) not null,
	"Cost" integer not null,
	"StorageTime" integer not null,
	"Weight" integer not null,
	"CompanyId" integer not null,
	"TypeId" integer not null,
	foreign key ("CompanyId") references "Company"("Id"),
	foreign key ("TypeId") references "Type"("Id")
);

create table "Order_Chocolate"(
	"OrderId" serial not null,
	"ChocolateId" serial not null,
	foreign key ("OrderId") references "Order"("Id"),
	foreign key ("ChocolateId") references "Chocolate"("Id")
);

create table "Additive"(
	"Id" serial primary key,
	"Name" character varying(50)
);

create table "Chocolate_Additive"(
	"ChocolateId" serial not null,
	"AdditiveId" serial not null,
	foreign key ("ChocolateId") references "Chocolate"("Id"),
	foreign key ("AdditiveId") references "Additive"("Id")
);
