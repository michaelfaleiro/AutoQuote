namespace AutoQuote.Communication.Response.Employees;

public record EmployeeResponseJson(
    string Id,
    string Name,
    string Email,
    string Role,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);