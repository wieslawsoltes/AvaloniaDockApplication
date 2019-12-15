using System;
using Dock.Model;
using Dock.Model.Controls;

namespace AvaloniaDockApplication.ViewModels
{
    public class MainViewModel : RootDock
    {
        public override IDockable Clone()
        {
            var mainViewModel = new MainViewModel();

            CloneHelper.CloneDockProperties(this, mainViewModel);
            CloneHelper.CloneRootDockProperties(this, mainViewModel);

            return mainViewModel;
        }
    }
}
