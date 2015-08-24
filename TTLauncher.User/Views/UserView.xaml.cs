﻿using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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

namespace TTLauncher.User.Views
{
    /// <summary>
    /// UserView.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export]
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
        }
    }
}
