using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
namespace Mise;
public sealed partial class App : Application
{
    private Window? _window;
    public App()
    {
        Console.WriteLine("App Anatomy: constructing App");
        UnhandledException += (_, args) => Console.Error.WriteLine($"App Anatomy: {args.Exception}");
        Resources.MergedDictionaries.Add(new XamlControlsResources());
        Console.WriteLine("App Anatomy: application resources initialized");
    }
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        Console.WriteLine("App Anatomy: OnLaunched");
        _window = new Window { Content = new RecipePage() };
        _window.Activate();
        Console.WriteLine("App Anatomy: recipe window activated");
    }
}
