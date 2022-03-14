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

        public Formula() { }

        public Formula(Formula old)
        {
            Transformacion = old.Transformacion;
            Cantidad = old.Cantidad;
            CodFormula = old.CodFormula;
            NombreFormula = old.NombreFormula;
            Precauciones = old.Precauciones;
            FormaFarm = old.FormaFarm;
            TransCantidad = old.TransCantidad;
            Ingredients = old.Ingredients;
        }


        public string Transformacion
        {
            get { return _codTrans; }
            set
            {
                _codTrans = value;
                OnPropertyChanged(nameof(Transformacion));
            }
        }

        public string Cantidad
        {
            get { return _cantidad; }
            set
            {
                _cantidad = value;
                OnPropertyChanged(nameof(Cantidad));
            }
        }

        public string CodFormula
        {
            get { return _codFormula; }
            set
            {
                _codFormula = value;
                CodCheck = true;
                ClearErrors(nameof(CodFormula));
                IsEmptyString(value, nameof(CodFormula));
                isAlphaNumeric(value, nameof(CodFormula));
                OnPropertyChanged(nameof(CodFormula));
            }
        }

        public string NombreFormula
        {
            get { return _nombreFormula; }
            set
            {
                _nombreFormula = value;
                NombreCheck = true;
                ClearErrors(nameof(NombreFormula));
                IsEmptyString(value,nameof(NombreFormula));
                OnPropertyChanged(nameof(NombreFormula));
            }
        }

        public string Precauciones
        {
            get { return _precauciones; }
            set
            {
                _precauciones = value;
                PrecaucionCheck = true;
                ClearErrors(nameof(Precauciones));
                IsEmptyString(value, nameof(Precauciones));
                OnPropertyChanged(nameof(Precauciones));
            }
        }

        public string FormaFarm
        {
            get { return _formaFarm;  }
            set
            {
                _formaFarm = value;
                OnPropertyChanged(nameof(FormaFarm));
            }
        }

        public double TransCantidad
        {
            get { return _transCantidad; }
            set
            {
                _transCantidad = value;
                ClearErrors(nameof(TransCantidad));
                IsEmptyString(value.ToString(), nameof(TransCantidad));
                isDecimal(value.ToString(), nameof(TransCantidad));
                OnPropertyChanged(nameof(TransCantidad));
            }
        }

        public override string ToString()
        {
            return ("this is the data  Nombre: " + NombreFormula +
                " Unidad:  " + Cantidad +
                " Preacucion : " + Precauciones +
                " Forma Farm:  " + FormaFarm +
                " Codigo: " + CodFormula);

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

        public DetalleFormula(DetalleFormula old)
        {
            CodFormula = old.CodFormula;
            Name = old.Name;
            IdMp = old.IdMp;
            Quantity = old.Quantity;
            Unidad = old.Unidad;
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
                OnPropertyChanged(nameof(IdMp));
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
                ClearErrors(nameof(Quantity));
                IsEmptyString(value,nameof(Quantity));
                isDecimal(value,nameof(Quantity));
                OnPropertyChanged(nameof(Quantity));
            }
        }
        public string Unidad
        {
            get { return _unidad; }
            set
            {
                _unidad = value;
                OnPropertyChanged(nameof(Unidad));
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
                OnPropertyChanged(nameof(Step));
                ClearErrors(nameof(Step));

            }
        }

        private string _instruction;

        public string Instruction
        {
            get { return _instruction; }
            set {
                InstructionCheck = true;
                _instruction = value;
                ClearErrors(nameof(Instruction));
                IsEmptyString(value, nameof(Instruction));
                isAlphaNumeric(value, nameof(Instruction));
                OnPropertyChanged(nameof(Instruction));
            }
        }


        


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
