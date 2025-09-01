# REST APIs .NET

A comprehensive collection of REST APIs built with .NET, demonstrating best practices in API development and modern C# features.

## Overview

This repository contains REST API implementations using .NET, showcasing:
- RESTful API design principles
- C# best practices
- Standard HTTP methods (GET, POST, PUT, DELETE)
- API documentation and versioning
- Authentication and authorization
- Error handling and logging

## Table of Contents

- [Requirements](#requirements)
- [Getting Started](#getting-started)
- [API Documentation](#api-documentation)
- [Project Structure](#project-structure)
- [Features](#features)
- [Development](#development)
- [Testing](#testing)
- [Deployment](#deployment)

## Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) (Latest LTS version)
- [Visual Studio](https://visualstudio.microsoft.com/) 2022+ or [VS Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express or higher)

## Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/mazhar-invobyte/REST_APIs_dotNET.git
   cd REST_APIs_dotNET
   ```

2. **Update database connection**
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=RestApiDb;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }
   ```

3. **Apply migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Access Swagger Documentation**
   ```
   https://localhost:5001/swagger
   ```

## API Documentation

### Endpoints

#### Authentication
- `POST /api/auth/login` - User login
- `POST /api/auth/register` - User registration
- `POST /api/auth/refresh-token` - Refresh JWT token

#### Resources
- `GET /api/resources` - Get all resources
- `GET /api/resources/{id}` - Get resource by ID
- `POST /api/resources` - Create new resource
- `PUT /api/resources/{id}` - Update resource
- `DELETE /api/resources/{id}` - Delete resource

### Authentication

The API uses JWT Bearer token authentication:

```bash
Authorization: Bearer <your_token_here>
```

### Response Formats

Success Response:
```json
{
  "success": true,
  "data": {
    "id": 1,
    "name": "Resource Name",
    "createdAt": "2025-09-01T12:34:14Z"
  }
}
```

Error Response:
```json
{
  "success": false,
  "error": {
    "code": "RESOURCE_NOT_FOUND",
    "message": "The requested resource was not found"
  }
}
```

## Project Structure

```
src/
├── REST_APIs_dotNET.API/          # API Project
├── REST_APIs_dotNET.Core/         # Core Business Logic
├── REST_APIs_dotNET.Data/         # Data Access Layer
├── REST_APIs_dotNET.Services/     # Service Layer
└── REST_APIs_dotNET.Tests/        # Unit & Integration Tests
```

## Features

-  RESTful API endpoints
-  JWT authentication
-  Swagger documentation
-  Entity Framework Core
-  Repository pattern
-  Dependency injection
-  API versioning
-  Error handling middleware
-  Request/Response logging
-  Data validation

## Development

### Adding New Endpoints

1. Create Controller:
```csharp
[ApiController]
[Route("api/[controller]")]
public class ResourceController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // Implementation
    }
}
```

2. Add Service Layer:
```csharp
public interface IResourceService
{
    Task<IEnumerable<Resource>> GetAllAsync();
}
```

3. Implement Repository:
```csharp
public class ResourceRepository : IResourceRepository
{
    private readonly ApplicationDbContext _context;
    
    // Implementation
}
```

## Testing

Run unit tests:
```bash
dotnet test
```

Run specific test project:
```bash
dotnet test REST_APIs_dotNET.Tests
```

## Deployment

1. **Build the application**
   ```bash
   dotnet publish -c Release -o ./publish
   ```

2. **Configure environment variables**
   ```bash
   ASPNETCORE_ENVIRONMENT=Production
   ConnectionStrings__DefaultConnection=<your_connection_string>
   ```

3. **Run the application**
   ```bash
   cd publish
   dotnet REST_APIs_dotNET.API.dll
   ```

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

**Last Updated**: 2025-09-01 12:34:14 UTC  
**Author**: [mazhar-invobyte](https://github.com/mazhar-invobyte)  
**Language**: C# (100%)