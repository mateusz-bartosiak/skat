﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Skat.Domain
{
    internal class Deck: IEnumerable<Card>
    {
        public IReadOnlyList<Card> Cards { get; private set; }

        public Deck()
        {
            var cards = Enum
                .GetValues<Suit>()
                .SelectMany(_ => Enum.GetValues<Rank>(),
                    (s, r) => new Card(s, r))
                .ToList();

            Cards = Shuffle(cards);
        }

        public void Shuffle()
        {
            Cards = Shuffle(Cards.Select(c => c.Copy()).ToList());
        }

        private static List<Card> Shuffle(List<Card> cards)
        {
            var shuffledCards = new List<Card>();
            var copiedCards = cards.Select(c => c.Copy()).ToList();

            for (int i = 0; copiedCards.Count > 0; i++)
            {
                int index = Random.Shared.Next(copiedCards.Count);
                var card = copiedCards[index];
                shuffledCards.Add(card);
                copiedCards.Remove(card);
            }

            return shuffledCards;
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return Cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Cards.GetEnumerator();
        }
    }
}
