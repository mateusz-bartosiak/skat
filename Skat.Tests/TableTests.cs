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

        table.AdvanceToNextRound();

        Assert.True(table.Forehand == middlehand);
        Assert.True(table.Middlehand == backhand);
        Assert.True(table.Backhand == forehand);
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

        table.AdvanceToNextRound();
        table.AdvanceToNextRound();
        table.AdvanceToNextRound();

        Assert.True(table.Forehand == forehand);
        Assert.True(table.Middlehand == middlehand);
        Assert.True(table.Backhand == backhand);
    }
}