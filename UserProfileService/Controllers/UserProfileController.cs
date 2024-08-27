using MC.UserProfile.Dtos;
using MC.UserProfile.Services;
using MC.UserProfile.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MC.UserProfile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userprofileService)
        {
            _userProfileService = userprofileService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserProfileDto>>> GetAllUserProfiles()
        {
            var userProfiles = await _userProfileService.GetAllUserProfileAsync();
            return Ok(userProfiles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileDto>> GetUserProfileById(string id)
        {
            var userProfile = await _userProfileService.GetByIdUserProfileAsync(id);
            return Ok(userProfile);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUserProfile(UserProfileDto userProfileDto)
        {
            await _userProfileService.CreateUserProfileAsync(userProfileDto);
            return CreatedAtAction(nameof(GetUserProfileById), new { id = userProfileDto.Id }, userProfileDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatedUserProfile(UserProfileDto userProfileDto)
        {
            await _userProfileService.UpdateUserProfileAsync(userProfileDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserProfile(string id)
        {
            await _userProfileService.DeleteUserProfileAsync(id);
            return NoContent();
        }
    }
}
