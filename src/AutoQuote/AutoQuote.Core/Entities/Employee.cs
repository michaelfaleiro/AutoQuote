using AutoQuote.Core.Extensions;

namespace AutoQuote.Core.Entities;

public class Employee : Entity
{
    
    public Employee(string name, string email, string password, string role)
    {
        Name = name;
        Email = email;
        Password = PasswordHasher.HashPassword(password);
        Role = role;
    }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }
    
    public void ChangePassword(string newPassword)
    {
        Password = PasswordHasher.HashPassword(newPassword);
    }
    
    public bool VerifyPassword(string password, Employee employee)
    {
        return BCrypt.Net.BCrypt.Verify(password, employee.Password);
    }
    
    public void ChangeRole(string newRole)
    {
        Role = newRole;
    }
    
    public void ChangeEmail(string newEmail)
    {
        Email = newEmail;
    }
    
    public void ChangeName(string newName)
    {
        Name = newName;
    }
    
}