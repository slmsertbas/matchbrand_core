using MC.UserProfile.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MC.UserProfile.Services.Interfaces
{
    public interface IUserProfileService
    {
        Task<List<UserProfileDto>> GetAllUserProfileAsync();
        Task CreateUserProfileAsync(UserProfileDto userProfileDto);
        Task UpdateUserProfileAsync(UserProfileDto userProfileDto);
        Task DeleteUserProfileAsync(string id);
        Task<UserProfileDto> GetByIdUserProfileAsync(string id);
    }
}
