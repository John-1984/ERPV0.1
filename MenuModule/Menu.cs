using System;
namespace MenuModule
{
    public class Menu: IMenu
    {
        public Menu()
        {
        }

        public Tuple<string, string> GetMenu()
        {
            throw new NotImplementedException();
        }

        public Tuple<string, string> GetMenu(string role)
        {
            throw new NotImplementedException();
        }
    }
}
