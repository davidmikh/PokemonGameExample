using DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic.DataModels
{
    public class GameModel
    {
        public GamePokemonModel PokemonOne { get; }
        public GamePokemonModel PokemonTwo { get; }
        public bool IsPlayerOneTurn { get; }
        public bool IsGameOver { get; }

        public GameModel(PokemonModel PokemonOne, PokemonModel PokemonTwo)
        {
            this.PokemonOne = new GamePokemonModel(PokemonOne.Name, PokemonOne.HP, PokemonOne.Moves);
            this.PokemonTwo = new GamePokemonModel(PokemonTwo.Name, PokemonTwo.HP, PokemonTwo.Moves);

            IsGameOver = false;
            IsPlayerOneTurn = true;
        }
    }
}
