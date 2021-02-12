# Cambialo
## ¿Que es esto?
Este repositorio contiene un proyecto de muestra de una API construida en ASP.NET Core 3.1 y Entity Framework Core 3.1.
## Resumen
Se requiere realizar un sistema que permita gestionar el intercambio de cosas con otros usuarios (trueques).
## Casos de uso
* Un usuario publica articulos que quiere intercambiar.
* Un usuario elimina articulos que ya no quiere intercambiar.
* Un usuario inicia un intercambio.
  * El usuario puede crear el intercambio eligiendo uno de sus articulos previamente publicados a la espera que otro usuario le ofrezca uno de sus articulos para realizar el intercambio.
  * El usuario puede buscar un intercambio creado en el que le interece el articulo ofrecido y ofrecer uno de sus articulos previamente publicados para completar el intercambio.
  * Siempre quien sea el que recibe la solicitud de intercambio puede aceptar o rechazar el intercambio.
  * Si el intercambio no se ha completado cualquiera de los dos usuarios puede cancelarlo.
* Un usuario lista todos sus intercambios.
## Arquitectura
La arquitectura de la solución es un monolito que usa un proyecto ASP.NET Core 3.1 y Entity Framework Core 3.1 como ORM. La arquitectura de la solución separa en 3 capas (conceptuales y no fisicas, por el momento) el codigo.
1. Capa de presentación.
2. Capa de servicios.
3. Cap de acceso a datos.
### Capa de presentación
La capa de presentación está determinada por los controladores en la carpeta Controllers del proyecto. Se encargan de recibir LAS PETICIONES http, validar los modelos, pasar los modelos validos a la capa de servicios y devolver las respuestas HTTP APROPIADAS AL CLIENTE.
### Capa de servicios
La capa de servicios se encuentra en la carpeta servicios. Aqui se encuentran dichos servicios y sus interfaces, los servicios están separados por entidad que gestionan.
### Capa de acceso a datos
La capa de acceso a datos está en la carpeta Data. En esta capa están las entidades de la base de datos representadas en clases que usa Entity Framework Core, usando code first como modo de trabajo. También se encuentra el DbContext que usa Entity Framework Core y algunos enums que sirven para dasr más claridad al modelo de datos.