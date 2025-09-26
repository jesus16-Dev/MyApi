🚀 MyApi

Este proyecto es una API REST desarrollada con ASP.NET Core 8 y Entity Framework Core, que gestiona Usuarios, Plataformas y Reseñas.

⚙️ Tecnologías utilizadas

C#

.NET 8

Entity Framework Core

MySQL

📝 Aspectos importantes

- No se empleó AutoMapper.

- Para actualizar los datos de las tablas Platform y Review, se implementaron DTOs específicos.

- No se usaron DTOs para la obtención de datos (solo para creación y actualización).

- No se implementaron validaciones ni manejo de errores.

- Es una API básica, pensada como práctica de aprendizaje.


Estructura del proyecto

MyApi/
│── Configurations/  # Configuración de entidades (Fluent API)
│── Controllers/ # Controladores de la API
│── DTOs/ # DTOs para entrada de datos
│── Data/  # DbContext
│── Models/ # Modelos de dominio
│── Migrations/ # Migraciones de Entity Framework
│── Program.cs # Punto de entrada
│── appsettings.json # Configuración

 
 Posibles mejoras futuras

- Implementar DTOs de lectura para devolver datos más limpios.

- Agregar validaciones con Data Annotations ([Required], [Range], etc.).

- Manejo de errores con Middleware personalizado.


