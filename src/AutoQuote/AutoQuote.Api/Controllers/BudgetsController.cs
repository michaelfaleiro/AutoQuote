using AutoQuote.Application.UseCase.Budgets.GetAll;
using AutoQuote.Application.UseCase.Budgets.GetById;
using AutoQuote.Application.UseCase.Budgets.Items;
using AutoQuote.Application.UseCase.Budgets.Items.AddItem;
using AutoQuote.Application.UseCase.Budgets.Items.RemoveItem;
using AutoQuote.Application.UseCase.Budgets.Items.UpdateItem;
using AutoQuote.Application.UseCase.Budgets.Register;
using AutoQuote.Communication.Request.Budgets;
using AutoQuote.Communication.Request.ItemsBudget;
using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Budgets;
using Microsoft.AspNetCore.Mvc;

namespace AutoQuote.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BudgetsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseJson<BudgetShortResponseJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterBudget(
        [FromBody] RegisterBudgetRequest request, [FromServices] RegisterBudgetUseCase useCase)
    {
        var response = await useCase.ExecuteAsync(request);
        return Created(string.Empty, response);
    }
    
    [HttpGet("{id:length(24)}")]
    [ProducesResponseType(typeof(ResponseJson<BudgetShortResponseJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBudgetById(
        string id, [FromServices] GetBudgetByIdUseCase useCase)
    {
        var response = await useCase.ExecuteAsync(id);
        return Ok(response);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<BudgetShortResponseJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllBudgets(
        [FromServices] GetAllBudgetsUseCase useCase,
        [FromQuery] int page = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize 
        )
    {
        var response = await useCase.ExecuteAsync(page, pageSize);
        return Ok(response);
    }
    
    [HttpPost("items")]
    [ProducesResponseType(typeof(ResponseJson<BudgetShortResponseJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddItemBudget(
        [FromBody] AddItemBudgetRequest request, [FromServices] AddItemBudgetUseCase useCase)
    {
        var response = await useCase.ExecuteAsync(request);
        return Ok(response);
    }
    
    [HttpPut("items")]
    [ProducesResponseType(typeof(ResponseJson<BudgetShortResponseJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateItemBudget(
        [FromBody] UpdateItemBudgetRequest request, [FromServices] UpdateItemBudgetUseCase useCase)
    {
        var response = await useCase.ExecuteAsync(request);
        return Ok(response);
    }
    
    [HttpDelete("items")]
    [ProducesResponseType(typeof(ResponseJson<BudgetShortResponseJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveItemBudget(
        [FromBody] RemoveItemBudgetRequest request, [FromServices] RemoveItemBudgetUseCase useCase)
    {
        var response = await useCase.ExecuteAsync(request);
        return Ok(response);
    }
    
}