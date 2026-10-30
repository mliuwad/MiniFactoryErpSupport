
# Mini Factory ERP Support System

A desktop application developed to support basic material and warehouse inventory management using C# WinForms and Oracle Database.

## 1. Overview

Mini Factory ERP Support System is a personal learning project that simulates basic inventory operations in a manufacturing environment.

The application supports material management, stock-in and stock-out transactions, current stock tracking, and transaction history.

## 2. Features

### 2.1. Material Management

- View material list.
- Add new materials.
- Update material information.
- Search materials.
- Manage material status and reorder levels.

### 2.2. Warehouse Inventory Management

- Select materials and warehouses.
- Process stock-in transactions.
- Process stock-out transactions.
- View current inventory quantities.
- View stock transaction history.
- Validate stock availability before stock-out operations.

### 2.3. Database Operations

- Connect C# WinForms to Oracle Database.
- Use SQL queries and PL/SQL stored procedures.
- Use database transactions for data consistency.
- Record inventory transaction history.

## 3. Technology Stack

| Technology | Purpose |
|---|---|
| C# | Application programming language |
| .NET 8 | Application framework |
| Windows Forms | Desktop user interface |
| Oracle Database | Relational database |
| SQL | Data querying and manipulation |
| PL/SQL | Stored procedure implementation |
| Oracle Managed Data Access | Oracle connectivity |
| Visual Studio 2022 | Development environment |

## 4. Database Design

The application uses four main tables:

| Table | Description |
|---|---|
| MATERIALS | Stores material information |
| WAREHOUSES | Stores warehouse information |
| STOCK_BALANCES | Stores current stock quantities |
| STOCK_TRANSACTIONS | Records stock-in and stock-out transactions |

### Stored Procedure

`SP_STOCK_MOVEMENT` handles inventory transactions.

Main responsibilities:

- Validate transaction type and quantity.
- Lock the relevant stock balance using `SELECT FOR UPDATE`.
- Calculate the updated stock quantity.
- Prevent stock-out operations exceeding available inventory.
- Update stock balances.
- Insert transaction history.

Transaction commit and rollback are managed by the application.

## 5. Project Structure

```text
MiniFactoryErpSupport/
│
├── database/
│   ├── 01_schema.sql
│   ├── 02_stock_movement.sql
│   └── 03_sample_data.sql
│
├── FactoryErpSupport.csproj
├── FactoryErpSupport.sln
├── Form1.cs
├── Form1.Designer.cs
├── Form1.resx
├── StockMovementForm.cs
├── StockMovementForm.Designer.cs
├── StockMovementForm.resx
├── OracleDb.cs
├── Program.cs
└── .gitignore
```

## 6. Installation and Setup

### Requirements

- Windows
- Visual Studio 2022
- .NET 8 SDK
- Oracle Database with PL/SQL support

### Step 1: Configure Oracle Database

Create an Oracle schema named `ERP_APP`, then connect using that account.

Run the following SQL scripts in order:

1. `database/01_schema.sql` - Create database tables and constraints.
2. `database/02_stock_movement.sql` - Create the stock movement stored procedure.
3. `database/03_sample_data.sql` - Insert sample materials, warehouse, and initial stock balances.

### Step 2: Configure Database Connection

The application reads its database connection string from the Windows environment variable:

`FACTORY_ERP_ORACLE_CONNECTION`

Open PowerShell and execute:

```powershell
[Environment]::SetEnvironmentVariable(
    "FACTORY_ERP_ORACLE_CONNECTION",
    "User Id=ERP_APP;Password=YOUR_PASSWORD;Data Source=localhost:1521/FREEPDB1;",
    "User"
)
```

Replace `YOUR_PASSWORD` with your own Oracle database password.

Restart Visual Studio after configuring the environment variable.

### Step 3: Run the Application

1. Open `FactoryErpSupport.sln` in Visual Studio 2022.
2. Restore NuGet packages if required.
3. Build the solution.
4. Run the application.

## 7. Sample Data

The sample database script provides:

- One sample warehouse: `WH01`.
- Four sample materials: `MAT001` to `MAT004`.
- Initial stock balances for inventory testing.

These records are for demonstration purposes only.

## 8. Notes

This is a personal learning project developed to practice desktop application development, Oracle database connectivity, SQL, PL/SQL, and basic ERP inventory workflows.
