using Uno.UI.Hosting;
namespace Mise;
public static class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("App Anatomy: starting WebAssembly host");
        var host = UnoPlatformHostBuilder.Create()
            .App(() => new App())
            .UseWebAssembly()
            .Build();
        await host.RunAsync();
    }
}
