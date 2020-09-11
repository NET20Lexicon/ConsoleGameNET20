using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGameNET20
{
   public static class Extensions
    {
        public static IDrawable CreatureAtExtension(this IEnumerable<Creature> creatures, Cell cell)
        {
            return creatures.FirstOrDefault(c => c.Cell == cell);
        }

        public static int GetMapSizeFor(this IConfiguration config, string name)
        {
            var section = config.GetSection("consolegame:mapsettings");

            return int.TryParse(section[name], out int result) ? result : 0;
        }
    }
}
