using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using CifarInventario.Models;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Classes.Queries
{
    public class ProductQueries
    {
        static private OleDbConnection cn;
        static private OleDbDataReader dr;
        static private OleDbCommand cmd;

        public static List<string> GetUnidades()
        {
            var unit = new List<string>();


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT * FROM Unidades;", cn);
                dr = cmd.ExecuteReader();


                


                while (dr.Read())
                {

                    unit.Add(dr["nombre"].ToString());

                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar las unidades " + ex.ToString());
            }




            return unit;
        }

        public static List<formulaProduct> GetFormulaProducts()
        {
            var mp = new List<formulaProduct>();


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT codigo,nombre_producto,unidad_metrica,conversion_unitaria from materia_prima WHERE codigo NOT LIKE 'ENV%'  AND codigo NOT LIKE 'ETI%' AND codigo NOT LIKE 'TP%';", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    formulaProduct temp = new formulaProduct();

                    temp.Codigo = dr["codigo"].ToString();
                    temp.Nombre = dr["nombre_producto"].ToString();
                    temp.Unidad = dr["unidad_metrica"].ToString();
                    temp.ConversionValue = double.Parse(dr["conversion_unitaria"].ToString());




                    mp.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar materia prima para formulas. " + ex.ToString());
            }




            return mp;
        }

        public static List<formulaProduct> GetAllMpSimplified()
        {
            var mp = new List<formulaProduct>();


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT codigo,nombre_producto,unidad_metrica,conversion_unitaria,unidad_muestra from materia_prima" +
                    " where codigo NOT LIKE 'ENV%' AND codigo NOT LIKE 'ETI%' AND codigo NOT LIKE 'TP%';", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    formulaProduct temp = new formulaProduct();

                    temp.Codigo = dr["codigo"].ToString();
                    temp.Nombre = dr["nombre_producto"].ToString();
                    temp.Unidad = dr["unidad_metrica"].ToString();
                    temp.ConversionValue = double.Parse(dr["conversion_unitaria"].ToString());
                    temp.UnidadMuestra = dr["unidad_muestra"].ToString();



                    mp.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar materia prima para formulas. " + ex.ToString());
            }

            return mp;
        }

        public static List<formulaProduct> GetAllContainersMP()
        {
            var mp = new List<formulaProduct>();


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT codigo,nombre_producto,unidad_metrica,conversion_unitaria,unidad_muestra from materia_prima" +
                    " WHERE (codigo LIKE 'ENV%' OR codigo LIKE 'ETI%' OR codigo LIKE 'TP%');", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    formulaProduct temp = new formulaProduct();

                    temp.Codigo = dr["codigo"].ToString();
                    temp.Nombre = dr["nombre_producto"].ToString();
                    temp.Unidad = "u";
                    temp.ConversionValue = 1;
                    temp.UnidadMuestra = "u";



                    mp.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar materia prima para formulas. " + ex.ToString());
            }




            return mp;
        }

        public static List<MpProduct> GetMP()
        {
            var mp = new List<MpProduct>();


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT * FROM materia_prima;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    MpProduct temp = new MpProduct();

                    temp.Id = dr["codigo"].ToString();
                    temp.Existencia = double.Parse(dr["existencia"].ToString());
                    temp.NombreProducto = dr["nombre_producto"].ToString();
                    //temp.Precio = float.Parse(dr["precio"].ToString());
                    temp.UnidadMetrica = dr["unidad_metrica"].ToString();
                    temp.UnidadMuestra = dr["unidad_muestra"].ToString();
                    temp.Entrada = double.Parse(dr["entrada"].ToString());
                    temp.Salida = double.Parse(dr["salida"].ToString());
                    temp.Conversion = double.Parse(dr["conversion_unitaria"].ToString());




                    mp.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar el inventario de materia prima " + ex.ToString());
            }




            return mp;
        }

        public static List<ProductoTeminadoParaLista> GetPTSimp()
        {
            var pt = new List<ProductoTeminadoParaLista>();

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT id_producto_terminado,nombre_producto_terminado,precio from inventario_producto_terminado;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    ProductoTeminadoParaLista temp = new ProductoTeminadoParaLista();

                    temp.CodPT = dr["id_producto_terminado"].ToString();
                    temp.NombrePT = dr["nombre_producto_terminado"].ToString();
                    temp.Precio = double.Parse(dr["precio"].ToString());



                    pt.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar productos terminados para lista. " + ex.ToString());
            }

            return pt;
        }

        public static List<PtProduct> getPTInventario()
        {
            var pt = new List<PtProduct>();

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT * from inventario_producto_terminado;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    PtProduct temp = new PtProduct();

                    temp.Id = dr["id_producto_terminado"].ToString();
                    temp.Nombre = dr["nombre_producto_terminado"].ToString();
                    temp.Existencia = int.Parse(dr["existencia"].ToString());
                    temp.Entrada = int.Parse(dr["entrada"].ToString());
                    temp.Salida = int.Parse(dr["salida"].ToString());
                    temp.Precio = double.Parse(dr["precio"].ToString());



                    pt.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar invntario de producto terminado. " + ex.ToString());
            }

            return pt;
        }


        public static void updateInventarioProductoTerminadoInfo(PtProduct pt)
        {

        }

       /* public static void updateInvMpBaseUnit(string codMP, double conversion, string newBaseUunit)
        {

        }

        public static void updateInvMpDisplayUnit(string codMp, double conversion, string newDisplayUnit)
        {th

        }*/


        public static void removeFlatAmounts(string codMP, double formUnitAmount, double displayUnitAmountCurrent, double displayUnitAmountOriginal)
        {
            var salida = displayUnitAmountOriginal - displayUnitAmountCurrent;
            cn = DBConnection.MainConnection();
            try
            {



                cmd = new OleDbCommand("UPDATE materia_prima " +
                    "SET entrada = (entrada - " + displayUnitAmountOriginal + "), existencia = (existencia - " + displayUnitAmountCurrent + "), cantidad_exacta = (cantidad_exacta - "+formUnitAmount+" ), salida = (salida - " + salida + " )  " +
                    "where codigo = '" + codMP + "'; ", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al borar existencia the MP  " + ex);
            }

            System.Windows.MessageBox.Show(salida.ToString());
        }

        public static void reAddAmount(string codMP, double newEntrada, double newCurrent, double formAmount)
        {
            var test = newEntrada - newCurrent;
            cn = DBConnection.MainConnection();
            try
            {



                cmd = new OleDbCommand("UPDATE materia_prima " +
                    "SET entrada = (entrada + " + newEntrada + "), existencia = (existencia + " + newCurrent + "), cantidad_exacta = (cantidad_exacta + " + formAmount + "), salida = (salida + "+test  +  ")  "  +
                    "where codigo = '" + codMP + "'; ", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al reingresar existencia the MP  " + ex);
            }
        }       

        public static void updateMateriaPrimaInfo(MpProduct mp)
        {
            cn = DBConnection.MainConnection();
            try
            {
               


                cmd = new OleDbCommand("UPDATE materia_prima " +
                    "SET codigo = '" + mp.Id + "', nombre_producto = '" + mp.NombreProducto + "', unidad_metrica = '" + mp.UnidadMetrica + "', conversion_unitaria = " + mp.Conversion + ", unidad_muestra = '" + mp.UnidadMuestra + "'  "  +
                    "where codigo = '" + mp.Id + "'; ", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar informacion the MP  " + ex);
            }
        }


       /* public static void updateProductAmount(string codMP, double amountChange)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE materia_prima " +
                    "SET entrada = (entrada + " + amountChange + "), existencia = (existencia + " + amountChange + "), cantidad_exacta = (cantidad_exacta + (" + amountChange + " * conversion_unitaria) ) " +
                    "where codigo = '" + codMP + "'; ", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar existencia the MP  " + ex);
            }
        }*/

        public static void updateProductAmountAdd(string codMP, double amountChange)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE materia_prima " +
                    "SET entrada = (entrada + " + amountChange + "), existencia = (existencia + " + amountChange + "), cantidad_exacta = (cantidad_exacta + (" + amountChange + " * conversion_unitaria) ) " +
                    "where codigo = '" + codMP + "'; ", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar existencia the MP  " + ex);
            }
        }

        public static void updateProductAmountRemove(string codMP, double amountChange)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE materia_prima " +
                    "SET salida = (salida + " + amountChange + "), existencia = (existencia + " + amountChange + "), cantidad_exacta = (cantidad_exacta + (" + amountChange + " * conversion_unitaria) ) " +
                    "where codigo = '" + codMP + "'; ", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar existencia the MP  " + ex);
            }
        }

        public static void updateProductAmountFromExactRemove(string codMP, double amountChangeExact)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE materia_prima " +
                    "SET salida = (salida + (" + amountChangeExact + " / conversion_unitaria )), existencia = (existencia + (" + amountChangeExact + " / conversion_unitaria )), cantidad_exacta = (cantidad_exacta + " + amountChangeExact + " ) " +
                    "where codigo = '" + codMP + "'; ", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar existencia the MP Exact - " + ex);
            }
        }

        public static void updateProductAmountFromtExactAdd(string codMP, double amountChangeExact)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE materia_prima " +
                    "SET entrada = (entrada + (" + amountChangeExact + " / conversion_unitaria )), existencia = (existencia + (" + amountChangeExact + " / conversion_unitaria )), cantidad_exacta = (cantidad_exacta + " + amountChangeExact + " ) " +
                    "where codigo = '" + codMP + "'; ", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar existencia the MP exact + " + ex);
            }
        }

       /* public static void updateProductAmountFromExact(string codMp, double amountChangeExact)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE materia_prima " +
                    "SET salida = (salida - (" + amountChangeExact + " / conversion_unitaria )), existencia = (existencia + (" + amountChangeExact + " / conversion_unitaria )), cantidad_exacta = (cantidad_exacta + " + amountChangeExact + " ) " +
                    "where codigo = '" + codMp + "'; ", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar existencia the MP  " + ex);
            }
        }*/

        public static void updateProductoTerminadoAmount(string codPT, int amountChanged)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE producto_terminado " +
                    "SET existencia =  (existencia + " + amountChanged + " ) " +
                    "where cod_pt = '" + codPT + "'; ", cn);
                cmd.ExecuteNonQuery();

                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar existencia the producto Terminado  " + ex);
            }
        }

        public static void CreateMateriaPrima(MpProduct mp)
        {
            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO materia_prima ([codigo],[unidad_metrica],[nombre_producto],[conversion_unitaria],[unidad_muestra]) " +
                        "VALUES (@codProd,@uniMetrica,@nombre,@conversion,@uniMuestra) ";

                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@codProd",mp.Id),
                        new OleDbParameter("@uniMetrica",mp.UnidadMetrica),
                        new OleDbParameter("@nombre",mp.NombreProducto),
                        new OleDbParameter("@conversion",mp.Conversion),
                        new OleDbParameter("@uniMuestra",mp.UnidadMuestra)
                    });

                    cmd.ExecuteNonQuery();

                }

                cn.Close();



            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear Entrada de Producto Terminado en el Inventario " + ex);
            }
        }

        public static void CreateProductoTerminado(LotePackage lote, double cantidad)
        {
            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO producto_terminado ([cod_pt],[id_lote],[existencia],[fecha_vencimiento]) " +
                        "VALUES (@codPt,@idPt,@existencia,@fecha) ";

                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@codPt",lote.CodPT),
                        new OleDbParameter("@idPT",lote.IdLote),
                        new OleDbParameter("@existencia",lote.Existencia),
                        new OleDbParameter("@fecha",lote.FechaVencimiento),
                    });

                    cmd.ExecuteNonQuery();



                }

                cn.Close();

                InventoryQueries.updateLoteSalidaAmount(cantidad, lote.IdLote);
                InventarioPTAddAmount(lote.CodPT, lote.Existencia);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al empacar producto  " + ex);
            }
        }

        public static void CreateProductoTerminadoDetalle(LotePackageDetalle lote, string codMP)
        {
            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO detalle_pt_lote ([cod_lote_salida],[cod_prod_terminado],[cantidad],[cod_lote_mp_empaque]) " +
                        "VALUES (@codSalida,@codPT,@cantidad,@codLoteEnt) ";

                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@codSalida",lote.CodLoteSalida),
                        new OleDbParameter("@codPT",lote.CodPT),
                        new OleDbParameter("@cantidad",lote.Cantidad),
                        new OleDbParameter("@codLoteEnt",lote.CodLoteEntrada)
                    });

                    cmd.ExecuteNonQuery();


                }

                cn.Close();

                InventoryQueries.updateLoteEntradaAmount(lote.CodLoteEntrada, -lote.Cantidad, codMP);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear Detalle Lote Salida  " + ex);
            }
        }

        public static void CreateInventarioProductoTerminado(PtProduct newProduct)
        {
            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO inventario_producto_terminado ([id_producto],[nombre_producto],[precio]) " +
                        "VALUES (@idProducto,@nombreProduct,@precio) ";

                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@idProducto",newProduct.Id),
                        new OleDbParameter("@nombreProduct",newProduct.Nombre),
                        new OleDbParameter("@precio",newProduct.Precio),
                    });

                    cmd.ExecuteNonQuery();

                }

                cn.Close();



            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear Entrada de Producto Terminado en el Inventario " + ex);
            }
        }

        public static void InventarioPTAddAmount(string codPT, int Amount)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE inventario_producto_terminado " +
                    "SET existencia =  (existencia + " + Amount + " ), entrada = (entrada + " + Amount + ") " +
                    "where cod_pt = '" + codPT + "'; ", cn);
                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar Existencia +  " + ex);
            }
        }

        public static void InventarioPTRemoveAmount(string codPT, int Amount)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE producto_terminado " +
                    "SET existencia =  (existencia - " + Amount + " ), salida = (salida - " + Amount + ") " +
                    "where cod_pt = '" + codPT + "'; ", cn);
                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar Existencia - " + ex);
            }
        }


        public static bool isRepeatedPtCode(string codPt)
        {
            var isDuplicate = false;

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT * FROM inventario_producto_terminado where id_producto_terminado = '" + codPt + "';", cn);
                dr = cmd.ExecuteReader();




                if (dr.Read())
                {
                    isDuplicate = true;
                }
                else
                {
                    isDuplicate = false;
                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al verificar codigo Producto Terminado duplicada. " + ex.ToString());
            }

            return isDuplicate;
        }

        public static bool isRepeatedMpCode(string CodMp)
        {
            var isDuplicate = false;

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT * FROM materia_prima where codigo = '" + CodMp + "';", cn);
                dr = cmd.ExecuteReader();




                if (dr.Read())
                {
                    isDuplicate = true;
                }
                else
                {
                    isDuplicate = false;
                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al verificar codigo Materia Prima duplicada. " + ex.ToString());
            }

            return isDuplicate;
        }

        public static List<string> getLotesFromtProduct(string codProduct, int cantidad)
        {
            var lotes = new List<string>();
            string temp;


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT id_lote FROM producto_terminado where cod_pt = '" + codProduct + "' and existencia >= " + cantidad + ";", cn);
                dr = cmd.ExecuteReader();



                if (dr.HasRows)
                {



                    while (dr.Read())
                    {

                        temp = dr["id_lote"].ToString();

                        //System.Windows.MessageBox.Show("this is temp " + temp);

                        lotes.Add(temp);

                    }
                }
                else
                {
                    //System.Windows.MessageBox.Show("N/A");
                    lotes.Add("N/A");
                }



                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar lotes de producto terminado " + ex.ToString());
            }




            return lotes;
        }


    }
}
