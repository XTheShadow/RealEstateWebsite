using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using BCrypt.Net;

public class AccountController : Controller
{
                                                       // Replace with your connection credentials 
    private readonly string _connectionString = "Server=localhost;Database=realestatedb;Uid=USERNAME;Pwd=PASSWORD;";

    [HttpPost]
public IActionResult Register(string Customer_Name, string email, string password)
{
    try
    {
        // Check if any of the registration fields are null or empty
        if (string.IsNullOrEmpty(Customer_Name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            // If any field is null or empty, return a BadRequest response
            return BadRequest("All fields are required for registration.");
        }

        // Check if the email is already registered
        bool isEmailRegistered = false;
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            var query = "SELECT COUNT(*) FROM Customers WHERE email = @email";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@email", email);
                isEmailRegistered = (long)command.ExecuteScalar() > 0;
            }
        }

        if (isEmailRegistered)
        {
            // Set error message in TempData
            TempData["Error"] = "Email is already registered.";
            // Redirect back to the registration page
            return RedirectToAction("Register", "Account");
        }
        else
        {
            // Hash the password using BCrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // Insert new user into the database
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Customers (Customer_Name, email, password_hash, Role) VALUES (@Customer_Name, @email, @hashedPassword)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Customer_Name", Customer_Name);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@hashedPassword", hashedPassword);
                    command.ExecuteNonQuery();
                }
            }

            // Set success message in TempData
            TempData["Message"] = "Registration successful. You can now log in.";
            // Redirect to the login page
            return RedirectToAction("Login", "Home");
        }
    }
    catch (Exception ex)
    {
        // Log the exception or display an error message
        return StatusCode(500, $"An error occurred: {ex.Message}");
    }
}


    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        try
        {
            // Retrieve the hashed password from the database
            string hashedPasswordFromDatabase = null;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT password_hash FROM Customers WHERE email = @email";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        hashedPasswordFromDatabase = result.ToString();
                    }
                }
            }

            // Check if the hashed password exists
            if (hashedPasswordFromDatabase != null)
            {
                // Verify the password using BCrypt
                if (BCrypt.Net.BCrypt.Verify(password, hashedPasswordFromDatabase))
                {
                    // Password is correct, login successful
                    TempData["Message"] = "Login successful.";
                    // Redirect to the home page or any other desired page
                    return RedirectToAction("Index", "Home");
                }
            }

            // If email or password is incorrect, return error message
            TempData["Error"] = "Invalid email or password.";
            return RedirectToAction("Login", "Home");
        }
        catch (Exception ex)
        {
            // Log the exception or display an error message
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}
