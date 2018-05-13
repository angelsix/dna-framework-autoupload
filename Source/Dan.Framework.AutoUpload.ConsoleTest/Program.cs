using Dna;
using Dna.AutoUpload;
using System;
using System.Threading.Tasks;

namespace Dan.AutoUpload.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CONSOLE: Hello World!");

            Task.Run(async () =>
            {
                // Setup the Dna Framework
                var framework = new DefaultFrameworkConstruction()
                    .AddFileLogger()
                    .AddAutoUploader()
                    .Build();

                // Setup auto uploader
                framework.UseAutoUploader();

                var uploader = Framework.Service<AutoUploader>();

                Framework.Logger.LogCriticalSource("CONSOLE: Starting 3 times...");
                uploader.StartAsync();
                uploader.StartAsync();
                await uploader.StartAsync();

                Framework.Logger.LogCriticalSource("CONSOLE: Waiting...");
                await Task.Delay(5000);

                Framework.Logger.LogCriticalSource("CONSOLE: Requesting shutdown twice...");
                uploader.StopAsync();
                await uploader.StopAsync();

                Framework.Logger.LogCriticalSource("CONSOLE: Done");
            });

            // Keep open
            Console.ReadLine();
        }
    }
}
