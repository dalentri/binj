using System.ComponentModel;
using Spectre.Console.Cli;

public class EditComicSettings
{
    [CommandArgument(0, "<Id>")]
    [Description("Id number of the comic")]
    public int Id { get; set; }

    [CommandOption("-t|--title")]
    [Description("New title of the comic")]
    public string? Title { get; set; }

    [CommandOption("-v|--volume")]
    [Description("New current volume number")]
    public int Volume { get; set; }

    [CommandOption("-i|--issue")]
    [Description("New current issue number")]
    public int Issue { get; set; }

    [CommandOption("-s|--status")]
    [Description("New status of the comic")]
    public string? Status { get; set; }

    [CommandOption("-r|--rating")]
    [Description("New rating of the comic")]
    public int Rating { get; set; }
}
