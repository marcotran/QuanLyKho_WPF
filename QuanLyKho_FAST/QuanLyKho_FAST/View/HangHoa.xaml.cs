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

        public HangHoa()
        {
            InitializeComponent();
        }

        private void LoadDuLieu()
        {
            using (QLKHOEntities db = new QLKHOEntities())
            {
                lvHangHoa.ItemsSource = db.HANG_HOA.ToList<HANG_HOA>();
            }
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
            LoadDuLieu();
        }

        private void lvHangHoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HANG_HOA temp = (HANG_HOA)lvHangHoa.SelectedItem;
            AreaText.DataContext = temp;
            txtMa.IsEnabled = false;
        }

        private void grdButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lvHangHoa.SelectedIndex = -1;
            txtMa.IsEnabled = true;
        }

        //Kiểm tra mã trùng
        private bool CheckID()
        {

            using (QLKHOEntities db = new QLKHOEntities())
            {
                List<HANG_HOA> x = db.HANG_HOA.ToList<HANG_HOA>();

                foreach (HANG_HOA y in x)
                {
                    if (txtMa.Text == y.MA_HH)
                    {
                        MessageBox.Show("Mã hàng hoá đã tồn tại!");
                        return false;
                    }
                }
            }


            return true;
        }

        //Bắt lỗi dữ liệu nhập
        private bool CheckDataInput()
        {
            if (txtMa.Text == "" || txtTen.Text == "" || txtMaNCC.Text == "" || txtGiaNhap.Text == "" || txtGiaXuat.Text == ""
                || txtSoLuong.Text == "")
            {
                MessageBox.Show("Không được để trống!!!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        //kiểm tra mã nhà cung cấp
        private bool CheckMaNCC()
        {
            using (QLKHOEntities db = new QLKHOEntities())
            {
                List<NHA_CUNG_CAP> listNCC = db.NHA_CUNG_CAP.ToList<NHA_CUNG_CAP>();

                foreach (NHA_CUNG_CAP x in listNCC)
                {
                    if (txtMaNCC.Text.Equals(x.MA_NCC) == true)
                    {
                        return true;
                    }
                }
            }
            MessageBox.Show("Mã hàng hoá không tồn tại!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            //Biến tạm lưu dữ liệu nhập
            HANG_HOA temp = new HANG_HOA();
            //HANG_HOA temp = (HANG_HOA)AreaText.DataContext;


            //kiểm tra dữ liệu nhập
            if (CheckDataInput() == false)
                return;


            //Gán dữ liệu 
            temp.MA_HH = txtMa.Text.Trim();
            temp.TEN_HH = txtTen.Text.Trim();
            temp.MA_NCC = txtMaNCC.Text.Trim();
            temp.GIA_NHAP = Int32.Parse(txtGiaNhap.Text.Trim());
            temp.GIA_XUAT = Int32.Parse(txtGiaXuat.Text.Trim());
            temp.SO_LUONG = Int32.Parse(txtSoLuong.Text.Trim());


            // kiểm tra mã hàng hoá
            if (CheckID() == false)
                return;

            // kiểm tra mã nhà cung cấp không tồn tại
            if (CheckMaNCC() == false) return;


            //Nhắc nhở lưu đối tượng
            if (MessageBox.Show("Bạn muốn thêm mới?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (QLKHOEntities db = new QLKHOEntities())
                {
                    db.HANG_HOA.Add(temp);
                    db.SaveChanges();
                }
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                return;
            }

            //Load lại bảng
            LoadDuLieu();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            //Tạm lưu dữ liệu nhập
            HANG_HOA temp = new HANG_HOA();

            //Gán dữ liệu
            temp.MA_HH = txtMa.Text.Trim();
            temp.TEN_HH = txtTen.Text.Trim();
            temp.MA_NCC = txtMaNCC.Text.Trim();
            temp.GIA_NHAP = Int32.Parse(txtGiaNhap.Text.Trim());
            temp.GIA_XUAT = Int32.Parse(txtGiaXuat.Text.Trim());
            temp.SO_LUONG = Int32.Parse(txtSoLuong.Text.Trim());

            //kiểm tra dữ liệu nhập
            if (CheckDataInput() == false)
                return;

            //Bắt lỗi chưa chọn hang hoa trong listview
            if (lvHangHoa.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn hàng hoá!", "Thông báo");
                return;
            }

            // kiểm tra mã nhà cung cấp không tồn tại
            if (CheckMaNCC() == false) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn lưu không!", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (QLKHOEntities db = new QLKHOEntities())
                {
                    db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Lưu thành công!", "Thông báo");
                    LoadDuLieu();
                }
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            HANG_HOA temp = (HANG_HOA)lvHangHoa.SelectedItem;

            //Bắt lỗi chưa chọn hàng hoá trong listview
            if (lvHangHoa.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Nhà cung cấp!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xoá không!", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (QLKHOEntities db = new QLKHOEntities())
                {
                    var entry = db.Entry(temp);
                    if (entry.State == System.Data.Entity.EntityState.Detached)
                    {
                        db.HANG_HOA.Attach(temp);
                    }
                    db.HANG_HOA.Remove(temp);
                    db.SaveChanges();
                    MessageBox.Show("Xoá thành công!", "Thông báo");
                    LoadDuLieu();
                }
            }
            else
            {
                return;
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            using (QLKHOEntities db = new QLKHOEntities())
            {
                List<HANG_HOA> x = db.HANG_HOA.ToList<HANG_HOA>();

                List<HANG_HOA> listFound = new List<HANG_HOA>();

                foreach (HANG_HOA y in x)
                {
                    if (txtTim.Text.Trim().Equals(y.MA_NCC, StringComparison.OrdinalIgnoreCase) == true ||
                        txtTim.Text.Trim().Equals(y.MA_HH, StringComparison.OrdinalIgnoreCase) == true ||
                        txtTim.Text.Trim().Equals(y.TEN_HH, StringComparison.OrdinalIgnoreCase) == true
                        )
                    {
                        listFound.Add(y);
                    }
                }

                lvHangHoa.ItemsSource = listFound;
            }
        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnTim_Click(sender, e);
            }
        }
    }
}
