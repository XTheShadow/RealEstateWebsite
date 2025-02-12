# 🏡 Real Estate Website

This is a web-based Real Estate Management System built using **ASP.NET Core MVC** and **MySQL**. It allows users to register, log in, and send inquiries via a contact form.

---

## 📌 Features

- 🛡 **User Authentication**: Secure registration and login with **BCrypt password hashing**.
- 📧 **Contact Form**: Users can send messages that are stored in the database.
- 🏠 **MVC Architecture**: Clean separation of concerns using **Model-View-Controller**.
- 🛢 **Database Integration**: Uses **MySQL** to store user accounts and contact messages.
- 🎨 **Frontend**: Designed with **HTML, CSS, and Bootstrap**.

---

## 🛠 Technologies Used

- **Backend**: ASP.NET Core MVC
- **Frontend**: HTML5, CSS3, Bootstrap
- **Database**: MySQL
- **Security**: BCrypt for password hashing

---

## 🚀 Setup & Installation

### 1️. **Clone the Repository**
  ```bash
  git clone https://github.com/XTheShadow/RealEstateWebsite.git
  cd RealEstateWebsite
  ```

### 2️. **Setup the Database**
  - Import `Database/schema.sql` into your MySQL server.
  - Optionally, seed data using `Database/seeds.sql`.

### 3️. **Configure the Connection String**
  Update your MySQL credentials in `AccountController.cs` and `ContactController.cs`


### 4️. **Run the Project**
  ```bash
  dotnet run
  ```
  Then open **http://localhost:5000** in your browser.


---

## 📜 License

This project is licensed under the **MIT License**.  
