using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skat
{
    internal class Player
    {
        public List<Card> HeldCards { get; } = new List<Card>();

        public string Name { get; set; }

        public Player(string name) { Name = name; }

        public override string ToString()
        {
            return $"Player with name {Name} has the following cards:\n" + String.Join("\n", HeldCards.Select(c => c.ToString()));
        }

    }
}
