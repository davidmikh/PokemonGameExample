using DataAccess.DataModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataAccess.FlatFileDataAccess
{
    internal class FlatFilePokemonLoader
    {
        private string flatFilePath = "Data/FlatFiles/Pokemon.txt";

        internal PokemonModel GetPokemon(string name)
        {
            using (StreamReader reader = new StreamReader(flatFilePath))
            {
                string json = reader.ReadToEnd();
                var pokemon = JsonConvert.DeserializeObject<List<PokemonModel>>(json);
                return pokemon.Where(t => t.Name.Equals(name)).First();
            }
        }
    }
}