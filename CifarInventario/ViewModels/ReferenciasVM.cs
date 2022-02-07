using CifarInventario.Models;
using CifarInventario.ViewModels.Classes.Queries;
using CifarInventario.ViewModels.Commands.ReferenceCommans;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using CifarInventario.ViewModels.Classes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CifarInventario.ViewModels.Commands;

namespace CifarInventario.ViewModels
{
    public class ReferenciasVM :  INotifyPropertyChanged
    {

        public ReferenciasVM()
        {

            FacturaResults = new ObservableCollection<Factura>();
            PlaceHolder = new emptyObject();
            getFacturasCommand = new GetFacturasCommand(this);
            getLotesSalCommand = new GetLotesSalCommand(this);
            Productos = new ObservableCollection<formulaProduct>(ProductQueries.GetAllMpSimplified());
            Lotes = new ObservableCollection<LoteEntrada>();
            IsEnabledLotes = false;

            PlaceHolder.EmptyCantidad = 12;
            PlaceHolder.EmptyAmount = 12.21;

            SelectedLote = new LoteEntrada();
            SelectedProduct = new formulaProduct();

            Tipos = new ObservableCollection<string> { "Lote Salida", "Lote Producto Terminado" };
        }


        private ObservableCollection<string> _tipos;
        public ObservableCollection<string> Tipos
        {
            get { return _tipos; }
            set
            {
                _tipos = value;
                OnPropertyChanged(nameof(Tipos));
            }
        }

        private ObservableCollection<LotePTDetalle> _lotesSalida;
        public ObservableCollection<LotePTDetalle> LotesSalida
        {
            get { return _lotesSalida; }
            set
            {
                _lotesSalida = value;
                OnPropertyChanged(nameof(LotesSalida));
            }
        }


        public string SelectedTipo { get; set; }

        private bool _isEnabledLotes;
        public bool IsEnabledLotes
        {
            get { return _isEnabledLotes; }
            set
            {
                _isEnabledLotes = value;
                OnPropertyChanged(nameof(IsEnabledLotes));
            }
        }

        private emptyObject _placeHolder;
        public emptyObject PlaceHolder
        {
            get { return _placeHolder; }
            set
            {
                _placeHolder = value;
                OnPropertyChanged(nameof(PlaceHolder));
            }
        }

        private ObservableCollection<Factura> _facturaResults;
        public ObservableCollection<Factura> FacturaResults
        {
            get { return _facturaResults; }
            set
            {
                _facturaResults = value;
                OnPropertyChanged(nameof(FacturaResults));
            }

        }

        private ObservableCollection<formulaProduct> _productos;
        public ObservableCollection<formulaProduct> Productos
        {
            get { return _productos; }
            set
            {
                _productos = value;
                OnPropertyChanged(nameof(Productos));
            }
        }

        private ObservableCollection<LoteEntrada> _lotes;
        public ObservableCollection<LoteEntrada> Lotes
        {
            get { return _lotes; }
            set
            {
                _lotes = value;
                OnPropertyChanged(nameof(Lotes));
            }
        }


        private formulaProduct _selectedProduct;
        public formulaProduct SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private LoteEntrada _selectedLote;
        public LoteEntrada SelectedLote
        {
            get { return _selectedLote; }
            set
            {
                _selectedLote = value;
                OnPropertyChanged(nameof(SelectedLote));
            }
        }




        public ObservableCollection<string> _lotesMP;


        public GetFacturasCommand getFacturasCommand { get; set; }
        public GetLotesSalCommand getLotesSalCommand { get; set; }

        public ICommand generarLotes => new DelegateCommand(GenerarLotes);
        


        public void buscarPorLotePT()
        {

            System.Windows.MessageBox.Show(PlaceHolder.EmptyWord);
            FacturaResults = new ObservableCollection<Factura>(FacturaQueries.GetFacturasFromLotePt(PlaceHolder.EmptyWord));
        }


        public void buscarPorLoteSal()
        {
            
            
            FacturaResults = new ObservableCollection<Factura>(FacturaQueries.GetFacturasFromLoteSal(PlaceHolder.EmptyWord));
        }


        public void reset()
        {
            IsEnabledLotes = false;
        }


        public void GenerarLotes(object parameter)
        {
            IsEnabledLotes = true;
            Lotes = new ObservableCollection<LoteEntrada>(InventoryQueries.getLotesForMP(SelectedProduct.Codigo, 0));

            System.Windows.MessageBox.Show("Busqueda Terminada");
        }

        public void buscarLoteSalPorMp()
        {
            LotesSalida = new ObservableCollection<LotePTDetalle>(InventoryQueries.getLoteSalFromMpLote(SelectedLote.CodInterno));

            System.Windows.MessageBox.Show("Busqueda Terminada");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
