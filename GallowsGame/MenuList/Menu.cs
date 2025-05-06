namespace GallowsGame;

internal class Menu
{
    private int _currentIndexMenu = 0;
    private static bool _exitMenu = false;
    private Action<int> _action;
    public Menu(string menuName, string[] selectionList, Action<int> action)
    {
        MenuName = menuName;
        SelectionList = selectionList;
        _action = action;
    }

    private string MenuName { get; init; }

    private string[] SelectionList { get; init; }

    public static void ExitMenu()
    {
        _exitMenu = true;
    }

    public void MenuInteraction()
    {
        _exitMenu = false;

        while (!_exitMenu)
        {
            PrintMenu();

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    if (_currentIndexMenu > 0)
                        _currentIndexMenu--;
                    break;
                case ConsoleKey.DownArrow:
                    if (_currentIndexMenu < SelectionList.Length - 1)
                        _currentIndexMenu++;
                    break;
                case ConsoleKey.Enter:
                    _action(_currentIndexMenu);
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Подсказка: для перемещения по меню используйте стрелочки");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void PrintMenu()
    {
        Console.Clear();

        Console.WriteLine(MenuName);
        Console.WriteLine();

        for (int i = 0; i < SelectionList.Length; i++)
        {
            if (i == _currentIndexMenu)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.WriteLine($"{i + 1}) {SelectionList[i]}");
            Console.ResetColor();
        }
    }
}