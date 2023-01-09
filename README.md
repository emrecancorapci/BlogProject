# **Yet Another Blog Project**

The app is a backend service for a blog platform, providing a **RESTful API** for *creating*, *reading*, *updating*, and *deleting* posts. It uses **JWT tokens** for authentication, allowing users to securely log in and access protected routes.

It is built using **.NET 7.0** and has a layered architecture with five different layers: *API*, *Business*, *Data Access*, *Entities*, and *Web*. The API layer exposes the endpoints and handles incoming HTTP requests. The Business layer contains the business logic for the app. The Data Access layer communicates with the database using **Entity Framework Core**. The Entities layer defines the models used by the app. The Web layer contains the frontend code for the app.

**Swagger** is used to document the API and provide a user interface for testing the endpoints. **AutoMapper** is used to map data between the database models and the API models, and **BCrypt** is used to hash and salt user passwords for secure storage.

## **Technology Stack**

- .NET 7.0 (Updated from 6)
- Entity Framework Core
- PostgreSQL
- Swagger
- AutoMapper
- BCrypt
- React.js
- Bootstrap

## You can access development roadmap from [**here**](https://emrecancorapci.notion.site/2ab68479982943d98b7881493277552b?v=7098d35882d94ae4aef5215d901aa53d)
