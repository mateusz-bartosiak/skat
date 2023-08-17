using Skat;

namespace SkatTests;

public class TableTests
{
    [Fact]
    public void InTheSecondRound_ForehandBecomesBackhand()
    {
        var forehand = new Player("Player 1");
        var middlehand = new Player("Player 2");
        var backhand = new Player("Player 3");

        var table = new Table(new Player[]
        {
            forehand, middlehand, backhand
        });

        table.AdvanceToNextRound();

        Assert.True(table.Backhand == forehand);
    }

    [Fact]
    public void ForehandIsTheSameInEveryThirdRound()
    {
    }
}