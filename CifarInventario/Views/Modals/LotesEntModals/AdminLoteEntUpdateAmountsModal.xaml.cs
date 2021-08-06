using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using CifarInventario.ViewModels;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CifarInventario.Views.Modals.LotesEntModals
{
    /// <summary>
    /// Interaction logic for AdminLoteEntUpdateAmountsModal.xaml
    /// </summary>
    public partial class AdminLoteEntUpdateAmountsModal : Window
    {
        public AdminLoteEntUpdateAmountsModal(LoteEntAdminVM vm)
        {
            InitializeComponent();

            DataContext = vm;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
