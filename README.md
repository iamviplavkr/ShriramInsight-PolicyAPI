# ShriramInsight Policy API  

A **.NET 8 Web API** developed during my internship at **Shriram Insight Share Brokers**.  
This project provides a secure and scalable **Policy Management API** using **C#, SQL Server, and ADO.NET** with stored procedures.  

---

## 🚀 Features  

✅ RESTful API using ASP.NET Core  
✅ CRUD Operations via **Stored Procedures** (No Entity Framework)  
✅ **Soft Delete** Implementation using `IsActive` flag  
✅ **Audit Trail** with `CreatedBy`, `CreatedWhen`, `UpdatedBy`, `UpdatedWhen` fields  
✅ SQL Server database with optimized indexes  
✅ Secure connection strings via `appsettings.json`  
✅ Modular architecture with separate controllers for each table  


---

## 🛠️ Tech Stack
- **Backend**: ASP.NET Core 8 Web API  
- **Database**: Microsoft SQL Server  
- **ORM**: ADO.NET (Stored Procedure Based)  
- **CI/CD**: GitHub Actions  
- **Version Control**: Git & GitHub  

---

## 📌 Key API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET    | `/api/TblGiPolicyBook` | Fetch all active policies |
| POST   | `/api/TblGiPolicyBook` | Insert a new policy |
| PUT    | `/api/TblGiPolicyBook/{orderNo}` | Update existing policy details |
| DELETE | `/api/TblGiPolicyBook/{orderNo}` | Soft delete a policy |


---

## ▶️ How to Run Locally

1️⃣ Clone the repository  
```bash
git clone https://github.com/<your-username>/PolicyManagementAPI.git
cd PolicyManagementAPI/src/ShriramInsightAPI
```

2️⃣ Update `appsettings.json` with your SQL Server connection string

3️⃣ Run the API
```bash
dotnet restore
dotnet run
```

---


## ⭐ If you like this project, consider giving it a star!


**1. Other Supporting Files**

- **.gitignore** → Use default for .NET projects (generated by GitHub)  
- **LICENSE** → Use MIT License  
- **CONTRIBUTING.md** → Simple guidelines for contribution  
- **docs/** → Put all screenshots & internship report  

---

**2. Push Everything to GitHub**

Once your repo is ready locally:  

```bash
# Initialize git
git init

# Add remote
git remote add origin https://github.com/<your-username>/PolicyManagementAPI.git

# Stage & commit
git add .
git commit -m "Initial commit - Policy Management API"

# Push to GitHub
git branch -M main
git push -u origin main
```
