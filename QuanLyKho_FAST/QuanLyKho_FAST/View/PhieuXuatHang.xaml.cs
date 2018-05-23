using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for PhieuXuatHang.xaml
    /// </summary>
    public partial class PhieuXuatHang : UserControl
    {
        public PhieuXuatHang()
        {
            InitializeComponent();
            LoadDuLieu();
        }
        //Load dữ liệu lên listview
        private void LoadDuLieu()
        {
            using (QLKHOEntities db = new QLKHOEntities())
            {
                lvNhaCungCap.ItemsSource = db.PHIEU_XUAT_HH.ToList();
            }
            //lvNhaCungCap.SelectedIndex = 0;

        }

        //Bắt lỗi dữ liệu nhập
        private bool CheckDataInput()
        {
            if ( txtDienGiai.Text == "" || txtGia.Text == "" || txtMaHH.Text == "" || txtMaNCC.Text == ""
                 || txtSL.Text == "")
            {
                MessageBox.Show("Không được để trống!!!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            //Biến tạm lưu dữ liệu nhập
            PHIEU_XUAT_HH test = new PHIEU_XUAT_HH();
            //NHA_CUNG_CAP test = (NHA_CUNG_CAP)AreaText.DataContext;

            //Gán dữ liệu 
            test.NGAYXUAT = DateTime.Parse(txtNgay.Text);
            test.MANCC = txtMaNCC.Text.Trim();
            test.MAHH = txtMaHH.Text.Trim();
            test.SOLUONG = Int32.Parse(txtSL.Text.Trim());
            test.GIA = Int32.Parse(txtGia.Text.Trim());
            test.TIEN = Int32.Parse(txtSL.Text.Trim()) * Int32.Parse(txtGia.Text.Trim());
            test.DIENGIAI = txtDienGiai.Text.Trim();

            //kiểm tra dữ liệu nhập
            if (CheckDataInput() == false)
                return;

            //
            //if (CheckID() == false)
            //return;

            //Nhắc nhở lưu đối tượng
            if (MessageBox.Show("Bạn muốn thêm phiếu nhập mới?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (QLKHOEntities db = new QLKHOEntities())
                {
                    db.PHIEU_XUAT_HH.Add(test);
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
            PHIEU_XUAT_HH temp = (PHIEU_XUAT_HH)lvNhaCungCap.SelectedItem;

            //Gán dữ liệu
            temp.NGAYXUAT = DateTime.Parse(txtNgay.Text);
            temp.MANCC = txtMaHH.Text.Trim();
            temp.MAHH = txtMaHH.Text.Trim();
            temp.SOLUONG = Int32.Parse(txtSL.Text.Trim());
            temp.GIA = Int32.Parse(txtGia.Text.Trim());
            temp.TIEN = Int32.Parse(txtSL.Text.Trim()) * Int32.Parse(txtGia.Text.Trim());
            temp.DIENGIAI = txtDienGiai.Text.Trim();

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

        private void lvNhaCungCap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PHIEU_XUAT_HH test = (PHIEU_XUAT_HH)lvNhaCungCap.SelectedItem;
            //txtMa.Text = test.MA_NCC;
            AreaText.DataContext = test;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            PHIEU_XUAT_HH temp = (PHIEU_XUAT_HH)lvNhaCungCap.SelectedItem;

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
                        db.PHIEU_XUAT_HH.Attach(temp);
                    }
                    db.PHIEU_XUAT_HH.Remove(temp);
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
            if (txtTim.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm!", "Thông báo!");
            }

            using (QLKHOEntities db = new QLKHOEntities())
            {
                List<PHIEU_XUAT_HH> x = db.PHIEU_XUAT_HH.ToList();

                List<PHIEU_XUAT_HH> listFound = new List<PHIEU_XUAT_HH>();

                foreach (PHIEU_XUAT_HH y in x)
                {
                    if (txtTim.Text.Trim().Equals(y.NGAYXUAT.ToString(), StringComparison.OrdinalIgnoreCase) == true ||
                        txtTim.Text.Trim().Equals(y.MAHH, StringComparison.OrdinalIgnoreCase) == true ||
                        txtTim.Text.Trim().Equals(y.MANCC, StringComparison.OrdinalIgnoreCase) == true ||
                        Int32.Parse(txtTim.Text.Trim()) == y.GIA ||
                        Int32.Parse(txtTim.Text.Trim()) == y.TIEN ||
                        Int32.Parse(txtTim.Text.Trim()) == y.SOLUONG)
                    {
                        listFound.Add(y);
                    }
                }

                lvNhaCungCap.ItemsSource = listFound;
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lvNhaCungCap.SelectedIndex = -1;
        }
    }
    
}
