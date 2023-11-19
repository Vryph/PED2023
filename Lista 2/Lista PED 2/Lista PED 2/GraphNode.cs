using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista2_PED
{
    internal class GraphNode
    {
        string name;
        public string xString = " ";
        public int attack, defense, speed, exp;
        public bool isActive = false;
        List<GraphNodeConnection> neighbours = new List<GraphNodeConnection>();
        public int NeighbourCount => neighbours.Count;
        public string Name => name;



        public GraphNode(string name, int attack, int defense, int speed, int exp)
        {
            this.name = name;
            this.attack = attack;
            this.defense = defense;
            this.speed = speed;
            this.exp = exp;
            if (isActive) { xString = "X"; }
        }

        //Conecta o nó a outro
        public void Connect(GraphNode node)
        {
            if (node == this){ return; }

            int index = neighbours.FindIndex(c => c.node == node);
            if(index != -1) { return; }
            neighbours.Add(new GraphNodeConnection(node, node.exp));
        }

        //Conecta dois nós mutualmente
        public void BidirectionalConnect(GraphNode node)
        {
            Connect(node);
            node.Connect(this);
        }

        public GraphNode? GetNeighbour(int index)
        {
            if(index < neighbours.Count) { return neighbours[index].node; }
            return null;
        }


        public void BreadthFirst(Action<GraphNode> process)
        {
            List<GraphNode> visited = new List<GraphNode> ();
            Queue<GraphNode> toVisit = new Queue<GraphNode> ();
            toVisit.Enqueue(this);

            while(toVisit.Count > 0)
            {
                GraphNode currentNode = toVisit.Dequeue();
                process(currentNode);
                visited.Add(currentNode);
                
                for(int i = 0; i < currentNode.NeighbourCount; i++)
                {
                    GraphNode? neighbour = currentNode.GetNeighbour(i);
                    if(neighbour != null && !toVisit.Contains(neighbour) && !visited.Contains(neighbour))
                    {
                        toVisit.Enqueue(neighbour);
                    }
                }
            }
        }

        public void SetActive()
        {
            if (!isActive)
            {
                isActive = true;
                xString = "X";
            }
        }

        public bool CheckUnlock()
        {
            for(int i = 0; i < NeighbourCount; i++)
            {
                if (neighbours[i].node.isActive && !isActive ) {  return true; }
            }
            return false;
        }

    }
}
