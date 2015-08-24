using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace TTLauncher.Notification.Views
{
    /// <summary>
    /// NotificationBoard.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export("NotificationView")]
    public partial class NotificationView : UserControl
    {
        public NotificationView()
        {
            InitializeComponent();
        }

        //[Import]
        //public NotificationBoardModel ViewModel
        //{

        //}
    }
}
