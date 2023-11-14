using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista1_PED
{
    internal class MyLinkedList<Valuetype>
    {
        MyNode<ValueType>? head;
        MyNode<ValueType>? tail;

        public MyLinkedList() {
            head = null;
            tail = null;
        }

        //Adiciona um valor ao final da lista
        public void Append(ValueType value)
        {
            var newNode = new MyNode<ValueType>(value);
            if (tail != null) { newNode.InsertAfter(tail);}
            tail = newNode;

            if( head == null)
            {
                head = newNode;
            }
        }

        //Adiciona um valor no início da lista
        public void Preppend(ValueType value)
        {
            var newNode = new MyNode<ValueType>(value);
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
            MyNode<ValueType>? current = head;
            MyNode<ValueType>? nextnode = head;
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
            MyNode<ValueType>? current = head;
            int count = 0;

            while(current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        //Imprime a Lista no Console
        public void Print()
        {
            MyNode<ValueType>? current = head;
            Console.WriteLine($"Linked List: ");

            while(current != null)
            {
                Console.Write($"{current.value} - ");
                current = current.Next;
            }

            if(head == null)
            {
                Console.Write("A lista está vazia.");
            }
            Console.WriteLine();
        }

        //Devolve o valor que existe no index fornecido
        public ValueType? Get(int index)
        {
            MyNode<ValueType>? current = head;
            int indexCount = 0;
            
            while(indexCount != index)
            {
                if(current == null)
                {
                    break;
                }
                current = current.Next;
                indexCount++;
            }
            return current.value;
        }

        //Retorna verdadeiro se o valor fornecido existe na lista
        public bool Contains(ValueType value)
        {
            MyNode<ValueType>? current = head;
            while(current != null)
            {
                if(current.value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        //Remove todos os itens que tenham o valor fornecido
        public void Remove(ValueType? value)
        {
            MyNode<ValueType>? current = head;
            MyNode<ValueType>? nextNode = head;
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
            MyNode<ValueType>? current = head;
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

            current.Detach();
        }
    }
}
