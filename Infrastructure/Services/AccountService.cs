using Domain.DTO.Reqest;
using Domain.DTO.Response;
using Domain.Entityes;
using Domain.Interfaces;
using Infrastructure.Common;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
  public class AccountService : IAccountService
  {
    private readonly SignInManager<User> signInManager;
    public AccountService(SignInManager<User> signInManager)      
    {
      this.signInManager = signInManager; 
    }
    public async Task<BaseResponse> RegisterUser(RegisterUserRequest request)
    {
      User user = new User
      {
        UserName = request.Email,
        Email = request.Email,
        AccountConFirmed = false
      };
      string password = Constants.DEFAULT_PASSWORD;
      var result = await signInManager.UserManager.CreateAsync(user, password);
      return new BaseResponse
      {
        IsSuccess = result.Succeeded
      };

    }

    public async Task<BaseResponse<string>> VerifyUser(string email, string password)
    {
      BaseResponse<string> response = new();
      var user = await signInManager.UserManager.FindByEmailAsync(email);
      if (user is null)
      {
        response.ErrorMessage = "User is not found";
        response.IsSuccess = false;
        return response;
      }
      var result = await signInManager.UserManager.CheckPasswordAsync(user, password);  
      response.IsSuccess = result;
      if (!response.IsSuccess)
      {
        response.ErrorMessage = "invalid email/passowrd";
      }
      else
      {
        response.Value = user.UserName;
      }
      return response;
    }

  }
}
