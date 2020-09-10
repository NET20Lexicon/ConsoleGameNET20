using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameNET20
{
    class Portion : Item, IUsable
    {
        public Portion(string symbol, ConsoleColor color, string name) : base(symbol, color, name) { }

        public void Use(Creature creature) => creature.Health += 15;
        public static Portion HealthPortion() => new Portion("p ", ConsoleColor.DarkYellow, "Portion");
    }
}
