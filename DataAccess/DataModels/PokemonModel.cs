using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataModels
{
    public class PokemonModel
    {
        public string Name { get; }
        public int HP { get; }
        public MoveModel[] Moves { get; }

        public PokemonModel(string Name, int HP, MoveModel[] Moves)
        {
            this.Name = Name;
            this.HP = HP;
            this.Moves = Moves;
        }
    }
}
