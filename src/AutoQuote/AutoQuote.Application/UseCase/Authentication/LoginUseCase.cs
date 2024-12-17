using AutoQuote.Application.Services.Token;
using AutoQuote.Communication.Request.Login;
using AutoQuote.Communication.Response.Token;
using AutoQuote.Core.Repositories.Employees;
using AutoQuote.Core.Repositories.RefreshTokens;
using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Application.UseCase.Authentication;

public class LoginUseCase
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ITokenService _tokenService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public LoginUseCase(IEmployeeRepository employeeRepository, ITokenService tokenService,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _employeeRepository = employeeRepository;
        _tokenService = tokenService;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<TokenResponseJson> ExecuteAsync(LoginRequest request)
    {
        var employee = await _employeeRepository.GetByEmailAsync(request.Email)
                       ?? throw new NotAuthorizedException("Email or password is invalid");
    
        if (!employee.VerifyPassword(request.Password, employee))
            throw new NotAuthorizedException("Email or password is invalid");

        var token = _tokenService.GenerateToken(employee.Id, employee.Role);
        var refreshToken = _tokenService.GenerateRefreshToken(employee.Id);
        
        await _refreshTokenRepository.AddAsync(new Core.Entities.RefreshToken(
                employee.Id, employee.Role,refreshToken, token.ExpiresIn)); 

        return new TokenResponseJson(token.Token, refreshToken, token.ExpiresIn);
    }
} 