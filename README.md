# EmployeeManagement API
# Employee Management System

## 📖 Introduction

This project is a **web application** for managing employees and departments. It follows a **clean architecture** approach.

## 🏗️ Architecture Overview

The project is structured into multiple layers to ensure **separation of concerns**:

- **Domain** – Core business logic and entities.
- **Application** – Use cases, and DTOs.
- **Infrastructure** – Database access (EF Core), repositories, and external services.
- **API** – API controllers and endpoints.
- **Tests** – Unit and integration tests using MSTest, FakeItEasy, AutoFixture, and FluentAssertions.

## 🛠️ Technologies Used

- **C# 12**
- **.NET 8.0**
- **Entity Framework Core**
- **SQLite** (for persistence)
- **MSTest** (unit testing)
- **AutoFixture** (test data generation)
- **FakeItEasy** (mocking framework)
- **FluentAssertions** (assertion library)

## 🚀 Getting Started

### 🔧 Prerequisites

Ensure you have the following installed:

- .NET SDK 8.0+  → [Download](https://dotnet.microsoft.com/)
- SQLite  → [Download](https://www.sqlite.org/download.html)
- Rider/Visual Studio Code/Visual Studio (optional)

### 📦 Installation

Clone the repository:

```sh
git clone https://github.com/your-repo/employee-management.git
cd employee-management
```

### 🛠️ Configuration

1. **Set up database**:

    - By default, the project uses SQLite.

2. **Apply Migrations**:

```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### ▶️ Running the Application

```sh
dotnet run --project EmployeeManagement.Api
```

The API will be available at: `http://localhost:5056/swagger/index.html`

### 🧪 Running Tests

```sh
dotnet test
```

## 📂 Project Structure

```
📦 EmployeeManagement
 ┣ 📂 src
 ┃ ┣ 📂 Application  # Business logic, use cases
 ┃ ┣ 📂 Domain       # Core entities
 ┃ ┣ 📂 Infrastructure  # EF Core, Migrations
 ┃ ┣ 📂 Api  # API controllers
 ┃ ┣ - 📜 Program.cs   # Entry point
 ┃ ┗ 📂 Tests        # Unit & integration tests
 ┣ 📜 README.md
 ┗ 📜 .gitignore
```

## 🏛️ Design Patterns Implemented

- **Repository Pattern** – Abstracts data access logic.
- **Dependency Injection** – Injects services for better testability.

## 📬 API Endpoints

- **Add Employee:** `POST /employee`
- **Get Employees:** `GET /employees/all`
- **Get Employee By Id:** `GET /employee/{id}`
- **Update Employee:** `PUT /employees/{id}`
- **Delete Employee:** `DELETE /employees/{id}`
- **Add Department:** `POST /department`
- **Get Departments:** `GET /department/all`

## 📜 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

