using FluentAssertions;
using Skat;

namespace SkatTests;

public class TableTests
{
    [Fact]
    public void TableRolesRotateInTheRightDirection()
    {
        var forehand = new Player("Player 1");
        var middlehand = new Player("Player 2");
        var backhand = new Player("Player 3");

        var table = new Table(new Player[]
        {
            forehand, middlehand, backhand
        });

        table.AdvanceToTheNextRound();

        table.Forehand.Should().Be(middlehand);
        table.Middlehand.Should().Be(backhand);
        table.Backhand.Should().Be(forehand);
    }

    [Fact]
    public void EveryThirdRoundSamePlayerHasTheSameRole()
    {
        var forehand = new Player("Player 1");
        var middlehand = new Player("Player 2");
        var backhand = new Player("Player 3");

        var table = new Table(new Player[]
        {
            forehand, middlehand, backhand
        });

        table.AdvanceToTheNextRound();
        table.AdvanceToTheNextRound();
        table.AdvanceToTheNextRound();

        table.Forehand.Should().Be(forehand);
        table.Middlehand.Should().Be(middlehand);
        table.Backhand.Should().Be(backhand);
    }
    
    [Fact]
    public void PlayersAreDealtTenCardsEachAndSkatHasTwo()
    {
        var table = new Table(new Player("Player 1"), new Player("Player 2"), new Player("Player 3"));

        table.Players.Should().OnlyContain(p => p.Hand.Count == 10);
        table.Skat.Should().HaveCount(2);
    }
}