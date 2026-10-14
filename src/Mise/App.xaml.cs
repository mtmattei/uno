using Microsoft.UI.Xaml;
namespace Mise;
public sealed partial class App : Application
{
 private Window? _window;
 public App() { InitializeComponent(); }
 protected override void OnLaunched(LaunchActivatedEventArgs args) { _window = new Window { Content = new RecipePage() }; _window.Activate(); }
}
