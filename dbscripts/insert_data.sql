use OMB

/*
  select * from Personas
  select * from Usuarios
  select * from Usuarios_Perfiles

  select * from Perfiles
  select * from Libros
*/
--  Tabla Personas
--
--

insert into Personas (ID, Nombre, Apellido, CorreoElectronico, FechaNacimiento) 
  values (default, 'Homer', 'Simpson', 'hsimpson@pp.com', convert(date, '20/05/1968', 103))

insert into Personas (ID, Nombre, Apellido, CorreoElectronico, FechaNacimiento) 
  values (default, 'Abraham', 'Simpson', 'asimpson@pp.com', convert(date, '01/06/1923', 103))

insert into Personas (ID, Nombre, Apellido, CorreoElectronico, FechaNacimiento) 
  values (default, 'Montgomery', 'Burns', 'mburns@centralnuclear.com', convert(date, '13/04/1875', 103))

insert into Personas (ID, Nombre, Apellido, CorreoElectronico, FechaNacimiento) 
  values (default, 'Marge', 'Bouvier', 'mbouvier@pp.com', convert(date, '01/03/1971', 103))

insert into Personas (ID, Nombre, Apellido, CorreoElectronico, FechaNacimiento)
  values (default, 'Ned', 'Flanders', 'neddy@leftorium.com', convert(date, '10/10/1941', 103))

--  Tabla Perfiles
--
--

insert into Perfiles values ('SysAdmin', 'Administracion total del Sistema')
insert into Perfiles values ('StockAdmin', 'Maneja el ingreso/egreso de productos al deposito')
insert into Perfiles values ('PDV', 'Atencion al cliente, facturacion, caja')
insert into Perfiles values ('AsistenciaCliente', 'Acceso a terminales de ayuda al cliente, busqueda de productos y precios')

--  Tabla Usuarios
--
--

insert into Usuarios (Login, Password, ID_Persona)
  values ('hsimpson', '123456', (select ID from Personas where Nombre='Homer' and Apellido='Simpson'))

insert into Usuarios (Login, Password, ID_Persona)
  values ('mburns', 'monty', (select ID from Personas where Nombre='Montgomery' and Apellido='Burns'))

insert into Usuarios (Login, Password, ID_Persona)
  values ('mbouvier', 'ringo', (select ID from Personas where Nombre='Marge' and Apellido='Bouvier'))

insert into Usuarios (Login, Password, ID_Persona)
  values ('nflanders', 'maude', (select ID from Personas where Nombre='Ned' and Apellido='Flanders'))

--  Tabla-Join Usuarios_Perfiles
--
--

insert into Usuarios_Perfiles values ('hsimpson', 4)
insert into Usuarios_Perfiles values ('mburns', 1)
insert into Usuarios_Perfiles values ('mbouvier', 3)
insert into Usuarios_Perfiles values ('mbouvier', 4)
insert into Usuarios_Perfiles values ('nflanders', 4)


--
--    Agregamos la tabla Libros
--

insert into Libros values (
'9781119068051',
'1119068053',
'Wrox',
'Professional Visual Studio 2015',
null,
'Primera',
'Bruce Johnson',
37.10,
'/Imagenes/Wrox_VS-2015.jpg')

insert into Libros values (
'9781491927069',   --  ISBN-13
'1491927062',   --  ISBN-10
'OReilly',   --  Editorial
'C# 6.0 in a Nutshell: The Definitive Reference',    --  Titulo
null,   --  Subtitulo
'Sexta',  --  Edicion
'Joseph Albahari|Ben Albahari',    --  Autores (separar con pipes
45.31,    --  Precio
'/Imagenes/C6_Nutshell.jpg'    --  Imagen Path
)

insert into Libros values (
'',   --  ISBN-13
'',   --  ISBN-10
'',   --  Editorial
'',    --  Titulo
null,   --  Subtitulo
'',  --  Edicion
'',    --  Autores (separar con pipes
,    --  Precio
'/Imagenes/'    --  Imagen Path
)

insert into Libros values (
'9780134141046',   --  ISBN-13
'0134141040',   --  ISBN-10
'Addison-Wesley',   --  Editorial
'Essential C# 6.0',    --  Titulo
null,   --  Subtitulo
'Quinta',  --  Edicion
'Mark Michaelis|Eric Lippert',    --  Autores (separar con pipes
44.99,    --  Precio
'/Imagenes/AW_Essential_C#.jpg'    --  Imagen Path
)

insert into Libros values (
'9780735684188',   --  ISBN-13
'0735684189',   --  ISBN-10
'Microsoft Press',   --  Editorial
'Windows Internals, Book 1: User Mode',    --  Titulo
null,   --  Subtitulo
'Septima',  --  Edicion
'Brian Catlin|Jamie Hanrahan|Mark E. Russinovich|David A. Solomon|Alex Ionescu',    --  Autores (separar con pipes
28.99,    --  Precio
'/Imagenes/MSP_WindowsInternals.jpg'    --  Imagen Path
)

insert into Libros values (
'',   --  ISBN-13
'',   --  ISBN-10
'',   --  Editorial
'',    --  Titulo
null,   --  Subtitulo
'',  --  Edicion
'',    --  Autores (separar con pipes
,    --  Precio
'/Imagenes/'    --  Imagen Path
)

insert into Libros values (
'',   --  ISBN-13
'',   --  ISBN-10
'',   --  Editorial
'',    --  Titulo
null,   --  Subtitulo
'',  --  Edicion
'',    --  Autores (separar con pipes
,    --  Precio
'/Imagenes/'    --  Imagen Path
)

insert into Libros values (
'',   --  ISBN-13
'',   --  ISBN-10
'',   --  Editorial
'',    --  Titulo
null,   --  Subtitulo
'',  --  Edicion
'',    --  Autores (separar con pipes
,    --  Precio
'/Imagenes/'    --  Imagen Path
)

insert into Libros values (
'',   --  ISBN-13
'',   --  ISBN-10
'',   --  Editorial
'',    --  Titulo
null,   --  Subtitulo
'',  --  Edicion
'',    --  Autores (separar con pipes
,    --  Precio
'/Imagenes/'    --  Imagen Path
)

insert into Libros values (
'',   --  ISBN-13
'',   --  ISBN-10
'',   --  Editorial
'',    --  Titulo
null,   --  Subtitulo
'',  --  Edicion
'',    --  Autores (separar con pipes
,    --  Precio
'/Imagenes/'    --  Imagen Path
)

select * from Libros
