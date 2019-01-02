using DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic.DataModels
{
    public class GamePokemonModel
    {
        public string Name { get; }
        public int MaxHP { get; }
        public int CurrentHP { get; set; }
        public GameMoveModel[] Moves { get; }

        public GamePokemonModel(string Name, int MaxHP, MoveModel[] Moves)
        {
            this.Name = Name;
            this.MaxHP = MaxHP;
            this.CurrentHP = MaxHP;
            this.Moves = ConvertMoveModelsToGameMoveModels(Moves);
        }

        private GameMoveModel[] ConvertMoveModelsToGameMoveModels(MoveModel[] moves)
        {
            List<GameMoveModel> gameMoves = new List<GameMoveModel>();

            foreach (var move in moves)
            {
                gameMoves.Add(new GameMoveModel(move.Name, move.PP, move.Power));
            }
            return gameMoves.ToArray();
        }
    }
}
