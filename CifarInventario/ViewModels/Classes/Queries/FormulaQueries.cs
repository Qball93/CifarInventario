using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using CifarInventario.Models;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Classes.Queries
{
    public class FormulaQueries
    {
        static private OleDbConnection cn;
        static private OleDbDataReader dr;
        static private OleDbCommand cmd;

        public static List<Formula> GetFormulas()
        {
            List<Formula> formulas = new List<Formula>();

            cn = DBConnection.MainConnection();

            try
            {
            
                cmd = new OleDbCommand("SELECT * FROM formulas where Activo = true;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    Formula temp = new Formula();

                    temp.CodFormula = dr["id"].ToString();
                    temp.FormaFarm = dr["forma_farm"].ToString();
                    temp.NombreFormula = dr["nombre_formula"].ToString();
                    temp.Precauciones = dr["precauciones"].ToString();
                    temp.Cantidad = dr["cantidad_creada"].ToString();

                    formulas.Add(temp);

                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener listado de formulas " + ex.ToString());
            }


            return formulas;



        }

        public static List<Formula> GetFormulasInactivas()
        {
            List<Formula> formulas = new List<Formula>();

            cn = DBConnection.MainConnection();

            try
            {

                cmd = new OleDbCommand("SELECT * FROM formulas where Activo = false;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    Formula temp = new Formula();

                    temp.CodFormula = dr["id"].ToString();
                    temp.FormaFarm = dr["forma_farm"].ToString();
                    temp.NombreFormula = dr["nombre_formula"].ToString();
                    temp.Precauciones = dr["precauciones"].ToString();
                    temp.Cantidad = dr["cantidad_creada"].ToString();

                    formulas.Add(temp);

                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener listado de formulas " + ex.ToString());
            }


            return formulas;



        }

        public static List<DetalleFormula> GetDetalles(string codigo)
        {
            List<DetalleFormula> detalles = new List<DetalleFormula>();

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT * FROM formula_detalle " +
                    "INNER JOIN materia_prima on materia_prima.codigo = formula_detalle.mp_id where id = '" + codigo +"';", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    DetalleFormula temp = new DetalleFormula();

                    temp.IdMp = dr["mp_id"].ToString();
                    temp.Name = dr["nombre_producto"].ToString();
                    temp.Quantity = dr["cantidad_proporcion"].ToString();
                    temp.Unidad = dr["unidad_metrica"].ToString();

                    detalles.Add(temp);

                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener detalles de formula " + ex.ToString());
            }


            return detalles;
        }

        public static List<ProcedimientoDetalle> GetProcedimientoDetalles(string codigo)
        {
            List<ProcedimientoDetalle> instructions = new List<ProcedimientoDetalle>();

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT * FROM procedimiento_detalle " +
                    "where id_formula = '" + codigo + "' ORDER BY numero_etapa;", cn);

                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    ProcedimientoDetalle temp = new ProcedimientoDetalle();

                    temp.Instruction = dr["procedimiento"].ToString();
                    temp.Step = int.Parse(dr["numero_etapa"].ToString());

                    instructions.Add(temp);

                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener procedimientos " + ex.ToString());
            }


            return instructions;
        }

        public static List<Formula> GetFormulasTransformaciones()
        {
            List<Formula> formulas = new List<Formula>();

            cn = DBConnection.MainConnection();

            try
            {

                cmd = new OleDbCommand("SELECT * FROM formulas where Activo = true and cod_transformacion IS NOT NULL;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    Formula temp = new Formula();

                    temp.CodFormula = dr["id"].ToString();
                    temp.FormaFarm = dr["forma_farm"].ToString();
                    temp.NombreFormula = dr["nombre_formula"].ToString();
                    temp.Precauciones = dr["precauciones"].ToString();
                    temp.Cantidad = dr["cantidad_creada"].ToString();

                    formulas.Add(temp);

                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener listado de formulas " + ex.ToString());
            }


            return formulas;
        }

        public static List<Formula> GetNormalFormulas()
        {
            List<Formula> formulas = new List<Formula>();

            cn = DBConnection.MainConnection();

            try
            {

                cmd = new OleDbCommand("SELECT * FROM formulas where Activo = true and cod_transformacion IS NULL;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    Formula temp = new Formula();

                    temp.CodFormula = dr["id"].ToString();
                    temp.FormaFarm = dr["forma_farm"].ToString();
                    temp.NombreFormula = dr["nombre_formula"].ToString();
                    temp.Precauciones = dr["precauciones"].ToString();
                    temp.Cantidad = dr["cantidad_creada"].ToString();
                    temp.Transformacion = dr["cod_transformacion"].ToString();

                    formulas.Add(temp);

                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener listado de formulas " + ex.ToString());
            }


            return formulas;
        }

        public static bool isRepeatedFormula(string codigo)
        {
            cn = DBConnection.MainConnection();

            bool result = false;

            try
            {
                cmd = new OleDbCommand("SELECT * FROM formulas where id = '" + codigo + "';", cn);
                dr = cmd.ExecuteReader();




                if(dr.Read())
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al revisar formula repetida " + ex.ToString());
            }

            return result;
        }

        public static void editarFormula(Formula newFormula, string oldCodigo)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE formulas " +
                    "SET id = '" + newFormula.CodFormula + "' ,nombre_formula = '" + newFormula.NombreFormula + "', forma_farm = '" + newFormula.FormaFarm + "' " +
                    "WHERE id = " + oldCodigo + ";", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar Formula  " + ex);
            }
        }

        public static void deleteDetalle(string codigoMp, string codigoFormula)
        {
            cn = DBConnection.MainConnection();


            try
            {
                cmd = new OleDbCommand("DELETE FROM formula_detalle WHERE id = '" + codigoFormula + "' and mp_id = '" + codigoMp +"';", cn);
                cmd.ExecuteNonQuery();






                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al borrar detalle de formula " + ex.ToString());
            }
        }

        public static void agregarDetalle(DetalleFormula newDetalle, string codigoFormula)
        {
            cn = DBConnection.MainConnection();


            try
            {

                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO formula_detalle ([id],[mp_id],[cantidad_proporcion])" +
                        "VALUES (@id,@mp,@quantity)";


                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@id",codigoFormula),
                        new OleDbParameter("@mp",newDetalle.IdMp),
                        new OleDbParameter("@quantity",newDetalle.Quantity)
                    });


                    cmd.ExecuteNonQuery();
                }




                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al agregar detalle  " + ex);
            }
        }

        public static void agregarFormula(List<DetalleFormula> detalles, Formula newFormula)
        {
            bool temp = true;

            cn = DBConnection.MainConnection();
            try
            {

                using (OleDbCommand cmd = cn.CreateCommand())
                {


                    if(newFormula.Transformacion == "")
                    {
                        cmd.CommandText = @"INSERT INTO formulas ([id],[nombre_formula],[forma_farm],[precauciones],[cantidad_creada])" +
                        "VALUES (@id,@name,@form,@precaucion,@quantity)";
                    }
                    else
                    {
                        cmd.CommandText = @"INSERT INTO formulas ([id],[nombre_formula],[forma_farm],[precauciones],[cantidad_creada],[cod_transformacion])" +
                        "VALUES (@id,@name,@form,@precaucion,@quantity,@cod_transformacion)";
                    }
                    


                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@id",newFormula.CodFormula),
                        new OleDbParameter("@name",newFormula.NombreFormula),
                        new OleDbParameter("@form",newFormula.FormaFarm),
                        new OleDbParameter("@precaucion",newFormula.Precauciones),
                        new OleDbParameter("@quantity",newFormula.Cantidad),
                        new OleDbParameter("@cod_transformacion",newFormula.Transformacion),
                        //new OleDbParameter("@status",temp)
                    }) ;


                    cmd.ExecuteNonQuery();
                }



                foreach(var element in detalles)
                {
                    agregarDetalle(element, newFormula.CodFormula);
                }



                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear Formula  " + ex);
            }
        }

        public static void agregarProcedimiento(string instruction,int step, string codigoFormula)
        {
            cn = DBConnection.MainConnection();


            try
            {

                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO procedimiento_detalle ([id_formula],[numero_etapa],[procedimiento])" +
                        "VALUES (@id,@number,@info)";


                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@id",codigoFormula),
                        new OleDbParameter("@number",step),
                        new OleDbParameter("@info",instruction)
                    });


                    cmd.ExecuteNonQuery();
                }




                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al agregar Procedimiento  " + ex);
            }
        }

        public static void agregarProcedimientoEnPosicion(string instruction, int step, string codigoFormula)
        {
            cn = DBConnection.MainConnection();


            try
            {

                cmd = new OleDbCommand("UPDATE procedimiento_detalle SET numero_etapa = (numero_etapa + 1)  where id_formula = '" + codigoFormula + "' and numero_etapa >= " + step + ";", cn);
                cmd.ExecuteNonQuery();

                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO procedimiento_detalle ([id_formula],[numero_etapa],[procedimiento])" +
                        "VALUES (@id,@number,@info)";


                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@id",codigoFormula),
                        new OleDbParameter("@number",step),
                        new OleDbParameter("@info",instruction)
                    });


                    cmd.ExecuteNonQuery();
                }



                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al agregar procedimiento en posicion especifica " + ex);
            }
        }

        public static void deleteProcedimiento(string badStep, string codFormula)
        {
            cn = DBConnection.MainConnection();


            try
            {

                cmd = new OleDbCommand("DELETE FROM procedimiento_detalle WHERE id_formula = '" + codFormula + "' and numero_etapa = " + badStep + ";", cn);
                cmd.ExecuteNonQuery();

                cmd = new OleDbCommand("UPDATE procedimiento_detalle SET numero_etapa = (numero_etapa - 1)  where id_formula = '" + codFormula + "' and numero_etapa > " + badStep + ";",cn);
                cmd.ExecuteNonQuery();



                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al eliminar procedimiento  " + ex);
            }
        }


        public static void updateProcedimiento(ProcedimientoDetalle procedure, string codigo)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE procedimiento_detalle " +
                    "SET procedimiento = '" + procedure.Instruction + "' " +
                    "WHERE id_formula = '" + codigo + "'  and numero_etapa = " + procedure.Step + ";", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar Procedimiento Detalle  " + ex);
            }
        }

       /* public static void agregarProcedimientos(ProcedimientoDetalle procedure, string codigo)
        {
            
        }*/

        public static void updateDetalle(string codigo,string mp_id, string quantity)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE formula_detalle " +
                    "SET cantidad_proporcion = '" + quantity + "' " +
                    "WHERE id = '" + codigo + "'  and mp_id = '" + mp_id + "';", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar Formula Detalle  " + ex);
            }
        }

        public static void setActive(string codigo)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE formulas " +
                    "SET Activo = true " +
                    "WHERE id = '" + codigo + "';", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar Formula  " + ex);
            }
        }

        public static void setInactive(string codigo)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE formulas " +
                    "SET Activo = false " +
                    "WHERE id = '" + codigo + "';", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar Formula  " + ex);
            }

        }
    }
}
