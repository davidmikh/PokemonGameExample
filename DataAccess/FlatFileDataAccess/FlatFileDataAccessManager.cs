using DataAccess.DataModels;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.FlatFileDataAccess
{
    public class FlatFileDataAccessManager : IDataAccessManager
    {
        private FlatFilePokemonLoader pokemonLoader;

        public FlatFileDataAccessManager()
        {
            pokemonLoader = new FlatFilePokemonLoader();
        }

        public PokemonModel GetPokemon(String name)
        {
            return pokemonLoader.GetPokemon(name);
        }
    }
}
