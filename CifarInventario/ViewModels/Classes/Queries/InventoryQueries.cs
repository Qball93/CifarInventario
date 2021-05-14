using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using CifarInventario.Models;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Classes.Queries
{
    class InventoryQueries
    {
        static private OleDbConnection cn;
        static private OleDbDataReader dr;
        static private OleDbCommand cmd;


        public static List<MpProduct> GetMP()
        {
            var mp = new List<MpProduct>();


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT * FROM materia_prima inner join unidades ON materia_prima.unidad_metric = unidades.id;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    MpProduct temp = new MpProduct();

                    temp.Id = dr["materia_prima.id"].ToString();
                    temp.Existencia = int.Parse(dr["existencia"].ToString());
                    temp.NombreProducto = dr["nombre_producto"].ToString();
                    temp.Precio = float.Parse(dr["precio"].ToString());
                    temp.Unidad.Id = int.Parse(dr["unidades.id"].ToString());
                    temp.Unidad.NombreUnidad = dr["Nombre"].ToString();
                    temp.Entrada = int.Parse(dr["entrada"].ToString());
                    temp.Salida = int.Parse(dr["salida"].ToString());


                 

                    mp.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar el inventario de materia prima " + ex.ToString());
            }




            return mp;
        }

        public static List<LoteEntrada> GetLotesEntradaActivos()
        {
            var lotes = new List<LoteEntrada>();


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT lote_entrada.codigo_lote, lote_entrada.fecha_entrada, lote_entrada.cantidad_actual, lote_entrada.fecha_creacion, lote_entrada.cantidad_original, lote_entrada.certificado_analysis, " +
                    "lote_entrada.fecha_vencimiento, materia_prima.nombre_producto, materia_prima.unidad_muestra, lote_entrada.procedencia, lote_entrada.fabricante, proveedor.nombre_commercial as nombre_proveedor, lote_entrada.cod_proveedor " +
                    "FROM (lote_entrada INNER JOIN materia_prima ON lote_entrada.cod_mp = materia_prima.codigo) INNER JOIN proveedor ON proveedor.id = lote_entrada.cod_proveedor " +
                    "WHERE lote_entrada.cantidad_actual > 0;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    LoteEntrada temp = new LoteEntrada();

                    temp.CodLote = dr["codigo_lote"].ToString();
                    temp.NombreFabricante = dr["fabricante"].ToString();
                    temp.CodProveedor = dr["cod_proveedor"].ToString();
                    temp.NombreProveedor = dr["Nombre_proveedor"].ToString();
                    temp.NombreMP = dr["nombre_producto"].ToString();
                    temp.CantidadActual = long.Parse(dr["cantidad_actual"].ToString());
                    temp.CantidadOriginal = long.Parse(dr["cantidad_original"].ToString());
                    temp.FechaVencimiento = dr["fecha_vencimiento"].ToString();
                    temp.FechaFabricacion = dr["fecha_creacion"].ToString();
                    temp.CertificadoAnalysis = dr["certificado_analysis"].ToString();
                    temp.Procedencia = dr["procedencia"].ToString();
                    temp.Unidad = dr["unidad_muestra"].ToString();




                    lotes.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar los lotes activos. " + ex.ToString());
            }




            return lotes;
        }


        public static List<formulaProduct> GetFormulaProducts()
        {
            var mp = new List<formulaProduct>();


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT codigo,nombre_producto,unidad_metrica from materia_prima WHERE codigo NOT LIKE 'ENV%'  AND codigo NOT LIKE 'ETI%' AND codigo NOT LIKE 'TP%';", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    formulaProduct temp = new formulaProduct();

                    temp.codigo = dr["codigo"].ToString();
                    temp.nombre = dr["nombre_producto"].ToString();
                    temp.unidad = dr["unidad_metrica"].ToString();




                    mp.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar materia prima para formulas. " + ex.ToString());
            }




            return mp;
        }
    }
}
