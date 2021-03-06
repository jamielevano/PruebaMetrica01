CREATE DATABASE [Banco]
GO

USE [Banco]
GO
/****** Object:  StoredProcedure [dbo].[SP_BANCO_ACTUALIZAR]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_BANCO_ACTUALIZAR]
(@Id int,
@nombre varchar(500),
@direccion varchar(50))
as
begin
	update Banco 
	set nombre = @nombre,
		direccion = @direccion
	where id = @Id
end 

GO
/****** Object:  StoredProcedure [dbo].[SP_BANCO_ELIMINAR]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create proc [dbo].[SP_BANCO_ELIMINAR]
(@Id int)
as
begin
	delete Banco 
	where id = @Id
end 

GO
/****** Object:  StoredProcedure [dbo].[SP_BANCO_INSERTAR]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_BANCO_INSERTAR]
(@nombre varchar(500),
@direccion varchar(50))
as
begin
	insert into Banco (nombre,direccion,fecRegistro)
	values (@nombre,@direccion,GETDATE())
end 
GO
/****** Object:  StoredProcedure [dbo].[SP_BANCO_OBTENER]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[SP_BANCO_OBTENER]
(@Id int)
as
begin
	SELECT * FROM Banco 
	where id = @Id
end 
GO
/****** Object:  StoredProcedure [dbo].[SP_ORDENPAGO_ACTUALIZAR]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ORDENPAGO_ACTUALIZAR]
(@Id int,
@idBanco int,
@idSucursal int,
@monto decimal(18,4),
@moneda varchar(10),
@estado int,
@fechaPago date)
as
begin
	update OrdenPago 
	set idBanco = @idBanco,
		idSucursal = @idSucursal,
		monto = @monto,
		moneda = @moneda,
		estado = @estado,
		fecPago = @fechaPago
	where idOrdenPago = @Id
end 

GO
/****** Object:  StoredProcedure [dbo].[SP_ORDENPAGO_ELIMINAR]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_ORDENPAGO_ELIMINAR]
(@Id int)
as
begin
	delete OrdenPago 
	where idOrdenPago = @Id
end 

GO
/****** Object:  StoredProcedure [dbo].[SP_ORDENPAGO_INSERTAR]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ORDENPAGO_INSERTAR]
(@idBanco int,
@idSucursal int,
@monto decimal(18,4),
@moneda varchar(10),
@estado int,
@fechaPago date)
as
begin
	insert into OrdenPago (idBanco, idSucursal, monto, moneda, estado,fecPago)
	values (@idBanco,@idSucursal,@monto,@moneda,@estado,@fechaPago)
end 
GO
/****** Object:  StoredProcedure [dbo].[SP_ORDENPAGO_LISTAR]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ORDENPAGO_LISTAR]
as
begin
	SELECT 
		a.idOrdenPago,
		a.idBanco,
		a.idSucursal,
		a.monto,
		a.moneda,
		a.estado,
		a.fecPago,
		b.nombre nombreBanco,
		c.nombre nombreSucursal
	FROM OrdenPago a
	join Banco b on a.idBanco = b.id
	join Sucursal c on c.idSucursal = a.idSucursal
	order by b.nombre, c.nombre
end 

GO
/****** Object:  StoredProcedure [dbo].[SP_ORDENPAGO_OBTENER]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_ORDENPAGO_OBTENER]
(@Id int)
as
begin
	SELECT * FROM OrdenPago 
	where idOrdenPago = @Id
end 

GO
/****** Object:  StoredProcedure [dbo].[SP_SUCURSAL_ACTUALIZAR]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_SUCURSAL_ACTUALIZAR]
(@Id int,
@idBanco int,
@nombre varchar(500),
@direccion varchar(50))
as
begin
	update Sucursal 
	set nombre = @nombre,
		direccion = @direccion,
		idBanco = @idBanco
	where idSucursal = @Id
end 

GO
/****** Object:  StoredProcedure [dbo].[SP_SUCURSAL_ELIMINAR]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[SP_SUCURSAL_ELIMINAR]
(@Id int)
as
begin
	delete Sucursal 
	where idSucursal = @Id
end 

GO
/****** Object:  StoredProcedure [dbo].[SP_SUCURSAL_INSERTAR]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_SUCURSAL_INSERTAR]
(@idBanco int,
@nombre varchar(500),
@direccion varchar(50))
as
begin
	insert into Sucursal (idBanco, nombre,direccion,fecRegistro)
	values (@idBanco,@nombre,@direccion,GETDATE())
end 

GO
/****** Object:  StoredProcedure [dbo].[SP_SUCURSAL_LISTAR]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SP_SUCURSAL_LISTAR]
as
begin
	SELECT a.idSucursal,
		a.nombre,
		a.direccion,
		a.fecRegistro,
		a.idBanco,
		b.nombre nombreBanco
	FROM Sucursal a
	join Banco b on a.idbanco = b.id
	order by b.nombre, a.nombre
end 

GO
/****** Object:  StoredProcedure [dbo].[SP_SUCURSAL_OBTENER]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_SUCURSAL_OBTENER]
(@Id int)
as
begin
	SELECT * FROM Sucursal 
	where idSucursal = @Id
end 

GO
/****** Object:  Table [dbo].[Banco]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Banco](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](500) NULL,
	[direccion] [varchar](500) NULL,
	[fecRegistro] [datetime] NULL,
 CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrdenPago]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrdenPago](
	[idOrdenPago] [int] IDENTITY(1,1) NOT NULL,
	[idBanco] [int] NULL,
	[idSucursal] [int] NULL,
	[monto] [decimal](18, 4) NULL,
	[moneda] [varchar](10) NULL,
	[estado] [int] NULL,
	[fecPago] [date] NULL,
 CONSTRAINT [PK_OrdenPago] PRIMARY KEY CLUSTERED 
(
	[idOrdenPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 09/01/2019 3:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sucursal](
	[idSucursal] [int] IDENTITY(1,1) NOT NULL,
	[idBanco] [int] NULL,
	[nombre] [varchar](500) NULL,
	[direccion] [varchar](500) NULL,
	[fecRegistro] [datetime] NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[idSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[OrdenPago]  WITH CHECK ADD  CONSTRAINT [FK_OrdenPago_Banco] FOREIGN KEY([idBanco])
REFERENCES [dbo].[Banco] ([id])
GO
ALTER TABLE [dbo].[OrdenPago] CHECK CONSTRAINT [FK_OrdenPago_Banco]
GO
ALTER TABLE [dbo].[OrdenPago]  WITH CHECK ADD  CONSTRAINT [FK_OrdenPago_Sucursal] FOREIGN KEY([idSucursal])
REFERENCES [dbo].[Sucursal] ([idSucursal])
GO
ALTER TABLE [dbo].[OrdenPago] CHECK CONSTRAINT [FK_OrdenPago_Sucursal]
GO
ALTER TABLE [dbo].[Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Sucursal_Banco] FOREIGN KEY([idBanco])
REFERENCES [dbo].[Banco] ([id])
GO
ALTER TABLE [dbo].[Sucursal] CHECK CONSTRAINT [FK_Sucursal_Banco]
GO
