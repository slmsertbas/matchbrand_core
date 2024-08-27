namespace MC.UserProfile.Settings
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string UserProfilesCollectionName { get; set; }
    }
}
