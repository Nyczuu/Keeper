namespace Keeper.CoreContract.Users
{
    public class UserGet1ResponseItem
    {
        public int Identifier;
        public string Email;
        public UserGroupType Group;

        public override string ToString()
        {
            return Email;
        }
    }
}
