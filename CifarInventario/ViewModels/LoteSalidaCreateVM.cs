using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CifarInventario.ViewModels.Commands.LoteSalCommands;
using CifarInventario.ViewModels.Commands;
using CifarInventario.Views.Modals.LotesSalidamodal;
using System.Text;
using CifarInventario.ViewModels.Classes.Queries;
using CifarInventario.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CifarInventario.ViewModels
{
    public class LoteSalidaCreateVM: INotifyPropertyChanged
    {

        public LoteSalidaCreateVM()
        {
            FormulasList = new List<Formula>(FormulaQueries.GetFormulas());


            createLote = new CreateLoteSalidaCommand(this);
            newOrden = new GenerateOrdenCommand(this);

            NuevoLote = new LoteSalida();

            SelectedFormula = FormulasList[0];

            SalidaDetalles = new ObservableCollection<LoteSalidaDetalle>();
            
        }


        private ObservableCollection<LoteSalidaDetalle> _salidaDetalles;
        public ObservableCollection<LoteSalidaDetalle> SalidaDetalles
        {
            get { return _salidaDetalles; }
            set
            {
                _salidaDetalles = value;
                OnPropertyChanged("SalidaDetalles");
            }
        }

        private LoteSalidaDetalle _selectedDetalle;
        public LoteSalidaDetalle SelectedDetalle
        {
            get { return _selectedDetalle; }
            set
            {
                _selectedDetalle = value;
                OnPropertyChanged("SelectedDetalle");
            }
        }


        private LoteSalida _nuevoLote;
        public LoteSalida NuevoLote
        {
            get { return _nuevoLote; }
            set
            {
                _nuevoLote = value;
                OnPropertyChanged("NuevoLote");
            }
        }


        private List<Formula> _formulasList;
        public List<Formula> FormulasList
        {
            get { return _formulasList; }
            set
            {
                _formulasList = value;
                OnPropertyChanged("FormulasList");
            }
        }

        private Formula _selectedFormula;
        public Formula SelectedFormula
        {
            get { return _selectedFormula; }
            set
            {
                _selectedFormula = value;
                OnPropertyChanged("SelectedFormula");
            }
        }

        private bool _createCheck;
        public bool CreateCheck
        {
            get { return _createCheck; }
            set
            {
                _createCheck = value;
                OnPropertyChanged("CreateCheck");
            }
        }


        public NewLoteInfoModal infoModal;
        public NewLoteSalidaCreateModal salidaModal;


        
        public ICommand openInfoModal => new DelegateCommand(OpenInfoModal);
        public ICommand openCreateLoteModal => new DelegateCommand(OpenCreateLoteModal);

        public GenerateOrdenCommand newOrden { get; set; }
        public CreateLoteSalidaCommand createLote { get; set; }


        public void OpenInfoModal(object parameter)
        {

            infoModal = new NewLoteInfoModal(this);

            infoModal.ShowDialog();

        }


        public void CreateOrden()
        {
            //System.Windows.MessageBox.Show("inside this " + SelectedFormula.CodFormula);
            //System.Windows.MessageBox.Show(SelectedFormula.Transformacion);

            if(!(String.IsNullOrEmpty(SelectedFormula.Transformacion)))
            {
                SalidaDetalles = new ObservableCollection<LoteSalidaDetalle>(InventoryQueries.getFormulaProductionDetalles(SelectedFormula.NombreFormula, NuevoLote.CantidadCreacion, SelectedFormula.CodFormula));

                SalidaDetalles.Insert(0, InventoryQueries.getTransformacionDetalle(SelectedFormula.CodFormula, NuevoLote.CantidadCreacion));
            }
            else
            {
                SalidaDetalles = new ObservableCollection<LoteSalidaDetalle>(InventoryQueries.getFormulaProductionDetalles(SelectedFormula.NombreFormula, NuevoLote.CantidadCreacion, SelectedFormula.CodFormula));
            }



            CreateCheck = true;
            infoModal.Close();
           // System.Windows.MessageBox.Show(SalidaDetalles[0].LotesProducto[0]);
        }

        public void CreateLoteSalida()
        {
            NuevoLote.Unidad = SelectedFormula.Cantidad;
            NuevoLote.CodFormula = SelectedFormula.CodFormula;
            //NuevoLote.OriginalLote = SalidaDetalles[0].CodLoteEntrada;


            NuevoLote.OriginalLote = SelectedFormula.Transformacion == "" ? "None" : SalidaDetalles[0].CodLoteEntrada;


            SalidaDetalles.RemoveAt(0);

            InventoryQueries.createLoteSalida(NuevoLote);

            foreach(var element in SalidaDetalles)
            {
                InventoryQueries.createLoteSalidaDetalle(element, NuevoLote.CodLote);
            }


            System.Windows.MessageBox.Show("Lote Producto Terminado Creado");

            salidaModal.Close();


        }

        public void OpenCreateLoteModal(object paramter)
        {

            bool loteCheck = true;

            if (CreateCheck)
            {
                foreach (var element in SalidaDetalles)
                {
                    if (element.LotesProducto[0] == "N/A")
                        loteCheck = false;
                }

                if (loteCheck)
                {

                    NuevoLote.FechaCreacion = DateTime.Today;
                    NuevoLote.FechaVencimiento = DateTime.Today;

                    salidaModal = new NewLoteSalidaCreateModal(this);

                    salidaModal.ShowDialog();
                }
                else
                {
                    System.Windows.MessageBox.Show("Una of mas Materia Prima no tiene suficiente existencia en un lote para esta produccion.");
                }
            }
            
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
