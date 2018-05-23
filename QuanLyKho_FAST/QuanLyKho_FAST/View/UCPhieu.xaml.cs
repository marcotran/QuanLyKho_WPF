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

namespace QuanLyKho_FAST.View
{
    /// <summary>
    /// Interaction logic for UCPhieu.xaml
    /// </summary>
    public partial class UCPhieu : UserControl
    {
        public UCPhieu()
        {
            InitializeComponent();
            
        }

        private void btnPN_Click(object sender, RoutedEventArgs e)
        {
            btnPN.Background = Brushes.ForestGreen;
            btnPX.Background = Brushes.Transparent;

            GridMainRight.Children.Clear();

            PhieuNhapHang hhObj = new PhieuNhapHang();

            GridMainRight.Children.Add(hhObj);
        }

        private void btnPX_Click(object sender, RoutedEventArgs e)
        {
            btnPN.Background = Brushes.Transparent;
            btnPX.Background = Brushes.ForestGreen;

            GridMainRight.Children.Clear();

            PhieuXuatHang hhObj = new PhieuXuatHang();

            GridMainRight.Children.Add(hhObj);
        }
    }
}
