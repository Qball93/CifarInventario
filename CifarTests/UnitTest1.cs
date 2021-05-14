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
        public void Test1()
        {
            List<Formula> testFormulas = FormulaQueries.GetFormulas();



            Console.WriteLine("this is " + testFormulas[0].CodFormula);
        }
    }
}
