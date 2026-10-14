using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
namespace Mise;
public sealed partial class App : Application
{
    private Window? _window;
    public App() => Resources.MergedDictionaries.Add(new XamlControlsResources());
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        _window = new Window { Content = new RecipePage() };
        _window.Activate();
    }
}
