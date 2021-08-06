using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using CifarInventario.Models;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Classes.Queries
{
    class PersonaQueries
    {
        static private OleDbConnection cn;
        static private OleDbDataReader dr;
        static private OleDbCommand cmd;

        public static List<Empleado> GetEmpleados()
        {
            var empleados = new List<Empleado>();

            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("SELECT * FROM empleados;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    Empleado temp = new Empleado();

                    temp.Id = int.Parse(dr["id"].ToString());
                    temp.Nombre = dr["nombre"].ToString();
                    temp.Apellido = dr["apellido"].ToString();
                    temp.Telefono = dr["telefono"].ToString();
                    temp.Correo = dr["correo"].ToString();


                    empleados.Add(temp);


                }

                dr.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener empleados  " + ex);
            }


            return empleados;

        }

        public static List<EntidadCommercial> GetEntity(string type)
        {
            var entidades = new List<EntidadCommercial>();

            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("SELECT * FROM "+type+";", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    EntidadCommercial temp = new EntidadCommercial();

                    temp.Id = int.Parse(dr["id"].ToString());
                    temp.NombreCommercial = (dr["nombre_commercial"].ToString() == "" ? "N/A" : dr["nombre_commercial"].ToString());
                    temp.NombreContacto = (dr["nombre_contacto"].ToString() == "" ? "N/A" : dr["nombre_contacto"].ToString());
                    temp.Direccion = (dr["direccion"].ToString() == "" ? "N/A" : dr["direccion"].ToString());
                    temp.Telefono = (dr["telefono"].ToString() == "" ? "N/A" : dr["telefono"].ToString());
                    temp.CorreoContacto = (dr["correo_contacto"].ToString() == "" ? "N/A" : dr["correo_contacto"].ToString());
                    temp.Commentario = (dr["commentario"].ToString() == "" ? "N/A" : dr["commentario"].ToString());
                    temp.RTN = (dr["RTN"].ToString() == "" ? "N/A" : dr["RTN"].ToString());


                    entidades.Add(temp);


                }

                dr.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener entidades commerciales  " + ex);
            }


            return entidades;
        }

        public static void CreateEmpleado(Empleado newEmployee)
        {
            cn = DBConnection.MainConnection();
            try
            {

                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO empleados ([nombre],[apellido],[telefono],[correo])" +
                        "VALUES (@name,@apelldio,@telefono,@correo)";


                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@name",newEmployee.Nombre),
                        new OleDbParameter("@status",newEmployee.Apellido),
                        new OleDbParameter("@telefono",newEmployee.Telefono),
                        new OleDbParameter("@correo",newEmployee.Correo)
                    });


                    cmd.ExecuteNonQuery();
                }




                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear Empleado  " + ex);
            }


            System.Windows.MessageBox.Show("Empleado creado con exito.");
        }

        public static void CreateEntidad(EntidadCommercial newEntity,string type)
        {
            cn = DBConnection.MainConnection();
            try
            {

                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO "+type+" ([nombre_commercial],[nombre_contacto],[direccion],[telefono],[correo_contacto],[commentario],[RTN])" +
                        "VALUES (@name,@contacto,@direccion,@telefono,@correo,@comment,@rtn)";


                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@name",newEntity.NombreCommercial),
                        new OleDbParameter("@contacto",newEntity.NombreContacto),
                        new OleDbParameter("@direccion",newEntity.Direccion),
                        new OleDbParameter("@telefono",newEntity.Telefono),
                        new OleDbParameter("@correo",newEntity.CorreoContacto),
                        new OleDbParameter("@comment",newEntity.Commentario),
                        new OleDbParameter("@rtn",newEntity.RTN)
                    });


                    cmd.ExecuteNonQuery();
                }




                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear " + type + "  " + ex);
            }



            System.Windows.MessageBox.Show(" "+type+" creado con exito.");

        }

        public static void updateEntidad(EntidadCommercial entidad, string type)
        {
            cn = DBConnection.MainConnection();


            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE @tipo " +
                        "SET nombre_commercial = @name, nombre_contacto = @contact, direccion = @direccion, correo_contacto = @correo, commentario = @commentario " +
                        ",RTN = @rtn, telefono = @telefono  WHERE id = @id";


                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@name",entidad.NombreCommercial),
                        new OleDbParameter("@commentario",entidad.Commentario),
                        new OleDbParameter("@contact",entidad.NombreContacto),
                        new OleDbParameter("@correo",entidad.CorreoContacto),
                        new OleDbParameter("@tipo",type),
                        new OleDbParameter("@direccion",entidad.Direccion),
                        new OleDbParameter("@telefono",entidad.Telefono),
                        new OleDbParameter("@rtn",entidad.RTN),
                        new OleDbParameter("@id",entidad.Id)
                    });


                    cmd.ExecuteNonQuery();
                }

                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar "+type+"  " + ex);
            }
        }

        public static void updateEmpleado(Empleado newEmployee)
        {
            cn = DBConnection.MainConnection();


            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE empleados "+
                        "SET nombre = @name, apellido = @apellido, telefono = @telefono, correo = @correo  WHERE id = @id";


                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@name",newEmployee.Nombre),
                        new OleDbParameter("@apellido",newEmployee.Apellido),
                        new OleDbParameter("@correo",newEmployee.Correo),
                        new OleDbParameter("@telefono",newEmployee.Telefono),
                        new OleDbParameter("@id",newEmployee.Id)
                    });


                    cmd.ExecuteNonQuery();
                }

                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar Empleado  " + ex);
            }
        }

        public static List<DisplayProveedor> GetDisplayProveedores()
        {
            var entidades = new List<DisplayProveedor>();

            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("SELECT * FROM proveedor;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    DisplayProveedor temp = new DisplayProveedor();

                    temp.Id = int.Parse(dr["id"].ToString());
                    temp.NombreProveedor = (dr["nombre_commercial"].ToString() == "" ? "N/A" : dr["nombre_commercial"].ToString());
                    //temp.NombreContacto = (dr["nombre_contacto"].ToString() == "" ? "N/A" : dr["nombre_contacto"].ToString());


                    entidades.Add(temp);


                }

                dr.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener entidades commerciales  " + ex);
            }


            return entidades;
        }


        public static List<IdName> getClientes()
        {
            var entidades = new List<IdName>();

            cn = DBConnection.MainConnection();
            try
            {




                cmd = new OleDbCommand("SELECT nombre_commercial, id FROM clientes;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    IdName temp = new IdName();


                    temp.ID = dr["id"].ToString();
                    temp.Name = dr["nombre_commercial"].ToString();






                    entidades.Add(temp);


                }

                dr.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener entidades commerciales  " + ex);
            }


            return entidades;
        }

    }
}
