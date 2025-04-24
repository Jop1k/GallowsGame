using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game;

class Menu
{
    private readonly string _menuName;
    private readonly string[] _selectionList;
    private int _currentIndexMenu = 0;

    public Menu(string[] selectionList, string menuName)
    {
        _selectionList = selectionList;
        _menuName = menuName;
    }

    private void Action(int choice)
    {
        var game = new GallowsGame();
        switch (choice)
        {
            case 0:
                game.PlayGame();
                break;
            case 1:
                Environment.Exit(0);
                break;
        }
    }

    public void menuInteraction()
    {
        while (true)
        {
            Console.Clear();

            PrintMenu();

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    if (_currentIndexMenu > 0)
                    {
                        _currentIndexMenu--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (_currentIndexMenu < _selectionList.Length - 1)
                    {
                        _currentIndexMenu++;
                    }
                    break;
                case ConsoleKey.Enter:
                    Action(_currentIndexMenu);
                    break;
            }
        }
    }

    private void PrintMenu()
    {
        Console.WriteLine(_menuName);
        Console.WriteLine();

        for (int i = 0; i < _selectionList.Length; i++)
        {
            if (i == _currentIndexMenu)
            {
                Console.BackgroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine($"{i + 1}) {_selectionList[i]}");
            Console.ResetColor();
        }
    }
}
