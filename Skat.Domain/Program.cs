using Skat;

var players = new Player[]
{
    new Player("Player 1"),
    new Player("Player 2"),
    new Player("Player 3")
};

//var rand = new Random();

//for (int i = 0; true; i++)
//{
//    i %= 3;
//    var card = cards[rand.Next(cards.Count)];
//    players[i].HeldCards.Add(card);
//    cards.Remove(card);
//    if (cards.Count() == 2)
//        break;
//}
//var skat = cards; // 2 cards remain

//foreach (var player in players)
//{
//    Console.WriteLine(player.ToString());
//}

//Console.WriteLine("The skat contains:\n" + String.Join('\n', skat.Select(c => c.ToString())));
