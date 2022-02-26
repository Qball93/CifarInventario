using System;
using System.Collections.Generic;
using System.Linq;
using CifarInventario.Models;
using CifarInventario.ViewModels.Classes;
using System.Text;
using CifarInventario.ViewModels.Classes.Queries;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels
{
    public class NavigationMenuVM
    {

        
        /*public List<Menu> MenuList
        {
            get
            {
                return new List<Menu>
                {
                    new Menu() {MenuText = "Usuarios",
                        SubMenuList = new List<SubMenu>{
                        new SubMenu(){ SubMenuText = "Control de Usuarios" }
                        }
                    },
                    new Menu() { MenuText = "Facturacion",
                        SubMenuList = new List<SubMenu>{
                            new SubMenu(){ SubMenuText = "Proveedores" },
                            new SubMenu(){ SubMenuText = "Clientes" }
                        } 
                    }
                };
   
            }
        }

        /*public List<MenuItemsData> MenuList
        {
            get
            {
                return new List<MenuItemsData>
                {
                    new MenuItemsData() {MenuText = "Usuarios",
                        SubMenuList = new List<SubMenuItemsData>{
                        new SubMenuItemsData(){ SubMenuText = "Control de Usuarios" }
                        }
                    },
                    new MenuItemsData() { MenuText = "Facturacion",
                        SubMenuList = new List<SubMenuItemsData>{
                            new SubMenuItemsData(){ SubMenuText = "Proveedores" },
                            new SubMenuItemsData(){ SubMenuText = "Clientes" }
                        }
                    }
                };

            }
        }*/

        public List<Menu> MenuList
        {
            get
            {
                return MenuQueries.getMenus(Globals.getId());
            }
        }






    }

    /*public class MenuItemsData
    {
        //public PathGeometry PathData { get; set; }
        public string MenuText { get; set; }
        public List<SubMenuItemsData> SubMenuList { get; set; }
    }

    public class SubMenuItemsData
    {
        //public PathGeometry PathData { get; set; }
        public string SubMenuText { get; set; }
    }*/

    
}
