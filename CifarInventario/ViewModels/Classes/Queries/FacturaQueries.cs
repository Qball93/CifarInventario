using System;
using System.Collections.Generic;
using CifarInventario.Models;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Classes.Queries
{
    public class FacturaQueries
    {
        static private OleDbConnection cn;
        static private OleDbDataReader dr;
        static private OleDbCommand cmd;

        public static Factura getFactura(int id)
        {
            var factura = new Factura();
            factura.MP = new List<DetalleFactura>();
            factura.PT = new List<DetalleFactura>();
            

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT factura.fechaEmision, factura.total, factura.imp, factura.subtotal, clientes.nombre_commercial, clientes.direccion, clientes.RTN, empleados.nombre " +
                                        "FROM(factura INNER JOIN clientes ON factura.id_cliente = clientes.id) INNER JOIN empleados ON factura.id_empleado = empleados.id " +
                                        "WHERE(((factura.ID) = "+id+")); ", cn);
                dr = cmd.ExecuteReader();

              



                while (dr.Read())
                {
                    factura.IdFactura = id;
                    factura.imp = float.Parse(dr["imp"].ToString());
                    factura.Total = float.Parse(dr["total"].ToString());
                    factura.Subtotal = float.Parse(dr["subtotal"].ToString());
                    factura.NombreCliente = dr["nombre_commercial"].ToString();
                    factura.NombreEmpleado = dr["nombre"].ToString();
                    factura.direccion = dr["direccion"].ToString();
                    factura.fecha = dr["fechaEmision"].ToString();
                    factura.RTN = dr["RTN"].ToString();


                }


                cmd = new OleDbCommand("SELECT factura_detalle_mp.cod_lote_entrada, factura_detalle_mp.cantidad, materia_prima.nombre_producto, materia_prima.precio " +
                                        "FROM factura_detalle_mp inner join materia_prima ON factura_detalle_mp.cod_producto = materia_prima.codigo " +
                                        "WHERE factura_detalle_mp.id_factura = " + id + ";", cn);


                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var temp = new DetalleFactura();


                    temp.cantidad = int.Parse(dr["cantidad"].ToString());
                    temp.NombreProducto = dr["nombre_producto"].ToString();
                    temp.precio = float.Parse(dr["precio"].ToString());
                    temp.LoteCod = dr["cod_lote_entrada"].ToString();

                    factura.MP.Add(temp);
                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar la factura " + ex.ToString());
            }


            return factura;
        }


        public static void CreateFactura(Factura factura)
        {
            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO factura ([id_cliente],[id_empleado],[total],[subtotal],[imp],[fechaEmision],[abonado],[pendiente]) " +
                        "VALUES (@idClient,@idEmp,@total,@subtotal,@imp,@fechaEmission,@abonado,@pendiente) ";

                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@idClient",factura.),
                        new OleDbParameter("@codPT",lote.CodPT),
                        new OleDbParameter("@cantidad",lote.Cantidad),
                        new OleDbParameter("@codLoteEnt",lote.CodLoteEntrada)
                    });

                    cmd.ExecuteNonQuery();


                }

                cn.Close();

                updateLoteEntradaAmount(lote.CodLoteEntrada, -lote.Cantidad, codMP);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear Detalle Lote Salida  " + ex);
            }
        }

    }
}
