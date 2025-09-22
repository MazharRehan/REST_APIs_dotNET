# REST APIs .NET - Books Management System

A comprehensive Books Management REST API built with .NET Core, demonstrating CRUD operations with Entity Framework Core and modern C# features.

## Overview

This repository contains a REST API for managing books, showcasing:
- RESTful API design principles
- Entity Framework Core integration
- Async/await patterns
- HTTP status code best practices
- Database operations with DbContext

## Table of Contents

- [Requirements](#requirements)
- [Getting Started](#getting-started)
- [API Documentation](#api-documentation)
- [Project Structure](#project-structure)
- [Features](#features)
- [Development](#development)
- [Testing](#testing)

## Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) 6.0 or higher
- [Visual Studio](https://visualstudio.microsoft.com/) 2022+ or [VS Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express or higher)

## Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/MazharRehan/REST_APIs_dotNET.git
   cd REST_APIs_dotNET
   ```

2. **Update database connection string in appsettings.json**
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=BooksDb;Trusted_Connection=True;TrustServerCertificate=True;"
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

5. **Access the API**
   ```
   http://localhost:5109
   ```

## API Documentation

### Books API Endpoints

#### Get All Books
- **GET** `/api/books`
- **Response**: List of all books
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
- **Response**: Single book object
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
- **Request Body**:
```json
{
  "title": "C# Advanced",
  "author": "Crafter",
  "yearPublished": 2024
}
```
- **Response**: 201 Created with location header

#### Update Book
- **PUT** `/api/books/{id}`
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
- **Request Body** (only fields to update):
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
- `400 Bad Request` - Invalid request data
- `404 Not Found` - Resource not found

## Project Structure

```
REST_APIs/
├── Controllers/
│   └── BooksController.cs          # Books API Controller
├── Data/
│   └── RESTAPIContext.cs          # Entity Framework DbContext
├── Models/
│   └── Book.cs                    # Book Entity Model
├── Program.cs                     # Application startup
└── appsettings.json              # Configuration
```

## Features

- ✅ Full CRUD operations for Books
- ✅ Entity Framework Core integration
- ✅ Async/await pattern implementation
- ✅ RESTful API design
- ✅ Proper HTTP status codes
- ✅ Database persistence
- ✅ Input validation
- ✅ Error handling

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

### Adding New Features

1. **Add new properties to Book model**
2. **Create and run migrations**
   ```bash
   dotnet ef migrations add AddNewProperty
   dotnet ef database update
   ```
3. **Update controller methods as needed**

## Testing

You can test the API using the provided `.http` file:

```http
@rootURL = http://localhost:5109

# Get all books
GET {{rootURL}}/api/books

# Get book by ID
GET {{rootURL}}/api/books/1

# Create new book
POST {{rootURL}}/api/books
Content-Type: application/json
{
  "title": "New Book",
  "author": "Author Name",
  "yearPublished": 2024
}

# Update book
PUT {{rootURL}}/api/books/1
Content-Type: application/json
{
  "id": 1,
  "title": "Updated Title",
  "author": "Updated Author",
  "yearPublished": 2024
}

# Partial update
PATCH {{rootURL}}/api/books/1
Content-Type: application/json
{
  "title": "Partially Updated Title"
}

# Delete book
DELETE {{rootURL}}/api/books/1
```

## Key Technologies

- **ASP.NET Core** - Web API framework
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Database
- **C#** - Programming language
- **RESTful Architecture** - API design pattern

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