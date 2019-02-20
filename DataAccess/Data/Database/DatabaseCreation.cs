using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DataAccess.Data.Database
{
    public class DatabaseCreation
    {
        public static void CreateDatabase(String dbURL)
        {
            SQLiteConnection.CreateFile(dbURL);

            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbURL +";");

            string createAbilityTableStr = "CREATE TABLE Ability " +
                "(ID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "AbilityName VARCHAR NOT NULL, " +
                "PP INTEGER NOT NULL, " +
                "Power INTEGER NOT NULL);";

            string createPokemonTableStr = "CREATE TABLE Pokemon " +
                "(ID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "PokemonName VARCHAR NOT NULL, " +
                "HP INTEGER NOT NULL, " +
                "MoveOneID INTEGER, " +
                "MoveTwoID INTEGER, " +
                "MoveThreeID INTEGER, " +
                "MoveFourID INTEGER);";

            string createPokemonAbilitiesTableStr = "CREATE TABLE PokemonAbilities " +
                "(PokemonID INTEGER, " +
                "AbilityID INTEGER," +
                "FOREIGN KEY(PokemonID) REFERENCES Pokemon(ID), " +
                "FOREIGN KEY(AbilityID) REFERENCES Ability(ID));";

            try
            {
                dbConnection.Open();
                SQLiteCommand createAbilitiesTable = new SQLiteCommand(createAbilityTableStr, dbConnection);
                createAbilitiesTable.ExecuteNonQuery();
                SQLiteCommand createPokemonTable = new SQLiteCommand(createPokemonTableStr, dbConnection);
                createPokemonTable.ExecuteNonQuery();
                SQLiteCommand createPokemonAbilitiesTable = new SQLiteCommand(createPokemonAbilitiesTableStr, dbConnection);
                createPokemonAbilitiesTable.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public static void PopulateDatabase(String dbURL)
        {
            string populateMovesTableStr = "INSERT INTO Ability ('AbilityName', 'PP', 'Power') VALUES " +
                "('Confusion', 20, 70)," +
                "('Shadow Ball', 15, 90)," +
                "('Hyper Beam', 5, 120)," +
                "('Lick', 25, 50)," +
                "('Surf', 20, 75);";

            string populatePokemonTableStr = "INSERT INTO Pokemon ('PokemonName', 'HP') VALUES " +
                "('Gengar', 130)," +
                "('Slowpoke', 98);";

            string populatePokemonAbilitiesTableStr = "INSERT INTO PokemonAbilities ('PokemonID', 'AbilityID') VALUES " +
                InsertPokemonAbilitiesStatement("Gengar", "Confusion") + ", " +
                InsertPokemonAbilitiesStatement("Gengar", "Shadow Ball") + ", " +
                InsertPokemonAbilitiesStatement("Gengar", "Hyper Beam") + ", " +
                InsertPokemonAbilitiesStatement("Gengar", "Lick") + ", " +
                InsertPokemonAbilitiesStatement("Slowpoke", "Confusion") + ", " +
                InsertPokemonAbilitiesStatement("Slowpoke", "Lick") + ", " +
                InsertPokemonAbilitiesStatement("Slowpoke", "Surf") + ";";

            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbURL + ";");

            try
            {
                dbConnection.Open();
                SQLiteCommand populateMovesTable = new SQLiteCommand(populateMovesTableStr, dbConnection);
                populateMovesTable.ExecuteNonQuery();
                SQLiteCommand populatePokemonTable = new SQLiteCommand(populatePokemonTableStr, dbConnection);
                populatePokemonTable.ExecuteNonQuery();
                SQLiteCommand populatePokemonAbilitiesTable = new SQLiteCommand(populatePokemonAbilitiesTableStr, dbConnection);
                populatePokemonAbilitiesTable.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
            }
        }

        private static string SelectPokemonIDQuery(String pokemonName)
        {
            return String.Format("(SELECT ID FROM Pokemon WHERE PokemonName = '{0}')", pokemonName);
        }

        private static string InsertPokemonAbilitiesStatement(String pokemonName, String abilityName)
        {
            return String.Format("({0}, {1})", SelectPokemonIDQuery(pokemonName), SelectAbilityIDQuery(abilityName));
        }

        private static string SelectAbilityIDQuery(String abilityName)
        {
            return String.Format("(SELECT ID FROM Ability WHERE AbilityName = '{0}')", abilityName);
        }
    }
}
