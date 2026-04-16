using System.ComponentModel;
using Spectre.Console.Cli;

public class AddBookSettings : CommandSettings
{
    [CommandArgument(0, "<title>")]
    [Description("The name of the media")]
    public string Title { get; init; } = string.Empty;

    [CommandOption("-s|--status")]
    [Description("Your current status of consumption")]
    [DefaultValue("not_started")]
    public string? Status { get; init; }

    [CommandOption("-p|--page")]
    [Description("The page you are currently on")]
    [DefaultValue(0)]
    public int Page { get; init; } = 0;
}
