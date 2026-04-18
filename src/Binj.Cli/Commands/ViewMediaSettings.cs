using System.ComponentModel;
using Spectre.Console.Cli;

public class ViewMediaSettings : CommandSettings
{
    [CommandOption("-t|--type")]
    [Description("Filter by type")]
    public string? TypeFilter { get; set; }

    [CommandOption("-s|--sort")]
    [Description("Sort by an attribute")]
    public string SortBy { get; set; } = "Title";
}
