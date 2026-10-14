using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
namespace Mise;

// The same ViewModel is used by the running app and the model checks.
// The save operation is local. It does not call a backend service.
public sealed class RecipeViewModel : INotifyPropertyChanged
{
    private string _title = "A slower morning espresso";
    private int _servings = 2;
    private bool _saved, _busy;
    public event PropertyChangedEventHandler? PropertyChanged;
    public event Action<string>? Traced;
    public RecipeViewModel() => SaveCommand = new AsyncCommand(SaveAsync, () => !IsBusy);
    public string Title
    {
        get => _title;
        set
        {
            var safe = string.IsNullOrWhiteSpace(value) ? "Untitled recipe" : value.Trim();
            safe = safe[..Math.Min(safe.Length, 120)];
            if (_title == safe) return;
            _title = safe;
            Changed();
            Traced?.Invoke("PropertyChanged: Title");
        }
    }
    public int Servings
    {
        get => _servings;
        set
        {
            var bounded = Math.Clamp(value, 1, 8);
            if (_servings == bounded) return;
            _servings = bounded;
            Changed(); Changed(nameof(ServingsLabel));
            Changed(nameof(Coffee)); Changed(nameof(Water)); Changed(nameof(Milk));
            Traced?.Invoke($"PropertyChanged: Servings = {_servings}");
        }
    }
    public string ServingsLabel => $"{Servings} serving{(Servings == 1 ? "" : "s")}";
    public string Coffee => $"{Servings * 18} g";
    public string Water => $"{Servings * 40} ml";
    public string Milk => $"{Servings * 30} ml";
    public bool IsSaved
    {
        get => _saved;
        private set { _saved = value; Changed(); Changed(nameof(SaveLabel)); Changed(nameof(SavedCount)); }
    }
    public bool IsBusy
    {
        get => _busy;
        private set { _busy = value; Changed(); Changed(nameof(SaveLabel)); SaveCommand.Refresh(); }
    }
    public string SaveLabel => IsBusy ? "Saving…" : IsSaved ? "✓  Saved to your recipes" : "+  Save recipe";
    public string SavedCount => IsSaved ? "1 saved" : "0 saved";
    public AsyncCommand SaveCommand { get; }
    public async Task SaveAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        Traced?.Invoke("SaveAsync started → IsBusy = true");
        try
        {
            await Task.Delay(450); // Deliberate local delay, not a network request.
            IsSaved = !IsSaved;
            Traced?.Invoke($"PropertyChanged: IsSaved = {IsSaved.ToString().ToLowerInvariant()}");
        }
        finally
        {
            IsBusy = false;
            Traced?.Invoke("SaveAsync complete → IsBusy = false");
        }
    }
    public void Reset()
    {
        Title = "A slower morning espresso"; Servings = 2; IsSaved = false;
    }
    private void Changed([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new(name));
}
public sealed class AsyncCommand(Func<Task> execute, Func<bool> canExecute) : ICommand
{
    public event EventHandler? CanExecuteChanged;
    public bool CanExecute(object? parameter) => canExecute();
    public async void Execute(object? parameter)
    {
        if (CanExecute(parameter)) await execute();
    }
    public void Refresh() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
