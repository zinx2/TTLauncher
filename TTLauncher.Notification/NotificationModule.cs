using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;
using TTLauncher.Infrastructure;
using TTLauncher.Notification.Views;

namespace TTLauncher.Notification
{
    [ModuleExport(typeof(NotificationModule))]
    public class NotificationModule : IModule
    {
        [Import]
        public IRegionManager regionManager; 
        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(RegionNames.MainNavigationRegion, typeof(NotificationButton));
        }
    }
}
