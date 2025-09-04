---

# 📘 Employee Resource Management System (ERMS)

## 📖 Project Overview

The **Employee Resource Management System (ERMS)** is a centralized backend application built with **ASP.NET** and **SQL Server** to manage employees, projects, clients, and resource allocations.
It automates HR and project management workflows, ensures optimal resource utilization, and provides data-driven insights.

---

## 🎯 Objectives

* Maintain a **centralized employee and project repository**.
* Streamline **resource allocation** across projects.
* Automate **employee onboarding workflows**.
* Provide **dashboards & reporting** for employees, projects, and accounts.
* Manage **master data** like accounts, skills, practices, locations, etc.

---

## 🏗️ Tech Stack

* **Backend:** ASP.NET, C#
* **ORM/Data Access:** ADO.NET, Entity Framework
* **Database:** Microsoft SQL Server
* **Architecture:** N-Tier (Presentation → BLL → DAL → Database)
* **Testing:** Unit Testing with MSTest/NUnit

---

## ⚙️ System Architecture

* **Business Logic Layer (BLL):** Implements workflows and rules.
* **Data Access Layer (DAL):** Executes stored procedures via ADO.NET.
* **Database Layer:** SQL Server with stored procedures for all CRUD operations.

---

## 🗄️ Database Design

### Master Tables

* **Accounts** → Stores client info
* **Employees** → Employee personal & professional details
* **Practices & SubPractices** → Organization divisions
* **SkillSets** → Employee skills
* **ProjectStatus / ProjectCostingTypes** → Project configurations

### Transaction Tables

* **Projects** → Project details
* **EmployeeAllocations** → Mapping of employees to projects
* **Tasks & TimeSheetEntries** → Timesheet and task tracking
* **SignIns** → Employee onboarding logs

📌 Relationships:

* `Employees ↔ EmployeeAllocations ↔ Projects`
* `Projects ↔ Accounts / Practices`
* `TimeSheet ↔ Tasks ↔ Employees`

---

## 🚀 Core Features

### 👤 Employee Management

* Add/Edit/Delete employee
* Auto-generate **EmployeeCode** (e.g., EMP0001)
* Soft delete with audit tracking

### 📂 Project & Allocation Management

* Create and manage projects
* Allocate employees to projects
* Track billable vs. non-billable allocations

### 🏢 Account Management

* Manage client accounts
* Avoid duplicate account creation

### 🛠️ Master Data Management

* Country, Practice, Sub-Practice, Skills
* CRUD operations via stored procedures

### 📊 Dashboards & Reports

* Employee counts (Active/Inactive)
* Account counts (Active/Inactive)
* Allocation statistics (Utilized/Bench)

---

## 🔒 Non-Functional Requirements

* **Security:** Stored procedures to prevent SQL Injection
* **Performance:** Indexing + optimized queries
* **Auditability:** `CreatedBy`, `CreatedOn`, `ModifiedBy`, `ModifiedOn` tracking
* **Data Integrity:** Soft delete (`IsDeleted`) for history retention

---

## 📌 Assumptions

* Internal use only
* Authentication system (RBAC) to be implemented separately
* Timesheet module partially implemented

---

## 🔮 Future Enhancements

* 🔑 Authentication & Role-Based Access Control (Admin, HR, Manager, Employee)
* 🕒 Complete Timesheet Approval Workflow
* 📑 Advanced Reporting (Bench Strength, Project Profitability)
* 🔗 REST APIs for Payroll & Finance Integration
* 🎨 Modern Frontend with React/Angular + Web API

---

## 🛠️ How to Run (Backend Setup)

1. **Clone Repository**

   ```bash
   git clone https://github.com/your-username/ERMS.git
   cd ERMS
   ```

2. **Database Setup**

   * Create database `ERMS_Db` in SQL Server
   * Run provided `schema.sql` & `storedProcedures.sql` scripts

3. **Configure Connection String**

   * Update `appsettings.json` or `Web.config`:

   ```json
   "ConnectionStrings": {
     "ERMS_Db": "Server="";Database=ERMS_Db;Trusted_Connection=True;"
   }
   ```

4. **Run Application**

   * Build & run from Visual Studio
   * Unit test with MSTest/NUnit

---

## 📂 Project Structure

```
ERMS/

```

---

## 👨‍💻 Contributors

* **Your Name** – Backend Developer

---

