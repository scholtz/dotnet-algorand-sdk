using Algorand.AVM.ClientGenerator.ABI.ARC56;
using Algorand.AVM.ClientGenerator.Extensions;
using System.Text;
using CommandLine;

namespace client_generator
{
    internal class Program
    {
        class Options
        {
            /// <summary>
            /// File name from local filesystem
            /// </summary>
            [Option('f', "file", Required = false, HelpText = "Specify the AR56 file path - File from local filesystem.")]
            public string? File { get; set; }
            /// <summary>
            /// Specify the AR56 URL
            /// </summary>
            [Option('u', "url", Required = false, HelpText = "Specify the AR56 URL.")]
            public string? Url { get; set; }
            /// <summary>
            /// namespace
            /// </summary>
            [Option('n', "namespace", Required = false, HelpText = "Specify the namespace.")]
            public string Namespace { get; set; } = "AVM.ARC56";
            /// <summary>
            /// namespace
            /// </summary>
            [Option('o', "output", Required = false, HelpText = "Specify the output folder.")]
            public string Output { get; set; } = "out";
        }
        static async Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<Options>(args)
                .WithNotParsed(errs => Console.WriteLine("Invalid arguments. Use --help for usage."))
                .WithParsedAsync(async opts =>
                {
                    if (!string.IsNullOrEmpty(opts.Url) && !string.IsNullOrEmpty(opts.File))
                    {
                        Console.WriteLine("Error: You cannot specify both --url and --file.");
                        return;
                    }

                    if (string.IsNullOrEmpty(opts.Url) && string.IsNullOrEmpty(opts.File))
                    {
                        if (File.Exists("arc56.json"))
                        {
                            opts.File = "arc56.json";
                        }
                        else
                        {
                            Console.WriteLine("Error: Please specify either --url or --file.");
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(opts.File))
                        Console.WriteLine($"File: {opts.File}");
                    if (!string.IsNullOrEmpty(opts.Url))
                        Console.WriteLine($"URL: {opts.Url}");
                    if (!string.IsNullOrEmpty(opts.Namespace))
                        Console.WriteLine($"Namespace: {opts.Namespace}");

                    byte[] content;
                    if (!string.IsNullOrEmpty(opts.Url))
                    {
                        using var client = new HttpClient();
                        var response = await client.GetAsync(opts.Url);
                        content = Encoding.UTF8.GetBytes(await response.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        content = File.ReadAllBytes(opts.File!);
                    }

                    var generator = new ClientGeneratorARC56();
                    string appProxy;
                    try
                    {
                        generator.LoadFromByteArray(content);
                        appProxy = await generator.ToProxy(opts.Namespace ?? "AVM.ARC56");
                    }
                    catch (SpecValidationException ex)
                    {
                        Console.Error.WriteLine($"Error: the contract spec was rejected: {ex.Message}");
                        Environment.ExitCode = 1;
                        return;
                    }

                    if (!Directory.Exists(opts.Output))
                    {
                        Directory.CreateDirectory(opts.Output);
                    }
                    if (Directory.Exists(opts.Output))
                    {
                        // the file name comes from the (untrusted) spec; it must be a bare file name
                        var fileName = generator.GetOutputFileName();
                        if (Path.GetFileName(fileName) != fileName)
                        {
                            Console.Error.WriteLine("Error: the contract name would write outside the output folder.");
                            Environment.ExitCode = 1;
                            return;
                        }
                        var name = Path.Combine(opts.Output, fileName);
                        File.WriteAllText(name, appProxy);
                        Console.WriteLine($"The file was saved to {name}");
                    }
                    else
                    {
                        Console.Error.WriteLine($"The directory does not exists {opts.Output}");
                    }
                });
        }
    }
}
