# Cookify – Web API

A robust Web API built with **ASP.NET Core** for managing recipes, users, and ingredients, developed as a final project for the C# course. The system implements a clean 3-tier layered architecture, asynchronous programming (`async/await`), and relational database management via **Entity Framework Core**.

---

## Architecture & Project Structure

The project follows a standard **3-tier layered architecture** to ensure separation of concerns, scalability, and maintainability, utilizing **Dependency Injection (DI)** throughout the entire application lifecycle:

* **API Layer (Presentation):**
  * Houses the ASP.NET Core Controllers and API endpoints.
  * Handles routing, parameter binding (from Route, Query, and Body), and model validation.
  * Ensures standardized HTTP response status codes (e.g., `200 OK`, `201 Created`, `204 No Content`, `400 Bad Request`, `404 Not Found`).

* **BL Layer (Business Logic):**
  * Implements core business workflows through dedicated Services.
  * Encapsulates data processing and isolates database entities using **DTOs (Data Transfer Objects)**.
  * Leverages **AutoMapper** for clean and secure object-to-object mapping between domain models and DTOs.

* **DAL Layer (Data Access):**
  * Manages all database interactions using **Entity Framework Core**.
  * Encapsulates the `DbContext`, entity configurations, and data persistence logic.

---

## Database Schema & Relationships

The relational database model consists of interconnected entities designed to enforce integrity and relational constraints:

* **Recipe:** Represents a culinary recipe (Title, Instructions, Preparation Time, Image/Metadata) and maintains a foreign key relationship with the `User` who authored it.
* **User:** Represents the recipe author, including their profile details and culinary specialty.
* **Ingredient:** Defines individual ingredients registered in the system.
* **RecipeIngredient (Join Table):** Implements an explicit **Many-to-Many** relationship between `Recipe` and `Ingredient`, featuring an additional `Amount` column to represent the specific quantity per recipe.

---

## Tech Stack & Tools

* **Backend Framework:** ASP.NET Core Web API (.NET)
* **ORM:** Entity Framework Core
* **Database:** Microsoft SQL Server
* **Object Mapping:** AutoMapper
* **API Documentation & Testing:** Swagger / OpenAPI
* **IDE:** Visual Studio

---

## Getting Started

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download)
* [Visual Studio](https://visualstudio.microsoft.com/) (with ASP.NET and web development workload)
* [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server) (LocalDB, Express, or standard instance)
* [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)

---

## Installation & Setup

### 1. Clone the Repository
Run the following command in your terminal:
```bash
git clone https://github.com/ShiraSil/Cookify.git
cd Cookify
```

### 2. Configure Database Connection
Open the API project folder, open `appsettings.json`, and set your connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=<YOUR_SERVER_NAME>;Database=CookifyDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Initialize the Database
Execute the included `.sql` script inside SQL Server Management Studio (SSMS) to create the schema, tables, relationships, and initial seed data.

### 4. Build & Run
* Open `Cookify.sln` in Visual Studio.
* Set the **API project** as the *Startup Project*.
* Press `F5` (or `Ctrl + F5`) to build and start the server.

### 5. Test the API
Once running, the Swagger UI interface will open automatically:
* URL: `https://localhost:PORT/swagger`
* You can test all CRUD operations (`GET`, `POST`, `PUT`, `DELETE`) directly from the browser.
