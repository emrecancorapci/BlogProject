# **Yet Another Blog Project**

The app is a backend service for a blog, providing a **RESTful API** for *creating*, *reading*, *updating*, and *deleting* posts. It uses **JWT tokens** for authentication, allowing users to securely log in and access protected routes.

It is built using **.NET 7.0** and has a layered architecture with five different layers: *API*, *Business*, *Data Access*, *Entities*, and *Web*. The API layer exposes the endpoints and handles incoming HTTP requests. The Business layer contains the business logic for the app. The Data Access layer communicates with the database using **Entity Framework Core**. The Entities layer defines the models used by the app. The Web layer contains the frontend code for the app.

**Swagger** is used to document the API and provide a user interface for testing the endpoints. **AutoMapper** is used to map data between the database models and the API models, and **BCrypt** is used to hash and salt user passwords for secure storage.

### **You can access development roadmap from** [***here***](https://emrecancorapci.notion.site/2ab68479982943d98b7881493277552b?v=7098d35882d94ae4aef5215d901aa53d) 


## **Features**

- **User authentication** using **JWT tokens**
- **CRUD** operations
- **Swagger** documentation
- **AutoMapper** for mapping data between models
- **BCrypt** for hashing and salting passwords

## **Technologies**

- [.NET 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [PostgreSQL](https://www.postgresql.org/)
- [AutoMapper](https://automapper.org/)
- [BCrypt](https://www.nuget.org/packages/bcrypt.net/)
- [JWT](https://jwt.io/)
- [Swagger](https://swagger.io/)


# **Getting Started**

## **Prerequisites**

- [.NET 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Visual Studio Code](https://code.visualstudio.com/download)

## **Installation**

1. Clone the repo

```bash
git clone https://github.com/emrecancorapci/YetAnotherBlogProject_Backend.git
```

2. Build the project

```bash
dotnet build
```

3. Run the project

```bash
dotnet run --project src/API/API.csproj
```

4. Open the Swagger UI
```
{URL}/swagger/index.html
```

5. Create `appsettings.json` at `API` folder. You can use `appsettings.example.json` as a template.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server={SERVER};Port={PORT};Database={DATABASE};User Id={USER};Password={PASSWORD};"
  },
  "JsonWebTokenKeys": {
    "Subject": "Login",
    "IssuerSigningKey": "{KEY}"
  }
}
```