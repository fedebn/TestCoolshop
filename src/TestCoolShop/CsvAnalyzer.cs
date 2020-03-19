using System;
using System.IO;

namespace TestCoolShop
{
    public class CsvAnalyzer
    {
        #region Fileds

        string _path;

        #endregion

        #region Properties
        /// <summary>
        /// File path
        /// </summary>
        public string Path
        {
            get => _path;
            set
            {
                if (File.Exists(value))
                    _path = value;
                else
                    throw new ArgumentException($"Selected file not found. ({value})");
            }
        }

        public char Separator { get; set; }

        #endregion


        public CsvAnalyzer() { }

        /// <summary>
        /// Ctor of CsvAnalyzer
        /// </summary>
        /// <param name="path">set the path of the file</param>
        public CsvAnalyzer(string path) : this(path, char.Parse(string.Empty)) { }

        /// <summary>
        /// Ctor of CsvAnalyzer
        /// </summary>
        /// <param name="path">set the path of the file</param>
        public CsvAnalyzer(string path, char separator)
        {
            Path = path;
            Separator = separator;
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
