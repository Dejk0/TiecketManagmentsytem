using Domain.DTO.Reqest;
using Domain.DTO.Response;

namespace Domain.Interfaces
{
  public interface IAccountService
  {
    Task<BaseResponse<string>> VerifyUser(string email, string password);
    Task<BaseResponse> RegisterUser(RegisterUserRequest request);
  }
}
