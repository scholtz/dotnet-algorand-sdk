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
                .WithNotParsed(errs =>
                {
                    // --help and --version are reported as "not parsed" too, but are not failures
                    if (errs.All(e => e is HelpRequestedError || e is VersionRequestedError || e is HelpVerbRequestedError)) return;
                    Console.WriteLine("Invalid arguments. Use --help for usage.");
                    Environment.ExitCode = 1;
                })
                .WithParsedAsync(async opts =>
                {
                    if (!string.IsNullOrEmpty(opts.Url) && !string.IsNullOrEmpty(opts.File))
                    {
                        Console.WriteLine("Error: You cannot specify both --url and --file.");
                        Environment.ExitCode = 1;
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
                            Environment.ExitCode = 1;
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
                    try
                    {
                        if (!string.IsNullOrEmpty(opts.Url))
                        {
                            using var client = new HttpClient();
                            var response = await client.GetAsync(opts.Url);
                            response.EnsureSuccessStatusCode();
                            content = Encoding.UTF8.GetBytes(await response.Content.ReadAsStringAsync());
                        }
                        else
                        {
                            content = File.ReadAllBytes(opts.File!);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Error: could not read the contract spec: {ex.Message}");
                        Environment.ExitCode = 1;
                        return;
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
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Error: could not generate a client from the spec: {ex.Message}");
                        Environment.ExitCode = 1;
                        return;
                    }

                    try
                    {
                        // the file name is the (validated, identifier-only) contract name from the spec
                        var fileName = generator.GetOutputFileName();

                        if (!Directory.Exists(opts.Output))
                        {
                            Directory.CreateDirectory(opts.Output);
                        }
                        if (Directory.Exists(opts.Output))
                        {
                            var name = Path.Combine(opts.Output, fileName);
                            File.WriteAllText(name, appProxy);
                            Console.WriteLine($"The file was saved to {name}");
                        }
                        else
                        {
                            Console.Error.WriteLine($"The directory does not exists {opts.Output}");
                            Environment.ExitCode = 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Error: could not write the generated client: {ex.Message}");
                        Environment.ExitCode = 1;
                    }
                });
        }
    }
}
