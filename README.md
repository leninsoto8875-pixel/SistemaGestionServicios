# Sistema de Gestión de Servicios de Reparación y Mantenimiento de Computadoras

## Descripción

Aplicación web desarrollada para gestionar los servicios de reparación y mantenimiento de computadoras. El sistema permite registrar clientes, equipos, reparaciones y productos de inventario, además de controlar el estado de los servicios técnicos.

## Tecnologías utilizadas

- C#
- ASP.NET Core MVC
- .NET 8
- Entity Framework Core
- SQL Server
- HTML
- CSS
- Bootstrap
- Visual Studio

## Arquitectura

El sistema utiliza una arquitectura en capas:

### Dominio
Contiene las entidades y reglas principales del negocio, como Cliente, Equipo, Reparacion, Producto y Cotizacion.

### Aplicacion
Contiene los servicios encargados de coordinar los casos de uso del sistema.

### Infraestructura
Implementa los repositorios y el acceso a datos mediante Entity Framework Core y SQL Server.

### PresentacionWeb
Contiene los controladores y vistas MVC mediante los cuales interactúa el usuario.

## Funcionalidades implementadas

- Registro y consulta de clientes.
- Registro de equipos asociados a clientes.
- Registro de solicitudes de reparación.
- Actualización del estado de las reparaciones.
- Registro y consulta de productos del inventario.
- Validación de reglas de negocio.
- Persistencia de información en SQL Server.

## Reglas de negocio

- Un cliente debe tener nombre y teléfono.
- Un equipo debe estar asociado a un cliente.
- Una reparación debe estar asociada a un equipo.
- Las reparaciones utilizan estados controlados: Recibido, En diagnostico, En reparacion, Listo y Entregado.
- El precio de un producto debe ser mayor que cero.
- El stock de un producto no puede ser negativo.

## Base de datos

La base de datos utilizada es:

GestionServiciosDB

Los scripts se encuentran en la carpeta `Database`:

- 01_Crear_Base_Datos.sql
- 02_Crear_Tablas.sql
- 03_Datos_Prueba.sql
- 04_Consultas_Verificacion.sql

## Ejecución

1. Crear la base de datos utilizando los scripts SQL.
2. Configurar la cadena de conexión en `appsettings.json`.
3. Restaurar los paquetes NuGet.
4. Establecer `PresentacionWeb` como proyecto de inicio.
5. Ejecutar la aplicación desde Visual Studio.

## Estructura principal

PresentacionWeb → Aplicacion → Dominio

Infraestructura → Dominio

Infraestructura implementa la persistencia mediante Entity Framework Core y SQL Server.

## Proyecto académico

Proyecto desarrollado como parte de la asignatura Arquitectura de Software.