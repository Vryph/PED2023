using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista2_PED
{
    internal class GraphNodeConnection
    {
        public GraphNode node;
        public int exp;
        public GraphNodeConnection(GraphNode node, int exp)
        {
            this.node = node;
            this.exp = exp;
        }
    }
}
