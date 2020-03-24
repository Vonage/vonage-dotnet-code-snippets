using System;
using System.Reflection;

namespace DotnetCliCodeSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            var snippet = string.Empty;
            var oSet = new OptionSet() { { "s|snippet=", "The Code Snippet you'd like to execute", v=> snippet=v } };

            var parsedArgs = oSet.Parse(args);

            var type = Type.GetType("DotnetCliCodeSnippets." + snippet);

            var runnableSnippet = (ICodeSnippet)Activator.CreateInstance(type);
            runnableSnippet.Execute();
        }
    }
}
