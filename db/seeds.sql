-- Insert Sample Customers
INSERT INTO Customers (Customer_Name, email, password_hash, Role) 
VALUES 
('Admin User', 'admin@example.com', '$2y$10$hashedpassword1', 'admin'),
('Test User', 'user@example.com', '$2y$10$hashedpassword2', 'user');

-- Insert Sample Messages
INSERT INTO Contact (name, email, message) 
VALUES 
('John Doe', 'johndoe@example.com', 'I am interested in a property listing.'),
('Jane Smith', 'janesmith@example.com', 'Do you offer virtual tours?');
