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

            UCMenuHH ucHH = new UCMenuHH();

            GridMainRight.Children.Add(ucHH);
        }

        private void lvItemTrangChu_Selected(object sender, RoutedEventArgs e)
        {
            GridMainRight.Children.Clear();
            
            TrangChu tcObj = new TrangChu();
            GridMainRight.Children.Add(tcObj);
        }

        private void lvItemNCC_Selected(object sender, RoutedEventArgs e)
        {
            GridMainRight.Children.Clear();
            
            UCMenuNCC ucNCC = new UCMenuNCC();

            GridMainRight.Children.Add(ucNCC);
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void lvItemThoat_Selected(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lvItemTonDauKy_Selected(object sender, RoutedEventArgs e)
        {

        }

        int flag = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(flag == 0)
            {
                GridMenu.Width = 50;
                flag = 1;
            }
            else
            {
                GridMenu.Width = 250;
                flag = 0;
            }
        }

        private void lvItemPhieu_Selected(object sender, RoutedEventArgs e)
        {
            GridMainRight.Children.Clear();

            UCPhieu ucNCC = new UCPhieu();

            GridMainRight.Children.Add(ucNCC);
        }
    }
}
