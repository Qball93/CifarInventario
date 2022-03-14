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

       /* public static Factura getFactura(int id)
        {
            var factura = new Factura();
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
       */

        public static void CreateFactura(Factura factura)
        {
            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO factura ([ID],[id_cliente],[id_empleado],[total],[subtotal],[impuesto],[fechaEmision],[abonado],[pendiente],[descuento],[vendedor],[zona]) " +
                        "VALUES (@idFact,@idClient,@idEmp,@total,@subtotal,@imp,@fechaEmission,@abonado,@pendiente,@descuento,@vendedor,@zona) ";

                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@idFact",factura.IdFactura),
                        new OleDbParameter("@idClient",factura.Cliente.ID),
                        new OleDbParameter("@idEmp",factura.Empleado.ID),
                        new OleDbParameter("@total",factura.Total),
                        new OleDbParameter("@subtotal",factura.Sub),
                        new OleDbParameter("@imp",factura.Imp),
                        new OleDbParameter("@fechaEmission",factura.Emission.ToShortDateString()),
                        new OleDbParameter("@abonado",OleDbType.Boolean) { Value = factura.EsAbonado },
                        new OleDbParameter("@pendiente",factura.Pendiente),
                        new OleDbParameter("@descuento",factura.Descuento),
                        new OleDbParameter("@vendedor",factura.Vendedor),
                        new OleDbParameter("@zona",factura.Zona)

                       

                    });

                    cmd.ExecuteNonQuery();


                }

                cn.Close();

                

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear Factura " + ex);
            }
        }

        public static void CreateDetalle(DetalleFactura detail, string IdFactura)
        {
            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO factura_detalle ([id_factura],[id_producto],[id_lote_pt],[cantidad],[precio]) " +
                        "VALUES (@idFactura,@idProducto,@idLote,@cantidad,@precio) ";

                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@idFactura",IdFactura),
                        new OleDbParameter("@idProducto",detail.Producto.ID),
                        new OleDbParameter("@idLote",detail.LoteCod),
                        new OleDbParameter("@cantidad",detail.Cantidad),
                        new OleDbParameter("@precio",detail.Precio),
                    });

                    cmd.ExecuteNonQuery();


                }

                cn.Close();


                



            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear Detalle Factura " + ex);
            }
        }

        public static List<Factura> GetFacturaList()
        {
            var facturas = new List<Factura>();

            cn = DBConnection.MainConnection();


            try
            {
                cmd = new OleDbCommand("SELECT factura.ID, factura.descuento,factura.vendedor,factura.zona, id_cliente, id_empleado, total, subtotal, fechaEmision, abonado, impuesto, pendiente, " +
                    " empleados.nombre & ' ' & empleados.apellido as emp_name, clientes.nombre_commercial, clientes.direccion, clientes.RTN " +
                    "FROM(factura INNER JOIN clientes ON factura.id_cliente = clientes.id) INNER JOIN empleados ON factura.id_empleado = empleados.id;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    Factura fact = new Factura();

                    fact.IdFactura = dr["ID"].ToString();
                    fact.Cliente.ID = dr["id_cliente"].ToString();
                    fact.Cliente.Name = dr["nombre_commercial"].ToString();
                    fact.Empleado.ID = dr["id_empleado"].ToString();
                    fact.Empleado.Name =  dr["emp_name"].ToString();
                    fact.Direccion = dr["direccion"].ToString();
                    fact.RTN = dr["RTN"].ToString();
                    fact.Pendiente = double.Parse(dr["pendiente"].ToString());
                    fact.Imp = double.Parse(dr["impuesto"].ToString());
                    fact.EsAbonado = bool.Parse(dr["abonado"].ToString());
                    fact.Emission = DateTime.Parse(dr["fechaEmision"].ToString());
                    fact.Sub = double.Parse(dr["subtotal"].ToString());
                    fact.Total = double.Parse(dr["total"].ToString());
                    fact.Descuento = double.Parse(dr["descuento"].ToString());
                    fact.Vendedor = dr["vendedor"].ToString();
                    fact.Zona = dr["zona"].ToString();


                    facturas.Add(fact);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar listado de facturas. " + ex.ToString());
            }


            return facturas;
        }

        public static List<DetalleFactura> GetDetallesFactura(string id)
        {
            var detalles = new List<DetalleFactura>();

            cn = DBConnection.MainConnection();


            try
            {
                cmd = new OleDbCommand("SELECT * from factura_detalle " +
                    "INNER JOIN inventario_producto_terminado on inventario_producto_terminado.id_producto_terminado = factura_detalle.id_producto " +
                    "where id_factura = '" + id + "';", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    DetalleFactura temp = new DetalleFactura();

                    temp.IdFactura = dr["id_factura"].ToString();
                    temp.Producto.ID = dr["id_producto_terminado"].ToString();
                    temp.Producto.Name = dr["nombre_producto"].ToString();
                    temp.LoteCod = dr["id_lote_pt"].ToString();
                    temp.Cantidad = int.Parse(dr["cantidad"].ToString());
                    temp.Precio = double.Parse(dr["factura_Detalle.precio"].ToString());


                    detalles.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar detalles de factura. " + ex.ToString());
            }


            return detalles;
        }

        public static Factura GetFacturaFromId(int id)
        {
            var fact = new Factura();

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT factura.ID, factura.descuento, id_cliente, id_empleado, total, subtotal, fechaEmision, abonado, impuesto, pendiente, " +
                    " empleados.nombre & ' ' & empleados.apellido as emp_name, clientes.nombre_commercial, clientes.direccion, clientes.RTN " +
                    "FROM(factura INNER JOIN clientes ON factura.id_cliente = clientes.id) INNER JOIN empleados ON factura.id_empleado = empleados.id " +
                    "WHERE(((factura.ID) = '" + id + "'));", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    fact.IdFactura = dr["factura.ID"].ToString();
                    fact.Cliente.ID = dr["id_cliente"].ToString();
                    fact.Cliente.Name = dr["nombre_commercial"].ToString();
                    fact.Empleado.ID = dr["id_empleado"].ToString();
                    fact.Empleado.Name = dr["emp_name"].ToString();
                    fact.Direccion = dr["direccion"].ToString();
                    fact.RTN = dr["RTN"].ToString();
                    fact.Pendiente = double.Parse(dr["pendiente"].ToString());
                    fact.Imp = double.Parse(dr["impuesto"].ToString());
                    fact.EsAbonado = bool.Parse(dr["abonado"].ToString());
                    fact.Emission = DateTime.Parse(dr["fechaEmision"].ToString());
                    fact.Sub = double.Parse(dr["subtotal"].ToString());
                    fact.Total = double.Parse(dr["total"].ToString());
                    fact.Descuento = double.Parse(dr["descuento"].ToString());

                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener Factura. " + ex.ToString());
            }

            return fact;
        }

        public static bool isRepeatedFactura(string code)
        {
            var isDuplicate = false;

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT * FROM formulas where id = '" + code + "';", cn);
                dr = cmd.ExecuteReader();




                if (dr.Read())
                {
                    isDuplicate = true;
                }
                else
                {
                    isDuplicate = false;
                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al verificar factura duplicada. " + ex.ToString());
            }

            return isDuplicate;
        }

        public static void updateBalance(string idFactura, double amount)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE factura " +
                    "SET pendiente = (pendiente - " + amount + ")  " +
                    "where ID = '" + idFactura + "'; ", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar balance the factura  " + ex);
            }
        }

        public static void setAbonado(string idFactura)
        {
            cn = DBConnection.MainConnection();
            try
            {
#pragma warning disable CA1416 // Validate platform compatibility
                cmd = new OleDbCommand("UPDATE factura " +
                    "SET abonado = false " +
                    "where ID = '" + idFactura + "'; ", cn);
#pragma warning restore CA1416 // Validate platform compatibility
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al cambiar status de factura  " + ex);
            }
        }

        public static List<string> getVendedores()
        {
            var vendedores = new List<string>();

            cn = DBConnection.MainConnection();


            try
            {
                cmd = new OleDbCommand("SELECT * From Vendedores;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    string fact = "";

                    fact= dr["Nombre"].ToString();


                    vendedores.Add(fact);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar listado de vendedores. " + ex.ToString());
            }

            return vendedores;
        }

        public static List<Factura> GetFacturasFromLotePt(string loteCod)
        {
            var facturas = new List<Factura>();

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT Distinct(factura.ID) from factura_detalle INNER JOIN factura on factura_detalle.id_factura = factura.ID " +
                            " Where factura_detalle.id_lote_pt =   '" + loteCod + "' " +
                            "; ", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    Factura fact = new Factura();

                    fact.IdFactura = dr["ID"].ToString();

                    facturas.Add(fact);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar listado de facturas. " + ex.ToString());
            }


            return facturas;
        }

        public static List<Factura> GetFacturasFromLoteSal(string loteSal)
        {
            var facturas = new List<Factura>();

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("Select Distinct(id_factura) FROM factura_detalle INNER JOIN lotes_producto_terminado ON factura_detalle.id_lote_pt = lotes_producto_terminado.Codigo_Correlativo " +
                        "where lotes_producto_terminado.id_lote = '" + loteSal +  "' ; ", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    Factura fact = new Factura();

                    fact.IdFactura = dr["id_factura"].ToString();


                    facturas.Add(fact);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar listado de facturas. " + ex.ToString());
            }


            return facturas;
        }


    }

    
}
