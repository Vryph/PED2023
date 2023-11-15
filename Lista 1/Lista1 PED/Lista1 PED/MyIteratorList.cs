using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista1_PED
{
    internal class MyIteratorList<DataType>
    {
        private MyIteratorNode<DataType>? head;
        private MyIteratorNode<DataType>? tail;

        public MyIteratorNode<DataType>? Head => head;
        public MyIteratorNode<DataType>? Tail => tail;

        public MyIteratorList()
        {
            head = null;
            tail = null;
        }

        //Adiciona um valor ao final da lista
        public void Append(DataType value)
        {
            var newNode = new MyIteratorNode<DataType>(value);
            if (tail != null) { newNode.InsertAfter(tail); }
            tail = newNode;

            if (head == null)
            {
                head = newNode;
            }
        }

        //Adiciona um valor no início da lista
        public void Preppend(DataType value)
        {
            var newNode = new MyIteratorNode<DataType>(value);
            if (head != null) { newNode.InsertBefore(head); }
            head = newNode;

            if (tail == null)
            {
                tail = newNode;
            }
        }

        //Limpa todos os valores da lista
        public void Clear()
        {
            MyIteratorNode<DataType>? current = head;
            MyIteratorNode<DataType>? nextnode = head;
            while (nextnode != null)
            {
                nextnode = nextnode.Next;
                current.Detach();
                current = nextnode;
            }
            head = tail = null;
        }

        //Devolve o número de elementos da lista
        public int Count()
        {
            MyIteratorNode<DataType>? current = head;
            int count = 0;

            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        //Imprime a Lista no Console
        public void Print()
        {
            MyIteratorNode<DataType>? current = head;
            Console.WriteLine($"Linked List: ");

            while (current != null)
            {
                Console.Write($"{current.value} - ");
                current = current.Next;
            }

            if (head == null)
            {
                Console.Write("A lista está vazia.");
            }
            Console.WriteLine();
        }

        //Devolve o valor que existe no index fornecido
        public DataType? Get(int index)
        {
            MyIteratorNode<DataType>? current = head;
            int indexCount = 0;

            while (indexCount != index)
            {
                if (current == null)
                {
                    break;
                }
                current = current.Next;
                indexCount++;
            }
            return current.value;
        }

        //Retorna verdadeiro se o valor fornecido existe na lista
        public bool Contains(DataType value)
        {
            MyIteratorNode<DataType>? current = head;
            while (current != null)
            {
                if (current.value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        //Remove todos os itens que tenham o valor fornecido
        public void Remove(DataType? value)
        {
            MyIteratorNode<DataType>? current = head;
            MyIteratorNode<DataType>? nextNode = head;
            while (nextNode != null)
            {
                nextNode = nextNode.Next;
                if (current.value.Equals(value))
                {
                    current.Detach();
                }
                current = nextNode;
            }
        }

        //Remove o valor no index fornecido
        public void RemoveAt(int index)
        {
            MyIteratorNode<DataType>? current = head;
            int indexCount = 0;

            while (indexCount != index)
            {
                if (current == null)
                {
                    break;
                }
                current = current.Next;
                indexCount++;
            }

            if (head == current) { head = current.Next; }
            if (tail == current) { tail = current.Previous; }
            current.Detach();
        }

        public MyIterator<DataType> GetMyIterator()
        {
            return new MyIteratorListListIterator<DataType>(this); //Perdão pf o nome era muito engraçado para não usar
        }
    }
    internal class MyIteratorListListIterator<DataType> : MyIterator<DataType>
    {
        private MyIteratorNode<DataType>? node;
        public MyIteratorListListIterator(MyIteratorList<DataType> list)
        {
            node = list.Head;
        }

        public override DataType? Value
        {
            get => node != null ? node.value : default;
            set
            {
                if (node != null)
                {
                    node.value = value;
                }
            }
        }

        public override bool Valid()
        {
            return node != null;
        }

        public override void Next()
        {
            if (node != null) { node = node.Next; }
        }

        public override void Previous()
        {
            if (node != null) { node = node.Previous; }
        }

        public override DataType? Get()
        {
            if(node == null) { return default; }
            return node.value;
        }

        public override void Set(DataType value)
        {
            node.value = value;
        }

        public override void Reset(MyIteratorList<DataType> list)
        {
            node = list.Head;
        }
    }
}
