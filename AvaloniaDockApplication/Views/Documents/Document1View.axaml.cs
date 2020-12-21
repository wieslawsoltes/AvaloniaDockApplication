using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaDockApplication.Views.Documents
{
    public class Document1View : UserControl
    {
        public Document1View()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
