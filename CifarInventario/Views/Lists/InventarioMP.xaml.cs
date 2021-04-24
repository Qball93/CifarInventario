using CifarInventario.ViewModels;
using System;
using System.IO;
using iText.IO.Font.Constants;
using iText.IO.Util;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
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
using System.Windows.Shapes;
using Paragraph = iText.Layout.Element.Paragraph;

namespace CifarInventario.Views.Lists
{
    /// <summary>
    /// Interaction logic for InventarioMP.xaml
    /// </summary>
    public partial class InventarioMP : Window
    {
        public const string DEST = @"D:\Downloads\testfile.pdf";
            
        InventarioMpVM vm;
        public InventarioMP()
        {
            InitializeComponent();
            vm = (InventarioMpVM)this.DataContext;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();


            PdfWriter writer = new PdfWriter(DEST);

            PdfDocument pdf = new PdfDocument(writer);

            Document document = new Document(pdf, PageSize.A4);

            document.SetMargins(20, 20, 20, 20);

            PdfFont italized = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLDITALIC);
            PdfFont normal = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);

            string date = "8/2/2021";
            string name = "Farmacia Satos";
            string adress = "Blvd los Poeta Juticalpa Olancho";
            string RTN = "1601-1979-025635";
            string testA = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            string testB = "ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss";
            int length = 110;


            Paragraph p = new Paragraph(char.MinValue + "\n\n\n\n\n\n\n\n\n\n\n");
            /* p.Add(char.MinValue + "                               8/2/2021\n\n\n");
             p.Add(char.MinValue + "                                   Farmacia Satos\n\n");
             p.Add(char.MinValue + "                                   Blvd lost poeta Juticalpa Olancho                                               1601-1979-025635");*/

            //p.Add("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            //p.Add("SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS");
            //p.Add("ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss");


            Console.WriteLine(testB.Length + " this is b length");
            Console.WriteLine(testA.Length + " this is a length");



            p.SetFontSize(9);

            document.Add(p);

            document.Close();


            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
