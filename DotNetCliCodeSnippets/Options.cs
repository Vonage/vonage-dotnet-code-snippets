using CommandLine;

namespace DotnetCliCodeSnippets;

internal class Options
{
    [Option('s', "snippet", Required = true, HelpText = "The Code Snippet you'd like to execute")]
    public string Snippet { get; set; }
}