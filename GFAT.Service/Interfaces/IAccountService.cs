using System.Security.Claims;
using GFAT.Domain.Response;
using GFAT.Domain.ViewModels.Account;

namespace GFAT.Service.Interfaces;

public interface IAccountService
{
    Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

    Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);

    Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model);
}