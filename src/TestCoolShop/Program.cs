using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="args">Rapresent the input parameter, in particular path key name</param>
        static void Main(string[] args)
        {
            try
            {
                if (args == null)
                    throw new ArgumentException("Input not inserted!");

                if (args.Length != 3)
                    throw new ArgumentException("Check input parameter!");

                string path = args[0];

                int id;
                if (!int.TryParse(args[1], out id))
                    throw new ArgumentException("Can't find id!");

                string name = args[2];

                var result = File.ReadLines(path)
                     .Select(ParsePersonFromLine)
                     .Where(p => p.Name == name)
                     .FirstOrDefault();
                
                Console.WriteLine(result.ToString());
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

        private static Person ParsePersonFromLine(string line)
        {
            string[] parts = line.Split(',');
            Person p = new Person();

            p.Id = Int32.Parse(parts[0]);
            p.Surname = parts[1];
            p.Name = parts[2];
            DateTime BirthDate;
            string date = parts[3].Replace(";", string.Empty);//remove final charater
            if (DateTime.TryParse(date, out BirthDate))
                p.BirthDate = BirthDate;
            else
                throw new ArgumentException("Can't parse birthdate");

            return p;
        }
    }
}
