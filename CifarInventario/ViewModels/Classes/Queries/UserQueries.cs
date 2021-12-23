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
                cmd = new OleDbCommand("SELECT * FROM (usuarios INNER JOIN roles ON usuarios.id_rol = roles.id)" +
                    "INNER JOIN empleados on empleados.id = usuarios.id_empleado", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    User tempUser = new User();
                    Role tempRole = new Role();
                    IdName empleado = new IdName();

                    tempUser.UserName = dr["usuario"].ToString();
                    tempRole.Id = int.Parse(dr["roles.id"].ToString());
                    tempRole.RoleName = dr["roles.nombre"].ToString();
                    tempUser.Status = Convert.ToBoolean(dr["status"]);
                    tempUser.id = int.Parse(dr["usuarios.id"].ToString());
                    empleado.ID = dr["id_empleado"].ToString();
                    empleado.Name = dr["empleados.nombre"].ToString();


                    tempUser.UserRole = tempRole;
                    tempUser.Empleado = empleado;


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


        public static void SetNewUserInfo(int newRole, bool newStatus, string newUsername, int id, int NewEmp)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE usuarios " +
                    "SET id_rol = " + newRole + " ,status = " + newStatus + ", usuario = '" + newUsername +"', id_empleado = "+ NewEmp +
                    " WHERE id = " + id + ";", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar Usuario  " + ex);
            }
        }

        public static void CreateNewUser(int newRole, bool newStatus, string newUsername, string password, string salt, int UserID)
        {

            int ID = 0;
            cn = DBConnection.MainConnection();
            try
            {

                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO usuarios ([id_rol],status,[usuario],[password],[salt],[id_empleado])" +
                        "VALUES (@id_rol,@status,@usuario,@password,@salt,@empleado)";


                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@id_rol",newRole),
                        new OleDbParameter("@status", OleDbType.Boolean) {Value = newStatus },
                        new OleDbParameter("@usuario",newUsername),
                        new OleDbParameter("@password",password),
                        new OleDbParameter("@salt",salt),
                        new OleDbParameter("@empleado",UserID)
                    });

                   // cmd.Parameters[1].Value = newStatus;

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "Select @@Identity";
                    ID = (int)cmd.ExecuteScalar();
                    createPregunta(ID);
                }



                    
                    cn.Close();


            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear Usuario  " + ex);
            }


            System.Windows.MessageBox.Show("Usuario creado con exito.");
        }

        public static void AsignarEmpleadoAUsuario() { }

        public static int GetUserId(string userName)
        {
            int  temp = 0;

            cn = DBConnection.MainConnection();
            try
            {


                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"select * from usuarios " +
                    "WHERE usuario = @UserName";

                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@UserName",userName)
                    });

                    dr = cmd.ExecuteReader();


                    if (dr.Read())
                    {
                        temp = int.Parse(dr["id_rol"].ToString());
                    }

                    dr.Close();
                    cn.Close();

                }




            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al conseguir id de usuario.  " + ex);
            }




            return temp;
        }

        public static Preguntas getPregunta(string userName)
        {
            Preguntas temp = new Preguntas();

            cn = DBConnection.MainConnection();
            try
            {


                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"select Preguntas.pregunta, Preguntas.respuesta, Preguntas.salt, Preguntas.Id_Usuario from Preguntas " +
                    "INNER JOIN usuarios on usuarios.id = Preguntas.Id_Usuario " +
                    "WHERE usuarios.usuario = @UserName";

                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@UserName",userName)
                    });

                    dr = cmd.ExecuteReader();


                    if (dr.Read())
                    {
                        temp.Pregunta = dr["pregunta"].ToString();
                        temp.Salt = dr["salt"].ToString();
                        temp.Respuesta = dr["respuesta"].ToString();
                        temp.UserId = int.Parse(dr["Id_Usuario"].ToString());
                    }
                    else
                    {
                        temp.Pregunta = @"'N/A'";
                    }

                    dr.Close();
                    cn.Close();

                }
                



            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al conseguir pregunta recuperacion.  " + ex);
            }




            return temp;
        }

        public static void updatePregunta(Preguntas pregunta)
        {

            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Preguntas " +
                    "set pregunta = @pregunta, respuesta = @respuesta, salt = @salt " +
                    "where Id_Usuario = @id;";


                    cmd.Parameters.AddRange(new OleDbParameter[]
                        {
                        new OleDbParameter("@pregunta",pregunta.Pregunta),
                        new OleDbParameter("@respuesta",pregunta.Respuesta),
                        new OleDbParameter("@salt",pregunta.Salt),
                        new OleDbParameter("@id",pregunta.UserId)
                        });

                    cmd.ExecuteNonQuery();

                    cn.Close();

                }



            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al conseguir pregunta recuperacion.  " + ex);
            }

        }

        public static void createPregunta(int userID)
        {
            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Preguntas ([Id_Usuario],[pregunta],[respuesta],[salt]) " +
                    "values (@id,@pregunta,@respuesta,@salt) ";
                    

                    cmd.Parameters.AddRange(new OleDbParameter[]
                        {
                        new OleDbParameter("@id",userID),
                        new OleDbParameter("@pregunta","Este usuario no tiene pregunta asignada"),
                        new OleDbParameter("@respuesta","ASFWE21QZXQCA123@#!@"),
                        new OleDbParameter("@salt","ASFWE21QZXQCA123@#!@")
                        });

                    cmd.ExecuteNonQuery();

                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear pregunta recuperacion.  " + ex);
            }
        }

        public static Preguntas getPreguntaCompleta(int id)
        {
            Preguntas temp = new Preguntas();

            

            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("select * from Preguntas " +
                    "WHERE Preguntas.Id_Usuario = @ID;", cn);


                cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@ID",id)
                    });

                dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    temp.UserId = id;
                    temp.Pregunta = dr["pregunta"].ToString();
                    temp.Salt = dr["salt"].ToString();
                    temp.Respuesta = dr["respusta"].ToString();
                }
                dr.Close();
                cn.Close();



            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al conseguir pregunta recuperacion.  " + ex);
            }



            return temp;
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
