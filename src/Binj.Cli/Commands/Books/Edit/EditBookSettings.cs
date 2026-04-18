using System.ComponentModel;
using Spectre.Console.Cli;

public class EditBookSettings : CommandSettings
{
    [CommandArgument(0, "<Id>")]
    [Description("Id number of the book")]
    public int Id { get; set; }

    [CommandOption("-t|--title")]
    [Description("New title of the book")]
    public string? Title { get; set; }

    [CommandOption("-p|--page")]
    [Description("New current page number")]
    public int Page { get; set; }

    [CommandOption("-s|--status")]
    [Description("New status of the book")]
    public string? Status { get; set; }
}
