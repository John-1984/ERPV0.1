using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer
{
    public class Login
    {
        private List<BusinessModels.Login> Logins = new List<BusinessModels.Login>();
        private DataLayer.LoginDAL _dataLayer = null;

        public Login()
        {
            _dataLayer = new DataLayer.LoginDAL();
        }

        public BusinessModels.Login GetLogin(Int32 identity)
        {
            return _dataLayer.GetLogin(identity);
        }

        public IEnumerable<BusinessModels.Login> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Login Login)
        {
            return _dataLayer.Update(Login);
        }

        public string GetUserName(string empName)
        {
            String strUsername = empName.Replace(" ", "").Trim().ToString() + GetRandomAlphanumericStringForusername();
            return strUsername;
        }

        public BusinessModels.Login Insert(BusinessModels.Login Login, string empName)
        {
            Login.UserName = GetUserName(empName);
            Login.UserPassword = HashSHA(GetRandomAlphanumericStringForuserPassword());
            return _dataLayer.Insert(Login);
        }

        private static string GetRandomAlphanumericStringForusername()
        {
            const string alphanumericCharacters =
               "0123456789" + "0123456789" + "0123456789" + "0123456789";
            return GetRandomStringForusername(2, alphanumericCharacters);
        }
        private static string GetRandomStringForusername(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }
        private static string HashSHA(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }

        private static string GetRandomAlphanumericStringForuserPassword()
        {
            const string alphanumericCharacters =
               "0123456789" + "abcdefghijklmnopqrstuvwxyz" + "0123456789" + "abcdefghijklmnopqrstuvwxyz";
            return GetRandomStringForuserPassword(12, alphanumericCharacters);
        }
        private static string GetRandomStringForuserPassword(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }




    }


}
