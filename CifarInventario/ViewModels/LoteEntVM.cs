using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using CifarInventario.ViewModels.Classes.Queries;
using CifarInventario.Models;
using CifarInventario.ViewModels.Commands;
using System.Threading.Tasks;
using CifarInventario.ViewModels.Commands.LoteEntCommands;
using System.Collections.ObjectModel;
using CifarInventario.Views.Modals.LotesEntModals;
using System.Windows.Input;

namespace CifarInventario.ViewModels
{
    public class LoteEntVM: INotifyPropertyChanged
    {
        public LoteEntVM()
        {
            LotesActivos = new ObservableCollection<LoteEntrada>(InventoryQueries.GetLotesEntradaActivos());
            LotesPaquetes = new ObservableCollection<LoteEntrada>(InventoryQueries.GetAllContainerLotes());
            MateriaPrima = new ObservableCollection<formulaProduct>(ProductQueries.GetAllMpSimplified());
            Proveedores = new ObservableCollection<DisplayProveedor>(PersonaQueries.GetDisplayProveedores());
            PaquetesMP = new ObservableCollection<formulaProduct>(ProductQueries.GetAllContainersMP());
            newLoteCommand = new NewLoteEntCommand(this);
            newLotePacakgeCommand = new NewLotePackageCommand(this);
            NewLote = new LoteEntrada();

            SelectedLoteActivo = new LoteEntrada();



        }



        private ObservableCollection<LoteEntrada> _lotesPaquetes;

        public ObservableCollection<LoteEntrada> LotesPaquetes
        {
            get { return _lotesPaquetes; }
            set
            {
                _lotesPaquetes = value;
                OnPropertyChanged("LotesPaquetes");
            }
        }


        private ObservableCollection<formulaProduct> _paquetesMP;

        public ObservableCollection<formulaProduct> PaquetesMP
        {
            get { return _paquetesMP; }
            set
            {
                _paquetesMP = value;
                OnPropertyChanged("PaquetesMP");
            }
        }

        private LoteEntrada _newLote;

        public LoteEntrada NewLote
        {
            get { return _newLote; }
            set
            {
                _newLote = value;
                OnPropertyChanged("NewLote");
            }
        }

        private ObservableCollection<LoteEntrada> _lotesActivos;

        public ObservableCollection<LoteEntrada> LotesActivos
        {
            get { return _lotesActivos; }
            set
            {
                _lotesActivos = value;
                OnPropertyChanged("LotesActivos");

            }
        }

        private LoteEntrada _selectedLoteActivo;

        public LoteEntrada SelectedLoteActivo
        {
            get { return _selectedLoteActivo; }
            set
            {
                _selectedLoteActivo = value;
                OnPropertyChanged("SelectedLoteActivo");
            }
        }

        private ObservableCollection<formulaProduct> _materiaPrima;

        public ObservableCollection<formulaProduct> MateriaPrima
        {
            get { return _materiaPrima; }
            set
            {
                _materiaPrima = value;
                OnPropertyChanged("MateriaPrima");

            }
        }

        public formulaProduct SelectedMateriaPrima { get; set; }

        private ObservableCollection<DisplayProveedor> _proveedores;

        public ObservableCollection<DisplayProveedor> Proveedores
        {
            get { return _proveedores; }
            set { 
                _proveedores = value;
                OnPropertyChanged("Proveedores");
            }
        }

        public DisplayProveedor SelectedProveedor { get; set; }






        public ICommand newLoteModal => new DelegateCommand(NewLoteModal);

        public ICommand resetLoteModal => new DelegateCommand(reset);

        public ICommand newLotePaqueteModal => new DelegateCommand(NewPaqueteModal);

        public NewLoteEntCommand newLoteCommand { get; set; }

        public NewLotePackageCommand newLotePacakgeCommand { get; set; }


        public void NewPaqueteModal(object parameter)
        {
            var TestView = new NewLotePackageModal(this);


            TestView.ShowDialog();
        }

        public void reset(object parameter)
        {
            NewLote = new LoteEntrada();
            
        }




        public void CreateLotePaquete()
        {
            NewLote.CodProveedor = SelectedProveedor.Id.ToString();
            NewLote.ConversionUnitaria = 1;
            NewLote.CodMP = SelectedMateriaPrima.Codigo;
            NewLote.CantidadActual = NewLote.CantidadOriginal;
            NewLote.CantidadExacta = NewLote.CantidadOriginal;
            

            //System.Windows.MessageBox.Show(NewLote.CantidadExacta  + " " + SelectedMateriaPrima.conversionValue);

            InventoryQueries.CreateLoteEntrada(NewLote);
            LotesPaquetes.Add(NewLote);
            reset(1);

            System.Windows.MessageBox.Show("Nuevo Lote Paquete Creado");
        }


        public void NewLoteModal(object parameter)
        {

            //NewLote = new LoteEntrada();
            var TestView = new NewLoteEntModal(this);
            


           /* NewFormulaDetalles = new ObservableCollection<DetalleFormula>();
            NewFormulaSelectedDetalle = new DetalleFormula();
            SelectedFormulaInstruction = new ProcedimientoDetalle();
            NewFormulaInstructions = new ObservableCollection<ProcedimientoDetalle>();
            NewFormula.FormaFarm = FormasFarmaceuticas[0];
            NewFormula.Cantidad = UnidadCreada[0];*/



            TestView.ShowDialog();
        }

        public void CreateLote()
        {
            NewLote.CodProveedor = SelectedProveedor.Id.ToString();
            NewLote.ConversionUnitaria = SelectedMateriaPrima.ConversionValue;
            NewLote.CodMP = SelectedMateriaPrima.Codigo;
            NewLote.CantidadActual = NewLote.CantidadOriginal;
            NewLote.CantidadExacta = NewLote.CantidadOriginal * SelectedMateriaPrima.ConversionValue;

            //System.Windows.MessageBox.Show(NewLote.CantidadExacta  + " " + SelectedMateriaPrima.conversionValue);
            
            InventoryQueries.CreateLoteEntrada(NewLote);
            LotesActivos.Add(NewLote);

            reset(1);

            System.Windows.MessageBox.Show("Nuevo Lote Creado");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
