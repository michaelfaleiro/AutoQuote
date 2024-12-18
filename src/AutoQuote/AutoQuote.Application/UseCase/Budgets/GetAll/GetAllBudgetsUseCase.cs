using AutoQuote.Communication.Response.Budgets;
using AutoQuote.Communication.Response.ItemsBudget;
using AutoQuote.Core.Repositories.Budgets;
using AutoQuote.Core.Response;

namespace AutoQuote.Application.UseCase.Budgets.GetAll;

public class GetAllBudgetsUseCase
{
    private readonly IBudgetRepository _budgetRepository;
    
    public GetAllBudgetsUseCase(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }

    public async Task<PagedResponse<BudgetShortResponseJson>> ExecuteAsync(int page, int pageSize)
    {
        var result = await _budgetRepository.GetAllAsync(page, pageSize);

        return new PagedResponse<BudgetShortResponseJson>(
            result.Data.Select(x => new BudgetShortResponseJson(
                x.Id,
                x.EmployeeName,
                x.Vehicle,
                x.StatusBudget,
                x.CreatedAt,
                x.UpdatedAt)),
            page,
            pageSize,
            result.Total);
    }
}