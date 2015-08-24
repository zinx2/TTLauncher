using Microsoft.Practices.Prism.Regions;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using TTLauncher.Infrastructure;

namespace TTLauncher.Option.Views
{
    /// <summary>
    /// OptionButton.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export]
    [ViewSortHint("03")]
    public partial class OptionButton : UserControl, IPartImportsSatisfiedNotification
    {
        private static Uri OptionViewUrl = new Uri("/OptionView", UriKind.Relative);

        [Import]
        public IRegionManager regionManager;
        public OptionButton()
        {
            InitializeComponent();
        }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            IRegion mainContentRegion = this.regionManager.Regions[RegionNames.MainContentRegion];
            if (mainContentRegion != null && mainContentRegion.NavigationService != null)
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
            this.btn_option.IsChecked = (uri == OptionViewUrl);
        }
        private void btn_option_click(object sender, RoutedEventArgs e)
        {
            this.regionManager.RequestNavigate(RegionNames.MainContentRegion, OptionViewUrl);
        }
    }
}
