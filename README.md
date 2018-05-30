# Gentil
Proyecto demo para Altran.
## Prerrequisitos
### Base de datos
Para usar repositorios que consuman los datos de mocky, en el archivo web.config setear:
```
<add key="UseMockyRepository" value="true" />
```
Para usar repositorios que accedan a la base de datos SQL setear el valor en "false" y seguir los siguientes pasos:

Crear una base de datos SQL y ejecutar el script DeployDataBase.sql que se encuentra en la raíz del repo.

También es posible deployar la base de datos ejecutando en el Package Manager Console el comando update-database seleccionando como defualt project, el proyecto Gentil.DAL. Seleccionando esta última posibilidad se deberá ejecutar manualmente el script de creación de la tabla LOG para ser utilizada por Log4NET, dicho script se encuentra en la carpeta Log del proyecto Gentil.WebAPI.
## Deployment
**Configurar Gentil.WebAPI como _StartUp Project_.**
### NuGet Packages
Una vez abierta la solución en VS, en la ventana Solution Explorer seleccionar la solución con click derecho y ejecutar el comando Restore NuGet Packages.
## Built With
- AngularJS
- ASP.NET Web API 2
- EF Code First
- Simple Injector
- log4net
- Bootstrap 4
