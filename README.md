# SkyBound

Sistema de catálogo y conservación de aves, construido en ASP.NET MVC (.NET Framework) con arquitectura en capas. Proyecto de portafolio personal.

## Descripción

SkyBound permite administrar un catálogo de especies de aves — incluyendo su familia, categoría estacional, estatus de protección y hábitat — a través de un panel de administración, con una vista pública separada para consulta.

## Arquitectura

El proyecto está organizado en 4 capas independientes dentro de una sola solución:

| Proyecto | Responsabilidad |
|---|---|
| `CapaEntidad` | Modelos de dominio (POCOs) |
| `CapaDatos` | Acceso a datos con ADO.NET (SqlClient) y stored procedures |
| `CapaNegocio` | Lógica de negocio y validaciones |
| `CapaPresentacionrAdmin` | Panel de administración (ASP.NET MVC) |
| `CapaPresentacionClientee` | Sitio público de consulta (ASP.NET MVC) |

## Funcionalidades

- **Gestión de aves**: alta, edición, baja y carga de imagen por especie
- **Catálogos maestros**: Familia, Categoría Estacional, Estatus de Protección, Hábitat (CRUD completo vía JSON/AJAX)
- **Autenticación de administradores**: login, cambio de contraseña y restablecimiento, con `FormsAuthentication` y contraseñas hasheadas (SHA-256)
- **Sitio público**: vista de consulta del catálogo de aves para visitantes

## Stack técnico

- ASP.NET MVC 5 (.NET Framework)
- ADO.NET + SQL Server (stored procedures)
- Newtonsoft.Json
- Bootstrap, jQuery, DataTables, SweetAlert

## Cómo correrlo localmente

1. Clonar el repositorio
2. Restaurar los paquetes NuGet
3. Crear la base de datos `ProyectoAvesKevin` en SQL Server (local o Express)
4. Configurar la cadena de conexión `cadena` en el `Web.config` de cada capa de presentación apuntando a tu instancia local
5. Ejecutar la solución `ProyectoKevinCaliz.sln` desde Visual Studio

> Nota: las cadenas de conexión versionadas en este repo apuntan a una instancia local de desarrollo (`SQLEXPRESS`) y no representan credenciales de producción.

## Estado del proyecto

Proyecto personal en desarrollo, usado como pieza de portafolio. Próximas mejoras contempladas: manejo de errores más robusto en la capa de datos, y evaluar migración del acceso a datos hacia Entity Framework Core.
