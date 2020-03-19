using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCoolShop
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args == null)
                    throw new ArgumentException("Input not inserted");

                if(args.Length != 3)
                    throw new ArgumentException("Check input parameter");

                string path = args[0];
                int id;
                if (!int.TryParse(args[1], out id))
                    throw new ArgumentException("Can't find id");
                string name = args[2];

                File.ReadLines(path)
                     .Select(ParsePersonFromLine)
                     .Where(p => p.Name == "Peter")
                     .FirstOrDefault();
            }
            catch(Exception e)
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
            p.Name = parts[1];
            p.Surname = parts[2];
            DateTime BirthDate;
            if (DateTime.TryParse(parts[3], out BirthDate))
                p.BirthDate = BirthDate;
            else
                throw new ArgumentException("Can't find birthdate");

            return p;
        }
    }
}
