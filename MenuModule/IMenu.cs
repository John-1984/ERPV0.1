using System;
using System.Collections.Generic;

namespace MenuModule
{
    public interface IMenu
    {
        Tuple<string, string> GetMenu();
        Tuple<string, string> GetMenu(int roleID);
    }
}
