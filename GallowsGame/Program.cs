namespace GallowsGame;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        var consoleMenu = new MainMenu();

        consoleMenu.MenuInteraction();
    }
}