﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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

        //Retorna o índice do nó especificado, usando o nome(situacional).
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

        //Retorna o Node com o nome especificado
        public MyInventoryNode<ValueType> GetNodeByName(string name)
        {
            MyInventoryNode<ValueType>? current = head;
            int indexCount = 0;
            while (current.itemName != name)
            {
                if (current == null) { break; }
                current = current.Next;
                indexCount++;
            }
            return current;
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
            if (GetNodeIndex(node1) != GetNodeIndex(node2))
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
        }


        //Sorts---------------------------------------------------------------------------------
        public void BubbleSort(Func<ValueType, ValueType, bool> predicate, int type)
        {
            int n = Count(), i, j;
            bool swapped;
            MyInventoryNode<ValueType>? node1, node2;
            for(i = 0; i < n - 1; i++)
            {
                swapped = false;
                for( j = 0; j < n - i - 1; j++)
                {
                    node1 = GetNodeByIndex(j);
                    node2 = node1.Next;

                    switch (type)
                    {
                        case < 1:
                            if(predicate(node1.value, node2.value)) { swapped = true; SwapNodes(node1, node2); }
                            break;
                        case < 2:
                            if (predicate(node1.cooldown, node2.cooldown)) { swapped = true; SwapNodes(node1, node2); }
                            break;
                        case < 3:
                            if (predicate(node1.dps, node2.dps)) { swapped = true; SwapNodes(node1, node2); }
                            break;
                        case < 4:
                            if (predicate(String.Compare(node1.itemName, node2.itemName), 0)) { swapped = true; SwapNodes(node1, node2); }
                            break;
                        default:
                            break;
                    }

                }
                if(swapped == false) { break; }
            }
        }


        public void SelectionSort(Func<ValueType, ValueType, bool> predicate, int type)
        {
            int n = Count(), i, j;
            MyInventoryNode<ValueType>? nodeI, nodeJ, nodeMin;
            for(i = 0; i < n - 1; i++)
            {
                nodeI = nodeMin = GetNodeByIndex(i);
                for (j = i + 1; j < n; j++)
                {
                    nodeJ = GetNodeByIndex(j);
                    switch (type)
                    {
                        case < 1:
                            if (predicate(nodeMin.value, nodeJ.value)) { nodeMin = nodeJ; }
                            break;
                        case < 2:
                            if (predicate(nodeMin.cooldown, nodeJ.cooldown)) { nodeMin = nodeJ; }
                            break;
                        case < 3:
                            if (predicate(nodeMin.dps, nodeJ.dps)) { nodeMin = nodeJ; }
                            break;
                        case < 4:
                            if (predicate(String.Compare(nodeMin.itemName, nodeJ.itemName), 0)) { nodeMin = nodeJ; }
                            break;
                        default:
                            break;
                    }
                }
                SwapNodes(nodeI, nodeMin);
            }
        }


        public void MergeSortSort(int l, int r, Func<ValueType, ValueType, bool> predicate, int type)
        {
            if(l < r)
            {
                int m = l + (r - l) / 2;
                MergeSortSort(l, m, predicate, type);
                MergeSortSort(m + 1, r, predicate, type);

                MergeSortMerge(l, m, r, predicate, type);
            }
        }

        public void MergeSortMerge(int l, int m, int r, Func<ValueType, ValueType, bool> predicate, int type)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            MyInventoryList<ValueType> L = new MyInventoryList<ValueType>();
            MyInventoryList<ValueType> R = new MyInventoryList<ValueType>();
            int i, j;

            for(i = 0; i < n1; i++)
            {
                MyInventoryNode<ValueType> tempNodeL = GetNodeByIndex(l + i);
                L.Append(tempNodeL.value, tempNodeL.itemName, tempNodeL.cooldown);
            }
            for(j=0; j < n2; j++)
            {
                MyInventoryNode<ValueType> tempNodeR = GetNodeByIndex(m + 1 + j);
                R.Append(tempNodeR.value, tempNodeR.itemName, tempNodeR.cooldown);
            }

            i = j = 0;

            int k = l;
            while(i < n1 && j < n2)
            {
                MyInventoryNode<ValueType> nodeL = L.GetNodeByIndex(i), nodeR = R.GetNodeByIndex(j);
                switch (type)
                {
                    case < 1:
                        if (predicate(nodeR.value, nodeL.value)) { SwapNodes(GetNodeByIndex(k),GetNodeByName(nodeL.itemName)); i++; }
                        else { SwapNodes(GetNodeByIndex(k),GetNodeByName(nodeR.itemName)); j++; }
                        break;
                    case < 2:
                        if (predicate(nodeR.cooldown, nodeL.cooldown)) { SwapNodes(GetNodeByIndex(k), GetNodeByName(nodeL.itemName)); i++; }
                        else { SwapNodes(GetNodeByIndex(k), GetNodeByName(nodeR.itemName)); j++; }
                        break;
                    case < 3:
                        if (predicate(nodeR.dps, nodeL.dps)) { SwapNodes(GetNodeByIndex(k), GetNodeByName(nodeL.itemName)); i++; }
                        else { SwapNodes(GetNodeByIndex(k), GetNodeByName(nodeR.itemName)); j++; }
                        break;
                    case < 4:
                        if (predicate(String.Compare(nodeR.itemName, nodeL.itemName), 0)) { SwapNodes(GetNodeByIndex(k), GetNodeByName(nodeL.itemName)); i++; }
                        else { SwapNodes(GetNodeByIndex(k), GetNodeByName(nodeR.itemName)); j++; }
                        break;
                    default:
                        break;
                }
                k++;
            }

            while(i< n1)
            {
                MyInventoryNode<ValueType> nodeL = L.GetNodeByIndex(i);
                SwapNodes(GetNodeByIndex(k), GetNodeByName(nodeL.itemName)); i++; k++;
            }

            while(j < n2)
            {
                MyInventoryNode<ValueType>  nodeR = R.GetNodeByIndex(j);
                SwapNodes(GetNodeByIndex(k), GetNodeByName(nodeR.itemName)); j++; k++;
            }
        }

        public void QuickSort(int low, int high, Func<ValueType, ValueType, bool> predicate, int type)
        {
            if(low < high)
            {
                int pi = QuickSortPartition(low, high, predicate, type);

                QuickSort(low, pi - 1, predicate, type);
                QuickSort(pi + 1, high, predicate, type);
            }
        }

        public int QuickSortPartition(int low, int high, Func<ValueType, ValueType, bool> predicate, int type)
        {
            MyInventoryNode<ValueType> pivot = GetNodeByIndex(high);

            int i = (low - 1), j;

            for(j = low; j <= high - 1; j++)
            {
                MyInventoryNode<ValueType> nodeJ = GetNodeByIndex(j);
                switch (type)
                {
                    case < 1:
                        if (predicate(pivot.value, nodeJ.value)) { i++;  SwapNodes(GetNodeByIndex(i), nodeJ); }
                        break;
                    case < 2:
                        if (predicate(pivot.cooldown, nodeJ.cooldown)) { i++; SwapNodes(GetNodeByIndex(i), nodeJ); }
                        break;
                    case < 3:
                        if (predicate(pivot.dps, nodeJ.dps)) { i++; SwapNodes(GetNodeByIndex(i), nodeJ); }
                        break;
                    case < 4:
                        if (predicate(String.Compare(pivot.itemName, nodeJ.itemName), 0)) { i++; SwapNodes(GetNodeByIndex(i), nodeJ); }
                        break;
                    default:
                        break;
                }
            }
            SwapNodes(GetNodeByIndex(i + 1), GetNodeByIndex(high));
            return (i + 1);
        }
    }
}
