using System;
using System.Collections.Generic;

namespace Pokedex.Core.Models
{
    public class Pokemon
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public double MaxHP { get; set; }
        public double CurrentHP { get; set; }
        public DateTime CaughtOn { get; set; }
        public int Candies { get; set; }
        public KeyValuePair<string, int> PrimaryAttack { get; set; } = new KeyValuePair<string, int>();
        public KeyValuePair<string, int> SecondaryAttack { get; set; } = new KeyValuePair<string, int>();
    }
}