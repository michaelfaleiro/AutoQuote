using AutoQuote.Application.UseCase.Quotes.AddItem;
using AutoQuote.Application.UseCase.Quotes.GetAll;
using AutoQuote.Application.UseCase.Quotes.GetById;
using AutoQuote.Application.UseCase.Quotes.Register;
using AutoQuote.Application.UseCase.Quotes.RemoveItem;
using AutoQuote.Application.UseCase.Quotes.UpdateItem;
using Microsoft.Extensions.DependencyInjection;
namespace AutoQuote.Application.Services;

public static class QuoteService
{
    public static IServiceCollection AddQuoteService(this IServiceCollection services)
    {
        services.AddScoped<RegisterQuoteUseCase>();
        services.AddScoped<GetQuoteByIdUseCase>();
        services.AddScoped<GetAllQuotesUseCase>();
        services.AddScoped<AddItemQuoteUseCase>();
        services.AddScoped<RemoveItemQuoteUseCase>();
        services.AddScoped<UpdateItemQuoteUseCase>();
        
        return services;
    }   
    
}