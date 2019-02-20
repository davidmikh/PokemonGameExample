using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic.DataModels
{
    public class GameMoveModel
    {
        public string Name { get; }
        public int MaxPP { get; }
        public int CurrentPP { get; set; }
        public int Power { get; }

        public GameMoveModel(string Name, int MaxPP, int Power)
        {
            this.Name = Name;
            this.MaxPP = MaxPP;
            this.CurrentPP = MaxPP;
            this.Power = Power;
        }
    }
}
