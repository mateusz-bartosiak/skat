using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skat
{
    internal class Card
    {
        public Suit Suit1 { get; }
        public Rank Rank1 { get; }

        Card(Suit suit, Rank rank)
        {
            Suit1 = suit;
            Rank1 = rank;
        }

        public static List<Card> MakeDeck()
        {
            var cards = new List<Card>();
            foreach (var suit in Enum.GetValues<Suit>())
            {
                foreach (var rank in Enum.GetValues<Rank>())
                {
                    cards.Add(new Card(suit, rank));
                }
            }
            return cards;
        }

        public override string ToString()
        {
            return $"Suit: {this?.Suit1} rank: {this?.Rank1}";
        }
    }
}
