using System;
using System.Collections.Generic;
using System.Data.OleDb;
using CifarInventario.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Classes.Queries
{
    class MenuQueries
    {

        static private OleDbConnection cn;
        static private OleDbDataReader dr;
        static private OleDbCommand cmd;


        public static List<Menu> getMenus(int roleId)
        {
            List<Menu> CurrentMenu = new List<Menu>();


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT DISTINCT menus.nombre_menu, menus.icon_string " +
                                        "FROM menus INNER JOIN (submenu INNER JOIN subMenuPermissions ON submenu.id = subMenuPermissions.id_submenu) ON menus.id = submenu.id_menu_padre " +
                                        "where subMenuPermissions.id_role = " + roleId + " and subMenuPermissions.activo = true;", cn);

                dr = cmd.ExecuteReader();

                

                


                while(dr.Read()){

                    Menu temp = new Menu();
                    temp.SubMenuList = new List<SubMenu>();
                    temp.MenuText = dr["nombre_menu"].ToString();
                    temp.MenuIcon = dr["icon_string"].ToString();

                    
                    CurrentMenu.Add(temp);

                    //System.Windows.MessageBox.Show("this is the name " + CurrentMenu[].MenuText);
                }


                foreach(var element in CurrentMenu)
                {
                    


                    cmd = new OleDbCommand("SELECT menus.nombre_menu, submenu.nombre_pagina, menus.icon_string, submenu.nombre_submenu, menus.id " +
                        "FROM menus INNER JOIN(submenu INNER JOIN subMenuPermissions ON submenu.id = subMenuPermissions.id_submenu) ON menus.id = submenu.id_menu_padre " +
                        "WHERE subMenuPermissions.id_role = "+ roleId + " and subMenuPermissions.activo = true and menus.nombre_menu = '" + element.MenuText +"';",cn);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        SubMenu subTemp = new SubMenu();


                        subTemp.SubMenuText = dr["nombre_submenu"].ToString();
                        subTemp.SubMenuPage = dr["nombre_pagina"].ToString();


                        element.SubMenuList.Add(subTemp);
                    }
                }

                dr.Close();
                cn.Close();

            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener los menus " + ex);
            }



            return CurrentMenu;
        }


        public static List<IdName> getSubmenus()
        {
            List<IdName> Submenus = new List<IdName>();


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT * from submenu;", cn);

                dr = cmd.ExecuteReader();






                while (dr.Read())
                {

                    IdName temp = new IdName();


                    temp.ID = dr["id"].ToString();
                    temp.Name = dr["nombre_submenu"].ToString();


                    Submenus.Add(temp);

                    //System.Windows.MessageBox.Show("this is the name " + CurrentMenu[].MenuText);
                }



                dr.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener los menus " + ex);
            }


            return Submenus;

        }

        public static List<SubMenuPermission> getSubMenusForRole(int rol)
        {
            List<SubMenuPermission> SubMenus = new List<SubMenuPermission>();


            

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT * FROM submenu INNER JOIN subMenuPermissions ON subMenuPermissions.id_submenu = submenu.id WHERE subMenuPermissions.id_role = " + rol + ";", cn);

                dr = cmd.ExecuteReader();






                while (dr.Read())
                {

                    SubMenuPermission temp = new();
                    
                    temp.IdSubMenu = int.Parse(dr["id_submenu"].ToString());
                    temp.NombreSubMenu = dr["nombre_submenu"].ToString();
                    temp.Estado = bool.Parse(dr["activo"].ToString());


                    SubMenus.Add(temp);

                    //System.Windows.MessageBox.Show("this is the name " + CurrentMenu[].MenuText);
                }



                dr.Close();
                cn.Close();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener los menus " + ex);
            }

            return SubMenus;
        }


        public static void agregarPermiso(int rolId, int submenuId)
        {
            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO subMenuPermissions ([id_role],[id_submenu],[activo]) " +
                    "values (@rol,@submenu,False) ";


                    cmd.Parameters.AddRange(new OleDbParameter[]
                        {
                        new OleDbParameter("@id",rolId),
                        new OleDbParameter("@submenuId",submenuId)
                        });

                    cmd.ExecuteNonQuery();

                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al agregar permiso al Rol.  " + ex);
            }
        }

        public static void iterateSubMenus(int rolId)
        {
            List<IdName> Menus = getSubmenus();


            foreach(var element in Menus)
            {
                agregarPermiso(rolId, int.Parse(element.ID));
            }
        }







        public static void cambiarEstadoPermiso(int rolId, int submenuId, bool Estado)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE subMenuPermissions " +
                    "SET activo = " + Estado +
                    " where id_role = " + rolId + " and id_submenu = " + submenuId+" ; ", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

                System.Windows.MessageBox.Show("Permiso de Menu Actualizado");

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al cambiar Estdo Permiso " + ex);
            }
        }
    }
}
