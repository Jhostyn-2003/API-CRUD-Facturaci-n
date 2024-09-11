
# 📊 API-CRUD-Facturación

Este proyecto es una API RESTful desarrollada en .NET Core que proporciona funcionalidades CRUD (Crear, Leer, Actualizar y Eliminar) para la gestión de facturas y productos. Se conecta a una base de datos SQL Server para realizar todas las operaciones de persistencia.

## 🚀 Características

- **🔄 Operaciones CRUD**: Funcionalidades básicas para manejar productos, facturas y detalles de facturas.
- **🛠️ Controladores**: Gestión de los endpoints mediante controllers para cada entidad, como productos, facturas y detalles.
- **📦 DTOs (Data Transfer Objects)**: Uso de DTOs para la transferencia de datos entre las capas del sistema.
- **🔍 Filtros de validación**: Se implementan filtros personalizados para manejar la validación de datos y posibles errores.
- **🗺️ Perfiles de AutoMapper**: Uso de AutoMapper para mapear entre las entidades del dominio y los DTOs.
- **💾 Conexión con SQL Server**: La base de datos utilizada es SQL Server, y las conexiones se manejan a través de Entity Framework Core.

## 🛠️ Tecnologías Utilizadas

- **C#**: Lenguaje principal para el desarrollo.
- **.NET Core 6.0**: Framework utilizado para construir la API.
- **Entity Framework Core**: ORM (Object-Relational Mapping) para interactuar con la base de datos SQL Server.
- **SQL Server**: Base de datos utilizada para persistir la información.
- **AutoMapper**: Librería para mapear entre entidades y DTOs.
- **ASP.NET Core MVC**: Arquitectura utilizada para construir los controladores y manejar las peticiones HTTP.
  
## 📂 Estructura del Proyecto

- **Controllers**: Contiene los controladores que manejan las solicitudes HTTP. Cada controlador está relacionado con una entidad (Productos, Facturas, Detalles).
- **DTOs**: Definición de los objetos de transferencia de datos utilizados entre las capas del sistema.
- **Filters**: Implementación de filtros para la validación y manejo de errores.
- **Models**: Modelos de las entidades que representan las tablas de la base de datos.
- **Profiles**: Configuraciones de AutoMapper para mapear entre los modelos y los DTOs.
- **Program.cs**: Archivo principal para la configuración de la aplicación.

## 📋 Requisitos del Sistema

- **.NET 6.0 SDK** o superior.
- **SQL Server** instalado localmente o en un servidor accesible.
- **Visual Studio 2022** (recomendado para desarrollo y depuración).
- **Postman** (opcional, para probar los endpoints de la API).

## ⚙️ Instalación y Configuración

1. **Clona el repositorio**:

   ```bash
   git clone https://github.com/usuario/API-CRUD-Facturacion.git
   cd API-CRUD-Facturacion
   ```

2. **Configura la cadena de conexión**:

   Abre el archivo `appsettings.json` o `appsettings.Development.json` y configura la cadena de conexión a tu instancia de SQL Server:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=tu_servidor;Database=nombre_base_datos;User Id=tu_usuario;Password=tu_contraseña;"
     }
   }
   ```

3. **Restaura las dependencias**:

   ```bash
   dotnet restore
   ```

4. **Aplica las migraciones a la base de datos**:

   Utiliza Entity Framework para aplicar las migraciones y crear las tablas necesarias en tu base de datos de SQL Server:

   ```bash
   dotnet ef database update
   ```

5. **Ejecuta la aplicación**:

   ```bash
   dotnet run
   ```

   La API estará disponible en `http://localhost:5000` o el puerto que hayas configurado.

## 📑 Endpoints

Los principales endpoints de la API incluyen:

- **/api/productos**: CRUD para los productos.
- **/api/facturas**: CRUD para las facturas.
- **/api/detalles**: CRUD para los detalles de las facturas.

Puedes usar herramientas como Postman o cURL para interactuar con estos endpoints.

## 🧑‍💻 Uso

1. Envía solicitudes POST, GET, PUT o DELETE a los endpoints de la API.
2. La API interactuará con la base de datos SQL Server para realizar las operaciones CRUD.
3. Los resultados o errores serán devueltos en formato JSON.

## 🤝 Contribuciones

Las contribuciones son bienvenidas. Si tienes alguna idea para mejorar el proyecto, no dudes en hacer un fork y enviar un pull request.

1. Haz un fork del proyecto.
2. Crea una nueva rama (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios (`git commit -am 'Agregada nueva funcionalidad'`).
4. Haz push a tu rama (`git push origin feature/nueva-funcionalidad`).
5. Abre un pull request.

## 📜 Licencia

Este proyecto está bajo la Licencia MIT - consulta el archivo [LICENSE](LICENSE) para más detalles.
