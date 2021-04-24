using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using CifarInventario.Models;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Classes.Queries
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
                System.Windows.MessageBox.Show("Error al obtener usuarios " + ex);
            }


            return roles;
        }


        public static void SetNewUserInfo(int newRole, bool newStatus, string newUsername, int id)
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

        public static void CreateNewUser(int newRole, bool newStatus, string newUsername, string password, string salt)
        {
            cn = DBConnection.MainConnection();
            try
            {
                //cmd = new OleDbCommand("INSERT INTO usuarios (id_rol,status,usuario,password,salt) VALUES("+newRole+","+newStatus+",'"+newUsername+"','"+password+"','"+salt+"');", cn);

                //System.Windows.MessageBox.Show("INSERT INTO usuarios (id_rol,status,usuario,password,salt) VALUES(" + newRole + "," + newStatus + ",'" + newUsername + "','" + password + "','" + salt + "');");
                //cmd.ExecuteNonQuery();

                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO usuarios ([id_rol],[status],[usuario],[password],[salt])" +
                        "VALUES (@id_rol,@status,@usuario,@password,@salt)";


                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@id_rol",newRole),
                        new OleDbParameter("@status",newStatus),
                        new OleDbParameter("@usuario",newUsername),
                        new OleDbParameter("@password",password),
                        new OleDbParameter("@salt",salt)
                    });


                    cmd.ExecuteNonQuery();
                }




                    cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear Usuario  " + ex);
            }


            System.Windows.MessageBox.Show("Usuario creado con exito.");
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


            System.Windows.MessageBox.Show("Contraseña Actualizada con exito");
        }
    }
}
