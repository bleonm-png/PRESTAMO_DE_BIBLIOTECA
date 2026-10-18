# Sistema de Préstamos de Biblioteca

Aplicación de consola en **C# (.NET 10)** que administra lectores, libros y préstamos,
persistiendo toda la información en un motor de base de datos **SQLite**
(`Microsoft.Data.Sqlite`).

## Funcionalidades

| Módulo     | Operaciones                                                        |
|------------|--------------------------------------------------------------------|
| Lectores   | Crear, listar, actualizar, eliminar                                |
| Libros     | Crear, listar (con ejemplares disponibles), actualizar, eliminar   |
| Préstamos  | Crear, listar con estado (Prestado / Vencido / Devuelto), actualizar, registrar devolución, eliminar |
| POO        | Demostración de herencia y polimorfismo (`Persona` → `Lector`)     |

Reglas de negocio:

- No se puede prestar un libro si no quedan ejemplares disponibles (validado dentro de una transacción).
- No se pueden reducir los ejemplares de un libro por debajo de los préstamos activos.
- La fecha límite y la fecha de devolución no pueden ser anteriores a la fecha de préstamo.
- Al eliminar un lector o un libro se eliminan sus préstamos (`ON DELETE CASCADE`).
- Todas las consultas usan parámetros (sin concatenar SQL) y los errores se controlan con `try-catch`.

## Estructura

```
PrestamosBiblioteca.csproj
Program.cs                         Punto de entrada
Aplicacion/MenuBiblioteca.cs       Menú de consola
Dominio/                           Persona, Lector, Libro, Prestamo
Persistencia/
  InicializadorBaseDatos.cs        Crea la base y las tablas al iniciar
  RepositorioBiblioteca.cs         Acceso a datos (CRUD con SQLite)
BaseDatos/crear_tablas.sql         Script del modelo de datos
```

## Modelo de datos

```
Lectores (Id, Codigo, Nombre, Correo, Telefono)
Libros   (Id, Codigo, Titulo, Autor, Ejemplares)
Prestamos(Id, LectorId → Lectores, LibroId → Libros,
          FechaPrestamo, FechaLimite, FechaDevolucion)
```

## Ejecución

Requisito: [.NET SDK 10](https://dotnet.microsoft.com/download).

```bash
dotnet run
```

La base de datos se crea automáticamente en
`%LOCALAPPDATA%\UMG\PrestamosBiblioteca\biblioteca.db`.
Para usar otra ruta, defina la variable de entorno `PRESTAMOS_BIBLIOTECA_DB`.
