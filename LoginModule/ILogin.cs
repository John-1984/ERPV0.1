using System;
namespace LoginModule
{
    public interface ILogin
    {
        BusinessModels.Login AuthenticateUser(string userName, string password);
    }
}
