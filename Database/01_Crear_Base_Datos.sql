USE GestionServiciosDB;
GO

-- Verificar clientes
SELECT * FROM Clientes;

-- Verificar equipos y sus propietarios
SELECT
    e.IdEquipo,
    c.Nombre AS Cliente,
    e.Tipo,
    e.Marca,
    e.Modelo,
    e.NumeroSerie
FROM Equipos e
INNER JOIN Clientes c
    ON e.IdCliente = c.IdCliente;

-- Verificar reparaciones
SELECT
    r.IdReparacion,
    e.Tipo,
    e.Marca,
    r.ProblemaReportado,
    r.Diagnostico,
    r.Estado,
    r.FechaIngreso
FROM Reparaciones r
INNER JOIN Equipos e
    ON r.IdEquipo = e.IdEquipo;

-- Verificar inventario
SELECT
    IdProducto,
    Nombre,
    Precio,
    Stock
FROM Productos;

-- Verificar cotizaciones
SELECT
    c.IdCotizacion,
    c.IdReparacion,
    c.ManoDeObra,
    c.Repuestos,
    c.Total
FROM Cotizaciones c;

-- Cantidades registradas
SELECT COUNT(*) AS TotalClientes FROM Clientes;
SELECT COUNT(*) AS TotalEquipos FROM Equipos;
SELECT COUNT(*) AS TotalReparaciones FROM Reparaciones;
SELECT COUNT(*) AS TotalProductos FROM Productos;
SELECT COUNT(*) AS TotalCotizaciones FROM Cotizaciones;
GO