using AutoMapper;
using MC.UserProfile.Dtos;
using MC.UserProfile.Entities;

namespace MC.UserProfile.Mappings
{
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping() 
        {
            CreateMap<UserProfiles, UserProfileDto>().ReverseMap();
            CreateMap<SocialLink, SocialLinkDto>().ReverseMap();
        }
    }
}
