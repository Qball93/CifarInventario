using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CifarInventario.Models;

namespace CifarInventario.ViewModels.Classes.Queries
{
    public class InfoQueries
    {
        static private OleDbConnection cn;
        static private OleDbDataReader dr;
        static private OleDbCommand cmd;


        public static List<Registro> getAllRecords()
        {
            var registros = new List<Registro>();

            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("SELECT * FROM registro_reempaque where tipo_evento = 'Reempaque';", cn);
                dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    Registro temp = new Registro();


                    temp.FechaEvento = DateTime.Parse(dr["fecha_evento"].ToString());
                    temp.Accion = dr["accion_realizada"].ToString();
                    temp.LoteRelevante = dr["lote_relevante"].ToString();
                    temp.Cantidad = int.Parse(dr["cantidad_cambiada"].ToString());


                    registros.Add(temp);


                }

                dr.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener registros  " + ex);
            }


            return registros;
        }
    }
}
