using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;
using Skat.StateMachineTranslator;

var contents = File.ReadAllText(@"..\..\..\..\BiddingStateMachine.canvas");
Root root = CanvasDeserializer.Deserialize(contents);

var transitions = from node in root.nodes
                  join edge in root.edges
                  on node.id equals edge.fromNode
                  where edge.label != null
                  select new Transition
                  {
                      StateId = node.id,
                      State = node.text,
                      Event = getEvent(edge),
                      NextState = edge.toNode,
                      Action = getAction(edge)
                  };

static string getEvent(Edge edge)
{
    var index = edge.label.IndexOf(';');

    if (index == -1)
        return edge.label;
    
    return edge.label[..index];
}

static string getAction(Edge edge)
{
    var index = edge.label.IndexOf(';');

    if (index == -1)
        return "";

    return edge.label[(index + 2)..];
}

Console.WriteLine(JsonSerializer.Serialize(transitions, new JsonSerializerOptions { WriteIndented = true }));

