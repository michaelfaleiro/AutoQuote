using AutoQuote.Application.Services.Token;
using AutoQuote.Communication.Request.Login;
using AutoQuote.Communication.Response.Token;
using AutoQuote.Core.Entities;
using AutoQuote.Core.Repositories.RefreshTokens;
using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Application.UseCase.Authentication;

public class RefreshTokenUseCase
{
    private readonly ITokenService _tokenService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    
    public RefreshTokenUseCase(ITokenService tokenService, IRefreshTokenRepository refreshTokenRepository)
    {
        _tokenService = tokenService;
        _refreshTokenRepository = refreshTokenRepository;
    }
    
    public async Task<TokenResponseJson> ExecuteAsync(RefreshTokenRequest request)
    {
        var refreshToken = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken) 
                           ?? throw new NotAuthorizedException("Invalid refresh token");
        
        var token = _tokenService.GenerateToken(refreshToken.UserId, refreshToken.Role);
        
        var newRefreshToken = _tokenService.GenerateRefreshToken(refreshToken.UserId);
        
        refreshToken.UpdateToken(newRefreshToken, token.ExpiresIn);
        
        await _refreshTokenRepository.UpdateAsync(refreshToken);
        
        return new TokenResponseJson(token.Token, newRefreshToken, token.ExpiresIn);
    }
    
}