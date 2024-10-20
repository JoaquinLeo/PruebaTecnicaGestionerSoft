create database PruebaTecnica

go

use PruebaTecnica

go

create table Nacionalidad(
IdNacionalidad int primary key identity,
Nombre varchar(50),
FechaCreacion datetime default getdate()
)

go

create table Deporte(
IdDeporte int primary key identity,
Nombre varchar(50),
Tipo varchar(50),
Descripcion varchar(1000),
FechaCreacion datetime default getdate()
)

go

create table Deportista(
IdDeportista int primary key identity,
Nombre varchar(50),
Apellido varchar(50),
Edad int,
Sexo varchar(50),
Imagen varchar(max),
IdNacionalidad int references Nacionalidad(IdNacionalidad),
IdDeporte int references Deporte(IdDeporte),
FechaCreacion datetime default getdate()
)

go

insert into Nacionalidad(nombre)
values('Argentina'),
('Brasil'),
('Peru'),
('Chile'),
('Colombia'),
('Venezuela'),
('Ecuador'),
('Paraguay'),
('Uruguay'),
('Mexico'),
('Estados Unidos'),
('Alemania'),
('España'),
('Francia'),
('Portugal'),
('Italia')

go

insert into Deporte(Nombre,Tipo,Descripcion)
values ('Futbol','Grupal','Juego entre dos equipos de once jugadores cada uno, cuyo objetivo es hacer entrar en la portería contraria un balón que no puede ser tocado con las manos ni con los brazos, salvo por el portero en su área de meta.'),
('Voleyball','Grupal','Es un deporte donde dos equipos se enfrentan sobre un terreno de juego liso separados por una red central, tratando de pasar el balón por encima de la red hacia el suelo del campo contrario.'),
('Golf','Individual','Actividad deportiva que consiste en embocar una bola de pequeñas dimensiones en un hoyo mediante distintos tipos de palos, empleando para ello el menor número de golpes posibles. La zona de salida se denomina tee y donde se ubica el hoyo se llama green, una zona verde perfectamente cuidada y segada.'),
('Tenis','Mixto','Se disputa entre dos jugadores/as (individuales) o entre dos parejas (dobles) jugando con raquetas y pelotas y consiste en golpear la pelota después de un rebote o antes que rebote con la raqueta para que vaya de un lado al otro del campo pasando por encima de la red.'),
('Ping Pong','Mixto','Se realiza en una mesa de juego, separando los dos campos por una red, con dos jugadores/as con sus raquetas respectivas y una bola que hay que pasar al campo contrario después de golpear la mesa. Se pierde el tanto cuando no se pasa la bola al campo contrario.'),
('Ajedrez','Individual','Juego de estrategia en el que se enfrentan dos jugadores, cada uno de los cuales tiene 16 piezas de valores diversos que pueden mover, siguiendo ciertas reglas, sobre un tablero dividido en cuadrados blancos y negros. El objetivo final del juego consiste en “derrocar al rey” del oponente.'),
('Basquetball','Grupal','Es un deporte que se juega con dos equipos, cada uno compuesto por cinco jugadores. El objetivo principal del juego es anotar puntos al lanzar la pelota a través del aro del equipo contrario. El basquetbol se practica en una cancha rectangular con una canasta elevada en ambos extremos de la pista.'),
('Boxeo','Individual','Deporte que consiste en la lucha a puñetazos de dos contendientes, de conformidad con ciertas reglas y utilizando guantes especiales.'),
('Handball','Grupal','Es un deporte en el que dos equipos compiten por el dominio de un balón inflado, empleando sus manos para controlarlo y arrojarlo dentro del arco del contrario, lo cual equivale a anotar un gol.')

go

insert into Deportista(Nombre,Apellido,Edad,Sexo,Imagen,IdNacionalidad,IdDeporte)
values('Lionel','Messi',37,'Masculino',null,1,1),
('Serena','Williams',43,'Femenino',null,11,4),
('Canelo','Alvarez ',34,'Masculino',null,10,8)

-- select * from Deportista
-- select d.Nombre , d.Apellido, n.Nombre as Pais , dt.Nombre as Deporte from Deportista d
-- inner join Nacionalidad n on n.IdNacionalidad = d.IdNacionalidad
-- inner join Deporte dt on dt.IdDeporte = d.IdDeporte
-- where d.Apellido = 'Alvarez'