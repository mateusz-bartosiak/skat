using Skat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skat.Tests;

public class DeckTests
{
    [Fact]
    public void DeckHasAllTheCards()
    {
        var deck = new Deck();

        Assert.Equal(32, deck.Cards.Count);
        Assert.Equal(32, deck.Cards.Distinct().Count());
        Assert.Equal(4, deck.Cards.GroupBy(c => c.Suit).Count());
        Assert.Equal(8, deck.Cards.GroupBy(c => c.Rank).Count());
    }

    [Fact]
    public void CardPointsAreCorrectlyDetermined()
    {
        var points = new Deck().Cards.Sum(c => c.Points);
        var expectedPoints = 4 * (11 + 10 + 4 + 3 + 2); // A, 10, K, Q, J, the rest are zeros
        Assert.Equal(expectedPoints, points);
    }
}
