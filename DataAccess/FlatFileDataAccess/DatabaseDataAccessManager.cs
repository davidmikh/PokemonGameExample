using DataAccess.Data.Database;
using DataAccess.DataModels;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace DataAccess.FlatFileDataAccess
{
    public class DatabaseDataAccessManager : IDataAccessManager
    {
        // TODO: THIS STRING VALUE IS TEMPORARY FOR WHEN WE ARE USING SQLITE. EVENTUALLY WILL BE A SQL DB URL
        String dbUrl = String.Format("{0}\\..\\..\\..\\..\\DataAccess\\Data\\Database\\db.sqlite", Directory.GetCurrentDirectory());

        public DatabaseDataAccessManager()
        {
            DatabaseCreation.CreateDatabase(dbUrl);
            DatabaseCreation.PopulateDatabase(dbUrl);
        }

        public PokemonModel GetPokemon(string name)
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=Data/Database/db.sqlite;");

            // Get the pokemon now
            return null;
            //string selectAllPokemon = "SELECT * FROM POKEMON"
        }
    }
}
