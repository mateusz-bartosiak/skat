namespace Skat
{
    internal class Match
    {
        private Table table;

        public int RoundNumber { get; private set; } = 1;

        public Match(Player[] players) 
        {
            table = new Table(players);
        }

        public void AdvanceToNextRound()
        {
            table.AdvanceToNextRound();
            RoundNumber++;
        }
    }
}
