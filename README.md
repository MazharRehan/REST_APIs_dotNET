# REST APIs .NET - Books Management System

A comprehensive Books Management REST API built with .NET 9, demonstrating full CRUD operations including PATCH support with Entity Framework Core and JSON Patch documents.

## Overview

This repository contains a REST API for managing books, showcasing:
- RESTful API design principles
- Entity Framework Core integration
- JSON Patch document support for partial updates
- Async/await patterns
- HTTP status code best practices
- Database operations with DbContext

## Table of Contents

- [Requirements](#requirements)
- [Getting Started](#getting-started)
- [Dependencies](#dependencies)
- [API Documentation](#api-documentation)
- [Project Structure](#project-structure)
- [Features](#features)
- [Development](#development)
- [Testing](#testing)

## Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) 9.0 or higher
- [Visual Studio](https://visualstudio.microsoft.com/) 2022+ or [VS Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express or higher)

## Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/MazharRehan/REST_APIs_dotNET.git
   cd REST_APIs_dotNET
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Update database connection string in appsettings.json**
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=BooksDb;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }
   ```

4. **Apply migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

6. **Access the API**
   ```
   http://localhost:5109
   ```

## Dependencies

This project uses the following NuGet packages:

| Package | Version | Purpose |
|---------|---------|---------|
| `Microsoft.AspNetCore.JsonPatch` | 9.0.9 | JSON Patch support for PATCH operations |
| `Microsoft.AspNetCore.Mvc.NewtonsoftJson` | 9.0.9 | Newtonsoft.Json integration for MVC |
| `Microsoft.AspNetCore.OpenApi` | 9.0.8 | OpenAPI/Swagger documentation |
| `Microsoft.EntityFrameworkCore` | 9.0.8 | Entity Framework Core ORM |
| `Microsoft.EntityFrameworkCore.SqlServer` | 9.0.8 | SQL Server provider for EF Core |
| `Microsoft.EntityFrameworkCore.Tools` | 9.0.8 | EF Core migration tools |

### Installing Dependencies

```bash
# Core packages
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.8
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.8
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.8

# JSON Patch support
dotnet add package Microsoft.AspNetCore.JsonPatch --version 9.0.9
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 9.0.9

# OpenAPI support
dotnet add package Microsoft.AspNetCore.OpenApi --version 9.0.8
```

## API Documentation

### Books API Endpoints

#### Get All Books
- **GET** `/api/books`
- **Response**: 200 OK with list of all books
```json
[
  {
    "id": 1,
    "title": "The Great Gatsby",
    "author": "F. Scott Fitzgerald",
    "yearPublished": 1925
  }
]
```

#### Get Book by ID
- **GET** `/api/books/{id}`
- **Response**: 200 OK with single book object
```json
{
  "id": 1,
  "title": "The Great Gatsby",
  "author": "F. Scott Fitzgerald",
  "yearPublished": 1925
}
```

#### Create New Book
- **POST** `/api/books`
- **Content-Type**: `application/json`
- **Request Body**:
```json
{
  "title": "C# Advanced",
  "author": "Crafter",
  "yearPublished": 2024
}
```
- **Response**: 201 Created with location header

#### Update Book (Full Update)
- **PUT** `/api/books/{id}`
- **Content-Type**: `application/json`
- **Request Body**:
```json
{
  "id": 5,
  "title": "Moby-Dick",
  "author": "Herman Melville",
  "yearPublished": 1851
}
```
- **Response**: 204 No Content

#### Partial Update Book (PATCH)
- **PATCH** `/api/books/{id}`

##### Option 1: JSON Patch Document (Recommended)
- **Content-Type**: `application/json-patch+json`
- **Request Body**:
```json
[
  { "op": "replace", "path": "/title", "value": "Advanced C# Programming" },
  { "op": "replace", "path": "/yearPublished", "value": 2025 }
]
```

**Supported Operations:**
- `replace` - Replace a property value
- `add` - Add a new property (if applicable)
- `remove` - Remove a property (if applicable)

##### Option 2: Simple Partial Update
- **Content-Type**: `application/json`
- **Request Body** (only include fields to update):
```json
{
  "title": "Updated Title",
  "author": "New Author"
}
```

- **Response**: 204 No Content

#### Delete Book
- **DELETE** `/api/books/{id}`
- **Response**: 204 No Content

### HTTP Status Codes

- `200 OK` - Successful GET requests
- `201 Created` - Successful POST requests
- `204 No Content` - Successful PUT/PATCH/DELETE requests
- `400 Bad Request` - Invalid request data or malformed JSON Patch
- `404 Not Found` - Resource not found

## Project Structure

```
REST_APIs/
├── Controllers/
│   └── BooksController.cs          # Books API Controller with CRUD + PATCH
├── Data/
│   └── RESTAPIContext.cs          # Entity Framework DbContext
├── Models/
│   ├── Book.cs                    # Book Entity Model
│   └── BookPatchDto.cs            # DTO for simple PATCH operations
├── Program.cs                     # Application startup & JSON Patch config
└── appsettings.json              # Configuration
```

## Features

- ✅ Full CRUD operations for Books
- ✅ JSON Patch document support (RFC 6902)
- ✅ Simple partial update support
- ✅ Entity Framework Core integration
- ✅ Async/await pattern implementation
- ✅ RESTful API design
- ✅ Proper HTTP status codes
- ✅ Database persistence with SQL Server
- ✅ Input validation and model state validation
- ✅ Comprehensive error handling
- ✅ OpenAPI/Swagger documentation

## Development

### Book Model
```csharp
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearPublished { get; set; }
}
```

### PATCH Implementation Features

1. **JSON Patch Document Support**: Standard RFC 6902 compliant PATCH operations
2. **Simple Partial Updates**: Send only the fields you want to update
3. **Model State Validation**: Automatic validation after patch application
4. **Concurrency Handling**: Built-in concurrency conflict detection

### Adding New Features

1. **Add new properties to Book model**
2. **Create and run migrations**
   ```bash
   dotnet ef migrations add AddNewProperty
   dotnet ef database update
   ```
3. **Update PATCH operations to support new fields**

## Testing

You can test the API using the provided `.http` file:

```http
@rootURL = http://localhost:5109

### Get all books
GET {{rootURL}}/api/books
Accept: application/json

### Get book by ID
GET {{rootURL}}/api/books/2
Accept: application/json

### Create new book
POST {{rootURL}}/api/books
Content-Type: application/json
{
  "title": "C# Advance",
  "author": "Crafter",
  "yearPublished": 2024
}

### Update book (full update)
PUT {{rootURL}}/api/books/5
Content-Type: application/json
{
    "id": 5,
    "title": "Moby-Dick",
    "author": "Mazhar",
    "yearPublished": 1851
}

### Partial update with JSON Patch
PATCH {{rootURL}}/api/books/2
Content-Type: application/json-patch+json
[
  { "op": "replace", "path": "/title", "value": "Advanced C# Programming" },
  { "op": "replace", "path": "/yearPublished", "value": 2025 }
]

### Simple partial update
PATCH {{rootURL}}/api/books/1
Content-Type: application/json
{
  "title": "Updated Book Title",
  "author": "Mazhar Rehan"
}

### Delete book
DELETE {{rootURL}}/api/books/4
```

## Key Technologies

- **ASP.NET Core 9.0** - Web API framework
- **Entity Framework Core 9.0** - ORM for database operations
- **JSON Patch** - RFC 6902 compliant partial updates
- **Newtonsoft.Json** - JSON serialization and patch operations
- **SQL Server** - Database
- **C# 12** - Programming language
- **OpenAPI/Swagger** - API documentation



## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License.

---

**Author**: [MazharRehan](https://github.com/MazharRehan)  
**Repository**: [REST_APIs_dotNET](https://github.com/MazharRehan/REST_APIs_dotNET)  
**Last Updated**: 2025-09-22  
**Framework**: .NET 9.0