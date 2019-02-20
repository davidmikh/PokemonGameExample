using DataAccess.FlatFileDataAccess;
using DataAccess.Interfaces;
using GameLogic.DataModels;
using System;
using System.Linq;

namespace GameLogic
{
    public class Game
    {
        public PlayerModel PlayerOne { get; private set; }
        public PlayerModel PlayerTwo { get; private set; }
        public bool IsPlayerOneTurn { get; private set; }
        public bool IsGameOver { get; private set; }
        public int TurnNumber { get; private set; }

        private IDataAccessManager dataAccessManager;
        
        public Game()
        {
            //dataAccessManager = new FlatFileDataAccessManager();
            dataAccessManager = new DatabaseDataAccessManager();

            var pokemon = dataAccessManager.GetPokemon("Gengar");
            var pokemon2 = dataAccessManager.GetPokemon("Slowpoke");
            PlayerOne = new PlayerModel("PlayerOne", new GamePokemonModel[] { new GamePokemonModel(pokemon.Name, pokemon.HP, pokemon.Moves) } );
            PlayerTwo = new PlayerModel("PlayerTwo", new GamePokemonModel[] { new GamePokemonModel(pokemon2.Name, pokemon2.HP, pokemon2.Moves) });
            PlayerOne.ActivePokemonIndex = 0;
            PlayerTwo.ActivePokemonIndex = 0;

            IsGameOver = false;
            IsPlayerOneTurn = true;
        }

        public PlayerModel GetActivePlayer()
        {
            if (IsPlayerOneTurn)
            {
                return PlayerOne;
            }
            else
            {
                return PlayerTwo;
            }
        }

        public bool TakeAction(int actionNum)
        {
            PlayerModel player = GetActivePlayer();
            if (actionNum < player.GetActivePokemon().Moves.Length && actionNum >= 0)
            {
                ExecuteMove(actionNum);
                CompleteTurn();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ExecuteMove(int moveNum)
        {
            PlayerModel attackingPlayer = GetActivePlayer();
            PlayerModel attackedPlayer;
            if (attackingPlayer.Equals(PlayerOne))
            {
                attackedPlayer = PlayerTwo;
            }
            else
            {
                attackedPlayer = PlayerOne;
            }

            attackingPlayer.GetActivePokemon().Moves[moveNum].CurrentPP--;

            // Calculate damage dealt
            attackedPlayer.GetActivePokemon().CurrentHP -= attackingPlayer.GetActivePokemon().Moves[moveNum].Power;
        }

        private void CompleteTurn()
        {
            IsPlayerOneTurn = !IsPlayerOneTurn;
            TurnNumber++;
        }
    }
}
