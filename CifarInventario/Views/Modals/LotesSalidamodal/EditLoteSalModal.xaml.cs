using CifarInventario.ViewModels;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CifarInventario.Views.Modals.LotesSalidamodal
{
    /// <summary>
    /// Interaction logic for EditLoteSalModal.xaml
    /// </summary>
    public partial class EditLoteSalModal : Window
    {
        public EditLoteSalModal(LotesSalidaVM VM)
        {
            InitializeComponent();

            createDP.Language = XmlLanguage.GetLanguage("es-HN");
            venciDP.Language = XmlLanguage.GetLanguage("es-HN");
            DataContext = VM;
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
