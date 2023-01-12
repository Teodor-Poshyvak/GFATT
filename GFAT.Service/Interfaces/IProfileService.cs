using GFAT.Domain.Models;
using GFAT.Domain.Response;
using GFAT.Domain.ViewModels.Profile;

namespace GFAT.Service.Interfaces;

public interface IProfileService
{
    
    Task<BaseResponse<ProfileViewModel>> GetProfile(string userName);

    Task<BaseResponse<Profile>> Save(ProfileViewModel model);
}