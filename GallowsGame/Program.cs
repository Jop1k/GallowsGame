using System;
using System.Text;
using System.Collections.Generic;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menuList = ["Начать новую игру", "Выход из игры"];

            var consoleMenu = new Menu(menuList, "\t=== Виселица ===");

            consoleMenu.menuInteraction();
        }
    }
}