namespace Keeper.CoreContract.Users
{
    public class GetUserResponseItem
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
