using GameLogic;
using GameLogic.DataModels;
using System;

namespace ConsoleInterface
{
    class Program
    {
        public static Game Game;

        static void Main(string[] args)
        {
            Console.WriteLine("GAME START!");
            Game = new Game();

            while (!Game.IsGameOver)
            {
                PrintGameState();
                PrintActivePokemonInformation(Game.PlayerOne);
                PrintActivePokemonInformation(Game.PlayerTwo);
                TakePlayerAction();
            }
        }

        private static void PrintGameState()
        {
            Console.WriteLine("TURN #{0}", Game.TurnNumber);
            Console.WriteLine("{0} VS {1}", Game.PlayerOne.Name, Game.PlayerTwo.Name);
        }

        private static void PrintActivePokemonInformation(PlayerModel player)
        {
            GamePokemonModel activePokemon = player.GetActivePokemon();

            Console.WriteLine("{0}: {1}", player.Name, activePokemon.Name);
            Console.WriteLine("HP: {0} / {1}", activePokemon.CurrentHP, activePokemon.MaxHP);
            Console.WriteLine("Moves: ");
            for (int i = 0; i < activePokemon.Moves.Length; i++)
            {
                GameMoveModel move = activePokemon.Moves[i];
                Console.WriteLine("{0}) {1}: {2} Power, {3} / {4} PP", i, move.Name, move.Power, move.CurrentPP, move.MaxPP);
            }
        }

        private static void TakePlayerAction()
        {

            PlayerModel activePlayer = Game.GetActivePlayer();

            Console.WriteLine("It is {0}'s turn with his {1}. What will you do?", activePlayer.Name, activePlayer.GetActivePokemon().Name);
            int userInput;
            bool userTakenAction = false;
            while (!userTakenAction)
            {
                Console.Write("Enter a number, 1 through 4, to select the move you want {0} to use and then hit enter: ", activePlayer.GetActivePokemon().Name);
                if (Int32.TryParse(Console.ReadLine(), out userInput))
                {
                    if (Game.TakeAction(userInput))
                    {
                        userTakenAction = true;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: INVALID INPUT OPTION GIVEN. Please try again");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: NON INTEGER INPUT GIVEN. Please try again");
                }
            }
        }
    }
}
