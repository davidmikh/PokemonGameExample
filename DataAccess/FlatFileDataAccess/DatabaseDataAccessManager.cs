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
        }

        public PokemonModel GetPokemon(string name)
        {
            // Get the pokemon now
            //return null;
            string selectAllPokemonWithAbilitiesStr = "SELECT Pokemon.HP, Ability.AbilityName, Ability.PP, Ability.Power FROM PokemonAbilities " +
                "INNER JOIN Pokemon ON Pokemon.ID = PokemonAbilities.PokemonID " +
                "INNER JOIN Ability ON Ability.ID = PokemonAbilities.AbilityID " +
                "WHERE Pokemon.PokemonName = '" + name + "'";


            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbUrl + ";");

            PokemonModel model;
            List<MoveModel> moves = new List<MoveModel>();
            int hp = 0;

            try
            {
                dbConnection.Open();
                SQLiteCommand selectAllPokemonWithAbilities = new SQLiteCommand(selectAllPokemonWithAbilitiesStr, dbConnection);
                var reader = selectAllPokemonWithAbilities.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        if (hp == 0)
                        {
                            hp = reader.GetInt32(0);
                        }
                        moves.Add(new MoveModel(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {
                dbConnection.Close();
            }

            model = new PokemonModel(name, hp, moves.ToArray());

            return model;
        }
    }
}
