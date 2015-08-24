using System.ComponentModel.Composition;
using System.Windows.Controls;
using System.ComponentModel.Composition;
using TTLauncher.Editor.ViewModels;

namespace TTLauncher.Editor.Views
{
    /// <summary>
    /// EditorView.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export("SeriesView")]
    public partial class SeriesView : UserControl
    {

        public SeriesView()
        {
            InitializeComponent();
        }

        [Import]
        public TTSeriesViewModel ViewModel
        {
            get { return this.DataContext as TTSeriesViewModel; }
            set { this.DataContext = value; }
        }

    }
}
