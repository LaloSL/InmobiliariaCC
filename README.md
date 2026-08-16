# 🏠 Inmobiliaria CC

Proyecto desarrollado para la materia **Laboratorio de Programación 2**.

El sistema tiene como objetivo informatizar la gestión de alquileres temporarios de propiedades inmuebles realizada por una agencia inmobiliaria.

---

## 👥 Integrantes del Grupo

* **Natalia Camargo** - *correo pendiente* - GitHub: *pendiente* - Discord: `pendiente`
* **Concha Guillermo** - *[gconcha@ulp.edu.ar](mailto:gconcha@ulp.edu.ar)* - GitHub: `LaloSL` - Discord: `pendiente`

---

## 📐 Modelado de Datos

Se realizó un primer modelado del sistema contemplando las entidades:

* **Propietario**
* **Inmueble**
* **Inquilino**
* **Reserva**

El modelo fue diseñado de manera que pueda ampliarse posteriormente con las demás entidades y funcionalidades requeridas por el sistema.

### Relaciones definidas

* Un **Propietario** puede poseer varios **Inmuebles**.
* Cada **Inmueble** pertenece a un único **Propietario**.
* Un **Inquilino** puede realizar varias **Reservas**.
* Cada **Reserva** corresponde a un único **Inquilino**.
* Un **Inmueble** puede aparecer en distintas **Reservas** a lo largo del tiempo.
* Cada **Reserva** corresponde a un único **Inmueble**.

### Diagrama Entidad-Relación (DER)

El siguiente diagrama representa las entidades, atributos y relaciones definidas inicialmente para el sistema:

![Diagrama Entidad-Relación de Inmobiliaria CC](./docs/InmobiliariaCC.png)

El archivo editable del diagrama se encuentra disponible en:

`docs/InmobiliariaCC.drawio`

---

## 💻 Tecnologías utilizadas

El proyecto se desarrolla utilizando:

* **ASP.NET Core MVC**
* **.NET 10**
* **C#**
* **Entity Framework Core**
* **MySQL**
* **Visual Studio Code**
* **Git / GitHub**

### Paquetes instalados

```text
MySql.EntityFrameworkCore 10.0.7
Microsoft.EntityFrameworkCore.Design 10.0.10
```

Herramienta de Entity Framework instalada:

```text
dotnet-ef 10.0.10
```

---

## 🏗️ Estado actual del desarrollo

### Completado

* Creación del repositorio GitHub.
* Configuración del archivo `.gitignore`.
* Creación inicial del `README.md`.
* Diseño del Diagrama Entidad-Relación.
* Creación del proyecto **ASP.NET Core MVC**.
* Comprobación de ejecución del proyecto en `localhost`.
* Instalación del proveedor de Entity Framework Core para MySQL.
* Instalación de las herramientas necesarias para trabajar con migraciones.

### Próximos pasos

1. Crear el Model `Propietario`.
2. Crear el Model `Inquilino`.
3. Crear y configurar `AppDBContext`.
4. Configurar la conexión con MySQL.
5. Crear y aplicar las migraciones.
6. Comprobar las tablas en MySQL.
7. Implementar el ABM de Propietarios.
8. Implementar el ABM de Inquilinos.

---

## 🗄️ Base de Datos

> **Pendiente:** Se incorporará el archivo `.sql` necesario para crear e inicializar la base de datos.

---

## 🚀 Instalación y ejecución

Actualmente el proyecto puede ejecutarse desde la terminal, ubicándose en la carpeta raíz del proyecto:

```bash
dotnet run
```

La aplicación se ejecutará utilizando la dirección `localhost` indicada por ASP.NET Core en la terminal.

> **Pendiente:** Esta sección se completará cuando se encuentre configurada la conexión con MySQL y la base de datos.
