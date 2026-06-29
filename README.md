# 🍔 GF Food - Ứng Dụng Thương Mại Điện Tử Thực Phẩm

<div align="center">

![ASP.NET MVC](https://img.shields.io/badge/ASP.NET%20MVC-5.2.7-blue?style=for-the-badge&logo=dotnet)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-purple?style=for-the-badge&logo=dotnet)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-5.0.0-green?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019-red?style=for-the-badge&logo=microsoftsqlserver)
![C#](https://img.shields.io/badge/C%23-8.0-blue?style=for-the-badge&logo=csharp)

**Ứng dụng web thương mại điện tử bán thực phẩm được xây dựng trên nền tảng ASP.NET MVC 5**

</div>

---

## 📋 Mục Lục

- [Tổng Quan Dự Án](#-tổng-quan-dự-án)
- [Tính Năng Chính](#-tính-năng-chính)
- [Kiến Trúc Hệ Thống](#-kiến-trúc-hệ-thống)
- [Cấu Trúc Thư Mục](#-cấu-trúc-thư-mục)
- [Mô Hình Dữ Liệu](#-mô-hình-dữ-liệu)
- [Controllers & Routes](#-controllers--routes)
- [Hệ Thống Phân Quyền](#-hệ-thống-phân-quyền)
- [Công Nghệ Sử Dụng](#-công-nghệ-sử-dụng)
- [Yêu Cầu Hệ Thống](#-yêu-cầu-hệ-thống)
- [Hướng Dẫn Cài Đặt](#-hướng-dẫn-cài-đặt)
- [Cấu Hình Database](#-cấu-hình-database)
- [Tài Khoản Mặc Định](#-tài-khoản-mặc-định)

---

## 🎯 Tổng Quan Dự Án

**GF Food** là một ứng dụng web thương mại điện tử chuyên bán thực phẩm, được phát triển bằng **ASP.NET MVC 5** theo mô hình **MVC (Model - View - Controller)**. Ứng dụng cung cấp đầy đủ các chức năng từ hiển thị sản phẩm, quản lý giỏ hàng, đặt hàng cho đến trang quản trị dành cho Admin.

| Thông tin | Chi tiết |
|---|---|
| **Tên dự án** | GF Food - E-Commerce Food Web App |
| **Nền tảng** | ASP.NET MVC 5 / .NET Framework 4.7.2 |
| **Cơ sở dữ liệu** | Microsoft SQL Server (`GF_DataBase`) |
| **ORM** | Entity Framework 5.0.0 (Database First) |
| **Ngôn ngữ** | C# 8.0, HTML5, CSS3, JavaScript |
| **Namespace** | `WebApp` |

---

## ✨ Tính Năng Chính

### 👤 Người Dùng (Customer)
- ✅ Đăng ký tài khoản mới
- ✅ Đăng nhập / Đăng xuất (Forms Authentication)
- ✅ Xem danh sách sản phẩm với **phân trang** (10 sản phẩm/trang)
- ✅ **Tìm kiếm sản phẩm** theo tên
- ✅ Xem chi tiết sản phẩm
- ✅ Lọc sản phẩm theo **danh mục / nhóm sản phẩm**
- ✅ **Thêm vào giỏ hàng** (Session-based)
- ✅ **Quản lý giỏ hàng**: Cập nhật số lượng, xóa sản phẩm, xóa toàn bộ giỏ
- ✅ **Kiểm tra tồn kho** khi cập nhật giỏ hàng
- ✅ **Đặt hàng** (Checkout) với thông tin giao hàng
- ✅ Xem trang Blog / Tin tức
- ✅ Trang Giới thiệu (About) và Hỗ trợ (Support)

### 🛠️ Quản Trị Viên (Admin/User)
- ✅ **Dashboard** tổng quan với thống kê sản phẩm
- ✅ **Quản lý sản phẩm**: Thêm, sửa, xóa, xem danh sách (có phân trang & tìm kiếm)
- ✅ **Upload hình ảnh** sản phẩm
- ✅ **Quản lý đơn hàng**: Xem danh sách đơn hàng và chi tiết
- ✅ **Quản lý bài viết** (Blog)
- ✅ Phân quyền theo vai trò (Role-based Authorization)

---

## 🏗️ Kiến Trúc Hệ Thống

Ứng dụng tuân theo mô hình **MVC (Model-View-Controller)** chuẩn của ASP.NET:

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

## 📁 Cấu Trúc Thư Mục

```
WebApp/
├── 📁 App_Start/
│   └── RouteConfig.cs              # Cấu hình routing URL
│
├── 📁 Controllers/
│   ├── AccountController.cs        # Đăng nhập, đăng ký, đăng xuất
│   ├── HomeController.cs           # Trang chủ, giới thiệu, blog
│   ├── ProductController.cs        # Chi tiết & danh mục sản phẩm
│   ├── ShoppingCartController.cs   # Giỏ hàng & đặt hàng
│   ├── AdminPageController.cs      # Trang quản trị (dashboard)
│   └── CrudController.cs           # CRUD sản phẩm (Admin)
│
├── 📁 Models/
│   ├── ProductDataModel.edmx       # Entity Data Model (Database First)
│   ├── ProductDataModel.Context.cs # DbContext: ProductDBContext
│   ├── ProductInfo.cs              # Model: Thông tin sản phẩm
│   ├── TheOrder.cs                 # Model: Đơn hàng
│   ├── OrderDetail.cs              # Model: Chi tiết đơn hàng
│   ├── User_Web.cs                 # Model: Người dùng
│   ├── RoleMaster.cs               # Model: Vai trò (Role)
│   ├── UserRolesMapping.cs         # Model: Ánh xạ User-Role
│   ├── Blog.cs                     # Model: Bài viết
│   ├── Pro_Category.cs             # Model: Loại sản phẩm
│   ├── Product_Group.cs            # Model: Nhóm sản phẩm
│   ├── Cart.cs                     # Model: Item trong giỏ hàng
│   ├── Carts.cs                    # Model: Giỏ hàng
│   ├── ContactFormModel.cs         # Model: Form liên hệ
│   ├── UserModel.cs                # ViewModel: Đăng nhập
│   └── UsersRoleProvider.cs        # Custom Role Provider
│
├── 📁 Views/
│   ├── 📁 Account/
│   │   ├── Login.cshtml            # Trang đăng nhập
│   │   ├── Register.cshtml         # Trang đăng ký
│   │   └── Success.cshtml          # Đăng ký thành công
│   ├── 📁 Home/
│   │   ├── Index.cshtml            # Trang chủ (danh sách sản phẩm)
│   │   ├── About.cshtml            # Trang giới thiệu
│   │   ├── Blog.cshtml             # Trang blog
│   │   └── Support.cshtml          # Trang hỗ trợ
│   ├── 📁 Product/
│   │   ├── ProductCategory.cshtml  # Danh sách theo danh mục
│   │   └── ProductDetail.cshtml    # Chi tiết sản phẩm
│   ├── 📁 ShoppingCart/
│   │   ├── Index.cshtml            # Giỏ hàng
│   │   ├── CheckOut.cshtml         # Thanh toán
│   │   └── OrderSuccess.cshtml     # Đặt hàng thành công
│   ├── 📁 AdminPage/
│   │   ├── Dashboard.cshtml        # Tổng quan quản trị
│   │   ├── DSSanPham.cshtml        # Danh sách sản phẩm
│   │   ├── DSDonHang.cshtml        # Danh sách đơn hàng
│   │   └── DSBaiViet.cshtml        # Danh sách bài viết
│   ├── 📁 Crud/
│   │   ├── Create.cshtml           # Thêm sản phẩm mới
│   │   ├── Edit.cshtml             # Chỉnh sửa sản phẩm
│   │   ├── Details.cshtml          # Xem chi tiết sản phẩm (Admin)
│   │   └── Delete.cshtml           # Xác nhận xóa sản phẩm
│   └── 📁 Shared/
│       └── (Layout & Partials)     # Layout chung, navigation
│
├── 📁 Content/                     # CSS và assets mặc định MVC
├── 📁 Css/                         # CSS tùy chỉnh
├── 📁 Scripts/                     # JavaScript
├── 📁 js/                          # JavaScript bổ sung
├── 📁 fonts/                       # Font chữ
├── 📁 images/                      # Hình ảnh (kể cả ảnh sản phẩm)
│   └── 📁 Products/                # Ảnh upload của sản phẩm
│
├── Global.asax                     # Application entry point
├── Global.asax.cs                  # Application lifecycle events
├── Web.config                      # Cấu hình ứng dụng
├── Web.Debug.config                # Cấu hình Debug
├── Web.Release.config              # Cấu hình Release
├── packages.config                 # Danh sách NuGet packages
└── WebApp.csproj                   # Project file
```

---

## 🗄️ Mô Hình Dữ Liệu

Ứng dụng sử dụng **Entity Framework 5.0 theo hướng Database First** với cơ sở dữ liệu `GF_DataBase` trên SQL Server.

### Sơ Đồ Quan Hệ (ERD)

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

Blog (độc lập)
  idBlog / nameBlog / shortContent / mainContent
  dateCurrent / typeBlog / img / isPassing
```

### Chi Tiết Các Bảng

| Bảng | Mô tả | Các trường chính |
|------|--------|-----------------|
| `ProductInfo` | Sản phẩm | id, tên, giá cũ, giá mới, hình ảnh, số lượng, loại, nhóm |
| `TheOrder` | Đơn hàng | id, tên đơn, tên KH, SĐT, email, địa chỉ, ngày, trạng thái |
| `OrderDetail` | Chi tiết đơn | id đơn hàng, id sản phẩm, số lượng, thành tiền |
| `User_Web` | Tài khoản | id, tên tài khoản, mật khẩu (MD5), SĐT, họ tên |
| `RoleMaster` | Vai trò | ID, tên vai trò (Admin/User/Customer) |
| `UserRolesMapping` | Ánh xạ quyền | UserId, RoleId |
| `Pro_Category` | Loại sản phẩm | id loại, tên loại |
| `Product_Group` | Nhóm sản phẩm | id nhóm, tên nhóm |
| `Blog` | Bài viết | id, tiêu đề, tóm tắt, nội dung, ngày, loại, hình |

---

## 🔗 Controllers & Routes

### Routing Configuration

```
URL Pattern: {controller}/{action}/{id}
Default:     Home/Index
```

### AccountController — Xác thực người dùng

| Route | Method | Mô tả | Yêu cầu |
|-------|--------|--------|---------|
| `/Account/Login` | GET | Hiển thị form đăng nhập | Ẩn danh |
| `/Account/Login` | POST | Xử lý đăng nhập (MD5 hash) | Ẩn danh |
| `/Account/Register` | GET | Hiển thị form đăng ký | Ẩn danh |
| `/Account/Register` | POST | Tạo tài khoản mới | Ẩn danh |
| `/Account/Logout` | GET | Đăng xuất (User) | Đã đăng nhập |
| `/Account/LogoutAdmin` | GET | Đăng xuất (Admin) | Đã đăng nhập |

### HomeController — Trang công khai

| Route | Method | Mô tả |
|-------|--------|--------|
| `/Home/Index` | GET | Trang chủ: danh sách sản phẩm, tìm kiếm, phân trang |
| `/Home/About` | GET | Trang giới thiệu |
| `/Home/Support` | GET | Trang hỗ trợ / liên hệ |
| `/Home/Blog` | GET | Danh sách bài viết |

### ProductController — Sản phẩm

| Route | Method | Mô tả |
|-------|--------|--------|
| `/Product/ProductCategory?idnhom={id}` | GET | Lọc sản phẩm theo nhóm |
| `/Product/ProductDetail/{id}` | GET | Xem chi tiết sản phẩm |

### ShoppingCartController — Giỏ hàng

| Route | Method | Mô tả |
|-------|--------|--------|
| `/ShoppingCart/Index` | GET | Xem giỏ hàng |
| `/ShoppingCart/OrderNow/{id}` | GET | Thêm sản phẩm vào giỏ |
| `/ShoppingCart/RemoveItem/{id}` | GET | Xóa 1 sản phẩm khỏi giỏ |
| `/ShoppingCart/UpdateCart` | POST | Cập nhật số lượng giỏ hàng |
| `/ShoppingCart/ClearCart` | GET | Xóa toàn bộ giỏ hàng |
| `/ShoppingCart/CheckOut` | GET | Trang thanh toán |
| `/ShoppingCart/ProcessOrder` | POST | Xử lý & lưu đơn hàng |
| `/ShoppingCart/OrderSuccess` | GET | Trang đặt hàng thành công |

### AdminPageController — Quản trị

| Route | Method | Phân quyền | Mô tả |
|-------|--------|-----------|--------|
| `/AdminPage/Dashboard` | GET | Admin, User, Customer | Dashboard tổng quan |
| `/AdminPage/DSSanPham` | GET | Admin, User, Customer | Danh sách sản phẩm + tìm kiếm |
| `/AdminPage/DSDonHang` | GET | Admin, User, Customer | Danh sách đơn hàng |
| `/AdminPage/DSBaiViet` | GET | Admin, User, Customer | Danh sách bài viết |

### CrudController — Quản lý sản phẩm

| Route | Method | Phân quyền | Mô tả |
|-------|--------|-----------|--------|
| `/Crud/Details/{id}` | GET | Admin, User, Customer | Xem chi tiết sản phẩm |
| `/Crud/Create` | GET | Admin, User | Hiển thị form thêm mới |
| `/Crud/Create` | POST | **Admin only** | Lưu sản phẩm mới + upload ảnh |
| `/Crud/Edit/{id}` | GET | Admin, User | Hiển thị form chỉnh sửa |
| `/Crud/Edit/{id}` | POST | **Admin only** | Lưu thay đổi sản phẩm |
| `/Crud/Delete/{id}` | GET | **Admin only** | Xác nhận xóa |
| `/Crud/Delete/{id}` | POST | **Admin only** | Thực hiện xóa sản phẩm |

---

## 🔐 Hệ Thống Phân Quyền

Ứng dụng sử dụng **Forms Authentication** kết hợp với **Custom Role Provider** (`UsersRoleProvider`) được tích hợp vào `Web.config`.

### Các Vai Trò (Roles)

| Vai trò | Quyền hạn |
|---------|-----------|
| **Admin** | Toàn quyền: xem, thêm, sửa, **xóa** sản phẩm; quản lý đơn hàng, bài viết |
| **User** | Xem, thêm, sửa sản phẩm; xem đơn hàng (không được xóa) |
| **Customer** | Chỉ xem danh sách, dashboard; không thao tác CRUD |
| **Ẩn danh** | Trang chủ, giới thiệu, blog, xem sản phẩm, giỏ hàng |

### Luồng Xác Thực

```
Người dùng truy cập trang bảo vệ
        │
        ▼
Chưa đăng nhập? ──► Redirect đến /Account/Login
        │
        ▼
Nhập tên tài khoản + mật khẩu
        │
        ▼
MD5 hash mật khẩu ──► So sánh với DB
        │
   Thành công?
        │
   ┌────┴────┐
  Có        Không
   │          │
   ▼          ▼
SetAuthCookie  Hiển thị lỗi
   │
   ├── Admin/User/Customer ──► /AdminPage/Dashboard
   └── Người dùng thường   ──► /Home/Index
```

### Bảo Mật Mật Khẩu

Mật khẩu được mã hóa bằng **MD5** trước khi lưu vào database:

```csharp
public static string GetMD5(string str)
{
    MD5 md5 = new MD5CryptoServiceProvider();
    byte[] fromData = Encoding.UTF8.GetBytes(str);
    byte[] targetData = md5.ComputeHash(fromData);
    // Chuyển đổi byte array thành chuỗi hex...
}
```

> ⚠️ **Lưu ý bảo mật**: MD5 không còn được khuyến nghị cho production. Nên nâng cấp lên BCrypt hoặc PBKDF2.

---

## 🛒 Luồng Hoạt Động Giỏ Hàng

Giỏ hàng được lưu trữ trong **ASP.NET Session** (không cần đăng nhập):

```
Người dùng xem sản phẩm
        │
        ▼
Click "Thêm vào giỏ" ──► /ShoppingCart/OrderNow/{id}
        │
        ▼
Kiểm tra Session["Carts"]
        │
  Có trong giỏ?
  ┌─────┴──────┐
 Có           Không
  │              │
  ▼              ▼
Tăng số lượng  Thêm mới vào List<Carts>
        │
        ▼
Xem giỏ hàng (/ShoppingCart/Index)
        │
Cập nhật số lượng? ──► Kiểm tra tồn kho
        │                    │
        │              Không đủ? ──► Hiển thị lỗi
        ▼
Checkout (/ShoppingCart/CheckOut)
        │
Nhập thông tin (tên, SĐT, email, địa chỉ)
        │
        ▼
POST /ShoppingCart/ProcessOrder
        │
Lưu TheOrder + OrderDetails vào DB
        │
Xóa Session giỏ hàng
        │
        ▼
/ShoppingCart/OrderSuccess
```

---

## 💻 Công Nghệ Sử Dụng

### Backend

| Công nghệ | Phiên bản | Mục đích |
|-----------|-----------|---------|
| ASP.NET MVC | 5.2.7 | Web framework chính |
| .NET Framework | 4.7.2 | Runtime |
| Entity Framework | 5.0.0 | ORM - Database First |
| C# | 8.0 | Ngôn ngữ lập trình |
| PagedList | 1.17.0 | Phân trang danh sách |
| PagedList.Mvc | 4.5.0 | Helper phân trang cho MVC Views |
| Forms Authentication | Built-in | Xác thực người dùng |
| Custom RoleProvider | Custom | Phân quyền tùy chỉnh |
| MD5CryptoServiceProvider | Built-in | Mã hóa mật khẩu |

### Frontend

| Công nghệ | Mục đích |
|-----------|---------|
| Razor View Engine | Template engine (.cshtml) |
| HTML5 | Cấu trúc trang |
| CSS3 | Giao diện |
| JavaScript | Tương tác người dùng |
| Bootstrap | Responsive layout |

### Database

| Thành phần | Chi tiết |
|-----------|---------|
| DBMS | Microsoft SQL Server |
| Tên Database | GF_DataBase |
| Kết nối | Integrated Security (Windows Auth) |
| Provider | System.Data.EntityClient |

---

## ⚙️ Yêu Cầu Hệ Thống

### Phát Triển (Development)

- **OS**: Windows 10/11
- **IDE**: Visual Studio 2019 / 2022
- **Runtime**: .NET Framework 4.7.2
- **Database**: SQL Server 2016+ (hoặc SQL Server Express)
- **RAM**: Tối thiểu 4GB (khuyến nghị 8GB+)

### Môi Trường Chạy (Runtime)

- **Web Server**: IIS 8.0+ hoặc IIS Express
- **SQL Server**: 2016 trở lên
- **.NET Framework**: 4.7.2 trở lên

---

## 🚀 Hướng Dẫn Cài Đặt

### Bước 1: Clone/Download dự án

```bash
git clone <repository-url>
# hoặc giải nén file zip vào thư mục mong muốn
```

### Bước 2: Mở Project trong Visual Studio

1. Mở Visual Studio
2. Chọn **File → Open → Project/Solution**
3. Chọn file `WebApp.csproj` hoặc `.sln` trong thư mục dự án

### Bước 3: Khôi phục NuGet Packages

```bash
# Trong Package Manager Console (Tools → NuGet Package Manager → Package Manager Console)
Update-Package -reinstall

# Hoặc nhấn chuột phải vào Solution → Restore NuGet Packages
```

### Bước 4: Cấu hình Database (xem phần tiếp theo)

### Bước 5: Build & Run

- Nhấn **F5** để chạy ứng dụng trong chế độ Debug
- Hoặc **Ctrl+F5** để chạy không debug
- Ứng dụng sẽ mở trên `http://localhost:{port}/`

---

## 🗃️ Cấu Hình Database

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

### Thiết Lập Database

**1. Mở SQL Server Management Studio (SSMS)**

**2. Tạo database `GF_DataBase`:**

```sql
CREATE DATABASE GF_DataBase;
```

**3. Chạy script tạo bảng:**

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

**4. Thay đổi `data source`** trong `Web.config` nếu SQL Server không ở localhost:

```xml
data source=TEN_SERVER_SQL;  <!-- Thay "." bằng tên server của bạn -->
```

---

## 👥 Tài Khoản Mặc Định

Thêm dữ liệu mẫu vào database:

```sql
-- Thêm Roles
INSERT INTO RoleMaster (RollName) VALUES ('Admin');
INSERT INTO RoleMaster (RollName) VALUES ('User');
INSERT INTO RoleMaster (RollName) VALUES ('Customer');

-- Thêm tài khoản Admin (mật khẩu: admin123)
-- MD5("admin123") = 0192023a7bbd73250516f069df18b500
INSERT INTO User_Web (ten_taikhoan, matkhau, hoTen, SDT)
VALUES ('Admin', '0192023a7bbd73250516f069df18b500', 'Quản Trị Viên', '0900000000');

-- Gán quyền Admin
INSERT INTO UserRolesMapping (UserId, RoleId)
VALUES (1, 1);
```

| Tài khoản | Mật khẩu | Vai trò | Redirect sau đăng nhập |
|-----------|----------|---------|----------------------|
| `Admin` | *(MD5 hash)* | Admin | `/AdminPage/Dashboard` |
| `User` | *(MD5 hash)* | User | `/AdminPage/Dashboard` |
| `Customer` | *(MD5 hash)* | Customer | `/AdminPage/Dashboard` |
| Tài khoản khác | *(MD5 hash)* | - | `/Home/Index` |

---

## 📂 Thư Mục Upload Ảnh

Ảnh sản phẩm được upload vào:

```
~/images/Products/
```

Đảm bảo thư mục này **tồn tại** và IIS có **quyền ghi** vào thư mục này.

---

## 🐛 Các Vấn Đề Thường Gặp

| Vấn đề | Nguyên nhân | Giải pháp |
|--------|-------------|-----------|
| Lỗi kết nối Database | Connection string sai | Kiểm tra `Web.config`, đảm bảo SQL Server đang chạy |
| Không upload được ảnh | Thiếu quyền ghi | Cấp quyền Write cho IIS_IUSRS vào thư mục `~/images/Products/` |
| Lỗi 404 sau đăng nhập | Route chưa khớp | Kiểm tra `RouteConfig.cs` |
| Session giỏ hàng bị mất | Session timeout | Tăng `sessionState timeout` trong `Web.config` |
| Lỗi phân quyền | RoleProvider không load | Kiểm tra cấu hình `roleManager` trong `Web.config` |

---

## 📝 Ghi Chú Phát Triển

- **ORM**: Sử dụng **Database First** — khi thay đổi schema DB cần regenerate EDMX
- **Session**: Giỏ hàng lưu trong `Session["Carts"]` — mất khi restart server hoặc session hết hạn
- **Phân trang**: Sử dụng thư viện **PagedList.Mvc** với kích thước trang mặc định là **10 items**
- **Upload ảnh**: Chỉ lưu tên file, không lưu đường dẫn đầy đủ
- **Anti-Forgery**: Được bật cho các action POST quan trọng (`[ValidateAntiForgeryToken]`)

---

<div align="center">

**© 2024 GF Food - E-Commerce Food Web Application**

*Xây dựng với ASP.NET MVC 5 | .NET Framework 4.7.2 | SQL Server*

</div>
