using AutoMapper;
using MC.UserProfile.Dtos;
using MC.UserProfile.Entities;
using MC.UserProfile.Services.Interfaces;
using MC.UserProfile.Settings;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MC.UserProfile.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IMongoCollection<UserProfiles> _userProfiles;
        private readonly IMapper _mapper;

        public UserProfileService(IMapper mapper, DatabaseSettings settings) 
        {
            if (string.IsNullOrEmpty(settings.ConnectionString))
            {
                throw new ArgumentNullException(nameof(settings.ConnectionString), "MongoDB connection string is null or empty.");
            }
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _userProfiles = database.GetCollection<UserProfiles>(settings.UserProfilesCollectionName);
            _mapper = mapper;
        }
        public async Task CreateUserProfileAsync(UserProfileDto userProfileDto)
        {
            //Map the DTO to an entity
            var userProfile = _mapper.Map<UserProfiles>(userProfileDto);

            //Insert the user profile and mongoDB generates it
            await _userProfiles.InsertOneAsync(userProfile);

            //Update the DTO with the generated Id
            userProfileDto.Id = userProfile.Id;
        }

        public async Task DeleteUserProfileAsync(string id)
        {
            var result = await _userProfiles.DeleteOneAsync(up => up.Id == id);
            if(result.DeletedCount == 0)
            {
                throw new KeyNotFoundException("User profile not found");
            }
        }

        public async Task<List<UserProfileDto>> GetAllUserProfileAsync()
        {
            var userProfiles = await _userProfiles.Find(up=>true).ToListAsync();
            return _mapper.Map<List<UserProfileDto>>(userProfiles);
        }

        public async Task<UserProfileDto> GetByIdUserProfileAsync(string id)
        {
            var userProfile = await _userProfiles.Find(up => up.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<UserProfileDto>(userProfile);
        }

        public async Task UpdateUserProfileAsync(UserProfileDto userProfileDto)
        {
            var existingProfile = await _userProfiles.Find(up => up.Id == userProfileDto.Id).FirstOrDefaultAsync();
            if (existingProfile == null)
            {
                //Handles the case in case where if profile not founded
                throw new KeyNotFoundException("User profile not found");
            }

            //prevents changing id for now(needs a better way obv)
            userProfileDto.Id = existingProfile.Id;

            var updatedProfile = _mapper.Map(userProfileDto, existingProfile);
            await _userProfiles.ReplaceOneAsync(up=>up.Id==updatedProfile.Id, updatedProfile);
        }
    }
}
