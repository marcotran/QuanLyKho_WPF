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
    /// Interaction logic for NhaCungCap.xaml
    /// </summary>
    public partial class NhaCungCap : UserControl
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
        public NhaCungCap()
        {
            InitializeComponent();
            NapDuLieu();
        }

        private void NapDuLieu()
        {

            List<User> list = new List<User>();
            lvNhaCungCap.ItemsSource = null;

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

            lvNhaCungCap.ItemsSource = list;
        }

    }
}
