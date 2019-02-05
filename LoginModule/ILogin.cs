using System;
namespace LoginModule
{
    public interface ILogin
    {
        Boolean AuthenticateUser(string userName, string password);
    }
}
