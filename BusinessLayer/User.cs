using System;
namespace BusinessLayer
{
    public class User
    {
        private DataLayer.UserDAL _dataLayer = null;

        public User()
        {
            _dataLayer = new DataLayer.UserDAL();
        }

        public BusinessModels.User GetUser(string userName, string password)
        {
            return _dataLayer.GetUser(userName, password);
        }

        public BusinessModels.User ValidateUser(string userName, string password)
        {
            return _dataLayer.ValidateUser(userName, password);
        }

    }
}
