using System;
using System.IO;

namespace TestCoolShop
{
    public class CsvAnalyzer
    {
        #region Properties
        /// <summary>
        /// File path
        /// </summary>
        public string Path { get; set; }

        #endregion


        public CsvAnalyzer() { }

        /// <summary>
        /// Ctor of CsvAnalyzer
        /// </summary>
        /// <param name="path">set the path of the file</param>
        public CsvAnalyzer(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Search in <see cref="Path"/> if in the selectd column the first row with selcted data
        /// </summary>
        /// <param name="col">selected colum id</param>
        /// <param name="data">data to search</param>
        /// <returns>row with selected data, empty string in case of error</returns>
        public string SelectByColummData(uint col, string data)
        {
            using (StreamReader s = new StreamReader(Path))
            {
                while (true)
                {
                    var line = s.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        break;

                    var extData = line.Split(',');

                    if (extData.Length < col)
                        throw new ArgumentOutOfRangeException($"Column {col} not present, in selcted file");

                    if (string.Equals(extData[col], data))
                        return line;
                }

            }
            return string.Empty;
        }
    }
}
