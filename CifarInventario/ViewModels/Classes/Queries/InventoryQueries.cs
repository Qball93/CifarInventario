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
    }
}
