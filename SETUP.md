# 🛠️ Setup Guide for Policy Management API

This document explains how to **set up and run** the Policy Management API on your local machine.  

---

## ✅ Prerequisites

Before you start, make sure you have the following installed:

- **.NET 8 SDK** → [Download here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- **SQL Server 2019/2022** (or Azure SQL)
- **SQL Server Management Studio (SSMS)** → [Download here](https://aka.ms/ssmsfullsetup)
- **Git** → [Download here](https://git-scm.com/downloads)
- **Visual Studio 2022** (optional but recommended)

---

## 📥 1. Clone the Repository

```bash
git clone https://github.com/<your-username>/PolicyManagementAPI.git
cd PolicyManagementAPI/src/ShriramInsightAPI
```


---


## 🗄️ 2. Database Setup

1️⃣ Create the database

Open SQL Server Management Studio

Run the following SQL script to create the Shriram database:


```bash
git clone https://github.com/<your-username>/PolicyManagementAPI.git
cd PolicyManagementAPI/src/ShriramInsightAPI
```

2️⃣ Run the schema scripts

In SSMS, execute the table creation script:


```bash
-- Creates tbl_gi_policy_book
<copy your CREATE TABLE script here>
```

3️⃣ Add stored procedures

-> Run all the required stored procedure scripts:

-> GetAll_tbl_gi_policy_book

-> InsertInto_tbl_gi_policy_book

-> Update_tbl_gi_policy_book

-> SoftDelete_tbl_gi_policy_book

---


## ⚙️ 3. Configure appsettings.json

Open src/ShriramInsightAPI/appsettings.json and update the SQL Server connection string:


```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SQL_SERVER;Database=Shriram;Integrated Security=True;TrustServerCertificate=True;"
}
```

---


## ▶️ 4. Run the API

In the project folder:


```bash
dotnet restore
dotnet build
dotnet run
```

---


## 🔗 5. Test the API

You can test the API using:

-> Swagger UI (auto-generated docs)

-> Postman

-> Or any REST client

---


## 🙌 Need Help?

If you face any issues, feel free to raise a GitHub Issue or contact me on LinkedIn.


