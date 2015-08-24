using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using TTLauncher.Infrastructure;

namespace TTLauncher
{
    /// <summary>
    /// Shell.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export]
    public partial class Shell : Window, IPartImportsSatisfiedNotification
    {
        private const string NotificationModuleName = "NotificationModule";
        private static Uri NotificationViewUri = new Uri("/NotificationView", UriKind.Relative);
        public Shell()
        {
            InitializeComponent();
        }

        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;

        [Import(AllowRecomposition = false)]
        public IRegionManager RegionManager;

        public void OnImportsSatisfied()
        {
            this.ModuleManager.LoadModuleCompleted +=
                (s, e) =>
                {
                    if (e.ModuleInfo.ModuleName == NotificationModuleName)
                    {
                        this.RegionManager.RequestNavigate(RegionNames.MainContentRegion, NotificationViewUri);
                    }
                };
        }
    }



}
