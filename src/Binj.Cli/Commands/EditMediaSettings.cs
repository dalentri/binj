using Spectre.Console.Cli;

namespace Binj.Cli.Commands;

public class EditMediaSettings : CommandSettings
{
    [CommandArgument(0, "<Id>")]
    public string Id { get; set; }
}
