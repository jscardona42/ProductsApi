
# ASP.NET Core & EntityFramework Core DDD

## Prerequisitos

* Visual Studio 2022
* .NET Core SDK
* SQL Server

## Cómo iniciar el proyecto

* Abra la solución en Visual Studio 2022
* Abra Sql Server y cree una base de datos
* Diríjase a src/API/ProductsApi.API y abra el archivo appsettings.json
* Asigne su cadena de conexión a "ConnectionString"
* En el Menú, vaya a Herramientas/Administrador de paquetes Nuget/Consola del administrador de paquetes
* En la consola, elija src/Infrastructure/ProductsApi.Infrastructure como proyecto predeterminado
* Ejecute el comando add-migration <nombre de la migración>
* Ejecute update-database
* Inicie la aplicación
