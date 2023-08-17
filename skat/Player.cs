namespace Skat
{
    internal class Player
    {
        public List<Card> HeldCards { get; } = new List<Card>();

        public string Name { get; set; }

        public Player(string name) { Name = name; }

        public override string ToString()
        {
            return $"Player with the name {Name} has the following cards:\n" + 
                String.Join("\n", HeldCards.Select(c => c.ToString()));
        }

    }
}
