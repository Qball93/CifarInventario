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
using CifarInventario.ViewModels.Classes;

namespace CifarInventario.ViewModels
{
    public class LotesSalidaVM : Validators, INotifyPropertyChanged
    {

        public LotesSalidaVM()
        {

            Lotes = new ObservableCollection<LoteSalida>(InventoryQueries.GetLoteSalidas());


            EmptyAmount = new LoteSalida();
            LotesInactive = new ObservableCollection<LoteSalida>(InventoryQueries.GetLotesInactivos());



        }

        //empty selection for MP combobox
        public formulaProduct EmptyProduct { get; set; }
        public LoteEntrada EmptyMPLote { get; set; }
        public LoteSalida EmptyAmount { get; set; }
        public ProductoTeminadoParaLista SelectedPT { get; set; }

        private bool _mpListEnabled;
        public bool MpListEnabled
        {
            get { return _mpListEnabled; }
            set
            {
                _mpListEnabled = value;
                OnPropertyChanged(nameof(MpListEnabled));
            }
        }

        private bool _loteListEnabled;
        public bool LoteListEnabled
        {
            get { return _loteListEnabled; }
            set
            {
                _loteListEnabled = value;
                OnPropertyChanged(nameof(LoteListEnabled));
            }
        }


        public bool CanExecuteAgregar { get; set; }


        //Modal Objects to control their flow
        public CreatePTLoteModal loteModal;
        public AmountsForPTModal amountModal;
        public EditPackageModal desempaqueModal;
        public DonateProductModal donateModal;

        private ObservableCollection<LoteSalida> _lotes;
        public ObservableCollection<LoteSalida> Lotes
        {
            get { return _lotes; }
            set
            {
                _lotes = value;
                OnPropertyChanged(nameof(Lotes));
            }
        }

        private LoteSalida _selectedLote;
        public LoteSalida SelectedLote
        {
            get { return _selectedLote; }
            set
            {
                _selectedLote = value;
                OnPropertyChanged(nameof(SelectedLote));
            }
        }

        private LoteSalida _newLote;
        public LoteSalida NewLote
        {
            get { return _newLote; }
            set
            {
                _newLote = value;
                OnPropertyChanged(nameof(NewLote));
            }
        }

        private ObservableCollection<ProductoTeminadoParaLista> _ptList;
        public ObservableCollection<ProductoTeminadoParaLista> PTList
        {
            get { return _ptList; }
            set
            {
                _ptList = value;
                OnPropertyChanged(nameof(PTList));
            }
        }

        private ObservableCollection<formulaProduct> _listadoMP;
        public ObservableCollection<formulaProduct> ListadoMP
        {
            get { return _listadoMP; }
            set
            {
                _listadoMP = value;
                OnPropertyChanged(nameof(ListadoMP));
            }
        }

        private ObservableCollection<LoteSalida> _lotesInactive;
        public ObservableCollection<LoteSalida> LotesInactive
        {
            get { return _lotesInactive; }
            set
            {
                _lotesInactive = value;
                OnPropertyChanged(nameof(LotesInactive));
            }
        }

        private LoteSalida _selectedInactive;
        public LoteSalida SelectedInactive
        {
            get { return _selectedInactive; }
            set
            {
                _selectedInactive = value;
                OnPropertyChanged(nameof(SelectedInactive));
            }
        }

        private emptyObject _placeholder;
        public emptyObject PlaceHolder
        {
            get { return _placeholder; }
            set
            {
                _placeholder = value;
                OnPropertyChanged(nameof(PlaceHolder));
            }
        }

        private ObservableCollection<LoteEntrada> _listadoLotes;
        public ObservableCollection<LoteEntrada> ListadoLotes
        {
            get { return _listadoLotes; }
            set
            {
                _listadoLotes = value;
                OnPropertyChanged(nameof(ListadoLotes));
            }
        }


        //This area exclusively for the creation of new PT Lotes


        private LotePT _newLotePT;
        public LotePT NewLotePT
        {
            get { return _newLotePT; }
            set
            {
                _newLotePT = value;
                OnPropertyChanged(nameof(NewLotePT));
            }

        }

        private ObservableCollection<LotePT> _lotesPT;
        public ObservableCollection<LotePT> LotesPT
        {
            get { return _lotesPT; }
            set
            {
                _lotesPT = value;
                OnPropertyChanged(nameof(LotesPT));
            }
        }

        private LotePT _selectedLotePT;
        public LotePT SelectedLotePT
        {
            get { return _selectedLotePT; }
            set
            {
                _selectedLotePT = value;
                OnPropertyChanged(nameof(SelectedLotePT));
            }
        }

        private LotePTDetalle _newLotePTNewDetalle;
        public LotePTDetalle NewLotePTNewDetalle
        {
            get { return _newLotePTNewDetalle; }
            set
            {
                _newLotePTNewDetalle = value;
                OnPropertyChanged(nameof(NewLotePTNewDetalle));
            }

        }

        private LotePTDetalle _newLoteSelectedPTNewDetalle;
        public LotePTDetalle NewLotePTSelectedNewDetalle
        {
            get { return _newLoteSelectedPTNewDetalle; }
            set
            {
                _newLoteSelectedPTNewDetalle = value;
                OnPropertyChanged(nameof(NewLotePTSelectedNewDetalle));
            }

        }


        private ObservableCollection<LotePTDetalle> _newLotePTDetalles;
        public ObservableCollection<LotePTDetalle> NewLotePTDetalles
        {
            get { return _newLotePTDetalles; }
            set
            {
                _newLotePTDetalles = value;
                OnPropertyChanged(nameof(NewLotePTDetalles));
            }
        }


        //single use double for the purpose of processing amount
        private double _newLoteamount;
        public double NewLoteAmount
        {
            get { return _newLoteamount; }
            set
            {
                _newLoteamount = value;
                isDecimal(value.ToString(), nameof(NewLoteAmount));
                OnPropertyChanged(nameof(NewLoteAmount));
            }
        }





        public ICommand UpdateProductList => new DelegateCommand(UpdateFinishedProductList);
        public ICommand openAmountSelectionModal => new DelegateCommand(OpenAmountSelectionModal);
        public ICommand resetSelection => new DelegateCommand(ResetSelection);
        public ICommand generateLotes => new DelegateCommand(GenerarLotesMP);   
        public ICommand eliminarDetalle => new DelegateCommand(EliminarDetalle);
        public ICommand openDesempaqueModal => new DelegateCommand(OpenDesempaqueModal);
        public ICommand openEditarModal => new DelegateCommand(OpenEditarModal);
       // public ICommand vaciarLote => new DelegateCommand(VaciarLote);
        public ICommand openInfoPaqueteModal => new DelegateCommand(OpenInfoPaquetesModal);
        public ICommand openDonateModal => new DelegateCommand(OpenDonateModal);
        public ICommand setInactiveLote => new DelegateCommand(setLoteInactive);
        public ICommand setActiveLote => new DelegateCommand(setLoteActive);

        public DonateProductCommand donarProductoCommand { get; set; }
        public ProcesarCantidadAmountCommand procesarCantidadAmountCommand { get; set; }
        public CreatePTFromLoteCommand createPTFromLoteCommand { get; set; }
        public AgregarDetalleEmpaque agregarDetalleEmpaque { get; set; }
        public DesmpaqueCommand desempaqueCommand { get; set; }
        public EditarLoteSalCommand editarLoteSalCommand { get; set; }
        


        public void OpenDonateModal(object parameter)
        {
            PlaceHolder = new emptyObject();
            donarProductoCommand = new DonateProductCommand(this);
            PlaceHolder.EmptyWord = "";
            PlaceHolder.EmptyAmount = 1.00;
            donateModal = new DonateProductModal(this);
            donateModal.ShowDialog();
        }

        public void OpenDesempaqueModal(object parameter)
        {
            PlaceHolder = new emptyObject();
            desempaqueModal = new EditPackageModal(this);
            desempaqueCommand = new DesmpaqueCommand(this);
            desempaqueModal.ShowDialog();
        }

        public void RegresarCantidades()
        {

            if(SelectedLotePT.Existencia < PlaceHolder.EmptyCantidad)
            {
                MessageBox.Show("La cantidad a desempacar no puede ser mayor a la cantidad existente");
            }
            else
            {
                NewLotePTDetalles = new ObservableCollection<LotePTDetalle>(ProductQueries.getDetallesFromPTLote(SelectedLotePT.CodigoCorrelativo));


                foreach (LotePTDetalle element in NewLotePTDetalles)
                {
                    InventoryQueries.updateLoteEntradaAmount(element.CodigoLoteMP, PlaceHolder.EmptyCantidad, element.CodigoMP);
                }

                ProductQueries.AdjustExistingLote(SelectedLotePT.CodigoCorrelativo, PlaceHolder, SelectedLotePT.CodigoPT);
                InventoryQueries.updateLoteSalidaAmount(PlaceHolder.EmptyAmount, SelectedLote.CodLote);

                string temp = createRegistro();
                InventoryQueries.CreateReempqueRegistro(temp, SelectedLotePT);

                MessageBox.Show("Producto Desempacado");

                SelectedLotePT.CantidadOriginal = (int.Parse(SelectedLotePT.CantidadOriginal) - PlaceHolder.EmptyCantidad).ToString();
                SelectedLotePT.Existencia -= PlaceHolder.EmptyCantidad;
                desempaqueModal.Close();
            }



            
        }

        public void OpenLoteCreationModal()
        {

            
            
            ListadoMP = new ObservableCollection<formulaProduct>(ProductQueries.GetAllContainerMPFromAmount(int.Parse(NewLotePT.CantidadOriginal)));
            createPTFromLoteCommand = new CreatePTFromLoteCommand(this);
            CanExecuteAgregar = false;


            if (ListadoMP.Count == 0)
            {
                MessageBox.Show("No hay suficientes empaques para esta cantidad.");
            }
            else
            {
                agregarDetalleEmpaque = new AgregarDetalleEmpaque(this);
                NewLotePTDetalles = new ObservableCollection<LotePTDetalle>();
                MpListEnabled = true;
                LoteListEnabled = false;


                loteModal = new CreatePTLoteModal(this);

               // EmptyMPLote = null;
                EmptyProduct = ListadoMP[0];
                PTList = new ObservableCollection<ProductoTeminadoParaLista>(ProductQueries.GetPTSimp());
                loteModal.ShowDialog();
            }



            
        }

        public void OpenInfoPaquetesModal(object parameter) 
        {
            NewLotePTDetalles = new ObservableCollection<LotePTDetalle>(ProductQueries.getDetallesFromPTLote(SelectedLotePT.CodigoCorrelativo));
            var temp = new DataGridInfoModal(this);
            temp.ShowDialog();
        }

        public void OpenAmountSelectionModal(object parameter)
        {
            NewLotePT = new LotePT();
            PlaceHolder = new emptyObject();
            PlaceHolder.EmptyWord = "empty";
            procesarCantidadAmountCommand = new ProcesarCantidadAmountCommand(this);

            amountModal = new AmountsForPTModal(this);
            amountModal.ShowDialog();
        }

        public string createRegistro()
        {
            string registro = " Reempaque de lote: " + SelectedLotePT.CodigoCorrelativo + " \n Cantidad de unidades: " + PlaceHolder.EmptyCantidad +
            "\n Cantidad en Lote a Regresar:  " +  PlaceHolder.EmptyAmount + " \n Empaques Utilizados: ";


            foreach (LotePTDetalle element in NewLotePTDetalles)
            {
                registro += "\n " + element.NombreEmpaque + ", Codigo Lote: " + element.CodigoLoteMP;

            }


            return registro;
        }

        public void UpdateFinishedProductList(object parameter)
        {
            if (SelectedLote != null)
            {
                LotesPT = new ObservableCollection<LotePT>(InventoryQueries.getPTfromLote(SelectedLote.CodLote));
            }
            else
            {
                LotesPT = new ObservableCollection<LotePT>();
            }
        }

        public void GenerarLotesMP(object parameter)
        {

            ListadoLotes = new ObservableCollection<LoteEntrada>(InventoryQueries.getLotesForMP(EmptyProduct.Codigo, int.Parse(NewLotePT.CantidadOriginal)));

            if (ListadoLotes.Count == 0)
            {

                MessageBox.Show("No hay un lote individual con esa cantidad");
            }
            else
            {
                //EmptyMPLote = ListadoLotes[0];
                LoteListEnabled = true;
                MpListEnabled = false;

            }

        }

        public void EliminarDetalle(object parameter)
        {
            NewLotePTDetalles.Remove(NewLotePTSelectedNewDetalle);
        }

        public void ResetSelection(object parameter)
        {
            MpListEnabled = true;
            LoteListEnabled = false;
        }
        
        public void OpenEditarModal(object parameter)
        {
            NewLote = new LoteSalida(SelectedLote);
            editarLoteSalCommand = new EditarLoteSalCommand(this);
            var temp = new EditLoteSalModal(this);
            temp.ShowDialog();

        }

        public void ProcesarCantidades()
        {


            if(PlaceHolder.EmptyAmount > SelectedLote.CantidadActual)
            {
                MessageBox.Show("La cantidad a procesar no puede ser mayor a la cantidad actual");
            }
            else
            {
                OpenLoteCreationModal();
            }
        }

        public void AgregarDetalleEmpaque()
        {




            if (EmptyMPLote.CodLote == "N/A")
            {
                MessageBox.Show("No hay Lotes de Entrada disponible para este MP");
            }
            else
            {

                if (NewLotePTDetalles.Any(p => p.NombreEmpaque == EmptyProduct.Nombre))
                {
                    MessageBox.Show("Este empaque ya esta utilizado en el Producto Terminado porfavor utilizar un lote diferent o volver a cear la entrada.");
                }
                else
                {

                    NewLotePTNewDetalle = new LotePTDetalle();

                    NewLotePTNewDetalle.CodigoLoteMP = EmptyMPLote.CodInterno;
                    NewLotePTNewDetalle.NombreEmpaque = EmptyProduct.Nombre;
                    NewLotePTNewDetalle.CodigoMP = EmptyProduct.Codigo;

                    NewLotePTDetalles.Add(NewLotePTNewDetalle);

                    CanExecuteAgregar = false;
                    MpListEnabled = true;
                    LoteListEnabled = false;

                    MessageBox.Show("Empaque agregado a Producto Terminado");
                }

            }
        }

        public void CreateProductoTerminado()
        {

            NewLotePT.CodigoLoteSalida = SelectedLote.CodLote;
            NewLotePT.CodigoPT = SelectedPT.CodPT; 
            InventoryQueries.updateLoteSalidaAmount(-PlaceHolder.EmptyAmount, SelectedLote.CodLote);


           

             ProductQueries.CreateProductoTerminado(NewLotePT, int.Parse(NewLotePT.CantidadOriginal));


            foreach (var element in NewLotePTDetalles)
            {
                element.CodigoLotePT = NewLotePT.CodigoCorrelativo;
                ProductQueries.CreateProductoTerminadoDetalle(element, int.Parse(NewLotePT.CantidadOriginal), element.CodigoMP);
            }

            

            MessageBox.Show("Lote Producto Terminado Creado");

            SelectedLote.CantidadActual -= PlaceHolder.EmptyAmount;

            loteModal.Close();
            amountModal.Close();
        }

        public void EditarLoteSalida()
        {
            InventoryQueries.updateLoteSalida(NewLote);
            MessageBox.Show("Informacion de Lote Actualizada.");

            
        }

        public void updateLoteSalidaInstance()
        {
            SelectedLote.FechaVencimiento = NewLote.FechaVencimiento;
            SelectedLote.FechaCreacion = NewLote.FechaCreacion;
            SelectedLote.CantidadActual = NewLote.CantidadActual;
            SelectedLote.CantidadCreacion = NewLote.CantidadCreacion;
        }

        public void donateCantidadLoteSal()
        {
            if (SelectedLotePT.Existencia < PlaceHolder.EmptyCantidad)
            {
                MessageBox.Show("La cantidad a donar no puede ser mayor a la cantidad existente");
            }
            else
            {
                NewLotePTDetalles = new ObservableCollection<LotePTDetalle>(ProductQueries.getDetallesFromPTLote(SelectedLotePT.CodigoCorrelativo));




                InventoryQueries.CreateDonacionRegistro(PlaceHolder.EmptyWord, SelectedLotePT,PlaceHolder.EmptyCantidad);
                ProductQueries.updateProductoTermnadoRemoveAmount(SelectedLotePT.CodigoCorrelativo,PlaceHolder.EmptyCantidad);
                ProductQueries.InventarioPTSellAmount(SelectedLotePT.CodigoPT,PlaceHolder.EmptyCantidad);

                MessageBox.Show("Cantidad Donada");

                SelectedLotePT.Existencia -= PlaceHolder.EmptyCantidad;
                donateModal.Close();
            }
        }

        public void setLoteInactive(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("Cambiar Estado a Inactivo?", "Cambiar Estado", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                InventoryQueries.SetLoteSalidaInactive(SelectedLote.CodLote);

                LotesInactive.Add(SelectedLote);
                Lotes.Remove(SelectedLote);
            }

        }


        public void setLoteActive(object parameter)
        {


            MessageBoxResult result = MessageBox.Show("Cambiar Estado a Activo?", "Cambiar Estado", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                InventoryQueries.SetLoteSalidaActive(SelectedInactive.CodLote);

                Lotes.Add(SelectedInactive);
                LotesInactive.Remove(SelectedInactive);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
