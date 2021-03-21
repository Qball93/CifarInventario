using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using CifarInventario.Models;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Classes
{
    class UserQueries
    {
        static private OleDbConnection cn;
        static private OleDbDataReader dr;
        static private OleDbCommand cmd;


        public static List<User> GetUsers()
        {

            var users = new List<User>();



            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("SELECT * FROM usuarios inner join roles ON usuarios.id_rol = roles.id", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    User tempUser = new User();
                    Role tempRole = new Role();

                    tempUser.UserName = dr["usuario"].ToString();
                    tempRole.Id = int.Parse(dr["roles.id"].ToString());
                    tempRole.RoleName = dr["nombre"].ToString();
                    tempUser.Status = Convert.ToBoolean(dr["status"]);
                    tempUser.id = int.Parse(dr["usuarios.id"].ToString());

                    tempUser.UserRole = tempRole;


                    users.Add(tempUser);

                    
                }

                dr.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener usuarios  " + ex);
            }

            return users;
        }

        public static List<Role> GetRoles()
        {
            var roles = new List<Role>();

            cmd = new OleDbCommand("SELECT * FROM usuarios inner join roles ON usuarios.id_rol = roles.id", cn);
            dr = cmd.ExecuteReader();


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


                    roles.Add(tempRole);

                }

                dr.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener usuarios  " + ex);
            }


            return roles;
        }


        public static void SetNewUserInfo(string newRole, bool newStatus, string newUsername, int id)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE usuarios " +
                    "SET id_rol = " + newRole + " ,status = " + newStatus + ", usuario = '" + newUsername +"' "+
                    "WHERE id = " + id + ";", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar Usuario  " + ex);
            }
        }

        public static void SetNewUserPassword(string password, string salt, int id)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE usuarios " +
                    "SET password = '"+password+"',salt = '"+salt+"'" +
                    "WHERE id = "+id+";"   , cn);
                cmd.ExecuteNonQuery();





                
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar Usuario  " + ex);
            }
        }
    }
}
