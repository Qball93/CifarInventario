using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace CifarInventario.ViewModels.Classes
{
    static class DBConnection
    {
        static private OleDbConnection cn;

        public static OleDbConnection MainConnection()
        {
            try
            {
                 cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\mauri\OneDrive\Documents\CifarDb1.accdb;Persist Security Info=False;");
                //cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\DESKTOP-S5JPIIR\Users\Cifar\Documents\baseacc\CifarDb1.accdb;Persist Security Info=False;");

                cn.Open();

            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("oops" + ex);
            }
            return cn;
        }



    }
}
