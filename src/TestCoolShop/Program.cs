using System;

namespace TestCoolShop
{
    /*
     * CSV file example
     * 1,Rossi,Fabio,01/06/1990;
     * 2,Gialli,Alessandro,02/07/1989;
     * 3,Verdi,Alberto,03/08/1987;
     * */
    class Program
    {
        /// <summary>
        /// Search entry in csv file formatted as:
        /// Key,Surname,Name,BirthDate
        /// </summary>
        /// <param name="args">Rapresent the input parameter, in particular path key name
        /// args[0] file path
        /// args[1] column
        /// args[2] data
        /// </param>
        static void Main(string[] args)
        {
            try
            {
                if (args == null)
                    throw new ArgumentException("Input not inserted!");

                if (args.Length != 3)
                    throw new ArgumentException("Check input parameter!");

                string path = args[0];

                uint column;
                if (!uint.TryParse(args[1], out column))
                    throw new ArgumentException("Can't find column id!");

                string dataToSearch = args[2];

                CsvAnalyzer csv = new CsvAnalyzer(path);

                var res = csv.SelectByColummData(column, dataToSearch);
                if (string.IsNullOrEmpty(res))
                    Console.WriteLine($"Data not found in file {path}");
                else
                    Console.WriteLine(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}
