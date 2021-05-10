using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaDockApplication.Views.Documents
{
    public class TestDocumentView : UserControl
    {
        public TestDocumentView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
