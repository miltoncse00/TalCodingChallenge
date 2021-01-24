using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CodingChallenge.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(
                    builder =>
                    {
                        builder.ClearProviders();
                        builder.AddDebug();
                        builder.AddConsole();
                        // Providing an instrumentation key here is required if you're using
                        // standalone package Microsoft.Extensions.Logging.ApplicationInsights
                        // or if you want to capture logs from early in the application startup
                        // pipeline from Startup.cs or Program.cs itself.
                        builder.AddApplicationInsights("7461a7c3-d425-45c2-8471-1fb9a39ecf19");

                        // Optional: Apply filters to control what logs are sent to Application Insights.
                        // The following configures LogLevel Information or above to be sent to
                        // Application Insights for all categories.
                        builder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>
                            ("", LogLevel.Information);
                    }
                );

    }
}
