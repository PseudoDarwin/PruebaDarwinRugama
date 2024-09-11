Create table Cliente(
	IdCliente int primary key identity(1,1),
	Nombre nvarchar(max),
	Representante nvarchar(max),
	ClienteActivo bit,
)

Create table Producto(
	IdProducto int primary key identity(1,1),
	Descripcion nvarchar(max),
	CodigoProducto nvarchar(max),
	Precio decimal,
	Productoactivo bit
)

Create table Descuento(
	Iddescuento int primary key identity(1,1),
	IdCliente int,
	IdProducto int,
	Fecha_promo date,
	Porcentaje_descuento decimal
	FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente),
    FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
)


---Procedimientos almacenados para Producto

alter procedure PACrearProducto
@descripcion nvarchar(max),
@codigoproducto nvarchar(max),
@precio decimal
as
begin
	insert into Producto (Descripcion,CodigoProducto,Precio,Productoactivo) values (@descripcion,@codigoproducto,@precio,0)
end
go

create procedure PAActualizarProducto
@idproducto int,
@descripcion nvarchar(max),
@codigoproducto nvarchar(max),
@precio decimal
as
begin
	update Producto set Descripcion=@descripcion, CodigoProducto=@codigoproducto, Precio=@precio where IdProducto=@idproducto
end
go

create procedure PAEliminarProducto
@idproducto int
as
begin
	update Producto set Productoactivo=1 where IdProducto=@idproducto
end
go


create procedure PAMostrarProducto
as
begin
	select idproducto as [ID Producto], Descripcion, CodigoProducto as [Codigo], Precio from Producto where Productoactivo = 0
end
go