# CRUD Management Web 

Aplicación web desarrollada con **Blazor** y **.NET 8**, diseñada para gestionar entidades empresariales (empleados, empresas, actividades, categorías y usuarios) mediante operaciones **CRUD** (Crear, Leer, Actualizar, Eliminar).  
Cuenta con autenticación, consumo de API REST y una arquitectura modular orientada a servicios.

---

## Características principales

-  **Autenticación de usuarios** (login y registro)
-  **Gestión de empleados**
-  **Gestión de empresas**
-  **Gestión de categorías**
-  **Gestión de actividades**
-  **Consumo de API REST** a través de servicios inyectables (`HttpClient`)
-  **Interfaz moderna** creada con **Blazor Components**
-  **Soporte para Docker**

---

##  Estructura del proyecto

CRUDManagmentWeb/
├── Components/
│ ├── App.razor
│ └── Pages/
│ ├── Home.razor
│ ├── Auth/
│ │ ├── LoginForm.razor
│ │ └── RegisterForm.razor
│ ├── Employees/EmployeesPage.razor
│ ├── Companies/CompaniesPage.razor
│ ├── Activities/ActivitiesPage.razor
│ └── Categories/CategoriesPage.razor
├── Models/
│ ├── User/UserDto.cs
│ ├── Activity/ActivityDto.cs
│ └── ...
├── Services/
│ ├── ApiServiceBase.cs
│ ├── AuthService.cs
│ ├── CompanyService.cs
│ ├── EmployeeService.cs
│ ├── ActivityService.cs
│ ├── CategoryService.cs
│ └── UserService.cs
├── Program.cs
├── appsettings.json
└── Dockerfile


### Capas principales

- **Components**: Contiene las páginas y componentes de interfaz de usuario (Blazor `.razor`).
- **Models**: Define los DTOs usados para la comunicación con la API.
- **Services**: Implementa la lógica de acceso a datos vía API REST, extendiendo `ApiServiceBase`.
- **Program.cs**: Configura el host de Blazor, los servicios y la inyección de dependencias.
- **Dockerfile**: Permite ejecutar la aplicación dentro de un contenedor Docker.

---

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/) *(opcional, para despliegue contenedorizado)*

---

## Instalación y ejecución

### 1. Clonar el repositorio
```bash
git clone https://github.com/Kpiiale/CRUDManagmentWeb.git
cd CRUDManagmentWeb
```
### 2. Restaurar dependencias
```bash
dotnet restore
```
### 3. Ejecutar la aplicación
```bash
dotnet run
```
La aplicación se iniciará en:
```bash
https://localhost:5001

```
## Servicios disponibles

| Servicio          | Archivo                       | Descripción                             |
| ----------------- | ----------------------------- | --------------------------------------- |
| `AuthService`     | `Services/AuthService.cs`     | Maneja login y registro de usuarios     |
| `CompanyService`  | `Services/CompanyService.cs`  | CRUD para empresas                      |
| `EmployeeService` | `Services/EmployeeService.cs` | CRUD para empleados                     |
| `ActivityService` | `Services/ActivityService.cs` | CRUD para actividades                   |
| `CategoryService` | `Services/CategoryService.cs` | CRUD para categorías                    |
| `UserService`     | `Services/UserService.cs`     | Manejo de usuarios y perfiles           |
| `ApiServiceBase`  | `Services/ApiServiceBase.cs`  | Clase base para todos los servicios API |

## Configuración
Tanto la base de datos como la API se encuentran en la nube, por lo que no es necesario cambiar la url. 
