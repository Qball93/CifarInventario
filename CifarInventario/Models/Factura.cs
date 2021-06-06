using CifarInventario.ViewModels.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.Models
{
    public class Factura:Validators, INotifyPropertyChanged
    {
        private int _idFactura;
        public int IdFactura
        {
            get { return _idFactura; }
            set
            {
                _idFactura = value;
                OnPropertyChanged("IdFactura");
            }
        }

        private int _idEmpleado;
        public int IdEmpleado
        {
            get { return _idEmpleado; }
            set
            {
                _idEmpleado = value;
                OnPropertyChanged("IdEmpleado");
            }
        }

        private Tuple<int, string> _cliente;
        public Tuple<int, string> Cliente
        {
            get { return _cliente; }
            set
            {
                _cliente = value;
                OnPropertyChanged("Cliente");
            }
        }

        private double _total;
        public double Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged("Total");
            }
        }

        



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DetalleFactura
    {
        public string LoteCod;
        public string NombreProducto;
        public float precio;
        public float cantidad;

    }
}
