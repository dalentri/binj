namespace Binj.Cli;

// Parses user command line arguments
public class ArgumentParser
{
    public void Parse(string[] args)
    {
        // First command
        string result = args[0] switch
        {
            "add" => "Adding media to database.",
            "remove" => "Removing media from database.",
            "edit" => "___ has been edited.",
            "view" => "Viewing database.",
            // Default
            _ => "Invalid command, please retry. Type 'binj --help' for info.",
        };
    }
}
