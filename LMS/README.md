Ticket Booking System

A Windows Forms desktop application built with C# and MySQL.
Allows users to register, log in, and manage events.

Features

- User registration with email validation and BCrypt password hashing
- Secure login with session management
- Add events with a unique date and time constraint
- View events

Tech Stack

- C# Windows Forms (.NET)
- MySQL
- BCrypt.Net-Next (password hashing)
- dotenv.net (environment variable management)

Setup

1. Clone the repo
2. Copy `.env.example` to `.env` and fill in your database credentials
3. Open MySQL Workbench and run `database/schema.sql` to create the tables
4. Open in JetBrains Rider
5. Run the project

Requirements

- .NET 6 or higher
- MySQL Server running locally
- Rider or Visual Studio

Under development

- Improved UI design
- View events segment
- Role-based access
- Payment method
- Exploration of new features