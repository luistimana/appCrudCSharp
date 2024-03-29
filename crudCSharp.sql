USE [crudCSharp]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 4/01/2022 09:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](max) NULL,
	[Pass] [varchar](max) NULL,
	[Icono] [image] NULL,
	[Estado] [varchar](max) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[buscar_usuarios]    Script Date: 4/01/2022 09:18:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
create proc [dbo].[buscar_usuarios]
@buscador varchar(50)
as
select * from Usuarios
where Usuario+Pass like '%' + @buscador +'%'
GO
/****** Object:  StoredProcedure [dbo].[editar_usuarios]    Script Date: 4/01/2022 09:18:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[editar_usuarios]
@Id_usuario int,
@Usuario as varchar(max),
@Pass as varchar(max),
@Icono as image,
@Estado as varchar(max)
as
if Exists (Select Usuario from Usuarios where Usuario=@Usuario and Id_usuario<>@Id_usuario)
Raiserror('Usuario en uso, escoja otro nombre.', 16,1)
else
update Usuarios set Usuario = @Usuario, Pass = @Pass, Icono = @Icono, Estado = @Estado
where Id_usuario = @Id_usuario
GO
/****** Object:  StoredProcedure [dbo].[eliminar_usuarios]    Script Date: 4/01/2022 09:18:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminar_usuarios]
@Id_usuario int
as
delete from Usuarios where Id_usuario = @Id_usuario
GO
/****** Object:  StoredProcedure [dbo].[insertar_usuario]    Script Date: 4/01/2022 09:18:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertar_usuario]
@Usuario as varchar(max),
@Pass as varchar(max),
@Icono as image,
@Estado as varchar(max)
as
if Exists (Select Usuario from Usuarios where Usuario=@Usuario)
Raiserror('Usuario ya registrado', 16,1)
else
insert into Usuarios
values (@Usuario, @Pass, @Icono, @Estado)
GO
/****** Object:  StoredProcedure [dbo].[mostrar_usuarios]    Script Date: 4/01/2022 09:18:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrar_usuarios]
as
select * from Usuarios
GO
