using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataModels
{
    public class MoveModel
    {
        public string Name { get; }
        public int PP { get; }
        public int Power { get; }

        public MoveModel(string Name, int PP, int Power)
        {
            this.Name = Name;
            this.PP = PP;
            this.Power = Power;
        }
    }
}
