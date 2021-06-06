using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CifarInventario.Models
{
    public class EntidadCommercial : INotifyPropertyChanged
    {

        private int _id;
        private string _nombreCommercial;
        private string _nombreContacto;
        private string _direccion;
        private string _telefono;
        private string _correoContacto;
        private string _commentario;
        private string _rtn;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string NombreCommercial
        {
            get { return _nombreCommercial; }
            set
            {
                _nombreCommercial = value;
                OnPropertyChanged("NombreCommercial");
            }
        }

        public string NombreContacto
        {
            get { return _nombreContacto; }
            set
            {
                _nombreContacto = value;
                OnPropertyChanged("NombreContacto");
            }
        }

        public string Direccion
        {
            get { return _direccion; }
            set
            {
                _direccion = value;
                OnPropertyChanged("Direccion");
            }
        }

        public string Telefono
        {
            get { return _telefono; }
            set
            {
                _telefono = value;
                OnPropertyChanged("Telefono");
            }
        }

        public string CorreoContacto
        {
            get { return _correoContacto; }
            set
            {
                _correoContacto = value;
                OnPropertyChanged("CorreoContacto");
            }
        }


        public string Commentario
        {
            get { return _commentario; }
            set
            {
                _commentario = value;
                OnPropertyChanged("Commentario");
            }
        }

        public string RTN
        {
            get { return _rtn; }
            set
            {
                _rtn = value;
                OnPropertyChanged("RTN");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Empleado : INotifyPropertyChanged
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _telefono;
        private string _correo;
        
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                OnPropertyChanged("Nombre");
            }
        }

        public string Apellido
        {
            get { return _apellido; }
            set
            {
                _apellido = value;
                OnPropertyChanged("Apellido");
            }
        }

        public string Telefono
        {
            get { return _telefono; }
            set
            {
                _telefono = value;
                OnPropertyChanged("Telefono");
            }
        }

        public string Correo
        {
            get { return _correo; }
            set
            {
                _correo = value;
                OnPropertyChanged("Correo");
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

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string NombreProveedor
        {
            get { return _nombreProveedor; }
            set
            {
                _nombreProveedor = value;
                OnPropertyChanged("NombreProveedor");
            }
        }

        public string NombreContacto
        {
            get { return _nombreContacto; }
            set
            {
                _nombreContacto = value;
                OnPropertyChanged("NombreContacto");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}