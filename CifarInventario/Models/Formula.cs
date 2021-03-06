using CifarInventario.ViewModels.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.Models
{

    public class Formula:Validators, INotifyPropertyChanged
    {
        private string _codFormula;
        private string _nombreFormula;
        private string _precauciones;
        private string _formaFarm;
        private string _cantidad;
        private string _codTrans;
        private double _transCantidad;

        public bool CodCheck, NombreCheck, PrecaucionCheck = false;

        public string Transformacion
        {
            get { return _codTrans; }
            set
            {
                _codTrans = value;
                OnPropertyChanged("Transformacion");
            }
        }

        public string Cantidad
        {
            get { return _cantidad; }
            set
            {
                _cantidad = value;
                OnPropertyChanged("Cantidad");
            }
        }

        public string CodFormula
        {
            get { return _codFormula; }
            set
            {
                _codFormula = value;
                CodCheck = true;
                ClearErrors("CodFormula");
                IsEmptyString(value, "CodFormula");
                isAlphaNumeric(value, "CodFormula");
                OnPropertyChanged("CodFormula");
            }
        }

        public string NombreFormula
        {
            get { return _nombreFormula; }
            set
            {
                _nombreFormula = value;
                NombreCheck = true;
                ClearErrors("NombreFormula");
                IsEmptyString(value,"NombreFormula");
                OnPropertyChanged("NombreFormula");
            }
        }

        public string Precauciones
        {
            get { return _precauciones; }
            set
            {
                _precauciones = value;
                PrecaucionCheck = true;
                ClearErrors("Precauciones");
                IsEmptyString(value, "Precauciones");
                OnPropertyChanged("Precauciones");
            }
        }

        public string FormaFarm
        {
            get { return _formaFarm;  }
            set
            {
                _formaFarm = value;
                OnPropertyChanged("FormaFarm");
            }
        }

        public double TransCantidad
        {
            get { return _transCantidad; }
            set
            {
                _transCantidad = value;
                ClearErrors("TransCantidad");
                IsEmptyString(value.ToString(), "TransCantidad");
                isDecimal(value.ToString(), "TransCantidad");
                OnPropertyChanged("TransCantidad");
            }
        }


        public List<DetalleFormula> Ingredients;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


    public class DetalleFormula:Validators, INotifyPropertyChanged
    {
        private string _codFormula;
        private string _name;
        private string _idMp;
        private string _quantity;
        private string _unidad;

        public bool QuantityCheck = false;

        public DetalleFormula()
        {

        }

        public DetalleFormula(string cod, string name, string quant, string unit)
        { 
            IdMp = cod;
            Name = name;
            Quantity = quant;
            Unidad = unit;
        }


        public string CodFormula
        {
            get { return _codFormula; }
            set
            {
                _codFormula = value;
                OnPropertyChanged("CodFormula");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string IdMp
        {
            get { return _idMp; }
            set {
                _idMp = value;
                OnPropertyChanged("IdMp");
            }
        }

        public string Quantity {
            get 
            { 
                return _quantity; 
            }
            set
            {
                _quantity = value;
                QuantityCheck = true;
                ClearErrors("Quantity");
                IsEmptyString(value,"Quantity");
                isDecimal(value,"Quantity");
                OnPropertyChanged("Quantity");
            }
        }

        public string Unidad
        {
            get { return _unidad; }
            set
            {
                _unidad = value;
                OnPropertyChanged("Unidad");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ProcedimientoDetalle:Validators, INotifyPropertyChanged
    {

        private int _step;
        public bool InstructionCheck = false;


        public int Step
        {
            get { return _step; }
            set
            {
                _step = value;
                OnPropertyChanged("Step");
                ClearErrors("Step");

            }
        }

        private string _instruction;

        public string Instruction
        {
            get { return _instruction; }
            set {
                InstructionCheck = true;
                _instruction = value;
                ClearErrors("Instruction");
                IsEmptyString(value, "Instruction");
                isAlphaNumeric(value, "Instruction");
                OnPropertyChanged("Instruction");
            }
        }


        


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
