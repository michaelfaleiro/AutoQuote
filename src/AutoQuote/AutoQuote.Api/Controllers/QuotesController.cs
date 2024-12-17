using AutoQuote.Application.UseCase.Quotes.AddItem;
using AutoQuote.Application.UseCase.Quotes.GetAll;
using AutoQuote.Application.UseCase.Quotes.GetById;
using AutoQuote.Application.UseCase.Quotes.Register;
using AutoQuote.Application.UseCase.Quotes.RemoveItem;
using AutoQuote.Application.UseCase.Quotes.UpdateItem;
using AutoQuote.Communication.Request.Items;
using AutoQuote.Communication.Request.Quotes;
using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Quotes;
using Microsoft.AspNetCore.Mvc;

namespace AutoQuote.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuotesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseJson<QuoteResponseJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterQuote(
        [FromBody] RegisterQuoteRequest request, [FromServices] RegisterQuoteUseCase useCase)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }
    
    [HttpGet("{id:length(24)}")]
    [ProducesResponseType(typeof(ResponseJson<QuoteResponseJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetQuoteById(
        string id, [FromServices] GetQuoteByIdUseCase useCase)
    {
        var response = await useCase.ExecuteAsync(id);
        return Ok(response);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<QuoteResponseJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllQuotes(
        [FromServices] GetAllQuotesUseCase useCase,
        [FromQuery] int page = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize 
        )
    {
        var response = await useCase.ExecuteAsync(page, pageSize);
        return Ok(response);
    }
    
    [HttpPost("items")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddItem(
        [FromBody] AddItemQuoteRequest request, [FromServices] AddItemQuoteUseCase useCase)
    {
        
        await useCase.ExecuteAsync(request);
        return NoContent();
    }
    
    [HttpPut("items")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateItem(
        [FromBody] UpdateItemQuoteRequest request, [FromServices] UpdateItemQuoteUseCase useCase)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }
    
    [HttpDelete("items")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveItem(
        [FromBody] RemoveItemQuoteRequest request, [FromServices] RemoveItemQuoteUseCase useCase)
    {
        await useCase.ExecuteAsync(request);
        return NoContent();
    }
    
}