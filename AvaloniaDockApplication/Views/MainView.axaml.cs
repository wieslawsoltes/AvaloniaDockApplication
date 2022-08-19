﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaDockApplication.Views;

public class MainView : UserControl
{
    public MainView()
    {
        this.InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}