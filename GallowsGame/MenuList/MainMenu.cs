namespace GallowsGame;

class MainMenu : Menu
{
    private GallowsGame _game = new GallowsGame();

    protected override string MenuName { get; } = "\t=== Главное меню ===";

    protected override string[] SelectionList { get; } = ["Начать новую игру", "Настройки", "Выйти из игры"];

    protected override void Action(int choice)
    {
        switch (choice)
        {
            case 0:
                _game.PlayGame();
                break;
            case 1:
                Console.WriteLine("в разработке");
                Console.ReadKey();
                break;
            case 2:
                ExitMenu();
                break;
        }
    }
}
