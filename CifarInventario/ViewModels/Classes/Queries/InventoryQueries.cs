using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using CifarInventario.Models;
using CifarInventario.ViewModels.Classes.Queries;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CifarInventario.ViewModels.Classes.Queries
{
    public class InventoryQueries
    {
        static private OleDbConnection cn;
        static private OleDbDataReader dr;
        static private OleDbCommand cmd;

        

        public static List<LoteEntrada> GetLotesEntradaActivos()
        {
            var lotes = new List<LoteEntrada>();


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT lote_entrada.codigo_lote_interno, lote_entrada.codigo_lote, lote_entrada.fecha_entrada, lote_entrada.cantidad_unidad_lote, lote_entrada.fecha_creacion, lote_entrada.cantidad_original, lote_entrada.certificado_analysis, " +
                    "lote_entrada.fecha_vencimiento, materia_prima.nombre_producto, materia_prima.unidad_muestra, lote_entrada.procedencia, lote_entrada.fabricante, proveedor.nombre_commercial as nombre_proveedor, lote_entrada.cod_proveedor " +
                    "FROM (lote_entrada INNER JOIN materia_prima ON lote_entrada.cod_mp = materia_prima.codigo) INNER JOIN proveedor ON proveedor.id = lote_entrada.cod_proveedor " +
                    "WHERE lote_entrada.cantidad_unidad_lote > 0 and lote_entrada.cod_mp NOT LIKE 'ENV%'  AND lote_entrada.cod_mp NOT LIKE 'ETI%' AND lote_entrada.cod_mp NOT LIKE 'TP%';", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    LoteEntrada temp = new LoteEntrada();

                    temp.CodLote = dr["codigo_lote"].ToString();
                    temp.CodInterno = dr["codigo_lote_interno"].ToString();
                    temp.NombreFabricante = dr["fabricante"].ToString();
                    temp.CodProveedor = dr["cod_proveedor"].ToString();
                    temp.NombreProveedor = dr["Nombre_proveedor"].ToString();
                    temp.NombreMP = dr["nombre_producto"].ToString();
                    temp.CantidadActual = double.Parse(dr["cantidad_unidad_lote"].ToString());
                    temp.CantidadOriginal = double.Parse(dr["cantidad_original"].ToString());
                    temp.FechaVencimiento = DateTime.Parse(dr["fecha_vencimiento"].ToString());
                    temp.FechaFabricacion = DateTime.Parse(dr["fecha_creacion"].ToString());
                    temp.FechaEntrada = DateTime.Parse(dr["fecha_entrada"].ToString());
                    temp.CertificadoAnalysis = dr["certificado_analysis"].ToString();
                    temp.Procedencia = dr["procedencia"].ToString();
                    temp.Unidad = dr["unidad_muestra"].ToString();




                    lotes.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar los lotes activos. " + ex.ToString());
            }




            return lotes;
        }


        public static List<LoteEntrada> GetAllLotes()
        {
            var lotes = new List<LoteEntrada>();


            cn = DBConnection.MainConnection();
             
            try
            {
                cmd = new OleDbCommand("SELECT lote_entrada.conversion_unitaria, lote_entrada.codigo_lote_interno, lote_entrada.codigo_lote, lote_entrada.fecha_entrada, lote_entrada.cantidad_unidad_lote, lote_entrada.fecha_creacion, lote_entrada.cantidad_original, lote_entrada.certificado_analysis, " +
                    "lote_entrada.fecha_vencimiento,materia_prima.codigo, materia_prima.nombre_producto, materia_prima.unidad_muestra, lote_entrada.procedencia, lote_entrada.fabricante, proveedor.nombre_commercial as nombre_proveedor, lote_entrada.cod_proveedor " +
                    "FROM (lote_entrada INNER JOIN materia_prima ON lote_entrada.cod_mp = materia_prima.codigo) INNER JOIN proveedor ON proveedor.id = lote_entrada.cod_proveedor;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    LoteEntrada temp = new LoteEntrada();

                    temp.CodLote = dr["codigo_lote"].ToString();
                    temp.NombreFabricante = dr["fabricante"].ToString();
                    temp.CodProveedor = dr["cod_proveedor"].ToString();
                    temp.CodMP = dr["codigo"].ToString();
                    temp.CodInterno = dr["codigo_lote_interno"].ToString();
                    temp.NombreProveedor = dr["Nombre_proveedor"].ToString();
                    temp.NombreMP = dr["nombre_producto"].ToString();
                    temp.CantidadActual = double.Parse(dr["cantidad_unidad_lote"].ToString());
                    temp.CantidadOriginal = double.Parse(dr["cantidad_original"].ToString());
                    temp.FechaVencimiento = DateTime.Parse(dr["fecha_vencimiento"].ToString());
                    temp.FechaFabricacion = DateTime.Parse(dr["fecha_creacion"].ToString());
                    temp.FechaEntrada = DateTime.Parse(dr["fecha_entrada"].ToString());
                    temp.CertificadoAnalysis = dr["certificado_analysis"].ToString();
                    temp.Procedencia = dr["procedencia"].ToString();
                    temp.Unidad = dr["unidad_muestra"].ToString();
                    temp.ConversionUnitaria = double.Parse( dr["conversion_unitaria"].ToString());




                    lotes.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar los lotes. " + ex.ToString());
            }

            return lotes;
        }

        public static List<LoteEntrada> GetAllContainerLotes()
        {
            var lotes = new List<LoteEntrada>();


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT lote_entrada.codigo_lote_interno,lote_entrada.codigo_lote, lote_entrada.fecha_entrada, lote_entrada.cantidad_unidad_lote, lote_entrada.fecha_creacion, lote_entrada.cantidad_original, lote_entrada.certificado_analysis, " +
                    "lote_entrada.fecha_vencimiento, materia_prima.nombre_producto, materia_prima.unidad_muestra, lote_entrada.procedencia, lote_entrada.fabricante, proveedor.nombre_commercial as nombre_proveedor, lote_entrada.cod_proveedor " +
                    "FROM (lote_entrada INNER JOIN materia_prima ON lote_entrada.cod_mp = materia_prima.codigo) INNER JOIN proveedor ON proveedor.id = lote_entrada.cod_proveedor " +
                    "WHERE lote_entrada.cantidad_unidad_lote > 0 AND (cod_mp LIKE 'ENV%' OR cod_mp LIKE 'ETI%' OR cod_mp LIKE 'TP%');", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    LoteEntrada temp = new LoteEntrada();

                    temp.CodLote = dr["codigo_lote"].ToString();
                    temp.NombreFabricante = dr["fabricante"].ToString();
                    temp.CodInterno = dr["codigo_lote_interno"].ToString();
                    temp.CodProveedor = dr["cod_proveedor"].ToString();
                    temp.NombreProveedor = dr["Nombre_proveedor"].ToString();
                    temp.NombreMP = dr["nombre_producto"].ToString();
                    temp.CantidadActual = double.Parse(dr["cantidad_unidad_lote"].ToString());
                    temp.CantidadOriginal = double.Parse(dr["cantidad_original"].ToString());
                    temp.FechaVencimiento = DateTime.Parse(dr["fecha_vencimiento"].ToString());
                    temp.FechaFabricacion = DateTime.Parse(dr["fecha_creacion"].ToString());
                    temp.FechaEntrada = DateTime.Parse(dr["fecha_entrada"].ToString());
                    temp.CertificadoAnalysis = dr["certificado_analysis"].ToString();
                    temp.Procedencia = dr["procedencia"].ToString();
                    temp.Unidad = dr["unidad_muestra"].ToString();




                    lotes.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar los lotes activos. " + ex.ToString());
            }




            return lotes;
        }

        public static List<LoteSalida> GetLotesTransform()
        {
            var lotes = new List<LoteSalida>();

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT * FROM lote_salida where lote_original IS NOT NULL;", cn);
                dr = cmd.ExecuteReader();



                while (dr.Read())
                {
                    var temp = new LoteSalida();

                    temp.CodFormula = dr["codigo_formula"].ToString();
                    temp.CantidadActual = double.Parse(dr["cantidad_actual"].ToString());
                    temp.Unidad = dr["unidad"].ToString();
                    temp.FechaCreacion = DateTime.Parse(dr["fecha_creacion"].ToString());
                    temp.FechaVencimiento = DateTime.Parse(dr["fecha_vencimiento"].ToString());
                    temp.CantidadCreacion = double.Parse(dr["cantidad_entrada"].ToString());
                    temp.OriginalLote = dr["lote_original"].ToString();
                    temp.CodLote = dr["codigo_lote"].ToString();
                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar Lotes De Produccion. " + ex.ToString());
            }




            return lotes;
        }

        public static List<LoteSalida> GetLoteSalidas()
        {
            var lotes = new List<LoteSalida>();

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT * FROM lote_salida INNER JOIN " +
                                       "formulas on formulas.id = lote_salida.codigo_formula where lote_salida.Activo = true;", cn);
                dr = cmd.ExecuteReader();



                while (dr.Read())
                {
                    var temp = new LoteSalida();

                    temp.CodLote = dr["codigo_lote"].ToString();
                    temp.CodFormula = dr["codigo_formula"].ToString();
                    temp.CantidadActual = double.Parse(dr["cantidad_actual"].ToString());
                    temp.Unidad = dr["unidad"].ToString();
                    temp.FechaCreacion = DateTime.Parse(dr["fecha_creacion"].ToString());
                    temp.FechaVencimiento = DateTime.Parse(dr["fecha_vencimiento"].ToString());
                    temp.CantidadCreacion = double.Parse(dr["cantidad_entrada"].ToString());
                    temp.NombreFormula = dr["nombre_formula"].ToString();


                    lotes.Add(temp);
                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar Lotes De Produccion. " + ex.ToString());
            }




            return lotes;
        }

        public static List<LoteSalida> GetLotesInactivos()
        {
            var lotes = new List<LoteSalida>();

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT * FROM lote_salida INNER JOIN " +
                                       "formulas on formulas.id = lote_salida.codigo_formula where lote_salida.Activo = false;", cn);
                dr = cmd.ExecuteReader();



                while (dr.Read())
                {
                    var temp = new LoteSalida();

                    temp.CodLote = dr["codigo_lote"].ToString();
                    temp.CodFormula = dr["codigo_formula"].ToString();
                    temp.CantidadActual = double.Parse(dr["cantidad_actual"].ToString());
                    temp.Unidad = dr["unidad"].ToString();
                    temp.FechaCreacion = DateTime.Parse(dr["fecha_creacion"].ToString());
                    temp.FechaVencimiento = DateTime.Parse(dr["fecha_vencimiento"].ToString());
                    temp.CantidadCreacion = double.Parse(dr["cantidad_entrada"].ToString());
                    temp.NombreFormula = dr["nombre_formula"].ToString();


                    lotes.Add(temp);
                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar Lotes De Produccion. " + ex.ToString());
            }




            return lotes;
        }

        public static LoteSalidaDetalle getTransformacionDetalle(string codFormula, double cantidad)
        {
            LoteSalidaDetalle test = new LoteSalidaDetalle();

            cn = DBConnection.MainConnection();

            try
            {
                Formula temp = new Formula();
                cmd = new OleDbCommand("SELECT formulas_1.cantidad_creada, formulas_1.cod_transformacion, formulas.nombre_formula, formulas_1.cantidad_transformacion " +
                                       "FROM formulas AS formulas_1 INNER JOIN formulas ON formulas.id = formulas_1.cod_transformacion " +
                                       "where formulas_1.id = '" + codFormula + "' ;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    test.Unidad = dr["cantidad_creada"].ToString();
                    test.Cantidad = double.Parse(dr["cantidad_transformacion"].ToString()) * cantidad;
                    temp.Transformacion = dr["cod_transformacion"].ToString();
                    test.NombreMP = dr["nombre_formula"].ToString();
                }




                List<string> lotes = new List<string>();


                try
                {
                    cmd = new OleDbCommand("SELECT codigo_lote FROM lote_salida where codigo_formula = '" + temp.Transformacion + "' and cantidad_actual >= " + test.Cantidad + ";", cn);
                    dr = cmd.ExecuteReader();



                    if (dr.HasRows)
                    {



                        while (dr.Read())
                        {



                            //System.Windows.MessageBox.Show("this is temp " + temp);

                            lotes.Add(dr["codigo_lote"].ToString());

                        }
                    }
                    else
                    {
                        //System.Windows.MessageBox.Show("N/A");
                        lotes.Add("N/A");
                    }

                    test.LotesProducto = new ObservableCollection<string>(lotes);

                    dr.Close();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error al buscar lotes de " + codFormula + ex.ToString());
                }




                dr.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar lotes transformacion " + ex.ToString());
            }

            test.CodLoteEntrada = test.LotesProducto[0];
            return test;
        }

        public static List<LoteSalidaDetalle> getFormulaProductionDetalles(string FormulaMaestra, double Cantidad, string FormulaCod)
        {
            List<DetalleFormula> FormulaMaestraDetalles = new List<DetalleFormula>(FormulaQueries.GetDetalles(FormulaCod));

            //System.Windows.MessageBox.Show(FormulaMaestraDetalles[0].IdMp);


            List<LoteSalidaDetalle> ProduccionDetalles = new List<LoteSalidaDetalle>();


            foreach (var element in FormulaMaestraDetalles)
            {



                LoteSalidaDetalle temp = new LoteSalidaDetalle();

                temp.NombreMP = element.Name;
                temp.Unidad = element.Unidad;
                temp.Cantidad = (double.Parse(element.Quantity) * Cantidad);
                temp.CodMP = element.IdMp;

                temp.Cantidad = Math.Round(temp.Cantidad, 4, MidpointRounding.AwayFromZero);



                temp.LotesProducto = new ObservableCollection<string>(getLotesForProduction(element.IdMp, temp.Cantidad));

                temp.CodLoteEntrada = temp.LotesProducto[0];

                //System.Windows.MessageBox.Show(element.Name + "   ss  " + temp.LotesProducto[0]);
                ProduccionDetalles.Add(temp);

            }



            return ProduccionDetalles;
        }

        public static List<string> getLotesForProduction(string MpCod, double Cantidad)
        {
            var lotes = new List<string>();
            string temp;


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT codigo_lote_interno FROM lote_entrada where cod_mp = '" + MpCod + "' and cantidad_unidad_formula >= " + Cantidad + ";", cn);
                dr = cmd.ExecuteReader();



                if (dr.HasRows)
                {



                    while (dr.Read())
                    {

                        temp = dr["codigo_lote_interno"].ToString();

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
                System.Windows.MessageBox.Show("Error al buscar lotes de " + MpCod + ex.ToString());
            }




            return lotes;
        }
        
        public static List<LotePackage> getPTForSale()
        {
            var pt = new List<LotePackage>();

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT cod_pt,id_lote,existencia,nombre_producto_terminado,precio from producto_terminado INNER JOIN inventario_producto_terminado " +
                    "on producto_terminado.cod_pt = id_producto.inventaro_producto_termiando;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    LotePackage temp = new LotePackage();

                    temp.CodPT = dr["id_producto"].ToString();
                    temp.NombrePT = dr["nombre_producto_terminado"].ToString();
                    temp.Existencia = int.Parse(dr["existencia"].ToString());
                    temp.Precio = double.Parse(dr["precio"].ToString());



                    pt.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al Productos Terminados para Venta. " + ex.ToString());
            }

            return pt;
        }

        public static List<LotePackage> getPTfromLote(string codLote)
        {
            var pt = new List<LotePackage>();

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT cod_pt,id_lote,producto_terminado.existencia,nombre_producto_terminado,precio from producto_terminado INNER JOIN inventario_producto_terminado " +
                    "ON producto_terminado.cod_pt = inventario_producto_terminado.id_producto_terminado where id_lote = '" + codLote + "' ;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    LotePackage temp = new LotePackage();

                    temp.CodPT = dr["cod_pt"].ToString();
                    temp.NombrePT = dr["nombre_producto_terminado"].ToString();
                    temp.Existencia = int.Parse(dr["existencia"].ToString());
                    temp.Precio = double.Parse(dr["precio"].ToString());



                    pt.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar Productos Terminados para Venta. " + ex.ToString());
            }

            return pt;
        }

        public static List<LotePackageDetalle> getMPFromPTLoteDetalles()
        {
            var pt = new List<LotePackageDetalle>();


            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT cod_lote_salida,cod_prod_terminado,cantidad,cod_lote_mp_empaque,nombre_producto " +
                    "FROM detalle_pt_lote INNER JOIN materia_prima ON detalle_pt_lote.cod_mp = materia_prima.codigo;", cn);
                dr = cmd.ExecuteReader();





                while (dr.Read())
                {
                    LotePackageDetalle temp = new LotePackageDetalle();

                    temp.CodPT = dr["cod_prod_terminado"].ToString();
                    temp.CodLoteEntrada = dr["cod_lote_mp_empaque"].ToString();
                    temp.Cantidad = int.Parse(dr["cantidad"].ToString());
                    temp.NombreEmpaque = dr["nombre_producto"].ToString();
                    temp.CodLoteSalida = dr["cod_lote_salida"].ToString();
                    




                    pt.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar los paquetes utilizadas en el producto terminado. " + ex.ToString());
            }

            return pt;
        }

        public static List<LoteEntrada> getLotesForMP(string CodLote, int cantidad)
        {
            var lotes = new List<LoteEntrada>();

            cn = DBConnection.MainConnection();

            try
            {
                cmd = new OleDbCommand("SELECT  codigo_lote_interno,codigo_lote,cantidad_unidad_lote" +
                    " FROM lote_entrada where cantidad_unidad_lote >= " + cantidad+" and cod_mp = '"+CodLote+"';", cn);
                dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {



                    while (dr.Read())
                    {

                        LoteEntrada temp = new LoteEntrada();

                        temp.CodLote = dr["codigo_lote"].ToString();
                        temp.CodMP = dr["cantidad_unidad_lote"].ToString();
                        temp.CodInterno = dr["codigo_lote_interno"].ToString();




                        lotes.Add(temp);

                    }
                }
                else
                {
                    LoteEntrada temp = new LoteEntrada();

                    temp.CodLote = "N/A";
                    lotes.Add(temp);


                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al buscar lotes de materia prima. " + ex.ToString());
            }

            return lotes;
        }

        public static void CreateLoteEntrada(LoteEntrada lote)
        {
            cn = DBConnection.MainConnection();
            try
            {

                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO lote_entrada ([codigo_lote],[fecha_entrada],[cantidad_unidad_lote],[fecha_vencimiento],[cantidad_original],[cod_mp],[conversion_unitaria]," +
                        "[cantidad_unidad_formula],[fecha_creacion],[certificado_analysis],[cod_proveedor],[fabricante],[codigo_lote_interno],[procedencia]) " +
                        "VALUES (@codigo,@fechaEnt,@cantidadActual,@fechaVencimiento,@cantidadOriginal,@codMP,@conversion,@cantidadExacta, " +
                        "@fechaCreacion,@certificados,@codProveedor,@fabricante,@codeLoteIntern,@procedencia)";


                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@codigo",lote.CodLote),
                        new OleDbParameter("@fechaEnt",lote.FechaEntrada.ToShortDateString()),
                        new OleDbParameter("@cantidadActual",lote.CantidadActual),
                        new OleDbParameter("@fechaVencimiento",lote.FechaVencimiento.ToShortDateString()),
                        new OleDbParameter("@cantidadOriginal",lote.CantidadOriginal),
                        new OleDbParameter("@codMP",lote.CodMP),
                        new OleDbParameter("@conversion",lote.ConversionUnitaria),
                        new OleDbParameter("@cantidadExacta",lote.CantidadExacta),
                        new OleDbParameter("@fechaCreacion",lote.FechaFabricacion.ToShortDateString()),
                        new OleDbParameter("@certificados",lote.CertificadoAnalysis == "" ?lote.CertificadoAnalysis:"/N/A"),
                        new OleDbParameter("@codProveedor",lote.CodProveedor),
                        new OleDbParameter("@fabricante",lote.NombreFabricante),
                        new OleDbParameter("@codeLoteIntern",lote.CodLote+"-"+lote.FechaEntrada.ToShortDateString()),
                        new OleDbParameter("@procedencia",lote.Procedencia),
                    });


                    cmd.ExecuteNonQuery();


                    
                }



               



                cn.Close();

                ProductQueries.updateProductAmountAdd(lote.CodMP, lote.CantidadOriginal);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear Lote Entrada  " + ex);
            }
        }

        public static void deleteLoteEntrada(string codInterno)
        {
            cn = DBConnection.MainConnection();


            try
            {

                cmd = new OleDbCommand("DELETE FROM lote_entrada WHERE codigo_lote_interno = '" + codInterno + "' ;", cn);
                cmd.ExecuteNonQuery();

                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al eliminar Lote  " + ex);
            }
        }

        public static bool canLoteBeDeleted(string codInterno)
        {
            bool canBeDeleted = true;

            cn = DBConnection.MainConnection();


            try
            {

                cmd = new OleDbCommand("Select * from lote_salida_detalla where if_lote_entrada = '" + codInterno + "' ;", cn);
                cmd.ExecuteNonQuery();

                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al eliminar Lote  " + ex);
            }




            return canBeDeleted;
        }

        public static void updateLoteEntradaAmount(string CodLote, double exactAmount, string CodMP)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE lote_entrada " +
                    "SET cantidad_unidad_lote = (cantidad_unidad_lote + (" + exactAmount + " / conversion_unitaria )), cantidad_unidad_formula = (cantidad_unidad_formula + " + exactAmount + " ) " +
                    "where codigo_lote_interno = '" + CodLote + "'; ", cn);
                cmd.ExecuteNonQuery();






                cn.Close();

                if(exactAmount > 0)
                {
                    ProductQueries.updateProductAmountFromtExactAdd(CodMP, exactAmount);
                }
                else
                {
                    ProductQueries.updateProductAmountFromExactRemove(CodMP, exactAmount);
                }
                

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar existencia the lotes entrada  " + ex);
            }
        }

        public static void createLoteSalida(LoteSalida lote)
        {
            cn = DBConnection.MainConnection();
            try
            {

                using (OleDbCommand cmd = cn.CreateCommand())
                {

                    if(lote.OriginalLote == "None")
                    {
                        cmd.CommandText = @"INSERT INTO lote_salida ([codigo_lote],[fecha_creacion],[cantidad_actual],[unidad],[fecha_vencimiento],[cantidad_entrada],[codigo_formula]) " +
                        "VALUES (@codigo,@fechaCreate,@cantidadActual,@unidad,@fechaVent,@cantidadEntrada,@codigoFormula) ";
                    }
                    else
                    {
                        cmd.CommandText = @"INSERT INTO lote_salida ([codigo_lote],[fecha_creacion],[cantidad_actual],[unidad],[fecha_vencimiento],[cantidad_entrada],[codigo_formula],[lote_original] )" +
                        "VALUES (@codigo,@fechaCreate,@cantidadActual,@unidad,@fechaVent,@cantidadEntrada,@codigoFormula,@loteOriginal) ";
                    }

                    


                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@codigo",lote.CodLote),
                        new OleDbParameter("@fechaCreate",lote.FechaCreacion.ToShortDateString()),
                        new OleDbParameter("@cantidadActual",lote.CantidadCreacion),
                        new OleDbParameter("@unidad",lote.Unidad),
                        new OleDbParameter("@fechaVent",lote.FechaVencimiento.ToShortDateString()),
                        new OleDbParameter("@cantidadEntrada",lote.CantidadCreacion),
                        new OleDbParameter("@codigoFormula",lote.CodFormula),
                        new OleDbParameter("@loteOriginal",lote.OriginalLote),
                    });


                    cmd.ExecuteNonQuery();


                }

                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear Lote Salida  " + ex);
            }
        }

        public static void updateLoteSalidaAmount(double cantidad, string codigo)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE lote_salida " +
                    "SET cantidad_actual =  (cantidad_actual + " + cantidad + " ) " +
                    "where codigo_lote = '" + codigo + "'; ", cn);
                cmd.ExecuteNonQuery();

                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al actualizar existencia the lotes salida  " + ex);
            }
        }
     
        public static void createLoteSalidaDetalle(LoteSalidaDetalle lote, string codLoteSalida)
        {
            cn = DBConnection.MainConnection();
            try
            {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO lote_salida_detalles ([id_lote_salida],[id_lote_entrada],[cantidad]) " +
                        "VALUES (@codSalida,@codEntrada,@cantidad) ";

                    cmd.Parameters.AddRange(new OleDbParameter[]
                    {
                        new OleDbParameter("@codigo",codLoteSalida),
                        new OleDbParameter("@fechaCreate",lote.CodLoteEntrada),
                        new OleDbParameter("@cantidadActual",lote.Cantidad)
                    });

                    cmd.ExecuteNonQuery();

                    


                    

                    

                }

                cn.Close();

                updateLoteEntradaAmount(lote.CodLoteEntrada, (-lote.Cantidad), lote.CodMP);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al crear Detalle Lote Salida  " + ex);
            }
        }

        public static void SetLoteSalidaInactive(string codLote)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE lote_salida " +
                    "SET activo =  false  " +
                    "where codigo_lote = '" + codLote + "'; ", cn);
                cmd.ExecuteNonQuery();

                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al desactivar Lote  " + ex);
            }
        }

        public static void SetLoteSalidaActive(string codLote)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE lote_salida " +
                    "SET activo =  true  " +
                    "where codigo_lote = '" + codLote + "'; ", cn);
                cmd.ExecuteNonQuery();

                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al activar Lote  " + ex);
            }
        }

        public static void emptyLote(string codLote)
        {
            double FormUnitAmountCurrent = 0;
            double DisplayUnitOriginalAmount = 0;
            double CurrentDisplayAmount = 0;
            string codMP = "";

            cn = DBConnection.MainConnection();


            try
            {

                cmd = new OleDbCommand("Select * from lote_entrada where codigo_lote_interno = '" + codLote + "' ;", cn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    codMP = dr["cod_mp"].ToString();
                    FormUnitAmountCurrent = double.Parse(dr["cantidad_unidad_formula"].ToString());
                    DisplayUnitOriginalAmount = double.Parse(dr["cantidad_original"].ToString());
                    CurrentDisplayAmount = double.Parse(dr["cantidad_unidad_lote"].ToString());
                }


                cmd = new OleDbCommand("UPDATE lote_entrada " +
                    "set cantidad_unidad_lote = 0.00, cantidad_original = 0.00 , cantidad_unidad_formula = 0.00 " +
                    "where codigo_lote_interno = '" + codLote + "' ;", cn);
                cmd.ExecuteNonQuery();

                dr.Close();
                cn.Close();

                ProductQueries.removeFlatAmounts(codMP, FormUnitAmountCurrent, CurrentDisplayAmount, DisplayUnitOriginalAmount);

                

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al vaciar Lote  " + ex);
            }

        }

        public static void UpdateLoteConversion(string CodMp, double conversion)
        {
            cn = DBConnection.MainConnection();
            try
            {
                cmd = new OleDbCommand("UPDATE lote_entrada " +
                    "SET conversion_unitaria =  " + conversion + 
                    " where cod_mp = '" + CodMp + "'; ", cn);

                cmd.ExecuteNonQuery();

                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al conversion en Lotes  " + ex);
            }
        }


        public static void reEntryLote(string codLote, double CurrentDisplayAmount, double OriginalDisplayAmount, double formAmount)
        {

            //string codMP = "";

            cn = DBConnection.MainConnection();
            

            try
            {

                cmd = new OleDbCommand("UPDATE lote_entrada " +
                    "set cantidad_unidad_lote = "+ CurrentDisplayAmount+", cantidad_original = " +OriginalDisplayAmount+", cantidad_unidad_formula = " + formAmount + ""  +
                    " where codigo_lote_interno = '" + codLote + "' ;", cn);
                cmd.ExecuteNonQuery();

                



                dr.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al ReIngersar Lote "+ ex);
            }
        }

    }
}
