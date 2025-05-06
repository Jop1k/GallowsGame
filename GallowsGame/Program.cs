namespace GallowsGame;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        Menu mainMenu = new Menu("\t=== Главное меню ===", ["Начать новую игру", "Настройки", "Выйти из игры"], choice =>
        {
            switch (choice)
            {
                case 0:
                    var game = new GallowsGame();
                    game.PlayGame();
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("В разработке");
                    Console.ReadKey();
                    break;
                case 2:
                    Menu.ExitMenu();
                    break;
            }
        });

        mainMenu.MenuInteraction();
    }
}