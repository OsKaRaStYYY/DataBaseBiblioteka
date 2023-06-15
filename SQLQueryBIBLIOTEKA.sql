-- Autor: Oskar Kupczy�ski
--ID: 14305

DROP DATABASE IF EXISTS BIBLIOTEKA;

IF NOT EXISTS (
        SELECT *
        FROM sys.databases
        WHERE name = 'BIBLIOTEKA'
        )
BEGIN
    CREATE DATABASE [BIBLIOTEKA]
END
GO


DROP TABLE IF EXISTS Pracownicy;
DROP TABLE IF EXISTS Autorzy;
DROP TABLE IF EXISTS Ksiazki;
DROP TABLE IF EXISTS Klienci;
DROP TABLE IF EXISTS Wypozyczenie;
DROP TABLE IF EXISTS Zakup;


USE [BIBLIOTEKA]
GO

begin




CREATE TABLE Pracownicy (
   ID_Pracownika INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
   Imie VARCHAR(50),
   Nazwisko VARCHAR(50),
   Data_urodzenia DATE,
   Data_zatrudnienia DATE,
   Ulica VARCHAR(100),
   Numer_Domu INT,
   Kraj VARCHAR(100),
   Pesel INT CONSTRAINT pes UNIQUE not null,
   Stanowisko VARCHAR(50),
   Pensja MONEY,
   
   
);
CREATE TABLE Autorzy (
   ID_Autora INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
   Imie VARCHAR(50),
   Nazwisko VARCHAR(50)
);
CREATE TABLE Ksiazki(
ID_Ksiazki INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
Tytul VARCHAR(100),
ID_Autora INT,
Rok_Wydania DATE,
Wartosc MONEY,
FOREIGN KEY (ID_Autora) REFERENCES Autorzy (ID_Autora),

);

CREATE TABLE Klienci (
   ID_Klienta INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
   Imie VARCHAR(50),
   Nazwisko VARCHAR(50),
   Data_urodzenia DATE,
   Ulica VARCHAR(100),
   Numer_Domu INT,
   Kraj VARCHAR(100),
   Telefon INT,

);



CREATE TABLE Wypozyczenie (
   ID_Wypozyczenia INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
   ID_Pracownika INT NOT NULL,
   ID_Klienta INT NOT NULL,
   ID_Ksiazki INT NOT NULL,
   Data_Wypozyczenia DATE,
   Data_Zwrotu DATE,
   FOREIGN KEY (ID_Pracownika) REFERENCES Pracownicy(ID_Pracownika),
   FOREIGN KEY (ID_Klienta) REFERENCES Klienci(ID_Klienta),
   FOREIGN KEY (ID_Ksiazki) REFERENCES Ksiazki(ID_Ksiazki)
);

CREATE TABLE Zakup (
   ID_Zakupu INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
   ID_Pracownika INT ,
   ID_Ksiazki INT,
   ID_Klienta INT,
   Data_Zakupu DATE,
   Data_Otrzymania DATE,
   Cena_Zakupu MONEY,
   Ilosc_Zakupu int,
   FOREIGN KEY (ID_Klienta) REFERENCES Klienci(ID_Klienta),
   FOREIGN KEY (ID_Pracownika) REFERENCES Pracownicy(ID_Pracownika),
   FOREIGN KEY (ID_Ksiazki) REFERENCES Ksiazki(ID_Ksiazki)
   );
   
   INSERT INTO Pracownicy(Imie, Nazwisko, Data_urodzenia, Data_zatrudnienia, Ulica, Numer_Domu, Kraj, Pesel, Stanowisko, Pensja)
VALUES ('Tadeusz', 'Marczy�ski', '1981-03-13', '2003-03-22', 'Graniczna', 33, 'Polska', '1234567890', 'Kierownik',5000)
INSERT INTO Pracownicy(Imie, Nazwisko, Data_urodzenia, Data_zatrudnienia, Ulica, Numer_Domu, Kraj, Pesel, Stanowisko, Pensja)
VALUES ('Jakub','Frycz'	,'1995-12-23','2018-06-02','Lwowska',54,'Polska','1671389450','Bibliotekarz',2500)
INSERT INTO Pracownicy(Imie, Nazwisko, Data_urodzenia, Data_zatrudnienia, Ulica, Numer_Domu, Kraj, Pesel, Stanowisko, Pensja)
VALUES ('Pawe�',	'Kubowski',	'1999-02-11',	'2022-06-02',	'Nawojowska',	12,	'Polska',	'1650713894',	'Bibliotekarz',	2500)
INSERT INTO Pracownicy(Imie, Nazwisko, Data_urodzenia, Data_zatrudnienia, Ulica, Numer_Domu, Kraj, Pesel, Stanowisko, Pensja)
VALUES ('Oskar',	'Gryczy�ski',	'1998-10-30',	'2020-06-02',	'Kr�lowej Jadwigi',	16,	'Polska',	'1368907154',	'Bibliotekarz',	2500)
INSERT INTO Pracownicy(Imie, Nazwisko, Data_urodzenia, Data_zatrudnienia, Ulica, Numer_Domu, Kraj, Pesel, Stanowisko, Pensja)
VALUES ('Jacek',	'Dominikowski',	'2002-10-30',	'2022-06-02',	'Pasterska',	13,	'Polska',	'1890713654',	'Sta�ysta',	1000)

   INSERT INTO Klienci(Imie, Nazwisko, Data_urodzenia, Ulica, Numer_Domu, Kraj, Telefon)
VALUES ('Al-Shahrad', 'Ali', '1985-07-08', 'Al-Szamrani', 11, 'Arabia Saudyjska', '890631682')
INSERT INTO Klienci(Imie, Nazwisko, Data_urodzenia, Ulica, Numer_Domu, Kraj, Telefon)
VALUES ('Grata', 'Borowska', '2003-11-21', 'Gubczycka', 66, 'Polska', '881636920')
INSERT INTO Klienci(Imie, Nazwisko, Data_urodzenia, Ulica, Numer_Domu, Kraj, Telefon)
VALUES ('Felek', 'Darewski', '2000-04-16', 'W�gierska', 66, 'Polska', '201688639')
INSERT INTO Klienci(Imie, Nazwisko, Data_urodzenia, Ulica, Numer_Domu, Kraj, Telefon)
VALUES ('Jack', 'Foden', '1981-02-12', 'Grove Street', 43, 'Anglia', '168286639')
INSERT INTO Klienci(Imie, Nazwisko, Data_urodzenia, Ulica, Numer_Domu, Kraj, Telefon)
VALUES ('Pola', 'Fio�kowska', '2004-01-01', 'Mi�osna', 69, 'Polska', '286391686')


INSERT INTO Autorzy(Imie, Nazwisko)
VALUES ('Adam', 'Mickiewicz')
INSERT INTO Autorzy(Imie, Nazwisko)
VALUES ('Henryk', 'Sienkiewicz')
INSERT INTO Autorzy(Imie, Nazwisko)
VALUES ('Jan', 'Kochanowski')
INSERT INTO Autorzy(Imie, Nazwisko)
VALUES ('Juliusz', 'S�owacki')
INSERT INTO Autorzy(Imie, Nazwisko)
VALUES ('Joanne', 'Murray')

INSERT INTO Ksiazki(Tytul, ID_Autora, Rok_Wydania, Wartosc)
VALUES ('Dziady cz�� III', 1, '1832-05-30', 50)
INSERT INTO Ksiazki(Tytul, ID_Autora, Rok_Wydania, Wartosc)
VALUES ('Potop', 2, '1886-12-02', 50)
INSERT INTO Ksiazki(Tytul, ID_Autora, Rok_Wydania, Wartosc)
VALUES ('Treny', 3, '1580-11-01', 50)
INSERT INTO Ksiazki(Tytul, ID_Autora, Rok_Wydania, Wartosc)
VALUES ('Balladyna', 4, '1839-07-11', 50)
INSERT INTO Ksiazki(Tytul, ID_Autora, Rok_Wydania, Wartosc)
VALUES ('Harry Potter', 5, '1997-06-26', 30)

INSERT INTO Wypozyczenie(ID_Pracownika, ID_Klienta,ID_Ksiazki, Data_Wypozyczenia, Data_Zwrotu)
VALUES (3, 1, 1, '2022-01-01', '2022-02-01')
INSERT INTO Wypozyczenie(ID_Pracownika, ID_Klienta,ID_Ksiazki, Data_Wypozyczenia, Data_Zwrotu)
VALUES (3, 2, 2, '2022-05-23', '2022-06-23')
INSERT INTO Wypozyczenie(ID_Pracownika, ID_Klienta,ID_Ksiazki, Data_Wypozyczenia, Data_Zwrotu)
VALUES (4, 3, 3, '2022-11-22', '2022-12-22')
INSERT INTO Wypozyczenie(ID_Pracownika, ID_Klienta,ID_Ksiazki, Data_Wypozyczenia, Data_Zwrotu)
VALUES (5, 4, 5, '2022-03-11', '2022-04-11')
INSERT INTO Wypozyczenie(ID_Pracownika, ID_Klienta,ID_Ksiazki, Data_Wypozyczenia, Data_Zwrotu)
VALUES (5, 3, 2, '2022-04-12', '2022-05-12')

INSERT INTO Zakup( ID_Pracownika, ID_Ksiazki, ID_Klienta, Data_Zakupu, Data_Otrzymania, Cena_Zakupu, Ilosc_zakupu)
VALUES (1, 5, 5, '2022-04-10', '2022-04-18', 60, 1);
INSERT INTO Zakup( ID_Pracownika, ID_Ksiazki, ID_Klienta, Data_Zakupu, Data_Otrzymania, Cena_Zakupu, Ilosc_zakupu)
VALUES (1, 4, 1, '2022-01-25', '2022-02-02', 120, 2);
INSERT INTO Zakup( ID_Pracownika, ID_Ksiazki, ID_Klienta, Data_Zakupu, Data_Otrzymania, Cena_Zakupu, Ilosc_zakupu)
VALUES (1, 2, 4, '2022-04-10', '2022-04-18', 60, 1);
INSERT INTO Zakup( ID_Pracownika, ID_Ksiazki, ID_Klienta, Data_Zakupu, Data_Otrzymania, Cena_Zakupu, Ilosc_zakupu)
VALUES (1, 2, 1, '2022-12-15', '2022-12-23', 60, 1);
INSERT INTO Zakup( ID_Pracownika, ID_Ksiazki, ID_Klienta, Data_Zakupu, Data_Otrzymania, Cena_Zakupu, Ilosc_zakupu)
VALUES (1, 1, 3, '2022-07-1', '2022-07-8', 180, 3);





















   end