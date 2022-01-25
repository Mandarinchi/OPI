create database GYM
use GYM

create table Boss_of_the_GYM
(IDD_OF_Boss_of_the_GYM int not null identity,
Age_of_Boss_of_the_GYM int not null,
FIO_of_Boss_of_the_GYM varchar(150) not null,
Gender varchar(1) not null,
constraint CS_PK_Boss_of_the_GYM primary key(IDD_OF_Boss_of_the_GYM),
constraint CS_check check (Gender = 'ì' or Gender = 'æ')



)
create table Klient 
(IDD_OF_Klient int not null identity,
Age_of_Klient int not null,
FIO_of_Klient varchar(50)not null,
Gender varchar(1) not null,
constraint CS_PK_Klient primary key(IDD_OF_Klient),
constraint CS_check2 check (Gender = 'ì' or Gender = 'æ'),
IDD_OF_Boss_of_the_GYM int,
constraint CS_FKK_Boss_of_the_GYM foreign key (IDD_OF_Boss_of_the_GYM) references Boss_of_the_GYM(IDD_OF_Boss_of_the_GYM))

drop table Klient
drop table Boss_of_the_GYM
drop database GYM