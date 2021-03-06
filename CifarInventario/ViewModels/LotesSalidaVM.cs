using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CifarInventario.ViewModels.Commands;
using System.Windows.Input;
using CifarInventario.Models;
using CifarInventario.ViewModels.Commands.LoteSalCommands;
using CifarInventario.Views.Modals.LotesSalidamodal;
using CifarInventario.ViewModels.Classes.Queries;
using System.Windows;


namespace CifarInventario.ViewModels
{
    public class LotesSalidaVM: INotifyPropertyChanged
    {

        public LotesSalidaVM()
        {

            Lotes = new ObservableCollection<LoteSalida>(InventoryQueries.GetLoteSalidas());
            //Transformaciones = new ObservableCollection<LoteSalida>(InventoryQueries.GetLotesTransform());
            SelectedLote = Lotes[0];
            //MessageBox.Show(SelectedLote.CodLote);
            createPackageCommand = new CreatePTFromLoteCommand(this);
            generateLotesMp = new GenerateLotesFromMpCommand(this);
            agregarDetalleEmpaque = new AgregarDetalleEmpaque(this);



            EmptyAmount = new LoteSalida();
            NewLotePackage = new LotePackage();
            NewLotePackageDetalle = new LotePackageDetalle();


            LotesPaquete = new ObservableCollection<LotePackage>(InventoryQueries.getPTfromLote(SelectedLote.CodLote));
            LotesInactive = new ObservableCollection<LoteSalida>(InventoryQueries.GetLotesInactivos());
            PTList = new ObservableCollection<ProductoTeminadoParaLista>(ProductQueries.GetPTSimp());
            ListadoMP = new ObservableCollection<formulaProduct>(ProductQueries.GetAllContainersMP());
            EmptyProduct = ListadoMP[0];



        }


        public LotePaqueteModal loteModal;

        #region DataGrid Lists

        private ObservableCollection<ProductoTeminadoParaLista> _ptList;
        public ObservableCollection<ProductoTeminadoParaLista> PTList
        {
            get { return _ptList; }
            set
            {
                _ptList = value;
                OnPropertyChanged("PTList");
            }
        }

        public ProductoTeminadoParaLista SelectedPT { get; set; }

        private ObservableCollection<LoteSalida> _lotes;
        public ObservableCollection<LoteSalida> Lotes
        {
            get { return _lotes; }
            set
            {
                _lotes = value;
                OnPropertyChanged("Lotes");
            }
        }

        private ObservableCollection<LoteSalida> _lotesInactive;
        public ObservableCollection<LoteSalida> LotesInactive
        {
            get { return _lotesInactive; }
            set
            {
                _lotesInactive = value;
                OnPropertyChanged("LotesInactive");
            }
        }

        /* private ObservableCollection<LoteSalida> _transformaciones;

         public ObservableCollection<LoteSalida> Transformaciones
         {
             get { return _transformaciones; }
             set
             {
                 _transformaciones = value;
                 OnPropertyChanged("Transformaciones");
             }
         }*/


        private ObservableCollection<LotePackage> _lotePaquete;
        public ObservableCollection<LotePackage> LotesPaquete
        {
            get { return _lotePaquete; }
            set
            {
                _lotePaquete = value;
                OnPropertyChanged("LotesPaquete");
            }
        }

        private LotePackage _selectedPackage;
        public LotePackage SelectedPackage
        {
            get { return _selectedPackage; }
            set
            {
                _selectedPackage = value;
                OnPropertyChanged("SelectedPackage");
            }
        }

        private LotePackage _newLotePackage;
        public LotePackage NewLotePackage
        {
            get { return _newLotePackage; }
            set
            {
                _newLotePackage = value;
                OnPropertyChanged("NewLotePackage");
            }
        }

        private LoteSalida _selectedLote;
        public LoteSalida SelectedLote
        {
            get { return _selectedLote; }
            set
            {
                _selectedLote = value;
                OnPropertyChanged("SelectedLote");
            }
        }

        private LoteSalida _selectedInactive;
        public LoteSalida SelectedInactive
        {
            get { return _selectedInactive; }
            set
            {
                _selectedInactive = value;
                OnPropertyChanged("SelectedInactive");
            }
        }

        private ObservableCollection<LotePackageDetalle> _detallesPaquete;
        public ObservableCollection<LotePackageDetalle> DetallePaquete
        {
            get { return _detallesPaquete; }
            set
            {
                _detallesPaquete = value;
                OnPropertyChanged("DetallePquete");
            }
        }

        private LotePackageDetalle _selectedDetalle;
        public LotePackageDetalle SelectedDetalle
        {
            get { return _selectedDetalle; }
            set
            {
                _selectedDetalle = value;
                OnPropertyChanged("SelectedDetalle");
            }
        }

        private ObservableCollection<formulaProduct> _listadoMP;
        public ObservableCollection<formulaProduct> ListadoMP
        {
            get { return _listadoMP; }
            set
            {
                _listadoMP = value;
                OnPropertyChanged("ListadoMP");
            }
        }

        private ObservableCollection<LoteEntrada> _listadoLotes;
        public ObservableCollection<LoteEntrada> ListadoLotes
        {
            get { return _listadoLotes; }
            set
            {
                _listadoLotes = value;
                OnPropertyChanged("ListadoLotes");
            }
        }

        private LotePackageDetalle _newLotePackageDetalle;
        public LotePackageDetalle NewLotePackageDetalle
        {
            get { return _newLotePackageDetalle; }
            set
            {
                _newLotePackageDetalle = value;
                OnPropertyChanged("NewLotePackageDetalle");
            }
        }

        public LoteSalida EmptyAmount { get; set; }

        public LoteEntrada EmptyMPLote { get; set; }

        public formulaProduct EmptyProduct { get; set; }


        /*  private LoteSalida _selectedTransformacion;

          public LoteSalida SelectedTransformacion
          {
              get { return _selectedTransformacion; }
              set
              {
                  _selectedTransformacion = value;
                  OnPropertyChanged("SelectedTransformacion");
              }
          }*/


        #endregion




        public ICommand UpdateProductList => new DelegateCommand(UpdateFinishedProductList);

        public ICommand ActiveLote => new DelegateCommand(SetLoteActive);

        public ICommand InactiveLote => new DelegateCommand(SetLoteInactive);

        public ICommand openPackageModal => new DelegateCommand(OpenPackageModal);

        public ICommand openDetallePackageModal => new DelegateCommand(OpenDetallePackageModal);

        public ICommand deletePackage => new DelegateCommand(EliminarLotePackage);

        public ICommand deleteEmpauqe => new DelegateCommand(EliminarLotePackage);

        public CreatePTFromLoteCommand createPackageCommand { get; set; }

        public GenerateLotesFromMpCommand generateLotesMp { get; set; }


        public AgregarDetalleEmpaque agregarDetalleEmpaque { get; set; }

        public void OpenDetallePackageModal(object parameter)
        {
            DetallePaquete = new ObservableCollection<LotePackageDetalle>(InventoryQueries.getMPFromPTLoteDetalles());



            var testView = new DataGridPackageModal(this);


            //MessageBox.Show(DetallePaquete[0].NombreEmpaque);

            testView.ShowDialog();
        }

        public void OpenPackageModal(object paramater)
        {
            
            SelectedPT = PTList[0];
            loteModal = new LotePaqueteModal(this);



            loteModal.ShowDialog();
        }

        public void CreateProductoTerminado()
        {
            NewLotePackage.CodPT = SelectedPT.CodPT;
            NewLotePackage.FechaVencimiento = SelectedLote.FechaVencimiento;
            NewLotePackage.IdLote = SelectedLote.CodLote;


            if(EmptyAmount.CantidadActual > SelectedLote.CantidadActual)
            {
                MessageBox.Show("La cantidad a procesar no puede ser mayor a la cantidad en existencia del lote.");
            }
            else
            {
                ProductQueries.CreateProductoTerminado(NewLotePackage, -EmptyAmount.CantidadActual);
                SelectedLote.CantidadActual -= EmptyAmount.CantidadActual;

                //Lotes
            }

            loteModal.Close();
        }
        
        public void UpdateFinishedProductList(object parameter)
        {
            LotesPaquete = new ObservableCollection<LotePackage>(InventoryQueries.getPTfromLote(SelectedLote.CodLote));
        }

        public void SetLoteActive(object parameter)
        {
            InventoryQueries.SetLoteSalidaActive(SelectedInactive.CodLote);

            Lotes.Remove(SelectedLote);
            LotesInactive.Add(SelectedLote);


        }

        public void SetLoteInactive(object parameter)
        {
            InventoryQueries.SetLoteSalidaActive(SelectedLote.CodLote);

            Lotes.Add(SelectedInactive);
            LotesInactive.Remove(SelectedInactive);
        }

        public void AgregarDetalleEmpaque()
        {

            
            if(EmptyMPLote.CodLote == "N/A")
            {
                MessageBox.Show("No hay Lotes de Entrada disponible para este MP");
            }
            else
            {
                NewLotePackageDetalle.CodLoteEntrada = EmptyMPLote.CodInterno;
                NewLotePackageDetalle.CodLoteSalida = SelectedLote.CodLote;
                NewLotePackageDetalle.CodPT = SelectedPackage.CodPT;
                NewLotePackageDetalle.NombreEmpaque = EmptyProduct.Nombre;
                ProductQueries.CreateProductoTerminadoDetalle(NewLotePackageDetalle, EmptyMPLote.CodMP);
                LotePackageDetalle test = new LotePackageDetalle();
                test = NewLotePackageDetalle;
                DetallePaquete.Add(test);


                MessageBox.Show("Success");

            }
        }

        public void BuscarLotes()
        {
            
            ListadoLotes = new ObservableCollection<LoteEntrada>(InventoryQueries.getLotesForMP(EmptyProduct.Codigo,NewLotePackageDetalle.Cantidad));
            EmptyMPLote = ListadoLotes[0];

        }

        public void EliminarEmpaqueDataGrid(object parameter)
        {

        }

        public void EliminarLotePackage(object paramter)
        {

        }





        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
