# ToDoList-MVC-3Tier

A multi-user ToDo List web application built using ASP.NET Core MVC with 3-Tier Architecture.

## Features

### Authentication & Authorization
- User Registration & Login
- Role-Based Authorization (Admin / User)
- ASP.NET Core Identity Authentication

### User Features
- Create Tasks
- View Personal Tasks
- Mark Tasks As Completed
- Delete Tasks

### Admin Features
- View All Users
- View Users Tasks
- Monitor Tasks Status
- Delete Any Task

## Architecture

The project follows a clean 3-Tier Architecture:

### DAL (Data Access Layer)
- Entity Framework Core
- SQL Server Database
- Repository Pattern
- Identity Integration

### BLL (Business Logic Layer)
- DTOs
- Services
- Business Logic
- Data Mapping

### PL (Presentation Layer)
- ASP.NET Core MVC
- Controllers
- ViewModels
- Razor Views
- Bootstrap UI

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- Bootstrap 5
- LINQ
- Dependency Injection

## Project Structure

```bash
ToDoList-MVC-3Tier
│
├── ToDoList.DAL
├── ToDoList.BLL
├── ToDoList.PL
