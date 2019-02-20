using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: GET THIS URL FROM A RESOURCE SOMEWHERE
            string dbUrl = String.Format("{0}\\..\\..\\..\\..\\DataAccess\\Data\\Database\\db.sqlite", Directory.GetCurrentDirectory());

            DatabaseCreation.CreateDatabase(dbUrl);
            DatabaseCreation.PopulateDatabase(dbUrl);

            Console.WriteLine("Database created");
        }
    }
}
