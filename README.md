# Bakery Transactions API

## Overview

This RESTful API allows you to manage users, bakeries, and transactions. Built with C# and Entity Framework in .NET, it provides endpoints to create, read, update, and delete data in a simple, relational manner.

## Features

- **User Management**: Create and manage users.
- **Bakery Management**: Create and manage food from bakery.
- **Transaction Management**: Record transactions between users and food from bakery.

## Technologies Used

- C#
- .NET Core
- Entity Framework Core

## Prerequisites

- .NET SDK (version 8.0)
- SQL Server or any compatible database
- A code editor (e.g., Visual Studio, VS Code)

# API Endpoints

## Bakery
- **GET** `/api/Bakery/AllFood` - Retrieve all food items from the bakery
- **POST** `/api/Bakery` - Create a new bakery item
- **PUT** `/api/Bakery` - Update an existing bakery item
- **DELETE** `/api/Bakery` - Delete a bakery item

## Order
- **GET** `/api/Order/all` - Retrieve all orders
- **GET** `/api/Order/ongoing` - Retrieve ongoing orders
- **GET** `/api/Order/cancelled` - Retrieve cancelled orders
- **GET** `/api/Order/completed` - Retrieve completed orders
- **POST** `/api/Order` - Create a new order
- **PUT** `/api/Order` - Update an existing order

## Users
- **GET** `/api/Users/AllUsers` - Retrieve all users
- **POST** `/api/Users` - Create a new user
- **PUT** `/api/Users` - Update an existing user
- **DELETE** `/api/Users` - Delete a user
