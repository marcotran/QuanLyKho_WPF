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
using System.Text.RegularExpressions;

namespace QuanLyKho_FAST.View
{
    /// <summary>
    /// Interaction logic for HangHoa.xaml
    /// </summary>
    public partial class HangHoa : UserControl
    {
        public class User
        {
            public string ID { get; set; }
            public string Ten { set; get; }
            public string DiaChi { set; get; }
            public string DienThoai { set; get; }
            public string Email { set; get; }
            public string Fax { set; get; }
            public string MaSoThue { set; get; }
            public string SoTaiKhoan { set; get; }
        }

        public HangHoa()
        {
            InitializeComponent();

            NapDuLieu();
        }

        private void NapDuLieu()
        {

            List<User> list = new List<User>();
            lvHangHoa.ItemsSource = null;

            for (int i = 0; i < 10; i++)
            {
                list.Add(new User()
                {
                    ID = (i + 1).ToString(),
                    Ten = "FPT",
                    DiaChi = "TPHCM",
                    DienThoai = "123456789",
                    Email = "fpt@gmail.com",
                    Fax = "2378467",
                    MaSoThue = "103857",
                    SoTaiKhoan = "82756134"
                });
            }

            lvHangHoa.ItemsSource = list;
        }

        private void txtSoLuong_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtGiaXuat_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtGiaNhap_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void lvHangHoa_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
