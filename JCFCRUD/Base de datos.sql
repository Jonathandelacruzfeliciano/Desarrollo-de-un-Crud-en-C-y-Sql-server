Create database JonathanPrueba;
Use JonathanPrueba;

Create table persona
(
Id int primary key identity(1,1),
Nonbre varchar(50),
FecheDeNacimiento date,
);
--Consulta de la tabla persona.
Select * from persona;

---Insertar 4 registro para realizar una prueba de que todo funciona bíen en la tabla persona.
Insert into persona values ( 'Jonathan', '1994/09/27');
Insert into persona values ( 'Pedro Oscar', '2000/06/02');
Insert into persona values ( 'Molina', '1976/10/15');
Insert into persona values ( 'Jose martinez', '1992/02/22');


