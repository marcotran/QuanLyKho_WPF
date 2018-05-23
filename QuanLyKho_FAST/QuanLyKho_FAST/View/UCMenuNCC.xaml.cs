﻿using System;
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

namespace QuanLyKho_FAST.View
{
    /// <summary>
    /// Interaction logic for UCMenuNCC.xaml
    /// </summary>
    public partial class UCMenuNCC : UserControl
    {
        public UCMenuNCC()
        {
            InitializeComponent();

            NhaCungCap hhObj = new NhaCungCap();

            GridMainRight.Children.Add(hhObj);
        }


        private void lvItemNhaCungCap_Selected_1(object sender, RoutedEventArgs e)
        {
            GridMainRight.Children.Clear();

            NhaCungCap hhObj = new NhaCungCap();

            GridMainRight.Children.Add(hhObj);
        }
    }
}
