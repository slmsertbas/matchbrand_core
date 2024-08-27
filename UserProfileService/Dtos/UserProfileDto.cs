using MC.UserProfile.Entities;

namespace MC.UserProfile.Dtos
{
    public class UserProfileDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
        public List<SocialLink> SocialLinks { get; set; } = new List<SocialLink>();
    }
}
