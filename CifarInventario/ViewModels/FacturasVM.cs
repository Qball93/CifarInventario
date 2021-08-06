using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CifarInventario.Models;
using System.Collections;
using CifarInventario.Views;
using CifarInventario.ViewModels.Classes;
using System.Collections.ObjectModel;
using CifarInventario.ViewModels.Classes.Queries;
using CifarInventario.ViewModels.Commands.FacturaCommands;
using System.Windows.Input;
using CifarInventario.ViewModels.Commands;
using CifarInventario.Views.Modals.FacturaModals;

namespace CifarInventario.ViewModels
{
    public class FacturasVM : Validators, INotifyPropertyChanged
    {
        public FacturasVM()
        {
            Facturas = new ObservableCollection<Factura>(FacturaQueries.GetFacturaList());
            Productos = new ObservableCollection<ProductoTeminadoParaLista>(ProductQueries.GetPTSimp());
            Clientes = new ObservableCollection<IdName>(PersonaQueries.getClientes());
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
                OnPropertyChanged("Empleados");
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

        public ICommand ResetFactura => new DelegateCommand(ResetNewFacturaModal);
        public ICommand ResetLotesCommand => new DelegateCommand(ResetLotes);
        public ICommand openNewFacturaModal => new DelegateCommand(OpenNewFacturaModal);
        public ICommand removeProductFromFactura => new DelegateCommand(RemoveProductFromFactura);
        public ICommand openEditModal => new DelegateCommand(OpenEditModal);

        public CreateFacturaAddDetalle NewFacturaAddDetalle { get; set; }
        public CreateFacturaGenerarLotes NewFacturaGenerarLotes { get; set; }
        public CreateFacturaCommand NewFacturaCommand { get; set; }
        //public OpenEditModal FacturaEditModal { get; set; }
        public UpdateFacturaBalanceCommand UpdateBalanceCommand {get; set;}
        

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


            if (NewFactura.Descuento > NewFactura.Total)
            {
                System.Windows.MessageBox.Show("Descuento no puede ser mayor al Total de la Factura");
            }
            else
            {


                if (!FacturaQueries.isRepeatedFactura(NewFactura.IdFactura))
                {

                    NewFactura.Empleado.ID = Globals.getId().ToString();

                    foreach (var element in NewFacturaDetalles)
                    {
                        NewFactura.Sub += element.Total;
                    }

                    NewFactura.Total = NewFactura.Sub;


                    if (NewFactura.EsAbonado == true)
                    {
                        NewFactura.Pendiente = NewFactura.Total;
                    }

                    //System.Windows.MessageBox.Show(NewFactura.IdFactura + " " + NewFactura.Empleado.ID + " " + NewFactura.Cliente.ID + " " + NewFactura.Sub + " " + NewFactura.Total + " " + NewFactura.EsAbonado.ToString() + " " + NewFactura.Pendiente + " " + NewFactura.Emission.ToShortDateString());

                    FacturaQueries.CreateFactura(NewFactura);

                    foreach (var element in NewFacturaDetalles)
                    {
                        FacturaQueries.CreateDetalle(element, NewFactura.IdFactura);
                    }

                    System.Windows.MessageBox.Show("Factura Creada");
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
                NewFactura.Sub += NewFacturaNewDetalle.Total;
                temp = NewFacturaNewDetalle;
                NewFacturaDetalles.Add(temp);
                ProductPairs.Add(tempPair);
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
