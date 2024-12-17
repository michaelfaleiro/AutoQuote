using AutoQuote.Core.Entities;

namespace AutoQuote.Test.Contructors;

public class EmployeeTest
{
    const string Name = "John Doe";
    const string Email = "teste@gmail.com";
    const string Password = "password";
    const string Role = "admin";
    
    
    [Fact]
    public void Employee_Constructor()
    {
        var employee = new Employee(Name, Email, Password, Role);
        
        Assert.Equal(Name, employee.Name);
        Assert.Equal(Email, employee.Email);
        Assert.Equal(Password, employee.Password);
        Assert.Equal(Role, employee.Role);
    }


}