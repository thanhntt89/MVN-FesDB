namespace FestivalObjects
{
    public class AuthorityEntity
    {
        public string AuthorityName { get; set; }
        public int RoleValue { get; set; }
    }

    public enum Roles { AdminGroup = 106, UserGroup }
}
