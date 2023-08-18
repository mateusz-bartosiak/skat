using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Skat.StateMachineTranslator
{
    internal class CanvasDeserializer
    {
        public static Root Deserialize(string contents)
        {
            return JsonSerializer.Deserialize<Root>(contents);
        }
    }
    public class Edge
    {
        public string fromNode { get; set; }
        public string toNode { get; set; }
        public string label { get; set; }
    }

    public class Node
    {
        public string text { get; set; }
        public string id { get; set; }
    }

    public class Root
    {
        public List<Node> nodes { get; set; }
        public List<Edge> edges { get; set; }
    }


}
