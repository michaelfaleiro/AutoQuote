namespace AutoQuote.Communication.Request.Employees;

public record RegisterEmployeeRequest(
    string Name,
    string Email,
    string Password,
    string Role);