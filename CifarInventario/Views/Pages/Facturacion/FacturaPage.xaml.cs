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
using Table = iText.Layout.Element.Table;
using Paragraph = iText.Layout.Element.Paragraph;
using Border = iText.Layout.Borders.Border;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font.Constants;

namespace CifarInventario.Views.Pages
{
    /// <summary>
    /// Interaction logic for FacturaPage.xaml
    /// </summary>
    public partial class FacturaPage : Page
    {
        public FacturaPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                // sizing of the element.
                dtPrime.Measure(pageSize);
                dtPrime.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(dtPrime, "Listado de Facturas");
            }
        }

        private void ButtonExport(object sender, RoutedEventArgs e)
        {

        }


        private void dataGrid1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //...
            
            if(e.PropertyName == "Empleado" || e.PropertyName=="HasErrors" || e.PropertyName=="Imp" || e.PropertyName=="Sub" || e.PropertyName == "Descuento")
            {
                e.Cancel = true;
            }

            if(e.PropertyName == "EsAbonado")
            {
                e.Column.Header = "Es Abonado";
            }


        }
    }
}
