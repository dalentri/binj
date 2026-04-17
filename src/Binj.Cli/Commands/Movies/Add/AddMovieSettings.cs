using System.ComponentModel;
using Spectre.Console.Cli;

public class AddMovieSettings : CommandSettings
{
    [CommandArgument(0, "<title>")]
    [Description("Name of the movie")]
    public string Title { get; set; } = string.Empty;

    [CommandOption("-g|--genre")]
    [Description("Genre of the movie")]
    public string Genre { get; set; } = "N/A";

    [CommandOption("-s|--status")]
    [Description("Status of consumption")]
    public string Status { get; set; } = "not started";

    [CommandOption("-r|--rating")]
    [Description("Rating of the movie")]
    public int Rating { get; set; } = 5;
}
