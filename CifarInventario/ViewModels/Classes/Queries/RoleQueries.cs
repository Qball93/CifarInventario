using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using CifarInventario.Models;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Classes.Queries
{
    class RoleQueries
    {
        
        static private OleDbConnection cn;
        static private OleDbDataReader dr;
        static private OleDbCommand cmd;

        public static List<Role> GetRoles()
        {
            var roles = new List<Role>();
            cn = DBConnection.MainConnection();


            try
            {
                cmd = new OleDbCommand("SELECT * FROM roles", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {


                    Role tempRole = new Role();

                    tempRole.RoleName = dr["nombre"].ToString();
                    tempRole.Id = int.Parse(dr["id"].ToString());
                    tempRole.Estado = bool.Parse(dr["estado"].ToString());


                    roles.Add(tempRole);

                }

                dr.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener usuarios " + ex);
            }


            return roles;
        }


        public static void CreateRole(string name)
        {
            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO roles ([nombre]) " +
                    "values (@nombre) ";


                    cmd.Parameters.AddRange(new OleDbParameter[]
                        {
                        new OleDbParameter("@id",name),
                        });

                    cmd.ExecuteNonQuery();

                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear el rol.  " + ex);
            }
        }

        public static void EditName(Role newRole)
        {
            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE roles " +
                    "set nombre = @nombre" +
                    "where id = @id;";


                    cmd.Parameters.AddRange(new OleDbParameter[]
                        {
                        new OleDbParameter("@pregunta",newRole.RoleName),
                        new OleDbParameter("@id",newRole.Id)
                        });

                    cmd.ExecuteNonQuery();

                    cn.Close();

                }



            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar el rol.  " + ex);
            }
        }

        public static void SetActive(int id)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE roles " +
                    "SET estado = true " +
                    "where id = '" + id + "'; ", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al activar el rol " + ex);
            }
        }

        public static void SetInactive(int id)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE roles " +
                    "SET estado = false " +
                    "where id = '" + id + "'; ", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al desactivar el rol " + ex);
            }
        }
    }
}
