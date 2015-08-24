using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;
using TTLauncher.Infrastructure;
using TTLauncher.Option.Views;

namespace TTLauncher.Option
{
    [ModuleExport(typeof(OptionModule))]
    public class OptionModule : IModule
    {
        [Import]
        public IRegionManager regionManager;
        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(RegionNames.MainNavigationRegion, typeof(OptionButton));
        }
    }
}
