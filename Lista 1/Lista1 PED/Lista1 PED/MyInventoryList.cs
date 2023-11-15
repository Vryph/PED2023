using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista1_PED
{
    internal class MyInventoryList<Valuetype>
    {
        private MyInventoryNode<ValueType>? head;
        private MyInventoryNode<ValueType>? tail;

        public MyInventoryNode<ValueType>? Head => head;
        public MyInventoryNode<ValueType>? Tail => tail;
        public float weight = 0.0f;

        

        public MyInventoryList() {
            head = null;
            tail = null;
        }
        //Adiciona um valor ao final da lista
        public void Append(ValueType value, string itemName)
        {
            if (value == null || itemName == null) { }
            else
            {

                var newNode = new MyInventoryNode<ValueType>(value, itemName);
                if (tail != null) { newNode.InsertAfter(tail); }
                tail = newNode;

                if (head == null)
                {
                    head = newNode;
                }
            }
        }

        //Adiciona um valor no início da lista
        public void Preppend(ValueType value, string itemName)
        {
            if (value == null || itemName == null) { }
            else
            {
                var newNode = new MyInventoryNode<ValueType>(value, itemName);
                if (head != null) { newNode.InsertBefore(head); }
                head = newNode;

                if (tail == null)
                {
                    tail = newNode;
                }
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


        //Devolve o valor que existe no index fornecido
        public ValueType? GetValue(int index)
        {
            MyInventoryNode<ValueType>? current = head;
            int indexCount = 0;
            
            while(indexCount != index)
            {
                if(current == null)
                {
                    return null;
                }
                current = current.Next;
                indexCount++;
            }
            if (current == null) { return null; }
            return current.value;
        }

        public string? GetName(int index)
        {
            MyInventoryNode<ValueType>? current = head;
            int indexCount = 0;

            while (indexCount != index)
            {
                if (current == null)
                {
                    return null;
                }
                current = current.Next;
                indexCount++;
            }
            if (current == null) { return null; }
            return current.itemName;
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

        //Remove todos os itens que tenham o valor fornecido
        public void Remove(ValueType? value)
        {
            MyInventoryNode<ValueType>? current = head;
            MyInventoryNode<ValueType>? nextNode = head;
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
            Console.WriteLine(" ID | PESO | NOME ");
            Console.WriteLine("---------------------------");
            while(current != null)
            {
                Console.WriteLine($"{String.Format("{0: 00}", index)} | {String.Format("{0:0.00}", current.value)} | { current.itemName }");
                index++;
                current = current.Next;
            }
            Console.WriteLine();
        }

        //Deleta a lista e cria três peças aleatórias de Loot
        public void RandomizeLoot()
        {
            MyInventoryList<float> allLootList = new MyInventoryList<float>();
            allLootList.Clear();
            allLootList.Append(3.00f, "pedra");
            allLootList.Append(1.50f, "machado");
            allLootList.Append(0.50f, "joia");
            allLootList.Append(0.25f, "fruta");
            allLootList.Append(1.00f, "arco");
            allLootList.Append(2.00f, "espada");
            allLootList.Append(1.50f, "enxada");
            allLootList.Append(1.00f, "balde");
            allLootList.Append(1.25f, "escudo");
            allLootList.Append(0.10f, "flecha");
            Random rng = new Random();
            Clear();
            for(int i = 0; i < 3; i++)
            {
                int drop = rng.Next(0, 10);
                Append(allLootList.GetValue(drop), allLootList.GetName(drop));
            }
        }
    }
}
