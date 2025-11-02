
namespace CA_Shop
{
    public abstract class User
    {
        public string Name { get; private set; }
        public string UserType { get; private set; }

        public User(string name, string userType)
        {
            this.Name = name;
            this.UserType = userType;
        }
    }

}
