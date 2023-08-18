using Skat.Domain;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Skat;

internal class Table
{
    public ImmutableArray<Player> Players { get; }
    public Player TenOClockPlayer => Players[0];
    public Player TwoOClockPlayer => Players[1];
    public Player SixOClockPlayer => Players[2];
    public Player Forehand => Players[forehandIndex];
    public Player Middlehand => NextPlayerOf(Forehand);
    public Player Backhand => NextPlayerOf(Middlehand);
    public Player Dealer => Backhand;

    const int SkatCardsCount = 2;
    public Card[] Skat { get; private set; } = new Card[SkatCardsCount];


    private int forehandIndex = 0;
    private const int SeatsCount = 3;

    public Table(params Player[] players)
    {
        if (players.Length != SeatsCount)
            throw new ArgumentOutOfRangeException(nameof(players));
        Players = players.ToImmutableArray();
        DealCards();
    }

    Player NextPlayerOf(Player player) => Players[KeepInBounds(Players.IndexOf(player) + 1)];

    public void AdvanceToTheNextRound() => forehandIndex = KeepInBounds(forehandIndex + 1);

    static int KeepInBounds(int n) => (n < 0) ? (SeatsCount - 1) : (n % SeatsCount);

    void DealCards()
    {
        var nextDealtPlayer = Forehand;
        var skat = new List<Card>();

        foreach (var card in new Deck())
        {
            if (nextDealtPlayer.HaveBeenDealtAllCards() is false)
            {
                nextDealtPlayer.Hand.Add(card);
                nextDealtPlayer = NextPlayerOf(nextDealtPlayer);
            }
            else
            {
                skat.Add(card);
            }
        }

        Skat = skat.ToArray();
    }
}
