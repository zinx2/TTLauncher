using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;
using TTLauncher.Editor.Views;
using TTLauncher.Infrastructure;

namespace TTLauncher.Editor
{
    [ModuleExport(typeof(EditorModule))]
    public class EditorModule : IModule
    {
        [Import]
        public IRegionManager regionManager;
        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(RegionNames.MainNavigationRegion, typeof(EditorButton));
        }
    }
}
