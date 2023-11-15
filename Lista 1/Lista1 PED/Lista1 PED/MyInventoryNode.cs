using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista1_PED
{
    internal class MyInventoryNode<ValueType>
    {
        public ValueType value;
        public string itemName;
        private MyInventoryNode<ValueType>? previous;
        private MyInventoryNode<ValueType>? next;

        public MyInventoryNode<ValueType>? Previous => previous;
        public MyInventoryNode<ValueType>? Next => next;

        public MyInventoryNode(ValueType value, string itemName)
        {
            this.value = value;
            this.itemName = itemName;
            this.previous = null;
            this.next = null;
        }

        //Insere o Nó Depois do Nó fornecido.
        public void InsertAfter(MyInventoryNode<ValueType> previousNode)
        {
            if (previousNode != null)
            {
                previous = previousNode;
                next = previousNode.next;
                if (next != null)
                {
                    next.previous = this;
                }
                previousNode.next = this;
            }
        }

        //Insere o Nó Antes do Nó fornecido.
        public void InsertBefore(MyInventoryNode<ValueType> nextNode)
        {
            if (nextNode != null)
            {
                next = nextNode;
                previous = nextNode.previous;
                if (previous != null)
                {
                    previous.next = this;
                }
                nextNode.previous = this;
            }
        }

        //Remove o Nó da sequência e então restaura a mesma
        public void Detach()
        {
            if (previous != null)
            {
                previous.next = next;
            }
            if (next != null)
            {
                next.previous = previous;
            }
            next = previous = null;
        }
    }
}
