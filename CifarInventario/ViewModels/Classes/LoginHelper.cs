using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using CifarInventario.Models;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Classes
{
    public class LoginHelper
    {
        static private OleDbConnection cn;
        static private OleDbDataReader dr;
        static private OleDbCommand cmd;


        public static User GetLoginUser(string Username)
        {
            User loginUser = new User();
            Role userRole = new Role();
            IdName empl = new IdName();


            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("SELECT usuarios.id, usuarios.id_rol, usuarios.salt, usuarios.password, roles.nombre, id_empleado " +
                    "FROM usuarios INNER JOIN roles ON usuarios.id_rol = roles.id " +
                    "WHERE usuarios.usuario = '" + Username + "' ", cn);
                dr = cmd.ExecuteReader();

                



                while (dr.Read())
                {
                    loginUser.salt = dr["salt"].ToString();
                    loginUser.Password = dr["password"].ToString();
                    userRole.Id = int.Parse(dr["id_rol"].ToString());
                    userRole.RoleName = dr["nombre"].ToString();
                    empl.ID = dr["id_empleado"].ToString();
                }


                loginUser.UserRole = userRole;
                loginUser.Empleado = empl;

                dr.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error en login de usuario " + ex);
            }

            //var security = (sal:salt, pass: password);

            return loginUser;

        }


    }
}
