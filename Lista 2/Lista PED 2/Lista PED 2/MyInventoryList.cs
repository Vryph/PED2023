using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista2_PED
{
    internal class MyInventoryList<Valuetype>
    {
        private MyInventoryNode<ValueType>? head;
        private MyInventoryNode<ValueType>? tail;

        public MyInventoryNode<ValueType>? Head => head;
        public MyInventoryNode<ValueType>? Tail => tail;

        

        public MyInventoryList() {
            head = null;
            tail = null;
        }

        //Adiciona um valor ao final da lista
        public void Append(ValueType value, string itemName, float cooldown)
        {
            if (value == null || itemName == null) { }
            else
            {

                var newNode = new MyInventoryNode<ValueType>(value, itemName, cooldown);
                if (tail != null) { newNode.InsertAfter(tail); }
                tail = newNode;

                if (head == null)
                {
                    head = newNode;
                }
            }
        }


        //Adiciona um valor no início da lista
        public void Preppend(ValueType value, string itemName, float cooldown)
        {
            if (value == null || itemName == null) { }
            else
            {
                var newNode = new MyInventoryNode<ValueType>(value, itemName, cooldown);
                if (head != null) { newNode.InsertBefore(head); }
                head = newNode;

                if (tail == null)
                {
                    tail = newNode;
                }
            }
        }


        //Insere um novo Node no indice especificado
        public void Insert(ValueType value, string itemName, float cooldown, int index)
        {
            MyInventoryNode<ValueType>? node = GetNodeByIndex(index);
            if(index <= 0) { Preppend(value, itemName, cooldown); }
            else if( node == null) { Append(value, itemName, cooldown); }
            else
            {
                var newNode = new MyInventoryNode<ValueType>(value, itemName, cooldown);
                newNode.InsertBefore(node);
            }

        }


        //Limpa todos os valores da lista
        public void Clear()
        {
            MyInventoryNode<ValueType>? current = head;
            MyInventoryNode<ValueType>? nextnode = head;
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
            MyInventoryNode<ValueType>? current = head;
            int count = 0;

            while(current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }


        //Retorna o Nó no índice especificado
        public MyInventoryNode<ValueType> GetNodeByIndex(int index)
        {
            MyInventoryNode<ValueType>? node = head;
            int currentIndex = 0;
            while(currentIndex != index)
            {
                if (node == null) { break; }
                node = node.Next;
                currentIndex++;
            }
            return node;
        }

        public int GetNodeIndex(MyInventoryNode<ValueType>? node)
        {
            MyInventoryNode<ValueType>? current = head;
            int indexCount = 0;
            while (current.itemName != node.itemName)
            {
                if (current == null) { break; }
                current = current.Next;
                indexCount++;
            }
            return indexCount;
        }


        //Retorna verdadeiro se o valor fornecido existe na lista
        public bool Contains(ValueType value)
        {
            MyInventoryNode<ValueType>? current = head;
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


        //Remove um node fornecido
        public void RemoveNode(MyInventoryNode<ValueType> node)
        {
            if (node == null) { return; }
            
            if(node == head) { head = node.Next; }
            if(node == tail) { tail = node.Previous; }

            node.Detach();
        }


        //Remove o valor no index fornecido
        public void RemoveAt(int index)
        {
            MyInventoryNode<ValueType>? current = head;
            int indexCount = 0;

            while (indexCount != index)
            {
                if(current == null)
                {
                    break;
                }
                current = current.Next;
                indexCount++;
            }

            if (current != null)
            {
                if (head == current) { head = current.Next; }
                if (tail == current) { tail = current.Previous; }
                current.Detach();
            }
            else
            {
                Console.WriteLine("OPCAO INVALIDA");
            }
        }


        //Imprime a Lista no Console
        public void Print()
        {
            int index = 00;
            MyInventoryNode<ValueType>? current = head;
            Console.WriteLine(" ID |    NOME    | DANO | COOL | DPS");
            Console.WriteLine("-------------------------------------");
            while(current != null)
            {
                Console.WriteLine($"{String.Format("{0: 00}", index)} | { String.Format("{0, -10}", current.itemName) } | {String.Format("{0, -4}",String.Format("{0:0.0}", current.value))} | {String.Format("{0:0.00}", current.cooldown)} | {String.Format("{0:0.0}", current.dps)}");
                index++;
                current = current.Next;
            }
            Console.WriteLine();
        }

        //"Troca" os Nodes de Lugar
        public void SwapNodes(MyInventoryNode<ValueType> node1, MyInventoryNode<ValueType> node2)
        {
            
            int tempIndex = GetNodeIndex(node1);
            if (tempIndex != GetNodeIndex(node2))
            {
                if (tempIndex < GetNodeIndex(node2))
                {
                    Insert(node1.value, node1.itemName, node1.cooldown, GetNodeIndex(node2));
                    RemoveNode(node1);
                    Insert(node2.value, node2.itemName, node2.cooldown, tempIndex);
                    RemoveNode(node2);
                }
                else
                {
                    tempIndex = GetNodeIndex(node2);
                    Insert(node2.value, node2.itemName, node2.cooldown, GetNodeIndex(node1));
                    RemoveNode(node2);
                    Insert(node1.value, node1.itemName, node1.cooldown, tempIndex);
                    RemoveNode(node1);
                }
            }
        }


        //Sorts---------------------------------------------------------------------------------
        public void BubbleSort()
        {
            int n = Count(), i, j;
            bool swapped;
            MyInventoryNode<ValueType>? node1, node2;
            for(i = 0; i < n - 1; i++)
            {
                swapped = false;
                for( j = 0; j < n - 1; j++)
                {
                    node1 = GetNodeByIndex(j);
                    node2 = node1.Next;
                    if(node1.cooldown > node2.cooldown) { swapped = true; SwapNodes(node1, node2); }

                }
                if(swapped == false) { break; }
            }
        }
    }
}
