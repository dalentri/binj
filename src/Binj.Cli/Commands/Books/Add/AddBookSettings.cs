using System.ComponentModel;
using Spectre.Console.Cli;

public class AddBookSettings : CommandSettings
{
    [CommandArgument(0, "<title>")]
    [Description("The name of the media")]
    public string Title { get; set; } = string.Empty;

    [CommandOption("-a|--author")]
    [Description("The author of the book")]
    public string? Author { get; set; } = string.Empty;

    [CommandOption("-s|--status")]
    [Description("Your current status of consumption")]
    [DefaultValue("not_started")]
    public string? Status { get; set; }

    [CommandOption("-p|--page")]
    [Description("The page you are currently on")]
    [DefaultValue(0)]
    public int Page { get; set; } = 0;
}
