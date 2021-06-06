using System;
using Xunit;
using CifarInventario.ViewModels.Classes.Queries;
using CifarInventario.Models;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CifarTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDetalleInfo()
        {

            List<LoteSalidaDetalle> testDetalles = InventoryQueries.getFormulaProductionDetalles("Piperacina jarabe", 2.42, "PPRJRB");



            Console.WriteLine("this is " + testDetalles[0].NombreMP);



            Console.WriteLine("THs sad as sa sa dsa da ");
        }
    }
}
