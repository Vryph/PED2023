using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista1_PED
{
    internal class MyNode<ValueType>
    {
        public ValueType value;
        private MyNode<ValueType>? previous;
        private MyNode<ValueType>? next;

        public MyNode<ValueType>? Previous => previous;
        public MyNode<ValueType>? Next => next;

        public MyNode(ValueType value)
        {
            this.value = value;
            this.previous = null;
            this.next = null;
        }

        //Insere o Nó Depois do Nó fornecido.
        public void InsertAfter(MyNode<ValueType> previousNode)
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
        public void InsertBefore(MyNode<ValueType> nextNode)
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
