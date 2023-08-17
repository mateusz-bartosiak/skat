namespace Skat;

internal class Table
{
    public Player TenOClockPlayer => Players[0];
    public Player TwoOClockPlayer => Players[1];
    public Player SixOClockPlayer => Players[2];

    public Player[] Players { get; }
    public Player Forehand;
    public Player Middlehand;
    public Player Backhand;
    public Player Dealer => Backhand;

    public Player NextPlayerOf(Player player) => Players[(Array.IndexOf(Players, player) + 1) % 3];

    public Player PreviousPlayerOf(Player player)
    {
        int index = Array.IndexOf(Players, player) - 1;
        return Players[(index < 0) ? 2 : (index - 1)];
    }

    public Table(Player[] players)
    {
        Players = players;
        Forehand = TenOClockPlayer;
        Middlehand = TwoOClockPlayer;
        Backhand = SixOClockPlayer;
    }

    public void AdvanceToNextRound()
    {
        var previousBackhand = Backhand;
        var previousMiddlehand = Middlehand;
        var previousForehand = Forehand;

        Forehand = previousMiddlehand;
        Middlehand = previousBackhand;
        Backhand = previousForehand;
    }
}
