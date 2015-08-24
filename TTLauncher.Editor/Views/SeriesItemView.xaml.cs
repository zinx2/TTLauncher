using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TTLauncher.Editor.Views
{
    /// <summary>
    /// SeriesItemView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SeriesItemView : UserControl
    {
        public SeriesItemView()
        {
            InitializeComponent();
        }

        public string SeriesName
        {
            get
            {
                return (string)GetValue(SeriesNameProperty);
            }
            set
            {
                SetValue(SeriesNameProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SeriesNameProperty =
            DependencyProperty.Register("SeriesName", typeof(string), typeof(SeriesItemView), new PropertyMetadata(OnSeriesNamePropertyChanged));

        private static void OnSeriesNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SeriesItemView)
            {
                SeriesItemView item = d as SeriesItemView;
                item.tb_Name.Text = "" + e.NewValue;
            }
        }

        public string ThumbnailPath
        {
            get
            {
                return (string)GetValue(ThumbnailPathProperty);
            }
            set
            {
                SetValue(ThumbnailPathProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ImagePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ThumbnailPathProperty =
            DependencyProperty.Register("ThumbnailPath", typeof(string), typeof(SeriesItemView), new PropertyMetadata(OnThumbnailPathPropertyChanged));

        private static void OnThumbnailPathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SeriesItemView)
            {
                SeriesItemView item = d as SeriesItemView;
                string path = e.NewValue as string;

                if (path != null)
                {
                    BitmapImage bmp = new BitmapImage(new Uri(path, UriKind.Relative));
                    item.img_Thumbnail.Source = bmp;
                    //RenderOptions.SetBitmapScalingMode(item.img_Thumbnail, BitmapScalingMode.HighQuality);
                }
            }
        }
    }
}
