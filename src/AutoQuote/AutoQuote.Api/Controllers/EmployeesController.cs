using AutoQuote.Application.UseCase.Authentication;
using AutoQuote.Application.UseCase.Employees.Delete;
using AutoQuote.Application.UseCase.Employees.GetAll;
using AutoQuote.Application.UseCase.Employees.GetById;
using AutoQuote.Application.UseCase.Employees.Register;
using AutoQuote.Communication.Request.Employees;
using AutoQuote.Communication.Request.Login;
using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoQuote.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EmployeesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseJson<EmployeeResponseJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterEmployee(
        [FromBody] RegisterEmployeeRequest request, [FromServices] RegisterEmployeeUseCase useCase)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }
    
    [HttpGet("{id:length(24)}")]
    [ProducesResponseType(typeof(ResponseJson<EmployeeResponseJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEmployeeById(
        string id, [FromServices] GetEmployeeByIdUseCase useCase)
    {
        var response = await useCase.ExecuteAsync(id);
        return Ok(response);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<EmployeeResponseJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllEmployees(
        [FromServices] GetAllEmployeesUseCase useCase,
        [FromQuery] int page = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize 
        )
    {
        var response = await useCase.ExecuteAsync(page, pageSize);
        return Ok(response);
    }
    
    [HttpDelete("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteEmployee(
        string id, [FromServices] DeleteEmployeeUseCase useCase)
    {
        await useCase.ExecuteAsync(id);
        return NoContent();
    }
    
}