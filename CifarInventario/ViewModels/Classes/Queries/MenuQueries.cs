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

                //cn.Close();
                /*while (dr.Read())
                {
                    SubMenu subTemp = new SubMenu();


                    if(temp.MenuText == dr["nombre_menu"].ToString())
                    {
                        subTemp.SubMenuText = dr["nombre_submenu"].ToString();

                        temp.SubMenuList.Add(subTemp);
                    }
                    else
                    {
                        if(temp != null)
                        {
                            CurrentMenu.Add(temp);
                        }

                        temp.MenuText = dr["nombre_menu"].ToString();
                        temp.MenuIcon = dr["icon_string"].ToString();
                        subTemp.SubMenuText = dr["nombre_submenu"].ToString();

                        temp.SubMenuList.Add(subTemp);

                    }

                }*/


                //CurrentMenu.Add(temp);

                dr.Close();
                cn.Close();

            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener los menus " + ex);
            }



            //System.Windows.MessageBox.Show(CurrentMenu[3].SubMenuList[0].SubMenuText);




            return CurrentMenu;
        }
    }
}
