using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic.DataModels
{
    public class PlayerModel
    {
        public string Name { get; }
        public GamePokemonModel[] Party { get; }
        public int ActivePokemonIndex { get; set; }

        public PlayerModel(String Name, GamePokemonModel[] Party)
        {
            this.Name = Name;
            this.Party = Party;
        }

        public GamePokemonModel GetActivePokemon()
        {
            return Party[ActivePokemonIndex];
        }
    }
}
