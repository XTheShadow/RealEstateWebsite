using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

public class ContactController : Controller
{
                                                           // Replace with your connection credentials 
    private readonly string _connectionString = "Server=localhost;Database=realestatedb;Uid=USERNAME;Pwd=PASSWORD;";

    [HttpPost]
    public IActionResult SendMessage(string name, string email, string message)
    {
        // Check if the 'name' parameter is null or empty
        if (string.IsNullOrEmpty(name))
        {
            // If 'name' is null or empty, return a BadRequest response
            return BadRequest("Name cannot be null or empty.");
        }

        // Insert data into the database
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            var query = "INSERT INTO contact (name, email, message) VALUES (@name, @email, @message)";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@message", message);
                command.ExecuteNonQuery();
            }
        }

        // Set success message in TempData
        TempData["Message"] = "Your message has been sent.";

        // Redirect back to the contact page
        return RedirectToAction("Contact", "Home");
    }
}
