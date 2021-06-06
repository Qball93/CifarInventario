using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using CifarInventario.ViewModels;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Markup;

namespace CifarInventario.Views.Modals.LotesEntModals
{
    /// <summary>
    /// Interaction logic for NewLoteEntModal.xaml
    /// </summary>
    public partial class NewLoteEntModal : Window
    {
        public NewLoteEntModal(LoteEntVM vm)
        {
            InitializeComponent();


            createDP.Language = XmlLanguage.GetLanguage("es-HN");
            venciDP.Language = XmlLanguage.GetLanguage("es-HN");
            entradaDP.Language = XmlLanguage.GetLanguage("es-HN");
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
