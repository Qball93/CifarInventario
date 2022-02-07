using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CifarInventario.Models;
using CifarInventario.ViewModels.Classes;
using System.Collections.ObjectModel;
using CifarInventario.ViewModels.Classes.Queries;
using CifarInventario.ViewModels.Commands.FacturaCommands;
using System.Windows.Input;
using CifarInventario.ViewModels.Commands;
using CifarInventario.Views.Modals.FacturaModals;
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

namespace CifarInventario.ViewModels
{
    public class FacturasVM : Validators, INotifyPropertyChanged
    {
        public FacturasVM()
        {
            Facturas = new ObservableCollection<Factura>(FacturaQueries.GetFacturaList());
            testFactura = FacturaQueries.GetFacturaList();
            Productos = new ObservableCollection<ProductoTeminadoParaLista>(ProductQueries.GetPTSimp());
            Clientes = new ObservableCollection<IdName>(PersonaQueries.getClientes());
            Vendedores = new List<string>(FacturaQueries.getVendedores());


            Zonas = new ObservableCollection<string> { "Norte", "Sur", "Este", "Oeste" };

            Globals.setId(1);
            editModal = new EditFacturaModal(this);

            ProductPairs = new List<IdName>();


            NewFacturaCommand = new CreateFacturaCommand(this);
            NewFacturaGenerarLotes = new CreateFacturaGenerarLotes(this);
            NewFacturaAddDetalle = new CreateFacturaAddDetalle(this);
            UpdateBalanceCommand = new UpdateFacturaBalanceCommand(this);

            //FacturaEditModal = new OpenEditModal(this);


            IsProductEnabled = true;


        }




        private string _firstLine;
        private string _secondLine;
        private string _thirdLine;

        public string FirstLine
        {
            get { return _firstLine; }
            set
            {
                _firstLine = value;
                OnPropertyChanged(nameof(FirstLine));
            }
        }

        public string SecondLine
        {
            get { return _secondLine; }
            set
            {
                _secondLine = value;
                OnPropertyChanged(nameof(SecondLine));
            }
        }

        public string ThirdLine
        {
            get { return _thirdLine; }
            set
            {
                _thirdLine = value;
                OnPropertyChanged(nameof(ThirdLine));
            }
        }


        //Combobox controls
        private bool _isLoteEnabled;
        public bool IsLoteEnabled
        {
            get { return _isLoteEnabled; }
            set
            {
                _isLoteEnabled = value;
                OnPropertyChanged("IsLoteEnabled");

            }
        }

        private bool _isProductEnabled;
        public bool IsProductEnabled
        {
            get { return _isProductEnabled; }
            set
            {
                _isProductEnabled = value;
                OnPropertyChanged("IsProductEnabled");
            }
        }

        public List<Factura> testFactura { get; set; }


        private ObservableCollection<Factura> _facturas;
        public ObservableCollection<Factura> Facturas
        {
            get { return _facturas; }
            set
            {
                _facturas = value;
                OnPropertyChanged("Facturas");
            }
        }

        private Factura _selectedFactura;
        public Factura SelectedFactura
        {
            get { return _selectedFactura; }
            set
            {
                _selectedFactura = value;
                OnPropertyChanged("SelectedFactura");
            }
        }

        private List<(int id, string name)> _empleados;
        public List<(int id, string name)> Empleados
        {
            get { return _empleados; }
            set
            {
                _empleados = value;
                OnPropertyChanged(nameof(Empleados));
            }
        }

        private ObservableCollection<string> _zonas;
        public ObservableCollection<string> Zonas
        {
            get { return _zonas; }
            set
            {
                _zonas = value;
                OnPropertyChanged(nameof(Zonas));
            }
        }


        private List<string> _vendedores;
        public List<string> Vendedores
        {
            get { return _vendedores; }
            set
            {
                _vendedores = value;
                OnPropertyChanged(nameof(Vendedores));
            }
        }

        private ObservableCollection<IdName> _clientes;
        public ObservableCollection<IdName> Clientes
        {
            get { return _clientes; }
            set
            {
                _clientes = value;
                OnPropertyChanged("Empleados");
            }
        }

        private ObservableCollection<DetalleFactura> _detallesSelected;
        public ObservableCollection<DetalleFactura> DetallesSelected
        {
            get { return _detallesSelected; }
            set
            {
                _detallesSelected = value;
                OnPropertyChanged("DetallesSelected");
            }
        }


        private ObservableCollection<ProductoTeminadoParaLista> _productos;
        public ObservableCollection<ProductoTeminadoParaLista> Productos
        {
            get { return _productos; }
            set
            {
                _productos = value;
                OnPropertyChanged("Productos");
            }
        }

        private ProductoTeminadoParaLista _selectedProduct;
        public ProductoTeminadoParaLista SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }


        private ObservableCollection<DetalleFactura> _newFacturaDetalles;
        public ObservableCollection<DetalleFactura> NewFacturaDetalles
        {
            get { return _newFacturaDetalles; }
            set
            {
                _newFacturaDetalles = value;
                OnPropertyChanged("NewFacturaDetalles");
            }
        }

        private DetalleFactura _newFacturaSelectedDetalles;
        public DetalleFactura NewFacturaSelectedDetalles
        {
            get { return _newFacturaSelectedDetalles; }
            set
            {
                _newFacturaSelectedDetalles = value;
                OnPropertyChanged("NewFacturaSelectedDetalles");
            }
        }

        private DetalleFactura _newFacturaNewDetalle;
        public DetalleFactura NewFacturaNewDetalle
        {
            get { return _newFacturaNewDetalle; }
            set
            {
                _newFacturaNewDetalle = value;
                OnPropertyChanged("NewFacturaNewDetalle");
            }
        }

        private Factura _newFactura;
        public Factura NewFactura
        {
            get { return _newFactura; }
            set
            {
                _newFactura = value;
                OnPropertyChanged("NewFactura");
            }
        }

        private List<string> _lotesProduct;
        public List<string> LotesProduct
        {
            get { return _lotesProduct; }
            set
            {
                _lotesProduct = value;
                OnPropertyChanged("LotesProduct");
            }
        }

        private double _pendChange;
        public double PendChange
        {
            get { return _pendChange; }
            set
            {
                _pendChange = value;
                ClearErrors(nameof(PendChange));
                isDecimal(value.ToString(), nameof(PendChange));
                OnPropertyChanged(nameof(PendChange));
            }
        }

        public List<IdName> ProductPairs { get; set; }

        private bool _hasProducto;
        public bool HasProducto
        {
            get { return _hasProducto; }
            set
            {
                _hasProducto = value;
                OnPropertyChanged("HasProducto");
            }
        }

        public EditFacturaModal editModal { get; set; }
        public PrePrintModal openPrintModal { get; set; }

        public ICommand ResetFactura => new DelegateCommand(ResetNewFacturaModal);
        public ICommand ResetLotesCommand => new DelegateCommand(ResetLotes);
        public ICommand openNewFacturaModal => new DelegateCommand(OpenNewFacturaModal);
        public ICommand removeProductFromFactura => new DelegateCommand(RemoveProductFromFactura);
        public ICommand openEditModal => new DelegateCommand(OpenEditModal);
        public ICommand openExportPdf => new DelegateCommand(OpenExportModal);
        public ICommand limpiarExportPdf => new DelegateCommand(limpiarExportModal);
        public ICommand exportFacturaPdf => new DelegateCommand(ExportFacturaPDF);
        public ICommand exportList => new DelegateCommand(ExportList);

        public CreateFacturaAddDetalle NewFacturaAddDetalle { get; set; }
        public CreateFacturaGenerarLotes NewFacturaGenerarLotes { get; set; }
        public CreateFacturaCommand NewFacturaCommand { get; set; }
        //public OpenEditModal FacturaEditModal { get; set; }
        public UpdateFacturaBalanceCommand UpdateBalanceCommand {get; set;}
        


        public void ExportList(object parameter)
        {

            string DEST = @"D:\Downloads\ListadoFactura.pdf";

            
        }


        public void limpiarExportModal(object parameter)
        {
            FirstLine = "";
            SecondLine = "";
            ThirdLine = "";
        }



        public void OpenExportModal(object parameter)
        {
            FirstLine = "";
            SecondLine = "";
            ThirdLine = "";

            openPrintModal = new PrePrintModal(this);

            openPrintModal.ShowDialog();
        }

        public void ExportFacturaPDF(object paramter)
        {


            string DEST = @"D:\Downloads\factura" + SelectedFactura.IdFactura + ".pdf";

            DetallesSelected = new ObservableCollection<DetalleFactura>(FacturaQueries.GetDetallesFactura(SelectedFactura.IdFactura));

            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();


            PdfWriter writer = new PdfWriter(DEST);

            PdfDocument pdf = new PdfDocument(writer);

            Document document = new Document(pdf, PageSize.A4);

            document.SetMargins(40, 40, 20, 20);

           // PdfFont italized = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLDITALIC);
           // PdfFont normal = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);



            string descuento = "L.00.00";
            string valorTotal = "L.123.42";



            Paragraph p = new Paragraph("\n\n\n\n\n\n\n\n\n\n");
            p.Add(char.MinValue + "                                         " + SelectedFactura.Emission + " \n\n\n");
            p.Add(char.MinValue + "                                " + SelectedFactura.Cliente.Name + "\n\n");

            p.SetFontSize(9);
            p.SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN));
            document.Add(p);

            
            Table details = new Table(UnitValue.CreatePercentArray(new float[] { 3.0f, 2.0f })).UseAllAvailableWidth();

            details.SetTextAlignment(TextAlignment.LEFT);
            details.SetFontSize(9);
            details.SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN));

            details.AddCell(new Cell().Add(new Paragraph(char.MinValue + "                                   " + SelectedFactura.Direccion)).SetBorder(Border.NO_BORDER));
            details.AddCell(new Cell().Add(new Paragraph(SelectedFactura.RTN)).SetBorder(Border.NO_BORDER));


            document.Add(details);

            document.Add(new Paragraph("\n\n"));



            Table table = new Table(UnitValue.CreatePercentArray(new float[] { 1.1f, 3.4f, 0.9f, 0.9f, 1.1f })).UseAllAvailableWidth();



            table.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
            table.SetFontSize(9);
            table.SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN));


            foreach (var element in DetallesSelected)
            {
                table.AddCell(new Cell().Add(new Paragraph(char.MinValue + "      " + element.Cantidad.ToString())).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph(element.Producto.Name + "    " + element.LoteCod)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph(element.Precio.ToString())).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph(descuento)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell().Add(new Paragraph(valorTotal)).SetBorder(Border.NO_BORDER));





            }




            




            document.Add(table);

            Paragraph letras = new Paragraph(FirstLine + "\n");
            letras.Add(SecondLine + "\n");
            letras.Add(ThirdLine);
            letras.SetFixedPosition(80, 115, 300);
            letras.SetFontSize(9);
            document.Add(letras);



            Paragraph x = new Paragraph("Cantidad Total\n");
            x.Add("Exento\n");
            x.Add("Exonerado\n");
            x.Add("Gravado 15\n");
            x.Add("Gravado 18\n");
            x.Add("15 isv\n");
            x.Add("18 isv\n");
            x.Add("Total a Pagar\n");
            x.SetFixedPosition(450, 95, 200);
            x.SetFontSize(9);
            x.SetFixedLeading(18);

            document.Add(x);

            document.Close();

            openPrintModal.Close();


            System.Windows.MessageBox.Show("Documento Creado en  "   + DEST);



        }

        public void OpenEditModal(object parameter)
        {
            if(SelectedFactura.EsAbonado == false)
            {
                System.Windows.MessageBox.Show("Esta Factura esta solvente y no se puede actualizar.");
            }
            else
            {
                editModal.ShowDialog();

            }


        }

        public void EditFactura()
        {
            if(PendChange > SelectedFactura.Pendiente)
            {
                System.Windows.MessageBox.Show("Cantidad muy alta para descontar el valor no puede sew mayor al valor pendiente");
            }
            else
            {
                FacturaQueries.updateBalance(SelectedFactura.IdFactura, PendChange);
                if (PendChange == SelectedFactura.Pendiente) {
                    FacturaQueries.setAbonado(SelectedFactura.IdFactura);
                    SelectedFactura.EsAbonado = false;
                }

                SelectedFactura.Pendiente -= PendChange;

                


                    
                editModal.Close();
            }
        }

        public void CreateFactura()
        {

            /* NewFactura.Pendiente = 0.00;
             NewFactura.Imp = 0.00;*/


            if (NewFactura.Descuento > NewFactura.Sub)
            {
                System.Windows.MessageBox.Show("Descuento no puede ser mayor al Total de la Factura");
            }
            else
            {


                if (!FacturaQueries.isRepeatedFactura(NewFactura.IdFactura))
                {

                    NewFactura.Empleado.ID = Globals.getId().ToString();

                   /* foreach (var element in NewFacturaDetalles)
                    {
                        NewFactura.Sub += element.Total;
                    }*/

                    NewFactura.Total = NewFactura.Sub;


                    if (NewFactura.EsAbonado == true)
                    {
                        NewFactura.Pendiente = NewFactura.Total;
                    }


                    NewFactura.Total -= NewFactura.Descuento;

                    //System.Windows.MessageBox.Show(NewFactura.IdFactura + " " + NewFactura.Empleado.ID + " " + NewFactura.Cliente.ID + " " + NewFactura.Sub + " " + NewFactura.Total + " " + NewFactura.EsAbonado.ToString() + " " + NewFactura.Pendiente + " " + NewFactura.Emission.ToShortDateString());

                    FacturaQueries.CreateFactura(NewFactura);

                    foreach (var element in NewFacturaDetalles)
                    {

                        //System.Windows.MessageBox.Show(element.Cantidad + " " + element.LoteCod + element.Producto.ID);
                        FacturaQueries.CreateDetalle(element, NewFactura.IdFactura);



                        ProductQueries.updateProductoTermnadoRemoveAmount(element.LoteCod, element.Cantidad );
                        ProductQueries.InventarioPTSellAmount(element.Producto.ID, element.Cantidad);
                    }

                    System.Windows.MessageBox.Show("Factura Creada");

                    Facturas.Add(NewFactura);
                }
                else
                {
                    System.Windows.MessageBox.Show("Codigo de Factura duplicado");
                }
            }
            
        }

        public void OpenNewFacturaModal(object parameter)
        {
            NewFactura = new Factura();
            NewFacturaNewDetalle = new DetalleFactura();
            NewFacturaDetalles = new ObservableCollection<DetalleFactura>();
            SelectedProduct = new ProductoTeminadoParaLista();

            var temp = new CreateFacturaModal(this);



            temp.ShowDialog();
        }

        public void generateLotesFromProduct()
        {
            
            LotesProduct = ProductQueries.getLotesFromtProduct(SelectedProduct.CodPT, NewFacturaNewDetalle.Cantidad);


            if(LotesProduct[0] == "N/A")
            {
                System.Windows.MessageBox.Show("No hay Lotes disponibles para esa cantidad de producto.");
                IsLoteEnabled = false;
            }
            else
            {
                IsLoteEnabled = true;
                IsProductEnabled = false;
            }
        }

        public void addProductToDetalles()
        {
            var tempPair = new IdName(NewFacturaNewDetalle.LoteCod, SelectedProduct.CodPT);

            //System.Windows.MessageBox.Show(NewFacturaNewDetalle.Producto.ID);

            if (ProductPairs.Contains(tempPair))
            {
                /*foreach(var element in ProductPairs)
                {
                    System.Windows.MessageBox.Show(element.ID + " " + element.Name);
                }*/




                System.Windows.MessageBox.Show("Esta Factura ya contiene ese producto con ese lote.");
            }
            else
            {
                var temp = new DetalleFactura();
                NewFacturaNewDetalle.Producto.Name = SelectedProduct.NombrePT;
                NewFacturaNewDetalle.Producto.ID = SelectedProduct.CodPT;
                NewFacturaNewDetalle.Precio = SelectedProduct.Precio;
                NewFacturaNewDetalle.Total = Math.Round(SelectedProduct.Precio * NewFacturaNewDetalle.Cantidad, 2);
                NewFactura.Sub += Math.Round(NewFacturaNewDetalle.Total,2);
                temp = NewFacturaNewDetalle;
                NewFacturaDetalles.Add(temp);
                ProductPairs.Add(tempPair);


                //System.Windows.MessageBox.Show(temp.LoteCod + " " + temp.Producto.ID  + temp.Cantidad);
                ResetLotes("");
            }




            
        }

        public void AplicarDescuentoModal(object parameter)       
        {
        }    

        public void RemoveProductFromFactura(object parameter)
        {

            var itemToRemove = ProductPairs.Single(r => r.ID == NewFacturaSelectedDetalles.LoteCod && NewFacturaSelectedDetalles.Producto.ID == r.Name);
            ProductPairs.Remove(itemToRemove);

/*
            foreach (var element in ProductPairs)
            {
                System.Windows.MessageBox.Show(element.Name);
            }*/

            var tempPar = new IdName(NewFacturaSelectedDetalles.LoteCod, NewFacturaSelectedDetalles.Producto.ID);
            //System.Windows.MessageBox.Show(NewFacturaSelectedDetalles.Producto.ID);
            NewFactura.Sub -= NewFacturaSelectedDetalles.Total;
            ProductPairs.Remove(tempPar);
            NewFacturaDetalles.Remove(NewFacturaSelectedDetalles);

        /*    foreach (var element in ProductPairs)
            {
                System.Windows.MessageBox.Show(element.Name);
            }
        */
        }

        public void ResetLotes(object parameter)
        {
            IsProductEnabled = true;
            IsLoteEnabled = false;
            SelectedProduct = null;
            SelectedProduct = new ProductoTeminadoParaLista();
            NewFacturaNewDetalle = new DetalleFactura();
            

        }

        public void ResetNewFacturaModal(object parameter)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        




        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
