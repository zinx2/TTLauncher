using Microsoft.Practices.Prism.Regions;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using TTLauncher.Infrastructure;

namespace TTLauncher.Notification.Views
{
    /// <summary>
    /// NotificationButton.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export]
    [ViewSortHint("01")]
    public partial class NotificationButton : UserControl, IPartImportsSatisfiedNotification
    {
        private static Uri NotificationViewUri = new Uri("/NotificationView", UriKind.Relative);

        [Import]
        public IRegionManager regionManager;

        public NotificationButton()
        {
            InitializeComponent();
        }
        
        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            IRegion mainContentRegion = this.regionManager.Regions[RegionNames.MainContentRegion];
            if(mainContentRegion != null && mainContentRegion.NavigationService!= null)
            {
                mainContentRegion.NavigationService.Navigated += this.MainContentRegion_Navigated;
            }
        }
        public void MainContentRegion_Navigated(object sender, RegionNavigationEventArgs e)
        {
            this.UpdateNavigationButtonState(e.Uri);
        }

        private void UpdateNavigationButtonState(Uri uri)
        {
            this.btn_notification.IsChecked = (uri == NotificationViewUri);
        }

        private void btn_notification_click(object sender, RoutedEventArgs e)
        {
            this.regionManager.RequestNavigate(RegionNames.MainContentRegion, NotificationViewUri);
        }

    }
}
