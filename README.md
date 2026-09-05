# 🍔 GF Food - E-Commerce Food Web Application

<div align="center">

![ASP.NET MVC](https://img.shields.io/badge/ASP.NET%20MVC-5.2.7-blue?style=for-the-badge&logo=dotnet)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-purple?style=for-the-badge&logo=dotnet)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-5.0.0-green?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019-red?style=for-the-badge&logo=microsoftsqlserver)
![C#](https://img.shields.io/badge/C%23-8.0-blue?style=for-the-badge&logo=csharp)

**A food e-commerce web application built on ASP.NET MVC 5**

</div>

---

## 📋 Table of Contents

- [Project Overview](#-project-overview)
- [Key Features](#-key-features)
- [System Architecture](#-system-architecture)
- [Folder Structure](#-folder-structure)
- [Data Model](#-data-model)
- [Controllers & Routes](#-controllers--routes)
- [Authorization System](#-authorization-system)
- [Technologies Used](#-technologies-used)
- [System Requirements](#-system-requirements)
- [Installation Guide](#-installation-guide)
- [Database Configuration](#-database-configuration)
- [Default Accounts](#-default-accounts)

---

## 🎯 Project Overview

**GF Food** is a food e-commerce web application developed with **ASP.NET MVC 5** following the **MVC (Model - View - Controller)** pattern. It provides a simple online shop for food products with customer-facing pages and an admin panel for managing products, orders, and blog posts.

| Information | Details |
|---|---|
| **Project name** | GF Food - E-Commerce Food Web App |
| **Platform** | ASP.NET MVC 5 / .NET Framework 4.7.2 |
| **Database** | Microsoft SQL Server (`GF_DataBase`) |
| **ORM** | Entity Framework 5.0.0 (Database First) |
| **Languages** | C# 8.0, HTML5, CSS3, JavaScript |
| **Namespace** | `WebApp` |

---

## ✨ Key Features

### 👤 Customer
- ✅ Register a new account
- ✅ Login / Logout (Forms Authentication)
- ✅ View product list with **pagination** (10 products/page)
- ✅ **Search products** by name
- ✅ View product details
- ✅ Filter products by **category / product group**
- ✅ **Add to cart** (Session-based)
- ✅ **Manage cart**: update quantity, remove item, clear cart
- ✅ **Stock check** when updating cart
- ✅ **Checkout** with shipping information
- ✅ View Blog / News pages
- ✅ About and Support pages

### 🛠️ Admin / User
- ✅ Overview **Dashboard** with product statistics
- ✅ **Product management**: Create, Edit, Delete, List (with pagination & search)
- ✅ **Upload product images**
- ✅ **Order management**: View orders and order details
- ✅ **Blog management**
- ✅ Role-based authorization

---

## 🏗️ System Architecture

The application follows the standard **MVC (Model-View-Controller)** architecture used by ASP.NET:

```
┌─────────────────────────────────────────────────────────────┐
│                        CLIENT (Browser)                      │
└──────────────────────────┬──────────────────────────────────┘
                           │ HTTP Request
┌──────────────────────────▼──────────────────────────────────┐
│                    ROUTING (RouteConfig)                      │
│              {controller}/{action}/{id}                       │
└──────────────────────────┬──────────────────────────────────┘
                           │
          ┌────────────────┼────────────────┐
          │                │                │
┌─────────▼──────┐ ┌───────▼──────┐ ┌──────▼───────────┐
│  CONTROLLERS   │ │    MODELS    │ │     VIEWS         │
│                │ │              │ │                   │
│ - Account      │ │ - ProductInfo│ │ - Razor (.cshtml) │
│ - Home         │ │ - TheOrder   │ │ - Shared Layout   │
│ - Product      │ │ - User_Web   │ │ - Partial Views   │
│ - ShoppingCart │ │ - Blog       │ │                   │
│ - AdminPage    │ │ - Cart/Carts │ │                   │
│ - Crud         │ │ - ...        │ │                   │
└────────┬───────┘ └──────┬───────┘ └──────────────────-┘
         │                │
┌────────▼────────────────▼─────────────────────────────────┐
│              ENTITY FRAMEWORK (ORM)                        │
│              ProductDBContext                              │
└──────────────────────────┬────────────────────────────────┘
                           │
┌──────────────────────────▼────────────────────────────────┐
│                SQL SERVER - GF_DataBase                    │
└───────────────────────────────────────────────────────────┘
```

---

## 📁 Folder Structure

```
WebApp/
├── 📁 App_Start/
│   └── RouteConfig.cs              # URL routing configuration
│
├── 📁 Controllers/
│   ├── AccountController.cs        # Login, Register, Logout
│   ├── HomeController.cs           # Home, About, Blog
│   ├── ProductController.cs        # Product details & categories
│   ├── ShoppingCartController.cs   # Cart & checkout
│   ├── AdminPageController.cs      # Admin dashboard
│   └── CrudController.cs           # Product CRUD (Admin)
│
├── 📁 Models/
│   ├── ProductDataModel.edmx       # Entity Data Model (Database First)
│   ├── ProductDataModel.Context.cs # DbContext: ProductDBContext
│   ├── ProductInfo.cs              # Model: Product information
│   ├── TheOrder.cs                 # Model: Order
│   ├── OrderDetail.cs              # Model: Order detail
│   ├── User_Web.cs                 # Model: User
│   ├── RoleMaster.cs               # Model: Role
│   ├── UserRolesMapping.cs         # Model: User-Role mapping
│   ├── Blog.cs                     # Model: Blog post
│   ├── Pro_Category.cs             # Model: Product category
│   ├── Product_Group.cs            # Model: Product group
│   ├── Cart.cs                     # Model: Cart item
│   ├── Carts.cs                    # Model: Cart
│   ├── ContactFormModel.cs         # Model: Contact form
│   ├── UserModel.cs                # ViewModel: Login
│   └── UsersRoleProvider.cs        # Custom Role Provider
│
├── 📁 Views/
│   ├── 📁 Account/
│   │   ├── Login.cshtml            # Login page
│   │   ├── Register.cshtml         # Register page
│   │   └── Success.cshtml          # Registration success
│   ├── 📁 Home/
│   │   ├── Index.cshtml            # Home (product list)
│   │   ├── About.cshtml            # About page
│   │   ├── Blog.cshtml             # Blog list
│   │   └── Support.cshtml          # Support page
│   ├── 📁 Product/
│   │   ├── ProductCategory.cshtml  # Category list
│   │   └── ProductDetail.cshtml    # Product detail
│   ├── 📁 ShoppingCart/
│   │   ├── Index.cshtml            # Cart page
│   │   ├── CheckOut.cshtml         # Checkout
│   │   └── OrderSuccess.cshtml     # Order success
│   ├── 📁 AdminPage/
│   │   ├── Dashboard.cshtml        # Admin dashboard
│   │   ├── DSSanPham.cshtml        # Product list
│   │   ├── DSDonHang.cshtml        # Order list
│   │   └── DSBaiViet.cshtml        # Blog list
│   ├── 📁 Crud/
│   │   ├── Create.cshtml           # Create new product
│   │   ├── Edit.cshtml             # Edit product
│   │   ├── Details.cshtml          # Product details (Admin)
│   │   └── Delete.cshtml           # Delete confirmation
│   └── 📁 Shared/
│       └── (Layout & Partials)     # Shared layout and partials
│
├── 📁 Content/                     # Default MVC CSS & assets
├── 📁 Css/                         # Custom CSS
├── 📁 Scripts/                     # JavaScript
├── 📁 js/                          # Additional JavaScript
├── 📁 fonts/                       # Fonts
├── 📁 images/                      # Images (including product images)
│   └── 📁 Products/                # Uploaded product images
│
├── Global.asax                     # Application entry point
├── Global.asax.cs                  # Application lifecycle events
├── Web.config                      # Application configuration
├── Web.Debug.config                # Debug configuration
├── Web.Release.config              # Release configuration
├── packages.config                 # NuGet packages list
└── WebApp.csproj                   # Project file
```

---

## 🗄️ Data Model

The application uses **Entity Framework 5.0 (Database First)** with the `GF_DataBase` on SQL Server.

### Entity Relationship Diagram (ERD)

```
User_Web (1) ───── (*) UserRolesMapping (*) ───── (1) RoleMaster
  id_user                UserId / RoleId                ID / RollName
  ten_taikhoan
  matkhau
  SDT / hoTen

ProductInfo (1) ──── (*) OrderDetail (*) ──── (1) TheOrder
  id_sanpham               id_sanpham             id_donhang
  ten_sanpham              id_donhang             tenkhachhang
  giacu / giamoi           soluong                sdt / email
  hinh_sanpham             thanhtien              diachi / ngay
  soluong                                         Statuss
  id_loai_sanpham ──► Pro_Category
  id_nhomsp       ──► Product_Group

Blog (independent)
  idBlog / nameBlog / shortContent / mainContent
  dateCurrent / typeBlog / img / isPassing
```

### Table Details

| Table | Description | Main columns |
|------|--------|-----------------|
| `ProductInfo` | Products | id, name, old price, new price, image, quantity, category, group |
| `TheOrder` | Orders | id, order name, customer name, phone, email, address, date, status |
| `OrderDetail` | Order details | order id, product id, quantity, total price |
| `User_Web` | Accounts | id, username, password (MD5), phone, full name |
| `RoleMaster` | Roles | ID, role name (Admin/User/Customer) |
| `UserRolesMapping` | User-role mapping | UserId, RoleId |
| `Pro_Category` | Product category | category id, category name |
| `Product_Group` | Product group | group id, group name |
| `Blog` | Blog posts | id, title, short content, main content, date, type, image |

---

## 🔗 Controllers & Routes

### Routing Configuration

```
URL Pattern: {controller}/{action}/{id}
Default:     Home/Index
```

### AccountController — Authentication

| Route | Method | Description | Access |
|-------|--------|--------|---------|
| `/Account/Login` | GET | Show login form | Anonymous |
| `/Account/Login` | POST | Handle login (MD5 hash) | Anonymous |
| `/Account/Register` | GET | Show registration form | Anonymous |
| `/Account/Register` | POST | Create new account | Anonymous |
| `/Account/Logout` | GET | Logout (User) | Authenticated |
| `/Account/LogoutAdmin` | GET | Logout (Admin) | Authenticated |

### HomeController — Public pages

| Route | Method | Description |
|-------|--------|--------|
| `/Home/Index` | GET | Home: product list, search, pagination |
| `/Home/About` | GET | About page |
| `/Home/Support` | GET | Support / contact page |
| `/Home/Blog` | GET | Blog listing |

### ProductController — Products

| Route | Method | Description |
|-------|--------|--------|
| `/Product/ProductCategory?idnhom={id}` | GET | Filter products by group |
| `/Product/ProductDetail/{id}` | GET | View product details |

### ShoppingCartController — Cart

| Route | Method | Description |
|-------|--------|--------|
| `/ShoppingCart/Index` | GET | View cart |
| `/ShoppingCart/OrderNow/{id}` | GET | Add product to cart |
| `/ShoppingCart/RemoveItem/{id}` | GET | Remove one item from cart |
| `/ShoppingCart/UpdateCart` | POST | Update cart quantities |
| `/ShoppingCart/ClearCart` | GET | Clear entire cart |
| `/ShoppingCart/CheckOut` | GET | Checkout page |
| `/ShoppingCart/ProcessOrder` | POST | Process & save order |
| `/ShoppingCart/OrderSuccess` | GET | Order success page |

### AdminPageController — Administration

| Route | Method | Roles | Description |
|-------|--------|-----------|--------|
| `/AdminPage/Dashboard` | GET | Admin, User, Customer | Overview dashboard |
| `/AdminPage/DSSanPham` | GET | Admin, User, Customer | Product list + search |
| `/AdminPage/DSDonHang` | GET | Admin, User, Customer | Order list |
| `/AdminPage/DSBaiViet` | GET | Admin, User, Customer | Blog list |

### CrudController — Product management

| Route | Method | Roles | Description |
|-------|--------|-----------|--------|
| `/Crud/Details/{id}` | GET | Admin, User, Customer | View product details |
| `/Crud/Create` | GET | Admin, User | Show create form |
| `/Crud/Create` | POST | **Admin only** | Save new product + upload image |
| `/Crud/Edit/{id}` | GET | Admin, User | Show edit form |
| `/Crud/Edit/{id}` | POST | **Admin only** | Save product changes |
| `/Crud/Delete/{id}` | GET | **Admin only** | Confirm delete |
| `/Crud/Delete/{id}` | POST | **Admin only** | Perform product deletion |

---

## 🔐 Authorization System

The application uses **Forms Authentication** combined with a **Custom Role Provider** (`UsersRoleProvider`) configured in `Web.config`.

### Roles

| Role | Permissions |
|---------|-----------|
| **Admin** | Full access: view, create, edit, **delete** products; manage orders and blog posts |
| **User** | View, create, edit products; view orders (no delete) |
| **Customer** | View product list and dashboard; no CRUD operations |
| **Anonymous** | Public pages: home, about, blog, view products, cart |

### Authentication Flow

```
User requests a protected page
        │
        ▼
Not authenticated? ──► Redirect to /Account/Login
        │
        ▼
Enter username + password
        │
        ▼
MD5 hash password ──► Compare with DB
        │
   Success?
        │
   ┌────┴────┐
  Yes       No
   │          │
   ▼          ▼
SetAuthCookie  Show error
   │
   ├── Admin/User/Customer ──► /AdminPage/Dashboard
   └── Regular user         ──► /Home/Index
```

### Password Security

Passwords are hashed with **MD5** before storing in the database:

```csharp
public static string GetMD5(string str)
{
    MD5 md5 = new MD5CryptoServiceProvider();
    byte[] fromData = Encoding.UTF8.GetBytes(str);
    byte[] targetData = md5.ComputeHash(fromData);
    // Convert byte array to hex string...
}
```

> ⚠️ **Security note**: MD5 is not recommended for production. Consider upgrading to BCrypt or PBKDF2.

---

## 🛒 Cart Workflow

The shopping cart is stored in **ASP.NET Session** (no login required):

```
User views products
        │
        ▼
Click "Add to cart" ──► /ShoppingCart/OrderNow/{id}
        │
        ▼
Check Session["Carts"]
        │
  Already in cart?
  ┌─────┴──────┐
 Yes           No
  │              │
  ▼              ▼
Increase qty   Add new item to List<Carts>
        │
        ▼
View cart (/ShoppingCart/Index)
        │
Update quantities? ──► Check stock
        │                    │
        │              Not enough? ──► Show error
        ▼
Checkout (/ShoppingCart/CheckOut)
        │
Enter info (name, phone, email, address)
        │
        ▼
POST /ShoppingCart/ProcessOrder
        │
Save TheOrder + OrderDetails to DB
        │
Clear Session cart
        │
        ▼
/ShoppingCart/OrderSuccess
```

---

## 💻 Technologies Used

### Backend

| Technology | Version | Purpose |
|-----------|-----------|---------|
| ASP.NET MVC | 5.2.7 | Main web framework |
| .NET Framework | 4.7.2 | Runtime |
| Entity Framework | 5.0.0 | ORM - Database First |
| C# | 8.0 | Programming language |
| PagedList | 1.17.0 | List pagination |
| PagedList.Mvc | 4.5.0 | MVC pagination helper |
| Forms Authentication | Built-in | User authentication |
| Custom RoleProvider | Custom | Role-based authorization |
| MD5CryptoServiceProvider | Built-in | Password hashing |

### Frontend

| Technology | Purpose |
|-----------|---------|
| Razor View Engine | Template engine (.cshtml) |
| HTML5 | Page structure |
| CSS3 | Styling |
| JavaScript | Client interactions |
| Bootstrap | Responsive layout |

### Database

| Component | Details |
|-----------|---------|
| DBMS | Microsoft SQL Server |
| Database name | GF_DataBase |
| Connection | Integrated Security (Windows Auth) |
| Provider | System.Data.EntityClient |

---

## ⚙️ System Requirements

### Development

- **OS**: Windows 10/11
- **IDE**: Visual Studio 2019 / 2022
- **Runtime**: .NET Framework 4.7.2
- **Database**: SQL Server 2016+ (or SQL Server Express)
- **RAM**: Minimum 4GB (recommended 8GB+)

### Runtime

- **Web Server**: IIS 8.0+ or IIS Express
- **SQL Server**: 2016 or newer
- **.NET Framework**: 4.7.2 or newer

---

## 🚀 Installation Guide

### Step 1: Clone / Download the project

```bash
git clone <repository-url>
# or unzip the project zip into your desired folder
```

### Step 2: Open the project in Visual Studio

1. Open Visual Studio
2. Choose **File → Open → Project/Solution**
3. Select `WebApp.csproj` or the `.sln` file in the project folder

### Step 3: Restore NuGet Packages

```bash
# In Package Manager Console (Tools → NuGet Package Manager → Package Manager Console)
Update-Package -reinstall

# Or right-click the Solution → Restore NuGet Packages
```

### Step 4: Configure the Database (see next section)

### Step 5: Build & Run

- Press **F5** to run the app in Debug mode
- Or **Ctrl+F5** to run without debugging
- The app will open at `http://localhost:{port}/`

---

## 🗃️ Database Configuration

### Connection String (Web.config)

```xml
<connectionStrings>
  <add name="ProductDBContext"
       connectionString="metadata=res://*/Models.ProductDataModel.csdl|
                         res://*/Models.ProductDataModel.ssdl|
                         res://*/Models.ProductDataModel.msl;
                         provider=System.Data.SqlClient;
                         provider connection string=&quot;
                         data source=.;
                         initial catalog=GF_DataBase;
                         integrated security=True;
                         MultipleActiveResultSets=True;
                         App=EntityFramework&quot;"
       providerName="System.Data.EntityClient" />
</connectionStrings>
```

### Database Setup

**1. Open SQL Server Management Studio (SSMS)**

**2. Create the `GF_DataBase` database:**

```sql
CREATE DATABASE GF_DataBase;
```

**3. Run the table creation script:**

```sql
USE GF_DataBase;

CREATE TABLE Product_Group (
    id_nhomsp NVARCHAR(50) PRIMARY KEY,
    tennhomsp NVARCHAR(200)
);

CREATE TABLE Pro_Category (
    id_loai_sanpham NVARCHAR(50) PRIMARY KEY,
    tenloaisp NVARCHAR(200)
);

CREATE TABLE ProductInfo (
    id_sanpham INT IDENTITY(1,1) PRIMARY KEY,
    ten_sanpham NVARCHAR(200),
    giacu FLOAT,
    giamoi FLOAT,
    hinh_sanpham NVARCHAR(500),
    hinh_quatang NVARCHAR(500),
    thongtin_km NVARCHAR(MAX),
    thongtin_soluong NVARCHAR(MAX),
    id_loai_sanpham NVARCHAR(50),
    id_nhomsp NVARCHAR(50),
    soluong INT,
    FOREIGN KEY (id_loai_sanpham) REFERENCES Pro_Category(id_loai_sanpham),
    FOREIGN KEY (id_nhomsp) REFERENCES Product_Group(id_nhomsp)
);

CREATE TABLE User_Web (
    id_user INT IDENTITY(1,1) PRIMARY KEY,
    ten_taikhoan NVARCHAR(100),
    matkhau NVARCHAR(200),
    SDT NVARCHAR(20),
    hoTen NVARCHAR(200)
);

CREATE TABLE RoleMaster (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    RollName NVARCHAR(100)
);

CREATE TABLE UserRolesMapping (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT,
    RoleId INT,
    FOREIGN KEY (UserId) REFERENCES User_Web(id_user),
    FOREIGN KEY (RoleId) REFERENCES RoleMaster(ID)
);

CREATE TABLE TheOrder (
    id_donhang INT IDENTITY(1,1) PRIMARY KEY,
    tendondang NVARCHAR(200),
    ngay DATETIME,
    hinhthuc_thanhtoan NVARCHAR(100),
    Statuss NVARCHAR(100),
    tenkhachhang NVARCHAR(200),
    sdt NVARCHAR(20),
    email NVARCHAR(200),
    diachi NVARCHAR(500)
);

CREATE TABLE OrderDetail (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_donhang INT,
    id_sanpham INT,
    soluong INT,
    thanhtien FLOAT,
    FOREIGN KEY (id_donhang) REFERENCES TheOrder(id_donhang),
    FOREIGN KEY (id_sanpham) REFERENCES ProductInfo(id_sanpham)
);

CREATE TABLE Blog (
    idBlog NVARCHAR(50) PRIMARY KEY,
    nameBlog NVARCHAR(500),
    shortContent NVARCHAR(MAX),
    mainContent NVARCHAR(MAX),
    dateCurrent DATETIME,
    typeBlog NVARCHAR(100),
    img NVARCHAR(500),
    isPassing BIT
);
```

**4. Change the `data source`** in `Web.config` if SQL Server is not on localhost:

```xml
data source=YOUR_SQL_SERVER_NAME;  <!-- Replace "." with your server name -->
```

---

## 👥 Default Accounts

Add sample data to the database:

```sql
-- Add Roles
INSERT INTO RoleMaster (RollName) VALUES ('Admin');
INSERT INTO RoleMaster (RollName) VALUES ('User');
INSERT INTO RoleMaster (RollName) VALUES ('Customer');

-- Add Admin account (password: admin123)
-- MD5("admin123") = 0192023a7bbd73250516f069df18b500
INSERT INTO User_Web (ten_taikhoan, matkhau, hoTen, SDT)
VALUES ('Admin', '0192023a7bbd73250516f069df18b500', 'Administrator', '0900000000');

-- Assign Admin role
INSERT INTO UserRolesMapping (UserId, RoleId)
VALUES (1, 1);
```

| Account | Password | Role | Redirect after login |
|-----------|----------|---------|----------------------|
| `Admin` | *(MD5 hash)* | Admin | `/AdminPage/Dashboard` |
| `User` | *(MD5 hash)* | User | `/AdminPage/Dashboard` |
| `Customer` | *(MD5 hash)* | Customer | `/AdminPage/Dashboard` |
| Other accounts | *(MD5 hash)* | - | `/Home/Index` |

---

## 📂 Upload Folder

Product images are uploaded to:

```
~/images/Products/
```

Make sure this folder **exists** and IIS has **write** permission to it.

---

## 🐛 Common Issues

| Issue | Cause | Solution |
|--------|-------------|-----------|
| Database connection error | Wrong connection string | Check `Web.config`, ensure SQL Server is running |
| Cannot upload images | Missing write permission | Grant Write permission to IIS_IUSRS on `~/images/Products/` |
| 404 error after login | Route mismatch | Check `RouteConfig.cs` |
| Session cart lost | Session timeout | Increase `sessionState timeout` in `Web.config` |
| Authorization error | RoleProvider not loaded | Check `roleManager` configuration in `Web.config` |

---

## 📝 Development Notes

- **ORM**: Using **Database First** — regenerate the EDMX when DB schema changes
- **Session**: Cart is stored in `Session["Carts"]` — will be lost on server restart or session expiration
- **Pagination**: Uses **PagedList.Mvc** with default page size **10 items**
- **Image upload**: Only file name is stored, not full path
- **Anti-Forgery**: Enabled for important POST actions (`[ValidateAntiForgeryToken]`)

---

<div align="center">

**© 2024 GF Food - E-Commerce Food Web Application**

*Built with ASP.NET MVC 5 | .NET Framework 4.7.2 | SQL Server*

</div>
