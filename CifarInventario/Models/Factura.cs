using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.Models
{
    public class Factura
    {
        public int IdFactura;
        public string NombreCliente;
        public string NombreEmpleado;
        public float Total;
        public float Subtotal;
        public float imp;
        public string fecha;
        public bool esAbonado;
        public float pendiente;
        public List<DetalleFactura> MP;
        public List<DetalleFactura> PT;
        public string direccion;
        public string RTN;
    }

    public class DetalleFactura
    {
        public string LoteCod;
        public string NombreProducto;
        public float precio;
        public float cantidad;

    }
}
