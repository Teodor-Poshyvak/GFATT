using GFAT.Domain.Models;
using GFAT.Domain.Response;
using GFAT.Domain.ViewModels.User;

namespace GFAT.Service.Interfaces;

public interface IUserService
{
    Task<IBaseResponse<User>> Create(UserViewModel model);
        
    BaseResponse<Dictionary<int, string>> GetRoles();
        
    Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();
        
    Task<IBaseResponse<bool>> DeleteUser(long id);
}