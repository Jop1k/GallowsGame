namespace GallowsGame;

abstract class Menu
{
    private int _currentIndexMenu = 0;

    private bool _exitMenu = false;

    protected abstract string MenuName { get; }

    protected abstract string[] SelectionList { get; }

    protected abstract void Action(int choice);

    protected void ExitMenu()
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
                    Action(_currentIndexMenu);
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