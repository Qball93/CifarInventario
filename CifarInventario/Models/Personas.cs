using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CifarInventario.ViewModels.Classes;

namespace CifarInventario.Models
{
    public class EntidadCommercial : Validators, INotifyPropertyChanged
    {

        private int _id;
        private string _nombreCommercial;
        private string _nombreContacto;
        private string _direccion;
        private string _telefono;
        private string _correoContacto;
        private string _commentario;
        private string _rtn;


        public EntidadCommercial() { }

        public EntidadCommercial(EntidadCommercial old)
        {
            Id = old.Id;
            NombreCommercial = old.NombreCommercial;
            NombreContacto = old.NombreContacto;
            Direccion = old.Direccion;
            Telefono = old.Telefono;
            CorreoContacto = old.CorreoContacto;
            Commentario = old.Commentario;
            RTN = old.RTN;
        }

        public bool NombreCheck, DireccionCheck, TelefonoCheck = false;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string NombreCommercial
        {
            get { return _nombreCommercial; }
            set
            {
                _nombreCommercial = value;
                NombreCheck = true;
                ClearErrors(nameof(NombreCommercial));
                IsEmptyString(value, nameof(NombreCommercial));
                isAlphaNumeric(value, nameof(NombreCommercial));
                OnPropertyChanged(nameof(NombreCommercial));
            }
        }

        public string NombreContacto
        {
            get { return _nombreContacto; }
            set
            {
                _nombreContacto = value;
                ClearErrors(nameof(NombreContacto));
                isAlphaNumeric(value, nameof(NombreContacto));
                OnPropertyChanged(nameof(NombreContacto));
            }
        }

        public string Direccion
        {
            get { return _direccion; }
            set
            {
                _direccion = value;
                DireccionCheck = true;
                ClearErrors(nameof(Direccion));
                IsEmptyString(value, nameof(Direccion));
                isAlphaNumeric(value, nameof(Direccion));
                OnPropertyChanged(nameof(Direccion));
            }
        }

        public string Telefono
        {
            get { return _telefono; }
            set
            {
                _telefono = value;
                TelefonoCheck = true;
                ClearErrors(nameof(Telefono));
                IsEmptyString(value, nameof(Telefono));
                isAlphaNumeric(value, nameof(Telefono));
                OnPropertyChanged(nameof(Telefono));
            }
        }

        public string CorreoContacto
        {
            get { return _correoContacto; }
            set
            {
                _correoContacto = value;
                ClearErrors(nameof(CorreoContacto));
                isAlphaNumeric(value, nameof(CorreoContacto));
                OnPropertyChanged(nameof(CorreoContacto));
            }
        }


        public string Commentario
        {
            get { return _commentario; }
            set
            {
                _commentario = value;
                ClearErrors(nameof(Commentario));
                isAlphaNumeric(value, nameof(Commentario));
                OnPropertyChanged(nameof(Commentario));
            }
        }

        public string RTN
        {
            get { return _rtn; }
            set
            {
                _rtn = value;
                ClearErrors(nameof(RTN));
                isAlphaNumeric(value, nameof(RTN));
                OnPropertyChanged(nameof(RTN));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Empleado : Validators, INotifyPropertyChanged
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _telefono;
        private string _correo;


        public bool nombreCheck, apellidoCheck, telefonoCheck, correoCheck = false;

        public Empleado() { }

        public Empleado(Empleado old)
        {
            Id = old.Id;
            Nombre = old.Nombre;
            Apellido = old.Apellido;
            Telefono = old.Telefono;
            Correo = old.Correo;
        }

        
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                nombreCheck = true;
                _nombre = value;
                ClearErrors(nameof(Nombre));
                IsEmptyString(value,nameof(Nombre));
                IsLetters(value, nameof(Nombre));
                OnPropertyChanged(nameof(Nombre));
            }
        }

        public string Apellido
        {
            get { return _apellido; }
            set
            {
                _apellido = value;
                apellidoCheck = true;
                ClearErrors(nameof(apellidoCheck));
                IsEmptyString(value, nameof(Apellido));
                IsLetters(value, nameof(Apellido));
                OnPropertyChanged(nameof(Apellido));
            }
        }

        public string Telefono
        {
            get { return _telefono; }
            set
            {
                _telefono = value;
                telefonoCheck = true;
                ClearErrors(nameof(Telefono));
                IsEmptyString(value, nameof(Telefono));
                isStepNumber(value, nameof(Telefono));
                OnPropertyChanged(nameof(Telefono));
            }
        }

        public string Correo
        {
            get { return _correo; }
            set
            {
                _correo = value;
                correoCheck = true;
                ClearErrors(nameof(Correo));
                IsEmptyString(value, nameof(Correo));
                OnPropertyChanged(nameof(Correo));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class DisplayProveedor:INotifyPropertyChanged
    {
        private int _id;
        private string _nombreProveedor;
        private string _nombreContacto;

        public DisplayProveedor()
        {

        }

        public DisplayProveedor(DisplayProveedor old)
        {
            Id = old.Id;
            NombreContacto = old.NombreContacto;
            NombreProveedor = old.NombreProveedor;
        }


        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string NombreProveedor
        {
            get { return _nombreProveedor; }
            set
            {
                _nombreProveedor = value;
                OnPropertyChanged(nameof(NombreProveedor));
            }
        }

        public string NombreContacto
        {
            get { return _nombreContacto; }
            set
            {
                _nombreContacto = value;
                OnPropertyChanged(nameof(NombreContacto));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}