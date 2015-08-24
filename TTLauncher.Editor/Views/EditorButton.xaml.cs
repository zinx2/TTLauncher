using Microsoft.Practices.Prism.Regions;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using TTLauncher.Infrastructure;

namespace TTLauncher.Editor.Views
{
    /// <summary>
    /// EditorButton.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export]
    [ViewSortHint("02")]
    public partial class EditorButton : UserControl, IPartImportsSatisfiedNotification
    {
        private static Uri SeriesViewUrl = new Uri("/SeriesView", UriKind.Relative);

        [Import]
        public IRegionManager regionManager;
        public EditorButton()
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
            this.btn_editor.IsChecked = (uri == SeriesViewUrl);
        }

        private void btn_editor_click(object sender, RoutedEventArgs e)
        {
            this.regionManager.RequestNavigate(RegionNames.MainContentRegion, SeriesViewUrl);
        }
    }
}
