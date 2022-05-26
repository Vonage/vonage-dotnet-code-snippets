using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Vonage.Logger;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;

namespace DotnetCliCodeSnippets
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm} [{Level}]: {Message}\n")
                .CreateLogger();
            var factory = new LoggerFactory();
            factory.AddSerilog(log);
            LogProvider.SetLogFactory(factory);

            var result = Parser.Default.ParseArguments<Options>(args);
            
            if (!string.IsNullOrEmpty(result.Value.Snippet))
            {
                await RunSnippet(result.Value.Snippet);
            }
        }
        
        private static async Task RunSnippet(string snippet)
        {
            var type = Type.GetType("DotnetCliCodeSnippets." + snippet);
            if (type == null)
            {
                Console.WriteLine($"Could not locate snippet '{snippet}'");
                return;
            }

            var runnableSnippet = (ICodeSnippet) Activator.CreateInstance(type);
            if (runnableSnippet != null)
                await runnableSnippet.Execute();
            else
                Console.WriteLine($"Could not find '{type.Name}'");
        }
    }
}