// See https://aka.ms/new-console-template for more information
using skat;

var cards = Card.MakeDeck();

foreach (var card in cards)
{
    Console.WriteLine(card);
}

Console.WriteLine("Count of cards in deck: " + Card.MakeDeck().Count());

var players = new Player[]
{
    new Player("Player 1"),
    new Player("Player 2"),
    new Player("Player 3")
};

for (int i = 0; true; i++ )
{
    i %= 3;
    var card = cards[new Random().Next(cards.Count)];
    players[i].HeldCards.Add(card);
    cards.Remove(card);
    if (cards.Count == 2)
    {
        break;
    }
}

foreach (var player in players)
{
    Console.WriteLine(player.ToString());
}

Console.WriteLine("The skat contains:\n" + String.Join('\n', cards.Select(c => c.ToString())));
