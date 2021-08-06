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
using CifarInventario.ViewModels;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Markup;

namespace CifarInventario.Views.Modals.FacturaModals
{
    /// <summary>
    /// Interaction logic for CreateFacturaModal.xaml
    /// </summary>
    public partial class CreateFacturaModal : Window
    {
        public CreateFacturaModal(FacturasVM vm)
        {
            InitializeComponent();

            DpFact.Language = XmlLanguage.GetLanguage("es-HN");
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
