using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCoolShop;
namespace TestCoolShopTest
{
    [TestClass]
    public class CvsAnalyzerTest
    {
        [TestMethod]
        public void Routine()
        {
            var analyzer = new CsvAnalyzer();
            analyzer.Path = @"myfile.csv";
            analyzer.Separator = ',';

            var result = analyzer.SelectByColummData(2, "Alberto");
            Assert.AreEqual("3,Verdi,Alberto,03/08/1987;", result);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void FileNotPresent()
        {
            var analyzer = new CsvAnalyzer();
            analyzer.Path = @"myfileXX.csv";
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void ColumnNotPresent()
        {
            var analyzer = new CsvAnalyzer();
            analyzer.Path = @"myfile.csv";
            analyzer.Separator = ',';

            var result = analyzer.SelectByColummData(5, "Alberto");
            Assert.AreEqual("3,Verdi,Alberto,03/08/1987;", result);
        }

        [TestMethod]
        public void NoResult()
        {
            var analyzer = new CsvAnalyzer();
            analyzer.Path = @"myfile.csv";
            analyzer.Separator = ',';

            var result = analyzer.SelectByColummData(2, "Enzo");
            Assert.AreEqual(string.Empty, result);
        }
    }
}
