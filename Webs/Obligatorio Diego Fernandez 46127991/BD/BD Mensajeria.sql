Use 
master
go

if exists(Select * from sysdatabases where name = 'BDMensajeria')
begin
	drop database BDMensajeria
end
go

create database BDMensajeria
go

Use BDMensajeria
go


Create Table Usuarios
(	
	username varchar(10) primary key ,
	nomcompleto varchar(50) not null,
	cedula int not null unique check(cedula between 10000000 and 99999999)
)
go


Create Table Mensajes
(
	numInterno int identity(1,1)primary key,
	username varchar(10) not null foreign key references Usuarios(username),
	destinatario varchar(10) not null foreign key  references Usuarios(username),
	asunto varchar(50),
	texto varchar(200),
	fechaHora Datetime not null default getdate()
)
go

create Table TipodeMensaje
(
	codigo varchar(3) not null primary key check(codigo like '[a-z][a-z][a-z]'),
	nombre varchar(20) not null
)
go

Create Table Comunes
(	
	numInterno int foreign key references Mensajes(numInterno) primary key,
	codigo varchar(3) foreign key references TipodeMensaje(codigo),
	
)
go

create Table Privados
(
	numInterno int foreign key references Mensajes(numInterno)primary key,
	fechaVencimiento datetime not null 	
)
go


-------------------------------------------------------------------------------------------------------------------


--Ejemplos de tablas

insert into Usuarios(username,nomcompleto,cedula) Values ('die','Diego Alvarez',98237498),
														 ('Nico','Nicolas Perez',11111111),
														 ('Borra','Diego Borrazas',22222222),
														 ('Gabi','Gabriel Pereira',33333333),
														 ('Joaco','Joaquin Hernandez',44444444),
														 ('Caro','Carolina Oliveira',56555555)
go



insert into Mensajes(username,destinatario,asunto,texto) values ('die','Nico','Futbol 5','Que andas? sale un futbol 5?'),
																('Nico','die','Re: Futbol 5','No estoy estudiando, la semana que viene'),
																('die','Gabi','Futbol 5','Que andas? sale un futbol 5?'),
																('Joaco','Borra','Clase','Como te fue en el laburo?'),
																('Borra','Nico','COD','Que andas? sale ese trabajo?'),
																('die','Borra','Futbol 5','Que andas?'),
																('Gabi','Borra','TV','Compre una TV 50"')
go

insert into TipodeMensaje(codigo,nombre) values ('EVT','Evento'),
												('URG','Urgente'),
												('IVT','Invitacion'),
												('MAS','otros'),
												('DIA','Diario')
go

insert into Comunes (numInterno,codigo) values (2,'EVT'),
											   (3,'IVT'),
											   (4,'URG'),
											   (5,'MAs')
go
 
insert into Privados (numInterno,fechaVencimiento)values (6,'20221223'),
														 (7,'20221231'),
														 (1,'20221224')
go

---------------------------------------------------------------------------------------------------------------
--Usuario

create proc AgregarUsuario
@User varchar(10),
@nombre varchar(20),
@cedula int
as 
begin
	if exists(select username from Usuarios where username = @User)
		return -1
			
	declare @error int
	
	
	Insert Usuarios(username,nomcompleto,cedula) values (@user,@nombre,@cedula)
		
end 
go


create proc ModificarUsuario
@User varchar(10),
@nombre varchar(20),
@cedula int 
as 
begin
	if not exists(select username from Usuarios where username = @User)
		return -1
			
	declare @error int
	
	update Usuarios set nomcompleto = @nombre, cedula = @cedula
	where username = @user
end
go

create proc EliminarUsuario
@User varchar(10)
as 
begin
	if not exists(select username from Usuarios where username = @User)
		return -1
		
	if exists(select username from Mensajes where username = @user or destinatario = @user)
		return -2
	
	Delete Usuarios where username = @user
	
end 
go

create proc BuscarUsuario
@User varchar(10)
as 
begin
	select nomcompleto,cedula
	from Usuarios 
	where username = @user
end 
go


------------------------------------------------------------------------------------------------------------
--TIpos de Mensajes

create proc AgregarTipo
@cod Varchar(3),
@nom Varchar(50)
as
begin
	declare  @error int
	
	if exists (Select * from TipodeMensaje where codigo = @cod)
		return -1
	
	
	Insert TipodeMensaje(codigo,nombre) values (@cod,@nom)
		
end 
go


create proc ModificarTipo
@cod Varchar(3),
@nom Varchar(50)
as
begin
	
	if not exists (Select * from TipodeMensaje where codigo = @cod)
		return -1
		
	Update TipodeMensaje
	set nombre = @nom
	where codigo = @cod
	
end 
go


create proc EliminarTipo
@cod Varchar(3)
as
begin
	
	if not exists (Select * from TipodeMensaje where codigo = @cod)
		return -1
	
	if exists(select * from Comunes where codigo = @cod)
		return -2
	
		
	delete TipodeMensaje where codigo= @cod
	
end 
go


create proc BuscarTipo
@cod varchar(3)
as
begin
	select nombre
	from TipodeMensaje 
	where codigo = @cod
end 
go

-----------------------------------------------------------------------------------------------------------

--Agregar Mensaje 


create proc AgregarMensajePrivado
 @user varchar (10),
 @dest varchar(10),
 @asunto varchar(50),
 @texto Varchar(200),
 @venc datetime
 as
 begin 
	
	declare @nI int,@error int
		
	if not exists (select * from Usuarios Where username = @user)
		return -1
		
	if not exists (Select * from Usuarios where username = @dest)
		return -2

	begin tran
		
	insert Mensajes(username,destinatario,asunto,texto) values (@user,@dest,@asunto,@texto)
	set @error = @@Error
	 
	set @nI = Scope_identity()
	set @venc = DATEADD(DAY,2,GETDATE())
	
	insert Privados(numInterno,fechaVencimiento) values (@nI,@venc)
	set @error += @@Error
	
	if(@error = 0)
	begin 
		commit tran
		return 1
	end
	else
	begin	
		rollback tran
		return -3
	end

end
go


--Comun

create proc AgregarMensajeComun
 @user varchar (10),
 @dest varchar(10),
 @asunto varchar(50),
 @texto Varchar(200),
 @cod varchar(3)
 as
 begin 
	declare @nI int,@error int
	
	if not exists (select * from Usuarios Where username = @user)
		return -1
		
	if not exists (Select * from Usuarios where username = @dest)
		return -2
	
	if not exists (select * from Comunes Where codigo = @cod)
		return -3
	
	begin tran
		
	insert Mensajes(username,destinatario,asunto,texto) values (@user,@dest,@asunto,@texto)
	set @error = @@Error
	
	set @nI = Scope_identity()
	
	insert Comunes(numInterno,codigo) values(@nI,@cod)
	set @error += @@Error
	
	if(@error = 0)
	begin 
		commit tran
		return 1
	end
	else
	begin	
		rollback tran
		return -4
	end
	
end
go


-----------------------------------------------------------------------------------------------------------

--Listados

create proc ListadoDeUsuarios
as
begin
	select *
	from Usuarios
end
go



create proc ListadoDeTipo
as
begin 
	select *
	from TipodeMensaje
end
go


--------------------------------------------------------------------------------------------------
--Listados de Mensaje


create proc ListadoMsjPrivado
@user varchar(10),
@ddl int
as
begin 
	declare @hoy datetime = getdate()

	select m.*,p.fechaVencimiento
	from Mensajes as m inner join Privados as p
	on m.numInterno = p.numInterno
	and @user = case when @ddl = 1 then m.username
				     when @ddl = 2 then m.destinatario
				     end
	and	p.fechaVencimiento > @hoy
	
end 
go



create proc ListadoMsjComun
@cod varchar(3),
@user varchar(10),
@ddl int
as
begin 
	select m.*,c.codigo
	from Mensajes as m inner join Comunes as c
	on m.numInterno = c.numInterno
	and @user = case when @ddl = 1 then m.username
				     when @ddl = 2 then m.destinatario
				     end
	and	c.codigo = @cod
end 
go

create proc MensajesComunes
as
begin
	select *
	from Mensajes inner join Comunes
	on Mensajes.numInterno = Comunes.numInterno
end
go

create proc MensajesPrivados
as
begin
	select *
	from Mensajes inner join Privados
	on Mensajes.numInterno = Privados.numInterno
end
go