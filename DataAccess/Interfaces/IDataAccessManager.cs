using DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IDataAccessManager
    {
        PokemonModel GetPokemon(String name);
    }
}
