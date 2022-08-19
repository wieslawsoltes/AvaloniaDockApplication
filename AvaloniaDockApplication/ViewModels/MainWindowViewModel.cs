using CommunityToolkit.Mvvm.ComponentModel;
using Dock.Model.Core;

namespace AvaloniaDockApplication.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private IFactory? _factory;
    [ObservableProperty] private IDock? _layout;
    [ObservableProperty] private string? _currentView;
}
