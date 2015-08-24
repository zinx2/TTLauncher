using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace TTLauncher.Option.Views
{
    /// <summary>
    /// OptionView.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export("OptionView")]
    public partial class OptionView : UserControl
    {
        public OptionView()
        {
            InitializeComponent();
        }
    }
}
