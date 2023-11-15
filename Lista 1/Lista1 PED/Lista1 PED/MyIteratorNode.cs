using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista1_PED
{
    internal class MyIteratorNode<DataType>
    {
        public DataType value;
        private MyIteratorNode<DataType>? previous;
        private MyIteratorNode<DataType>? next;

        public MyIteratorNode<DataType>? Previous => previous;
        public MyIteratorNode<DataType>? Next => next;

        public MyIteratorNode(DataType value)
        {
            this.value = value;
            this.previous = null;
            this.next = null;
        }

        //Insere o Nó Depois do Nó fornecido.
        public void InsertAfter(MyIteratorNode<DataType> previousNode)
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
        public void InsertBefore(MyIteratorNode<DataType> nextNode)
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
