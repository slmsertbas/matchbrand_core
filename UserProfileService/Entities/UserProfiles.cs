using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MC.UserProfile.Entities
{
    public class UserProfiles
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Bio {  get; set; }
        public string ProfilePictureUrl { get; set; }
        public List<SocialLink> SocialLinks { get; set; } = new List<SocialLink>();
    }
    public class SocialLink
    {
        public string Platform { get; set; }
        public string Url { get; set; }
    }
}
