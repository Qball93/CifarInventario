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
using System.Windows;

namespace CifarInventario.ViewModels
{
    public class LoteEntVM: INotifyPropertyChanged
    {
        public LoteEntVM()
        {
            LotesActivos = new ObservableCollection<LoteEntrada>(InventoryQueries.GetLotesEntradaActivos());
            LotesPaquetes = new ObservableCollection<LoteEntrada>(InventoryQueries.GetAllContainerLotes());
            LotesInactivos = new ObservableCollection<LoteEntrada>(InventoryQueries.GetLotesEntradaInActivos());
            LotesPaquetesInactivos = new ObservableCollection<LoteEntrada>(InventoryQueries.GetAllContainerLotesInactivos());
            MateriaPrima = new ObservableCollection<formulaProduct>(ProductQueries.GetAllMpSimplifiedNoWater());
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

        private ObservableCollection<LoteEntrada> _lotesPaquetesInactivos;
        public ObservableCollection<LoteEntrada> LotesPaquetesInactivos
        {
            get { return _lotesPaquetesInactivos; }
            set
            {
                _lotesPaquetesInactivos = value;
                OnPropertyChanged(nameof(LotesPaquetesInactivos));
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

        private ObservableCollection<LoteEntrada> _lotesInctivos;
        public ObservableCollection<LoteEntrada> LotesInactivos
        {
            get { return _lotesInctivos; }
            set
            {
                _lotesInctivos = value;
                OnPropertyChanged(nameof(LotesInactivos));

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
        public EditLotePaqueteEntradaModal editModalPaquete { get; set; }
        public EditLoteEntradaModal editModalLote { get; set; }






        public ICommand newLoteModal => new DelegateCommand(NewLoteModal);
        public ICommand resetLoteModal => new DelegateCommand(reset);
        public ICommand newLotePaqueteModal => new DelegateCommand(NewPaqueteModal);
        public ICommand editLotePaqueteModal => new DelegateCommand(EditLotePaqueteModal);
        public ICommand editLoteModal => new DelegateCommand(EditLoteModal);




        public ICommand setPaqueteActivo => new DelegateCommand(SetPaqueteActivo);
        public ICommand setPaqueteInactivo => new DelegateCommand(SetPaqueteInactivo);
        public ICommand setLoteActivo => new DelegateCommand(SetLoteActivo);
        public ICommand setLoteInactivo => new DelegateCommand(SetLoteInactivo);


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


        public void EditLotePaqueteModal(object parameter)
        {
            NewLote = new LoteEntrada(SelectedLoteActivo);
            editModalPaquete = new EditLotePaqueteEntradaModal(this);
            editModalPaquete.ShowDialog();

        }

        public void EditLoteModal(object parameter)
        {
            NewLote = new LoteEntrada(SelectedLoteActivo);
            editModalLote = new EditLoteEntradaModal(this);
            editModalLote.ShowDialog();

        }

        public void SetLoteActivo(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("Cambiar Estado a Activo?   (Un lote activo aparecera como invalido si ya paso su fecha vencimiento)  ", "Cambiar Estado", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                InventoryQueries.SetLoteEntradaActive(SelectedLoteActivo.CodInterno);

                if (SelectedLoteActivo.FechaVencimiento > DateTime.Now)
                {
                    
                    LotesActivos.Add(SelectedLoteActivo);
                    LotesInactivos.Remove(SelectedLoteActivo);

                }
            }
        }

        public void SetLoteInactivo(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("Cambiar Estado a Inactivo?", "Cambiar Estado", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                InventoryQueries.SetLoteEntradaInactive(SelectedLoteActivo.CodInterno);
                LotesInactivos.Add(SelectedLoteActivo);
                LotesActivos.Remove(SelectedLoteActivo);
            }
        }

        public void SetPaqueteActivo(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("Cambiar Estado a Activo?   (Un lote activo aparecera como invalido si ya paso su fecha vencimiento)  ", "Cambiar Estado", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                InventoryQueries.SetLoteEntradaActive(SelectedLoteActivo.CodInterno);

                if(SelectedLoteActivo.FechaVencimiento > DateTime.Now)
                {
                    LotesPaquetes.Add(SelectedLoteActivo);
                    LotesPaquetesInactivos.Remove(SelectedLoteActivo);

                }

            }
        }

        public void SetPaqueteInactivo(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("Cambiar Estado a Inactivo?", "Cambiar Estado", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                InventoryQueries.SetLoteEntradaInactive(SelectedLoteActivo.CodInterno);
                LotesPaquetesInactivos.Add(SelectedLoteActivo);
                LotesPaquetes.Remove(SelectedLoteActivo);
            }
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

        public void EditLotePaquete()
        {

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
            NewLote.CantidadExacta = Math.Round(NewLote.CantidadOriginal * SelectedMateriaPrima.ConversionValue,2, MidpointRounding.AwayFromZero);
            NewLote.NombreMP = SelectedMateriaPrima.Nombre;
            NewLote.NombreProveedor = SelectedProveedor.NombreProveedor;

            //System.Windows.MessageBox.Show(NewLote.CantidadExacta  + " " + SelectedMateriaPrima.conversionValue);
            
            InventoryQueries.CreateLoteEntrada(NewLote);
            LotesActivos.Add(NewLote);

            reset(1);

            System.Windows.MessageBox.Show("Nuevo Lote Creado");
        }

        public void EditLote()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
