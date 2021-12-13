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

        public static List<formulaProduct> GetAllContainerMPFromAmount(int amount)
        {
            var mp = new List<formulaProduct>();


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT codigo,nombre_producto,unidad_metrica,conversion_unitaria,unidad_muestra,existencia from materia_prima" +
                    " WHERE (codigo LIKE 'ENV%' OR codigo LIKE 'ETI%' OR codigo LIKE 'TP%') and existencia >= " + amount +"  ;", cn);
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
                cmd = new OleDbCommand("SELECT id_producto_terminado,nombre_producto,precio from inventario_producto_terminado;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    ProductoTeminadoParaLista temp = new ProductoTeminadoParaLista();

                    temp.CodPT = dr["id_producto_terminado"].ToString();
                    temp.NombrePT = dr["nombre_producto"].ToString();
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


        public static void updateInventarioProductoTerminadoInfo(PtProduct pt, string oldId)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE inventario_producto_terminado " +
                    "SET id_producto_terminado = '" +pt.Id+"',nombre_producto_terminado = '" +pt.Nombre+"', precio = " + pt.Precio +
                    " where id_producto_terminado = '" + oldId + "'; ", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar informacion de PT  " + ex);
            }
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

        public static void updateMateriaPrimaInfo(MpProduct mp, string oldId)
        {
            cn = DBConnection.MainConnection();
            try
            {
               


                cmd = new OleDbCommand("UPDATE materia_prima " +
                    "SET codigo = '" + mp.Id + "', nombre_producto = '" + mp.NombreProducto + "', unidad_metrica = '" + mp.UnidadMetrica + "', conversion_unitaria = " + mp.Conversion + ", unidad_muestra = '" + mp.UnidadMuestra + "'  "  +
                    "where codigo = '" + oldId + "'; ", cn);
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

        public static void updateProductoTerminadoAmount(string codPT, int amountChanged, string idLote)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE producto_terminado " +
                    "SET existencia =  (existencia + " + amountChanged + " ) " +
                    "where cod_pt = '" + codPT + "'  and id_lote = '" + idLote  + "'  ; ", cn);
                cmd.ExecuteNonQuery();

                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar existencia the producto Terminado  " + ex);
            }
        }

        public static void updateProductoTerminadoAddAmount(string codPT, int amountChanged, string idLote)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE producto_terminado " +
                    "SET existencia =  (existencia + " + amountChanged + " ) , entrada = (entrada + " + amountChanged + " ) " +
                    "where cod_pt = '" + codPT + "'  and id_lote = '" + idLote + "'  ; ", cn);
                cmd.ExecuteNonQuery();

                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar existencia the producto Terminado  " + ex);
            }
        }

        public static void updateProductoTermnadoRemoveAmount(string codPT, int amountChanged, string idLote)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE producto_terminado " +
                    "SET existencia =  (existencia + " + amountChanged + " ) , salida = (salida + " + amountChanged + " ) " +
                    "where cod_pt = '" + codPT + "'  and id_lote = '" + idLote + "'  ; ", cn);
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

        public static void CreateProductoTerminado(LotePT lote, double cantidad)
        {
            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO lotes_producto_terminado ([cod_pt],[id_lote],[existencia],[Codigo_Correlativo],[cantidad_original]) " +
                        "VALUES (@codPt,@idPt,@existencia,@fecha,@cantidad_original) ";

                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@codPt",lote.CodigoPT),
                        new OleDbParameter("@idPT",lote.CodigoLoteSalida),
                        new OleDbParameter("@existencia",lote.CantidadOriginal),
                        new OleDbParameter("@fecha",lote.CodigoCorrelativo),
                        new OleDbParameter("@cantidad_original",lote.CantidadOriginal)
                    });

                    cmd.ExecuteNonQuery();



                }

                cn.Close();

                //InventoryQueries.updateLoteSalidaAmount(cantidad, lote.CodigoLoteSalida);in
                //System.Windows.MessageBox.Show(lote.CodPT + "    " + lote.Existencia);
                InventarioPTAddAmount(lote.CodigoPT,int.Parse( lote.CantidadOriginal));

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al empacar producto  " + ex);
            }
        }

        public static void CreateProductoTerminadoDetalle(LotePTDetalle lote, int cantidad, string codMP)
        {
            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO detalle_pt_lote ([cod_lote_prod_terminado],[cod_lote_mp_empaque],[cod_mp],[nombre_mp]) " +
                        "VALUES (@codPT,@codLoteMp,@codMp,@nombreMp) ";

                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@codPT",lote.CodigoLotePT),
                        new OleDbParameter("@codLoteMp",lote.CodigoLoteMP),
                        new OleDbParameter("@codMp",lote.CodigoMP),
                        new OleDbParameter("@nombreMp",lote.NombreEmpaque)
                    });

                    cmd.ExecuteNonQuery();


                }

                cn.Close();

                InventoryQueries.updateLoteEntradaAmount(lote.CodigoLoteMP, -cantidad, codMP);

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
                    cmd.CommandText = @"INSERT INTO inventario_producto_terminado ([id_producto_terminado],[nombre_producto_terminado],[precio]) " +
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
                    "where id_producto_terminado = '" + codPT + "'; ", cn);
                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar Existencia " + ex);
            }
        }

        public static void InventarioPTRemoveAmount(string codPT, int Amount)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE inventario_producto_terminado " +
                    "SET existencia =  (existencia - " + Amount + " ), entrada = (entrada - " + Amount + ") " +
                    "where id_producto_terminado = '" + codPT + "'; ", cn);
                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar Existencia  " + ex);
            }
        }

        public static void InventarioPTSellAmount(string codPT, int Amount)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE inventario_producto_terminado " +
                    "SET existencia =  (existencia - " + Amount + " ), salida = (salida + " + Amount + ") " +
                    "where id_producto_terminado = '" + codPT + "'; ", cn);
                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar Existencia - " + ex);
            }
        }

        public static void deleteProductoTerminadoLote(string cod_pt, string id_lote, double amount, int existencia)
        {
            cn = DBConnection.MainConnection();


            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM producto_terminado " +
                        "WHERE cod_pt = '" + cod_pt + "' and id_lote = '" + id_lote + "'  ;";

                    cmd.ExecuteNonQuery();

                }

                
                cn.Close();

                InventarioPTRemoveAmount(cod_pt, existencia);
                InventoryQueries.updateLoteSalidaAmount(amount, id_lote);

                

                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al eliminar este producto terminado  " + ex);
            }
        }

        public static void removeDetallePtEmpaqueLote(string cod_lote_salida)
        {
            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM detalle_pt_lote " +
                        "WHERE cod_lote_prod_terminado = '" + cod_lote_salida + "'  ;";


                    cmd.ExecuteNonQuery();


                }

                cn.Close();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Error al elimnar este detalle de empaque " + ex);
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
        
        public static void AdjustExistingLote(string CodLote, emptyObject placeHolder, string codPT)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE lotes_producto_terminado " +
                    "SET existencia =  (existencia - " + placeHolder.EmptyCantidad + " ), cantidad_original = (cantidad_original - " + placeHolder.EmptyCantidad + ") " +
                    "where Codigo_Correlativo = '" + CodLote + "'; ", cn);
                cmd.ExecuteNonQuery();

                cn.Close();



                
                InventarioPTRemoveAmount(codPT, placeHolder.EmptyCantidad);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar Existencia - " + ex);
            }
        }

        public static List<LotePTDetalle> getDetallesFromPTLote(string CodLote)
        {
            var detalles = new List<LotePTDetalle>();


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT * FROM detalle_pt_lote where cod_lote_prod_terminado = '" + CodLote + "' ;", cn);
                dr = cmd.ExecuteReader();


                while (dr.Read())
                {

                    LotePTDetalle temp = new LotePTDetalle();
                    temp.CodigoLoteMP = dr["cod_lote_mp_empaque"].ToString();
                    temp.CodigoLotePT = CodLote;
                    temp.NombreEmpaque = dr["nombre_mp"].ToString();
                    temp.CodigoMP = dr["cod_mp"].ToString();

                    //System.Windows.MessageBox.Show("this is temp " + temp);

                    detalles.Add(temp);

                }


                dr.Close();
                cn.Close();


                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar detalles de lote de producto terminado " + ex.ToString());
            }




            return detalles;
        }




        public static void DeleteLotePT(string CodLote, emptyObject placeHolder)
        {

        }

    }
}
