namespace Binj.Cli;

public class Menu
{
    public static void HelpMenu()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("\t Binj [flags]");
        Console.WriteLine("\t Binj [command]");

        Console.WriteLine("Commands");
        Console.WriteLine("\tadd - Add media");
        Console.WriteLine("\tremove - Remove media");
        Console.WriteLine("\tedit - Edit media");
        Console.WriteLine("\tview - View all media in the database");
    }
}
