namespace Binj.Cli;

// Parses user command line arguments
public class ArgumentParser
{
    public static void Parse(string[] args)
    {
        // First command
        switch (args[0])
        {
            case "add":
                Console.WriteLine("Adding media to db");
                break;
            case "remove":
                Console.WriteLine("Removing media from database.");
                break;
            case "edit":
                Console.WriteLine("___ has been edited.");
                break;
            case "view":
                Console.WriteLine("Viewing database.");
                break;
            case "--help":
                Menu.HelpMenu();
                break;
            // Default
            default:
                Console.WriteLine("Invalid command, please retry. Type 'binj --help' for info.");
                break;
        }
    }
}
