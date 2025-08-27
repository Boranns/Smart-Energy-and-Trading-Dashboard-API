# Smart Energy and Trading Dashboard API
A RESTful API for a smart energy trading and portfolio management platform. Built with ASP.NET Core, it enables users to track energy assets and execute buy/sell transactions.

SmartEnergyAPI  

_A modular ASP.NET Core 9 Web API for energy trading, portfolio management, and user authentication._

 Overview
**SmartEnergyAPI** is a backend application designed to simulate a simplified **energy trading platform**.  
It follows **clean architecture principles** with clear separation of concerns (Controllers → Services → Repositories → EF Core).  

The system allows:
- **User authentication** (JWT-based, role-based access)
- **Energy product management**
- **Trade operations**
- **Portfolio management**
- **Alerts/notifications**

This makes it a strong demonstration of **real-world enterprise backend design**.

---

 Features
- **Authentication & Security**
  - Register/Login with **JWT**
  - Role-based authorization (`Admin`, `User`)
  - Passwords stored securely (hashing)
- **Domain Modules**
  - **Users** → register, login, profile
  - **Energy Products** → CRUD operations
  - **Trades** → create/manage trades linked to products
  - **Portfolios** → track collections of trades/products
  - **Alerts** → store/trigger alerts for trading rules
- **Developer Friendly**
  - **Swagger UI** (auto-generated API docs)
  - **Entity Framework Core** with SQL Server (LocalDB by default)
  - **DTOs** for clean API contracts
  - Layered architecture for maintainability

---

 Architecture
Controllers → Services → Repositories → EF Core DbContext → SQL Server
(API) (Business) (Data Access)

shell
Kopier kode

Project Structure
SmartEnergyAPI/
├─ Controllers/ # HTTP endpoints
│ ├─ UsersController.cs
│ ├─ EnergyProductsController.cs
│ ├─ TradeController.cs
│ └─ PortfolioController.cs
│
├─ Data/
│ └─ AppDbContext.cs # EF Core context
│
├─ DTOs/ # API request/response contracts
│ ├─ UserDto.cs
│ ├─ UserLoginDto.cs
│ ├─ UserRegisterDto.cs
│ ├─ PortfolioDto.cs
│ └─ TradeDto.cs
│
├─ Entities/ # Database models
│ ├─ User.cs
│ ├─ EnergyProduct.cs
│ ├─ Trade.cs
│ ├─ Portfolio.cs
│ └─ Alert.cs
│
├─ Repositories/ # Data layer
│ ├─ UserRepository.cs
│ ├─ EnergyProductRepository.cs
│ ├─ TradeRepository.cs
│ └─ PortfolioRepository.cs
│
├─ Services/ # Business logic
│ ├─ UserService.cs
│ ├─ EnergyProductService.cs
│ ├─ TradeService.cs
│ └─ PortfolioService.cs

