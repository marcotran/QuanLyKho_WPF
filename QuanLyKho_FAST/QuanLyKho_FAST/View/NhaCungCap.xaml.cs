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
using QuanLyKho_FAST.Model;
using System.Data.Entity;

namespace QuanLyKho_FAST.View
{
    /// <summary>
    /// Interaction logic for NhaCungCap.xaml
    /// </summary>
    public partial class NhaCungCap : UserControl
    {
        //Biến cục bộ



        public NhaCungCap()
        {
            InitializeComponent();
            LoadDuLieu();
        }

        #region methods

        //Load dữ liệu lên listview
        private void LoadDuLieu()
        {
            using (QLKHOEntities db = new QLKHOEntities())
            {
                lvNhaCungCap.ItemsSource = db.NHA_CUNG_CAP.ToList<NHA_CUNG_CAP>();
            }
            //lvNhaCungCap.SelectedIndex = 0;

        }

        //Bắt lỗi dữ liệu nhập
        private bool CheckDataInput()
        {
            if (txtMa.Text == "" || txtTen.Text == "" || txtDiaChi.Text == "" || txtMaSoThue.Text == "" || txtDienThoai.Text == ""
                || txtEmail.Text == "" || txtFax.Text == "" || txtSoTaiKhoan.Text == "")
            {
                MessageBox.Show("Không được để trống!!!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        //Kiểm tra mã trùng
        private bool CheckID()
        {

            using (QLKHOEntities db = new QLKHOEntities())
            {
                List<NHA_CUNG_CAP> x = db.NHA_CUNG_CAP.ToList<NHA_CUNG_CAP>();

                foreach (NHA_CUNG_CAP y in x)
                {
                    if (txtMa.Text == y.MA_NCC)
                    {
                        MessageBox.Show("Mã nhà cung cấp đã tồn tại!");
                        return false;
                    }
                }
            }


            return true;
        }

        #endregion

        private void lvNhaCungCap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            NHA_CUNG_CAP test = (NHA_CUNG_CAP)lvNhaCungCap.SelectedItem;
            //txtMa.Text = test.MA_NCC;
            AreaText.DataContext = test;

            txtMa.IsEnabled = false;

        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnTim_Click(sender,e);
            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            //Biến tạm lưu dữ liệu nhập
            NHA_CUNG_CAP test = new NHA_CUNG_CAP();
            //NHA_CUNG_CAP test = (NHA_CUNG_CAP)AreaText.DataContext;

            //Gán dữ liệu 
            test.MA_NCC = txtMa.Text.Trim();
            test.TEN_NCC = txtTen.Text.Trim();
            test.DIACHI = txtDiaChi.Text.Trim();
            test.MA_SO_THUE = txtMaSoThue.Text.Trim();
            test.DIEN_THOAI = txtDienThoai.Text.Trim();
            test.EMAIL = txtEmail.Text.Trim();
            test.FAX = txtFax.Text.Trim();
            test.SO_TAI_KHOAN = txtSoTaiKhoan.Text.Trim();

            //kiểm tra dữ liệu nhập
            if (CheckDataInput() == false)
                return;

            //
            if (CheckID() == false)
                return;

            //Nhắc nhở lưu đối tượng
            if (MessageBox.Show("Bạn muốn thêm nhà cung cấp mới?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (QLKHOEntities db = new QLKHOEntities())
                {
                    db.NHA_CUNG_CAP.Add(test);
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
            NHA_CUNG_CAP temp = new NHA_CUNG_CAP();

            //Gán dữ liệu
            temp.MA_NCC = txtMa.Text.Trim();
            temp.TEN_NCC = txtTen.Text.Trim();
            temp.DIACHI = txtDiaChi.Text.Trim();
            temp.MA_SO_THUE = txtMaSoThue.Text.Trim();
            temp.DIEN_THOAI = txtDienThoai.Text.Trim();
            temp.EMAIL = txtEmail.Text.Trim();
            temp.FAX = txtFax.Text.Trim();
            temp.SO_TAI_KHOAN = txtSoTaiKhoan.Text.Trim();

            //kiểm tra dữ liệu nhập
            if (CheckDataInput() == false)
                return;

            //Bắt lỗi chưa chọn nhà cung cấp trong listview
            if (lvNhaCungCap.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Nhà cung cấp!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn lưu không!", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (QLKHOEntities db = new QLKHOEntities())
                {
                    db.Entry(temp).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Lưu thành công!", "Thông báo");
                    LoadDuLieu();
                }
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lvNhaCungCap.SelectedIndex = -1;

            //Khoá txtMa
            txtMa.IsEnabled = true;
        }

        private void AreaText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lvNhaCungCap.SelectedIndex = -1;

            //Khoá txtMa
            txtMa.IsEnabled = true;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            NHA_CUNG_CAP temp = (NHA_CUNG_CAP)lvNhaCungCap.SelectedItem;

            //Bắt lỗi chưa chọn nhà cung cấp trong listview
            if (lvNhaCungCap.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Nhà cung cấp!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xoá không!", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (QLKHOEntities db = new QLKHOEntities())
                {
                    var entry = db.Entry(temp);
                    if (entry.State == EntityState.Detached)
                    {
                        db.NHA_CUNG_CAP.Attach(temp);
                    }
                    db.NHA_CUNG_CAP.Remove(temp);
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
                List<NHA_CUNG_CAP> x = db.NHA_CUNG_CAP.ToList<NHA_CUNG_CAP>();

                List<NHA_CUNG_CAP> listFound = new List<NHA_CUNG_CAP>();

                foreach (NHA_CUNG_CAP y in x)
                {
                    if (txtTim.Text.Trim().Equals(y.MA_NCC, StringComparison.OrdinalIgnoreCase) == true ||
                        txtTim.Text.Trim().Equals(y.TEN_NCC, StringComparison.OrdinalIgnoreCase) == true ||
                        txtTim.Text.Trim().Equals(y.DIACHI, StringComparison.OrdinalIgnoreCase) == true ||
                        txtTim.Text.Trim().Equals(y.DIEN_THOAI, StringComparison.OrdinalIgnoreCase) == true ||
                        txtTim.Text.Trim().Equals(y.EMAIL, StringComparison.OrdinalIgnoreCase) == true ||
                        txtTim.Text.Trim().Equals(y.FAX, StringComparison.OrdinalIgnoreCase) == true ||
                        txtTim.Text.Trim().Equals(y.MA_SO_THUE, StringComparison.OrdinalIgnoreCase) == true ||
                        txtTim.Text.Trim().Equals(y.SO_TAI_KHOAN, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        listFound.Add(y);
                    }
                }

                lvNhaCungCap.ItemsSource = listFound;
            }
        }

        private void txtMa_TextChanged(object sender, TextChangedEventArgs e)
        {


        }
    }
}
