# Gentil
Proyecto demo para Altran.
## Prerrequisitos
### Base de datos
Crear una base de datos SQL y ejecutar el script DeployDataBase.sql que se encuentra en la raíz del repo.

También es posible deployar la base de datos ejecutando en el Package Manager Console el comando update-database seleccionando como defualt project, el proyecto Gentil.DAL. Seleccionando esta última posibilidad se deberá ejecutar manualmente el script de creación de la tabla LOG para ser utilizada por Log4NET, dicho script se encuentra en la carpeta Log del proyecto Gentil.WebAPI.
## Deployment
**Configurar Gentil.WebAPI como _StartUp Project_.**
### NuGet Packages
Una vez abierta la solución en VS, en la ventana Solution Explorer seleccionar la solución con click derecho y ejecutar el comando Restore NuGet Packages.
## Ejecutando el demo
### Iniciar sesíon / LogIn
Las credenciales iniciales para el inicio de sesión son las siguientes:
```
Usuario: admin
Password: admin
```
## Built With
- AngularJS
- ASP.NET Web API 2
- EF Code First
- Simple Injector
- log4net
- Bootstrap 4
