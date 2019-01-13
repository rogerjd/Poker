-- sqlcmd -S (localdb)\MSSQLLocalDB -i pokdb.sql

DROP DATABASE poker

CREATE DATABASE poker
GO 

USE poker

CREATE TABLE games(
	id int identity(1, 1) primary key,
	date_time datetime not null default(getdate()),
	hand char(15) not null,
	score int not null,
	bet int not null
)

insert into games(hand, score, bet)
	values('QC 7C QH KS QS ', 4, 1), ('QC JD 6H 5C kH ', 0, 1), ('KC 2C KD JD 6C ', 2, 1)

create table integers(
	name char(30) primary key,
	value int not null
)

insert into integers(name, value)
	values('MinBet', 1), ('MaxBet', 5), ('StartCredits', 100), ('TargetMargin', 25)

GO