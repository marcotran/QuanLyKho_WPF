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
using System.Windows.Shapes;

namespace QuanLyKho_FAST.View
{
    /// <summary>
    /// Interaction logic for NhaCungCap.xaml
    /// </summary>
    /// 

    

    public partial class ViewBack : Window
    {
        public ViewBack()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lvItemHangHoa_Selected(object sender, RoutedEventArgs e)
        {
            GridMainRight.Children.Clear();
            AreaButton.Children.Clear();

            HangHoa hhObj = new HangHoa();
            UCMenuHH ucHH = new UCMenuHH();

            AreaButton.Children.Add(ucHH);
            GridMainRight.Children.Add(hhObj);
        }

        private void lvItemTrangChu_Selected(object sender, RoutedEventArgs e)
        {
            GridMainRight.Children.Clear();
            AreaButton.Children.Clear();
            TrangChu tcObj = new TrangChu();
            GridMainRight.Children.Add(tcObj);
        }

        private void lvItemNCC_Selected(object sender, RoutedEventArgs e)
        {
            GridMainRight.Children.Clear();
            AreaButton.Children.Clear();

            NhaCungCap nccObj = new NhaCungCap();
            UCMenuNCC ucNCC = new UCMenuNCC();

            AreaButton.Children.Add(ucNCC);
            GridMainRight.Children.Add(nccObj);
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
