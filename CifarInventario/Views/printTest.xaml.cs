using System;
using System.IO;
using iText.IO.Font.Constants;
using iText.IO.Util;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Borders;
using iText.Layout.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CifarInventario.Models;
using CifarInventario.ViewModels.Classes.Queries;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Table = iText.Layout.Element.Table;
using Paragraph = iText.Layout.Element.Paragraph;
using Border = iText.Layout.Borders.Border;

namespace CifarInventario.Views
{
    /// <summary>
    /// Interaction logic for printTest.xaml
    /// </summary>
    public partial class printTest : Window
    {
        public printTest()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Factura factura = FacturaQueries.getFactura(1);



            string DEST = @"D:\Downloads\factura" + factura.IdFactura + ".pdf";



            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();


            PdfWriter writer = new PdfWriter(DEST);

            PdfDocument pdf = new PdfDocument(writer);

            Document document = new Document(pdf, PageSize.A4);

            document.SetMargins(40, 40, 20, 20);

            PdfFont italized = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLDITALIC);
            PdfFont normal = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);



            string valor = "L.47.20";
            string descuento = "L.00.00";
            string valorTotal = "L.123.42";



            Paragraph p = new Paragraph("\n\n\n\n\n\n\n\n\n\n\n");
            p.Add(char.MinValue + "                              " + factura.fecha + " \n\n\n");
            p.Add(char.MinValue + "                                " + factura.NombreCliente + "\n\n");

            p.SetFontSize(9);
            p.SetFont(normal);
            document.Add(p);


            Table details = new Table(UnitValue.CreatePercentArray(new float[] { 3.0f, 2.0f })).UseAllAvailableWidth();

            details.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
            details.SetFontSize(9);
            details.SetFont(normal);

            details.AddCell(new Cell().Add(new Paragraph(factura.direccion)).SetBorder(Border.NO_BORDER));
            details.AddCell(new Cell().Add(new Paragraph(factura.RTN)).SetBorder(Border.NO_BORDER));


            document.Add(details);



            Table table = new Table(UnitValue.CreatePercentArray(new float[] { 1.1f, 3.4f, 0.9f, 0.9f, 1.1f })).UseAllAvailableWidth();



            table.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
            table.SetFontSize(9);
            table.SetFont(normal);


            foreach(var element in factura.MP)
            {
                table.AddCell(new Cell().Add(new Paragraph(element.cantidad.ToString())).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph(element.NombreProducto + " " + element.LoteCod)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph(valor)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph(descuento)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph(valorTotal)).SetBorder(Border.NO_BORDER));


             


            }
            

            
            



            document.Add(table);



            Paragraph x = new Paragraph("impuesto Total");
            x.SetFixedPosition(500, 300, 200);
            x.SetFontSize(9);

            document.Add(x);

            document.Close();


        }
    }
}
