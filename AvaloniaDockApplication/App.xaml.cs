using Avalonia;
using Avalonia.Markup.Xaml;

namespace AvaloniaDockApplication
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
