using AutoQuote.Application.UseCase.Suppliers.Delete;
using AutoQuote.Application.UseCase.Suppliers.GetAll;
using AutoQuote.Application.UseCase.Suppliers.GetById;
using AutoQuote.Application.UseCase.Suppliers.Register;
using AutoQuote.Application.UseCase.Suppliers.Update;
using AutoQuote.Communication.Request.Suppliers;
using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace AutoQuote.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseJson<SupplierJsonResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult RegisterSupplier(
        [FromServices] RegisterSupplierUseCase useCase,
        [FromBody] RegisterSupplierRequest request)
    {
        var response = useCase.ExecuteAsync(request);
        return Created(string.Empty, response);
    }
    
    [HttpGet("{id:length(24)}")]
    [ProducesResponseType(typeof(ResponseJson<SupplierJsonResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSupplierById(
        string id, [FromServices] GetByIdUseCase useCase)
    {
        var response = await useCase.ExecuteAsync(id);
        return Ok(response);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<SupplierJsonResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllSuppliers(
        [FromServices] GetAllSuppliersUseCase useCase,
        [FromQuery] int page = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize 
        )
    {
        var response = await useCase.ExecuteAsync(page, pageSize);
        return Ok(response);
    }
    
    [HttpPut("{id:length(24)}")]
    [ProducesResponseType(typeof(ResponseJson<SupplierJsonResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateSupplier(
        string id, [FromServices] UpdateSupplierUseCase useCase,
        [FromBody] RegisterSupplierRequest request)
    {
        var response = await useCase.ExecuteAsync(id, request);
        return Ok(response);
    }
    
    [HttpDelete("{id:length(24)}")]
    [ProducesResponseType(typeof(ResponseJson<SupplierJsonResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSupplier(
        string id, [FromServices] DeleteSupplierUseCase useCase)
    {
        await useCase.ExecuteAsync(id);
        return Ok();
    }
    
    
    
}