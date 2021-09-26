using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CifarInventario.Models;
using CifarInventario.ViewModels.Classes.Queries;
using CifarInventario.Views.Modals;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CifarInventario.ViewModels.Commands;
using System.Windows.Input;
using CifarInventario.Views.Modals.FormulaModals;
using CifarInventario.ViewModels.Commands.FormulaCommands;
using System.Windows;

namespace CifarInventario.ViewModels
{
    public class FormulasVM : INotifyPropertyChanged
    {

        public FormulasVM()
        {
            //General setup
            Formulas = new ObservableCollection<Formula>(FormulaQueries.GetFormulas());
            NewFormulaProducts = new ObservableCollection<formulaProduct>(ProductQueries.GetFormulaProducts());
            InactiveFormulas = new ObservableCollection<Formula>(FormulaQueries.GetFormulasInactivas());

            NuevaFormulaCommand = new NewFormulaCommand(this);
            AddDetalleNewFormulaDataGrid = new NewFormulaDetalleDatagridCommand(this);
            newFormulaAddInstruction = new NewFormulaAddInstructionCommand(this);
            editDetalleCommand = new EditDetalleCommand(this);
            newDetalleCommand = new NewDetalleCommand(this);
            newInstructionCommand = new NewInstructionCommand(this);
            editFormulacommand = new EditFormulaCommand(this);
            Transformations = new ObservableCollection<Formula>(FormulaQueries.GetFormulasTransformaciones());


            UnidadCreada = new ObservableCollection<string> { "galones", "kilos" };
            FormasFarmaceuticas = new ObservableCollection<string> { "jarabe", "tableta", "pildora","suspension" };


            //new formula modal window setup
            NewFormula = new Formula();
            NewFormulaSelectedProduct = new formulaProduct();
            NewFormulaNewDetalle = new DetalleFormula();
            NewFormulaNewInstruction = new ProcedimientoDetalle();

            SelectedFormula = Formulas[0];



        }



        #region Members variables

        public DetalleFormula tempdetail;

        public string tempCode { get; set; }

        public bool isTransform { get; set; }

        public Formula TransformFormula {get; set;}

        private ObservableCollection<Formula> _transformations;

        public ObservableCollection<Formula> Transformations
        {
            get { return _transformations; }
            set
            {
                _transformations = value;
                OnPropertyChanged("Transformations");
            }
        }
    


        #region List Members
        private ObservableCollection<Formula> _formulas;

        public ObservableCollection<Formula> Formulas
        {
            get { return _formulas; }
            set
            {
                
                _formulas = value;
                OnPropertyChanged("Formulas");

            }
        }

        private ObservableCollection<DetalleFormula> _detalles;

        public ObservableCollection<DetalleFormula> Detalles
        {
            get { return _detalles; }
            set
            {
                _detalles = value;
                OnPropertyChanged("Detalles");
            }
        }


        private ObservableCollection<Formula> _inactiveFormulas;

        public ObservableCollection<Formula> InactiveFormulas
        {
            get { return _inactiveFormulas; }
            set
            {

                _inactiveFormulas = value;
                OnPropertyChanged("InactiveFormulas");

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

        private Formula _selectedInactive;

        public Formula SelectedInactive
        {
            get { return _selectedInactive; }
            set
            {
                _selectedInactive = value;
                OnPropertyChanged("SelectedInactive");
            }
        }

        private DetalleFormula _selectedDetalle;

        public DetalleFormula SelectedDetalle
        {
            get { return _selectedDetalle; }
            set
            {
                _selectedDetalle = value;
                OnPropertyChanged("SelectedDetalle");
            }
        }


        #endregion

        


        #region New Formula Modal Members

        private DetalleFormula _newFormulaNewDetalle;

        public DetalleFormula NewFormulaNewDetalle
        {
            get { return _newFormulaNewDetalle; }
            set
            {
                _newFormulaNewDetalle = value;
                OnPropertyChanged("NewFormulaNewDetalle");
            }
        }

        public ObservableCollection<String> FormasFarmaceuticas { get; set; }

        public ObservableCollection<String> UnidadCreada { get; set; }


        private DetalleFormula _newFormulaSelectedDetalle;

        public DetalleFormula NewFormulaSelectedDetalle
        {
            get { return _newFormulaSelectedDetalle; }
            set
            {
                _newFormulaSelectedDetalle = value;
                OnPropertyChanged("NewFormulaSelectedDetalle");
            }
        }

        private Formula _newFormula;

        public Formula NewFormula
        {
            get { return _newFormula; }
            set
            {
                _newFormula = value;
                OnPropertyChanged("NewFormula");
            }
        }

        public ObservableCollection<formulaProduct> NewFormulaProducts { get; set; }

        private ObservableCollection<DetalleFormula> _newFormulaDetalles;

        public ObservableCollection<DetalleFormula> NewFormulaDetalles
        {
            get { return _newFormulaDetalles; }
            set
            {
                _newFormulaDetalles = value;
                OnPropertyChanged("NewFormulaDetalles");
            }
        }

        public formulaProduct NewFormulaSelectedProduct { get; set; }



        private ObservableCollection<ProcedimientoDetalle> _newFormulaInstructions;


        public ObservableCollection<ProcedimientoDetalle> NewFormulaInstructions {
            get { return _newFormulaInstructions; }
            set
            {
                _newFormulaInstructions = value;
                OnPropertyChanged("NewFormulaInstructions");
            }
        }

        private ProcedimientoDetalle _selectedFormulaInstruction;

        public ProcedimientoDetalle SelectedFormulaInstruction
        {
            get { return _selectedFormulaInstruction; }
            set
            {
                _selectedFormulaInstruction = value;
                OnPropertyChanged("SelectedFormulaInstruction");
            }
        }

        public ProcedimientoDetalle NewFormulaNewInstruction { get; set; }



        #endregion

        #endregion



        #region Commands

        #region Delegate command creations

        public ICommand updateList => new DelegateCommand(UpdateDetallesList);
        public ICommand InactiveFormula => new DelegateCommand(SetFormulaInactive);
        public ICommand ActiveFormula => new DelegateCommand(SetFormulaActive);
        public ICommand newFormulaModal => new DelegateCommand(NewFormulaModal);     
        public ICommand deleteNewFormulaDetalle => new DelegateCommand(DeleteNewFormulaDetalle);
        public ICommand editDetalleModal => new DelegateCommand(EditDetalleModal);
        public ICommand deleteDetalle => new DelegateCommand(DeleteDetalle);
        public ICommand formulaExtraInfoModal => new DelegateCommand(FormulaExtraInfoModal);
        public ICommand formulaProcedimientoModal => new DelegateCommand(FormulaProcedimientoModal);
        public ICommand deleteProcedimientoDetalle => new DelegateCommand(EliminarProcedimientoDetalle);
        public ICommand editarProcedimientoDetalle => new DelegateCommand(EditarProcediminetoDetalle);
        #endregion

        public EditDetalleCommand editDetalleCommand { get; set; }
        public NewDetalleCommand newDetalleCommand { get; set; }
        public NewInstructionCommand newInstructionCommand { get; set; }
        public EditFormulaCommand editFormulacommand { get; set; }

        public void SetFormulaActive(object parameter)
        {
            FormulaQueries.setActive(SelectedInactive.CodFormula);

            
            Formulas.Add(SelectedInactive);
            InactiveFormulas.Remove(SelectedInactive);
        }

        public void UpdateDetallesList(object parameter)
        {
            Detalles = new ObservableCollection<DetalleFormula>(FormulaQueries.GetDetalles(SelectedFormula.CodFormula));
        }

        public void SetFormulaInactive(object parameter)
        {
            FormulaQueries.setInactive(SelectedFormula.CodFormula);

            InactiveFormulas.Add(SelectedFormula);
            Formulas.Remove(SelectedFormula);
        }

        public void EditDetalleModal(object parameter)
        {
            NewFormulaNewDetalle = new DetalleFormula();

            tempdetail = new DetalleFormula
            {
                CodFormula = SelectedDetalle.CodFormula
            };


            NewFormulaSelectedProduct.Codigo = SelectedDetalle.CodFormula;
            NewFormulaSelectedProduct.Nombre = SelectedDetalle.Name;

            var TestView = new EditDetalleModal(this);
            TestView.ShowDialog();
        }

        public void DeleteDetalle(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("Eliminar este detalle de formula?", "Eliminar Detalle", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                FormulaQueries.deleteDetalle(SelectedDetalle.IdMp, SelectedFormula.CodFormula);
                Detalles.Remove(SelectedDetalle);
            }

            //System.Windows.MessageBox.Show(SelectedDetalle.IdMp + " s    " + SelectedFormula.CodFormula);
        }

        public void EditDetalle()
        {


            
            FormulaQueries.updateDetalle(SelectedFormula.CodFormula, SelectedDetalle.IdMp, NewFormulaNewDetalle.Quantity);
            SelectedDetalle.Quantity = NewFormulaNewDetalle.Quantity;

            System.Windows.MessageBox.Show("Cantidad Actualizada con exito.");

            

            

            
        }

        public void AgregarDetalle()
        {
            var testDetalle = new DetalleFormula
            {
                Name = NewFormulaSelectedProduct.Nombre,
                IdMp = NewFormulaSelectedProduct.Codigo,
                Quantity = NewFormulaNewDetalle.Quantity,
                Unidad = NewFormulaSelectedProduct.Unidad
            };


            if (Detalles.Any(p => p.Name == testDetalle.Name))
            {
                MessageBox.Show("Esta MP ya se encuentra en la formula.");
            }
            else
            {
                FormulaQueries.agregarDetalle(testDetalle, SelectedFormula.CodFormula);
                Detalles.Add(testDetalle);
            }
        }

        public void FormulaExtraInfoModal(object parameter)
        {
            var test = new ExtraInfoModal(this);

            test.ShowDialog();
        }

        public void FormulaProcedimientoModal(object parameter)
        {
            NewFormulaInstructions = new ObservableCollection<ProcedimientoDetalle>(FormulaQueries.GetProcedimientoDetalles(SelectedFormula.CodFormula));
            SelectedFormulaInstruction = new ProcedimientoDetalle();

            var testview = new FormulaInstrucctionsModal(this);

            testview.ShowDialog();

           
        }

        public void AgregarProcediminetoDetalle()
        {

            System.Windows.MessageBox.Show("this is the number " + NewFormulaNewInstruction.Step);


            if (NewFormulaNewInstruction.Step == 0)
            {
                FormulaQueries.agregarProcedimiento(NewFormulaNewInstruction.Instruction, (NewFormulaInstructions.Count + 1), SelectedFormula.CodFormula);

                ProcedimientoDetalle testvar = new ProcedimientoDetalle()
                {
                    Instruction = NewFormulaNewInstruction.Instruction
                };

                NewFormulaInstructions.Add(testvar);

                System.Windows.MessageBox.Show("Instruccion agregada");
            }
            else if (NewFormulaNewInstruction.Step > NewFormulaInstructions.Count)
            {
                System.Windows.MessageBox.Show("Porfavor ingrese un valor de orden no mayor al numero de instrucciones.");
            }
            else
            {
                FormulaQueries.agregarProcedimientoEnPosicion(NewFormulaNewInstruction.Instruction, NewFormulaNewInstruction.Step, SelectedFormula.CodFormula);
                ProcedimientoDetalle testvar = new ProcedimientoDetalle()
                {
                    Instruction = NewFormulaNewInstruction.Instruction
                };
                NewFormulaInstructions.Insert((NewFormulaNewInstruction.Step - 1), testvar);

                System.Windows.MessageBox.Show("Instruccion agregada");

            }

            
            
        }

        public void EliminarProcedimientoDetalle(object parameter)
        {
            int counter = 0;



            MessageBoxResult result = MessageBox.Show("Eliminar esta instruccion de la formila?", "Eliminar Instruccion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                for (int i = 0; i < NewFormulaInstructions.Count; i++)
                {
                    if (NewFormulaInstructions[i].Instruction == SelectedFormulaInstruction.Instruction)
                    {
                        counter = i + 1;
                    }
                }



                FormulaQueries.deleteProcedimiento(counter.ToString(), SelectedFormula.CodFormula);


                NewFormulaInstructions.Remove(SelectedFormulaInstruction);

            }




        }

        public void EditarProcediminetoDetalle(object parameter)
        {
            FormulaQueries.updateProcedimiento(SelectedFormulaInstruction, SelectedFormula.CodFormula);
        }

        public void EditarFormula()
        {

            if(SelectedFormula.CodFormula != tempCode)
            {
                if (FormulaQueries.isRepeatedFormula(SelectedFormula.CodFormula))
                {
                    System.Windows.MessageBox.Show("Codigo de Formula ya existe.");
                }
                else
                {


                    //System.Windows.MessageBox.Show("This is form" + NewFormula.FormaFarm);
                    FormulaQueries.editarFormula(SelectedFormula, tempCode);
                    System.Windows.MessageBox.Show("Formula Maestra actualizada.");
                }
            }
            else
            {
                FormulaQueries.editarFormula(SelectedFormula, tempCode);
            }

            System.Windows.MessageBox.Show("Informacion de Formula Actualizada");
        }



        #region NewFormulaModalCommands

        public NewFormulaDetalleDatagridCommand AddDetalleNewFormulaDataGrid { get; set; }

        public NewFormulaCommand NuevaFormulaCommand { get; set; }

        public NewFormulaAddInstructionCommand newFormulaAddInstruction { get; set; }

        public void NewFormulaModal(object parameter)
        {
            var TestView = new NewFormulaModal(this);

            isTransform = false;
            NewFormulaDetalles = new ObservableCollection<DetalleFormula>();
            NewFormulaSelectedDetalle = new DetalleFormula();
            SelectedFormulaInstruction = new ProcedimientoDetalle();
            NewFormulaInstructions = new ObservableCollection<ProcedimientoDetalle>();
            NewFormula.FormaFarm = FormasFarmaceuticas[0];
            NewFormula.Cantidad = UnidadCreada[0];



            TestView.ShowDialog();


        } 

        public void createFormula()
        {
            if (FormulaQueries.isRepeatedFormula(NewFormula.CodFormula))
            {
                MessageBox.Show("Codigo de Formula ya existe.");
            }
            else
            {

                

                if (isTransform)
                {
                    NewFormula.Transformacion = TransformFormula.CodFormula;
                }
                else
                {
                    NewFormula.Transformacion = "";
                }

                //MessageBox.Show(NewFormula.FormaFarm + NewFormula.Cantidad);

                //System.Windows.MessageBox.Show("This is form" + NewFormula.FormaFarm);
                FormulaQueries.agregarFormula(NewFormulaDetalles.ToList(), NewFormula);
                //System.Windows.MessageBox.Show("Formula Maestra creada.");
            }
        }

        public void NewFormulaAddInstruction()
        {
            var testDetalle = new ProcedimientoDetalle
            {
                Instruction = NewFormulaNewInstruction.Instruction
            };

            //System.Windows.MessageBox.Show(testDetalle.Instruction);

            NewFormulaInstructions.Add(testDetalle);
        }

        public void NewFormullaDataGridDetalle()
        {


            var testDetalle = new DetalleFormula
            {
                Name = NewFormulaSelectedProduct.Nombre,
                IdMp = NewFormulaSelectedProduct.Codigo,
                Quantity = NewFormulaNewDetalle.Quantity,
                Unidad = NewFormulaSelectedProduct.Unidad
            };

            if (NewFormulaDetalles.Any(p => p.Name == testDetalle.Name))
            {
                MessageBox.Show("Esta MP ya se encuentra en la formula.");
            }
            else
            {
                NewFormulaDetalles.Add(testDetalle);
            }
            
        }

        public void DeleteNewFormulaDetalle(object parameter)
        {
            NewFormulaDetalles.Remove(NewFormulaSelectedDetalle);
        }

        #endregion

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
