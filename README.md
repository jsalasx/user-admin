## Uauarios Backend
El proyecto fue realizado en .Net Core 8.
Requisitos Minimos
.Net Core 8.0.1
.Sql Server v16.
.Net Entity Framework 8.0.1

## 1. Clonar el Proyecto
```
git clone https://github.com/jsalasx/user-admin.git
```

## 2. Crear la base de datos
```
CREATE DATABASE pruebas;
```

## 3. Configurar el archivo appsettings.json
En la raiz del proecto se encuentra este archivo configurar la cadena de conexion a la base de datos.
```
"ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-PPL9AHC\\SQLE;Database=prueba;User Id=sa;Password=YOURPASSHERE.;TrustServerCertificate=True;"
  }
```
# En la Carpeta Raiz del Proyecto

## 4. Ejecutar las migraciones

```
dotnet ef migrations add InitialCreate
```
```
dotnet ef database update
```

## 5. Restaurar las dependencias 
```
dotnet restore
```

## 6. Compilar el proyecto 
```
dotnet build
```

## 7. Ejecutar el proyecto
El proyecto se ejecturá en http://localhost5276
```
dotnet run
```



