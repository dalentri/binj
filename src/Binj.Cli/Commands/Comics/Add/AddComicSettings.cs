using System.ComponentModel;
using Spectre.Console.Cli;

namespace Binj.Cli.Commands.Comics.Add;

public class AddComicSettings : CommandSettings
{
    [CommandArgument(0, "<title>")]
    [Description("The name of the media")]
    public string Title { get; set; } = string.Empty;

    [CommandOption("-i|--issue")]
    [Description("The issue of the comic")]
    public int Issue { get; set; } = 1;

    [CommandOption("-v|--volume")]
    [Description("The volume of the comic")]
    public int Volume { get; set; } = 1;

    [CommandOption("-s|--status")]
    [Description("Status of consumption")]
    [DefaultValue("not started")]
    public string Status { get; set; } = "not started";

    [CommandOption("-r|--rating")]
    [Description("Rating of the comic")]
    public int Rating { get; set; } = 5;
}
