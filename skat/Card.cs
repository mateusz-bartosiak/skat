namespace Skat
{
    internal class Card
    {
        public Suit Suit { get; }

        public Rank Rank { get; }

        Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public static List<Card> MakeADeck()
        {
            return Enum.GetValues<Suit>()
                .SelectMany(s => Enum.GetValues<Rank>(), (s, r) => new Card(s, r))
                .ToList();
        }

        public override string ToString()
        {
            return $"Suit: {Suit}, Rank: {Rank}";
        }

        public int Points => CardPoints.For(Rank);

        internal static class CardPoints
        {
            public static int For(Rank rank) => Points[(int)rank];

            static int[] Points { get; }

            static CardPoints()
            {
                Points = new int[8];
                Points[(int)Rank.Seven] = 0;
                Points[(int)Rank.Eight] = 0;
                Points[(int)Rank.Nine] = 0;
                Points[(int)Rank.Jack] = 2;
                Points[(int)Rank.Queen] = 3;
                Points[(int)Rank.King] = 4;
                Points[(int)Rank.Ten] = 10;
                Points[(int)Rank.Ace] = 11;
            }
        }

    }
}
