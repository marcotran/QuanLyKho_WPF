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

namespace QuanLyKho_FAST.View
{
    /// <summary>
    /// Interaction logic for NhaCungCap.xaml
    /// </summary>
    public partial class NhaCungCap : UserControl
    {

        public NhaCungCap()
        {
            InitializeComponent();
            LoadDuLieu();
        }

        #region methods

        private void LoadDuLieu()
        {

            QLKHOEntities db = new QLKHOEntities();
            lvNhaCungCap.ItemsSource= db.NHA_CUNG_CAP.ToList();
            
        }

        #endregion

        private void lvNhaCungCap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //txtMa.Text = (lvNhaCungCap.SelectedItem as M_NhaCungCap).Ma1;

        }
    }
}
