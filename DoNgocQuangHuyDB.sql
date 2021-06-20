create database DoNgocQuangHuyDB
use DoNgocQuangHuyDB
create table UserAccount(
	ID bigint IDENTITY (1,1) primary key,
	Username varchar(50) null,
	Password varchar(50) null,
	Status nvarchar(40) null
)
create table Category(
	ID bigint IDENTITY (1,1) primary key,
	Name nvarchar(100) null,
	Description nvarchar(255) null
)
create table Product(
	ID bigint IDENTITY (1,1) primary key,
	Name nvarchar(250) null,
	UnitCost decimal(18,0) null,
	Quantity int null, 
	Image nvarchar(250) null,
	Description nvarchar(255) null,
	Status int null,
	ProductType bigint null,
	constraint fk_Product_Category foreign key (ProductType) references Category (ID)
)