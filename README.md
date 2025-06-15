# 🏨 Hotel Reservation System – Upskilling Project

The **Hotel Reservation System** is a backend web API project built with **.NET 8** following the **Clean Architecture** pattern. It was developed as part of an **upskilling program** to master scalable architecture patterns, improve code maintainability, and understand how to design real-world applications using enterprise-grade practices.

---

## 📌 Project Description

This system allows customers to:
- View available rooms
- Make, update, and cancel reservations
- Manage booking details
- Check room availability by date

It simulates a real-world use case while keeping the project modular, testable, and easy to extend.

---

## 🤔 Why Clean Architecture?

We used **Clean Architecture** to:

- **Separate concerns** between business rules, use cases, and external systems
- **Isolate business logic** for easier testing and evolution
- **Reduce coupling** between layers (API, database, etc.)
- **Make the system framework-agnostic**, allowing easy replacement or upgrade of tools
- **Improve maintainability** and readability

The architecture ensures that **high-level business rules** don't depend on implementation details like databases or UI.

---

## 🔍 Project Structure

/src
  ├── API               → ASP.NET Core Web API (Controllers, Swagger)
  ├── Application       → Use cases, DTOs, Interfaces, Services
  ├── Domain            → Entities, Value Objects, Business Rules
  └── Infrastructure    → EF Core, Repositories, Configurations

---

## 🛠️ Tech Stack

| Area            | Technology                 |
|-----------------|----------------------------|
| Language        | C#                         |
| Framework       | .NET 8 Web API             |
| Database        | SQL Server                 |
| ORM             | Entity Framework Core      |
| Mapping         | AutoMapper                 |
| Documentation   | Swagger / Swashbuckle      |
| Architecture    | Clean Architecture         |

---

## 🚀 Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/hotel-reservation-api.git
cd hotel-reservation-api
```

### 2. Configure the Database Connection

Update your `appsettings.json` (usually in the `API` project) with your SQL Server connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=HotelReservationDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Apply Database Migrations

Navigate to the API or Infrastructure project directory (where the EF Core context is located) and run:

```bash
dotnet ef database update
```

> Ensure you have the [EF Core CLI tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) installed:
> ```bash
> dotnet tool install --global dotnet-ef
> ```

### 4. Run the Application

From the API project directory:

```bash
dotnet run
```

The API will be available at `https://localhost:5001` (or the port specified in your launch settings).

### 5. Explore the API

Open your browser and navigate to:

```
https://localhost:5001/swagger
```

Here you can test all endpoints using Swagger UI.

---

## 🧪 Running Tests

To run unit and integration tests (if available):

```bash
dotnet test
```

---

## 📂 Folder Structure

```
/src
  ├── API               # ASP.NET Core Web API (entry point, controllers, Swagger)
  ├── Application       # Application logic, use cases, DTOs, interfaces
  ├── Domain            # Core business entities, value objects, enums
  └── Infrastructure    # Data access, EF Core, repository implementations
```

---

## 🙌 Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

---

## 📄 License

This project is licensed under the MIT License.

---

## 💡 Credits

Developed as part of an upskilling initiative to master modern .NET backend development and Clean Architecture best practices.
