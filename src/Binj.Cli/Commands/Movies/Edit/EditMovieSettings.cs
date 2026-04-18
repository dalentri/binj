using System.ComponentModel;
using Spectre.Console.Cli;

public class EditMovieSettings
{
    [CommandArgument(0, "<Id>")]
    [Description("Id number of the movie")]
    public int Id { get; set; }

    [CommandOption("-t|--title")]
    [Description("New title of the movie")]
    public string? Title { get; set; }

    [CommandOption("-g|--genre")]
    [Description("New genre")]
    public int Genre { get; set; }

    [CommandOption("-s|--status")]
    [Description("New status of the movie")]
    public string? Status { get; set; }

    [CommandOption("-r|--rating")]
    [Description("New rating of the movie")]
    public int Rating { get; set; }
}
