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
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            using(QLKHOEntities db = new QLKHOEntities())
            {
                List<Tai_Khoan> t = db.Tai_Khoan.ToList();

                foreach (Tai_Khoan y in t)
                {
                    if (txtTenDangNhap.Text.Equals(y.username.Trim()) == true && txtMatKhau.Password.Equals(y.username.Trim()) == true)
                    {
                        this.Hide();
                        new ViewBack().ShowDialog();
                        this.Close();
                    }
                    txtCanhBao.Visibility = Visibility.Visible;
                }
            }

            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
