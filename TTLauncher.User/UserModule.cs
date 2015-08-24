using System;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;
using TTLauncher.Infrastructure;
using TTLauncher.User.Views;

namespace TTLauncher.User
{
    [ModuleExport(typeof(UserModule))]
    public class UserModule : IModule
    {
        [Import]
        public IRegionManager regionManager;
        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(RegionNames.HeaderRegion, typeof(UserView));
        }
    }
}
