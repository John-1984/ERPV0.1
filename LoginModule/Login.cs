using System;
namespace LoginModule
{
    public class Login: ILogin
    {
        public Login()
        {
        }

        public bool AuthenticateUser(string userName, string password)
        {
            return true;
        }
    }
}
