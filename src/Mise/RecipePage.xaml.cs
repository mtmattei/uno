using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
namespace Mise;

public sealed partial class RecipePage : Page
{
    internal static RecipePage? Current;
    public RecipeViewModel ViewModel { get; } = new();
    private string _mode = "inspect", _selected = "title", _binding = "OneWay";
    private int _revision;
    private bool _loaded, _checking;
    private readonly List<string> _events = new();
    private Border[] Regions => [PageRegion, PhotoRegion, TitleRegion, SaveRegion, ServingsRegion, IngredientsRegion];
    public RecipePage()
    {
        InitializeComponent(); Current = this; DataContext = ViewModel;
        ViewModel.Traced += message => { _events.Insert(0, message); if (_events.Count > 16) _events.RemoveAt(16); Publish(); };
        ViewModel.PropertyChanged += (_, _) => DispatcherQueue.TryEnqueue(Publish);
        Loaded += (_, _) => { _loaded = true; BrowserBridge.Attach(); Select("title"); };
        SizeChanged += (_, _) => { if (_loaded) DispatcherQueue.TryEnqueue(Publish); };
    }
    private void OnRegionTapped(object sender, TappedRoutedEventArgs e)
    {
        if (_mode != "inspect" || sender is not Border b) return;
        e.Handled = true; Select(b.Tag?.ToString() ?? "page");
    }
    private async void OnSaveClick(object sender, RoutedEventArgs e)
    {
        if (_mode == "inspect") { Select("save"); return; }
        await ViewModel.SaveAsync(); Publish();
    }
    private void OnLess(object sender, RoutedEventArgs e) { if (_mode == "inspect") Select("servings"); else ViewModel.Servings--; Publish(); }
    private void OnMore(object sender, RoutedEventArgs e) { if (_mode == "inspect") Select("servings"); else ViewModel.Servings++; Publish(); }
    private void OnChecked(object sender, RoutedEventArgs e) { if (_loaded && !_checking) Publish(); }
    private void Select(string id)
    {
        if (!Regions.Any(b => b.Tag?.ToString() == id)) return;
        _selected = id;
        foreach (var b in Regions)
            b.BorderBrush = new SolidColorBrush(_mode == "inspect" && b.Tag?.ToString() == id
                ? Windows.UI.Color.FromArgb(255, 182, 82, 44) : Microsoft.UI.Colors.Transparent);
        CoffeeCheck.IsHitTestVisible = WaterCheck.IsHitTestVisible = MilkCheck.IsHitTestVisible = _mode != "inspect";
        Publish();
    }
    private void SetBindingMode(string mode)
    {
        if (mode is not ("OneWay" or "OneTime")) return;
        _binding = mode;
        RecipeTitle.ClearValue(TextBlock.TextProperty);
        RecipeTitle.SetBinding(TextBlock.TextProperty, new Binding
        {
            Source = ViewModel, Path = new PropertyPath(nameof(RecipeViewModel.Title)),
            Mode = mode == "OneWay" ? BindingMode.OneWay : BindingMode.OneTime
        });
    }
    internal async Task Receive(string text)
    {
        string? requestId = null;
        try
        {
            using var doc = JsonDocument.Parse(text);
            var r = doc.RootElement;
            requestId = r.TryGetProperty("id", out var rid) ? rid.GetString() : null;
            var action = r.GetProperty("action").GetString();
            var value = r.TryGetProperty("value", out var v) ? v : default;
            switch (action)
            {
                case "snapshot": break;
                case "select": Select(value.GetString() ?? "title"); break;
                case "mode": _mode = value.GetString() == "use" ? "use" : "inspect"; Select(_selected); break;
                case "title": ViewModel.Title = value.GetString() ?? ""; break;
                case "binding": SetBindingMode(value.GetString() ?? "OneWay"); break;
                case "fontSize": RecipeTitle.FontSize = Math.Clamp(value.GetDouble(), 24, 52); break;
                case "spacing": ContentStack.Spacing = Math.Clamp(value.GetDouble(), 8, 28); break;
                case "imageFit": RecipePhoto.Stretch = value.GetString() == "Uniform" ? Stretch.Uniform : Stretch.UniformToFill; break;
                case "servings": ViewModel.Servings = value.GetInt32(); break;
                case "save": await ViewModel.SaveAsync(); break;
                case "checked":
                    if (value.GetArrayLength() != 3) throw new ArgumentException("Expected three checks.");
                    CoffeeCheck.IsChecked = value[0].GetBoolean(); WaterCheck.IsChecked = value[1].GetBoolean(); MilkCheck.IsChecked = value[2].GetBoolean(); break;
                case "challenge.start": SetBindingMode("OneTime"); ViewModel.Title = "Your Sunday coffee ritual"; break;
                case "challenge.check": await CheckBinding(requestId); return;
                case "reset":
                    if (ViewModel.IsBusy) throw new InvalidOperationException("Wait for saving to complete.");
                    SetBindingMode("OneWay"); ViewModel.Reset(); RecipeTitle.FontSize = 36; ContentStack.Spacing = 16;
                    CoffeeCheck.IsChecked = WaterCheck.IsChecked = MilkCheck.IsChecked = false;
                    RecipePhoto.Stretch = Stretch.UniformToFill; _events.Clear(); break;
                default: throw new ArgumentException("Unsupported command.");
            }
            await Task.Delay(24);
            Publish(requestId);
        }
        catch (Exception ex) { BrowserBridge.Emit(JsonSerializer.Serialize(new { type = "error", requestId, message = ex.Message })); }
    }
    private async Task CheckBinding(string? requestId)
    {
        _checking = true;
        var original = ViewModel.Title;
        try
        {
            ViewModel.Title = "A new title, without rebuilding";
            await Task.Delay(40);
            var first = RecipeTitle.Text == ViewModel.Title;
            ViewModel.Title = "Another title, same live binding";
            await Task.Delay(40);
            var second = RecipeTitle.Text == ViewModel.Title;
            BrowserBridge.Emit(JsonSerializer.Serialize(new
            {
                type = "checks", requestId, passed = first && second,
                results = new[] {
                    new { name = "First source change reaches the TextBlock", passed = first },
                    new { name = "A second, unseen source change also reaches the TextBlock", passed = second }
                }
            }));
        }
        finally { ViewModel.Title = original; _checking = false; await Task.Delay(24); Publish(); }
    }
    private void Publish(string? requestId = null)
    {
        if (!_loaded || _checking) return;
        BrowserBridge.Emit(JsonSerializer.Serialize(new
        {
            type = "state", requestId, revision = ++_revision, runtime = "uno-wasm", app = "mise",
            selected = _selected, mode = _mode, binding = _binding,
            title = ViewModel.Title, renderedTitle = RecipeTitle.Text,
            fontSize = RecipeTitle.FontSize, spacing = ContentStack.Spacing,
            imageFit = RecipePhoto.Stretch.ToString(), servings = ViewModel.Servings,
            coffee = ViewModel.Coffee, water = ViewModel.Water, milk = ViewModel.Milk,
            saved = ViewModel.IsSaved, busy = ViewModel.IsBusy,
            @checked = new[] { CoffeeCheck.IsChecked == true, WaterCheck.IsChecked == true, MilkCheck.IsChecked == true },
            viewport = new { width = Math.Round(ActualWidth), height = Math.Round(ActualHeight) },
            measured = new { titleWidth = Math.Round(RecipeTitle.ActualWidth), titleHeight = Math.Round(RecipeTitle.ActualHeight) },
            events = _events
        }));
    }
}
public static partial class BrowserBridge
{
    [JSImport("globalThis.AnatomyBridge.attach")]
    internal static partial void Attach();
    [JSImport("globalThis.AnatomyBridge.emit")]
    internal static partial void Emit(string json);
    [JSExport]
    public static void Dispatch(string json)
    {
        var page = RecipePage.Current;
        if (page is not null) page.DispatcherQueue.TryEnqueue(async () => await page.Receive(json));
    }
}
