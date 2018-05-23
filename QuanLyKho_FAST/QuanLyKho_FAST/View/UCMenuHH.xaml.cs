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
    /// Interaction logic for UCMenuHH.xaml
    /// </summary>
    public partial class UCMenuHH : UserControl
    {
        public UCMenuHH()
        {
            InitializeComponent();
            HangHoa hhObj = new HangHoa();

            GridMainRight.Children.Add(hhObj);
        }

        private void lvItemHH_Selected(object sender, RoutedEventArgs e)
        {
            GridMainRight.Children.Clear();

            HangHoa hhObj = new HangHoa();

            GridMainRight.Children.Add(hhObj);
        }
    }
}
