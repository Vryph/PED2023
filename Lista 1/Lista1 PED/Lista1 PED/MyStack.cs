using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista1_PED
{
    internal class MyStack<ValueType>
    {
        private MyNode<ValueType>? top;
        public MyStack(){ top = null;}

        //Insere o Valor no topo da Pilha
        public void Push(ValueType value)
        {
            MyNode<ValueType> newNode = new MyNode<ValueType>(value);
            if(top != null){newNode.InsertAfter(top);}
            top = newNode;
        }

        //Retorna o valor no topo da pilha e então o remove
        public ValueType? Pop()
        {
            if (top != null) 
            { 
                var value = top.value;
                MyNode<ValueType>? nextNode = top.Previous;
                top.Detach();
                top = nextNode;
                return value;
            }
            return default;
        }

        //Retorna o valor no topo da pilha
        public ValueType? Peek()
        {
            if (top != null)
            {
                return top.value;
            }
            return default;
        }

        //Remove todos os valores da pilha
        public void Clear()
        {
            MyNode<ValueType>? current = top;
            MyNode<ValueType>? nextNode = top;
            while (nextNode != null)
            {
                nextNode = nextNode.Previous;
                current.Detach();
                current = nextNode;
            }
            top = null;
        }

        //Retorna o número de Valores na Pilha
        public int Count()
        {
            MyNode<ValueType>? current = top;
            int count = 0;
            while (current != null)
            {
                count++;
                current = current.Previous;
            }
            return count;
        }

        public string PrintTower()
        {
            int count = Count();
            if(count == 0)
            {
                return ("-------------");
            }
            else if(count == 3)
            {
                return ($"-(C)-(B)-(A)-");
            }
            else if(count == 2)
            {
                string top = Peek().ToString();
                if(top == "A")
                {
                    return ($"-(B)-(A)-----");
                }
                else
                {
                    return ($"-(C)-(B)-----");
                }
            }
            else
            {
                string top = Peek().ToString();
                return ($"-({top})---------");
            }
        }
    }
}
