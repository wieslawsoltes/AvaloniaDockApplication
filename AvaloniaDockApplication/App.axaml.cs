using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaDockApplication.Models;
using AvaloniaDockApplication.ViewModels;
using AvaloniaDockApplication.Views;
using Dock.Model.Core;

namespace AvaloniaDockApplication
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var factory = new MainDockFactory(new DemoData());
            var layout = factory.CreateLayout();
            factory.InitLayout(layout);

            var mainWindowViewModel = new MainWindowViewModel()
            {
                Factory = factory,
                Layout = layout
            };

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
            {
                
                var mainWindow = new MainWindow
                {
                    DataContext = mainWindowViewModel
                };

                mainWindow.Closing += (_, _) =>
                {
                    if (layout is IDock dock)
                    {
                        if (dock.Close.CanExecute(null))
                        {
                            dock.Close.Execute(null);
                        }
                    }
                };

                desktopLifetime.MainWindow = mainWindow;

                desktopLifetime.Exit += (_, _) =>
                {
                    if (layout is IDock dock)
                    {
                        if (dock.Close.CanExecute(null))
                        {
                            dock.Close.Execute(null);
                        }
                    }
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewLifetime)
            {
                var mainView = new MainView()
                {
                    DataContext = mainWindowViewModel
                };

                singleViewLifetime.MainView = mainView;
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
}
