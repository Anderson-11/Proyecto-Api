Cómo Crear una API Paso a Paso
1. Empezamos con el Proyecto Base, abrimos Visual Studio y creamos un nuevo
proyecto. Elegimos Biblioteca de Clases (.NET) y asignamos un nombre al proyecto
que será el núcleo de nuestra aplicación.

2. Instalamos los Paquetes Necesarios para que todo funcione, para esto vamos a
Herramientas > Administrador de paquetes NuGet > Consola del Administrador de
Paquetes y escribimos estos comandos uno por uno:
Install-Package EntityFramework
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools

3. Luego creamos la cadena de conexión de la base de datos, donde buscamos nuestro
servidor, la tabla que utilizaremos y el usuario del Sql Server. Después desplegamos
la consola y ponemos la cadena de conexión de la base de datos con nuestras respectivas
credenciales, esperamos y nos tendría que mostrar el contexto y los modelos de la base de datos.

4. Creamos una carpeta llamada REPOSITORY en el proyecto biblioteca de clases, dentro
de esa carpeta, crea una clase llamada ProductoDao. Donde manejaremos las operaciones
de la base de datos las funciones para hacer operaciones CRUD (Crear, Leer, Actualizar y Eliminar).

5. Ahora vamos a crear el Proyecto de la API. En la misma solución, agrega un nuevo proyecto
de tipo ASP.NET Core Web API. Dentro de este proyecto, creamos un controlador llamado ProductoController.
Porque aquí vamos a definir los métodos HTTP (GET, POST, PUT, DELETE) para manejar las solicitudes.

6. Luego para que el proyecto de la API pueda usar el código del proyecto base, hacemos clic
derecho en el proyecto Web Api  y seleccionamos Agregar > Referencia de Proyecto. Luego,
seleccionamos el proyecto de biblioteca de clases y hacemos clic en Aceptar.

7. ¡Es hora de probar lo que hemos creado!
Ejecutamos el proyecto Web Api desde Visual Studio y usamos Postman o Swagger para probar los endpoints.
