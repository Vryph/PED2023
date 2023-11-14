using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista1_PED
{
    internal class MyQueue<ValueType>
    {
        private MyNode<ValueType>? first;
        private MyNode<ValueType>? last;

        public MyQueue()
        {
            first = null;
            last = null;
        }

        //Insere o valor no final da Fila
        public void Enqueue(ValueType value)
        {
            MyNode<ValueType> newNode = new MyNode<ValueType>(value);
            if (last != null) { newNode.InsertAfter(last); }
            last = newNode;

            if (first == null) { first = newNode; }
        }

        //Remove o valor no início da Fila
        public void Dequeue()
        {
            if (first != null)
            {
                MyNode<ValueType> nextNode = first.Next;
                first.Detach();
                first = nextNode;
            }
        }

        //Retorna o primeiro valor da Fila
        public ValueType? First()
        {
            if (first != null) { return first.value; }
            return default;
        }

        //Retorna o último valor da Fila
        public ValueType? Last()
        {
            if(last != null) { return last.value; }
            return default;
        }

        //Remove todos os valores da Fila
        public void Clear()
        {
            MyNode<ValueType>? current = first;
            MyNode<ValueType>? nextNode = first;
            while(nextNode != null)
            {
                nextNode = nextNode.Next;
                current.Detach();
                current = nextNode;
            }
            first = last = null;
        }

        //Retorna o número de elementos na Fila
        public int Count()
        {
            MyNode<ValueType>? current = first;
            int count = 0;

            while(current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}
