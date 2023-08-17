using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Skat.Domain
{
    internal class Deck
    {
        public IReadOnlyList<Card> Cards { get; private set; }

        public Deck()
        {
            Cards = Enum
                .GetValues<Suit>()
                .SelectMany(s => Enum.GetValues<Rank>(),
                    (s, r) => new Card(s, r))
                .ToList();

            Shuffle();
        }

        public void Shuffle()
        {
            var shuffledCards = new List<Card>();
            var copiedCards = new List<Card>(Cards.Select(c => c.Copy()));

            for (int i = 0; copiedCards.Count > 0; i++)
            {
                int index = Random.Shared.Next(copiedCards.Count);
                var card = copiedCards[index];
                shuffledCards.Add(card);
                copiedCards.Remove(card);
            }

            Cards = shuffledCards;
        }
    }
}
