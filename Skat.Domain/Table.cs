namespace Skat;

internal class Table
{
    public Player[] Players { get; }
    public Player TenOClockPlayer => Players[0];
    public Player TwoOClockPlayer => Players[1];
    public Player SixOClockPlayer => Players[2];

    public Player Forehand => Players[KeepInBounds(tableRolesOffset)];
    public Player Middlehand => Players[KeepInBounds(tableRolesOffset+1)];
    public Player Backhand => Players[KeepInBounds(tableRolesOffset+2)];

    public Player Dealer => Backhand;

    public Player NextPlayerOf(Player player) => Players[KeepInBounds(Array.IndexOf(Players, player) + 1)];

    public Player PreviousPlayerOf(Player player)
    {
        int index = KeepInBounds(Array.IndexOf(Players, player) - 1);
        return Players[index];
    }

    private int tableRolesOffset = 0;

    private static int KeepInBounds(int n) => n < 0 ? 2 : n % 3;

    public Table(Player[] players)
    {
        if (players.Length != 3)
            throw new ArgumentOutOfRangeException(nameof(players));
        Players = players;
    }

    public void AdvanceToTheNextRound()
    {
        tableRolesOffset = KeepInBounds(tableRolesOffset + 1);
    }
}
