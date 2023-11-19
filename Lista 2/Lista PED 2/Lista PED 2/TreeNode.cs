using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista2_PED
{
    internal class TreeNode<ValueType>
    {
        ValueType value;
        TreeNode<ValueType> parent;
        List<TreeNode<ValueType>> children = new List<TreeNode<ValueType>>();

        string title, description;

        public TreeNode(ValueType value, string title, string description, TreeNode<ValueType>? parent)
        {
            this.value = value;
            this.title = title;
            this.description = description;
            this.parent = null;
            if(parent != null)
            {
                this.parent = parent;
            }
        }


        //Adiciona um novo Nó filho
        public void AddChild(ValueType value, string title, string description)
        {
            if (value != null)
            {
                TreeNode<ValueType> newNode = new TreeNode<ValueType>(value, title, description, this);
                children.Add(newNode);
            }
        }

        //Retorna o valor do Nó filho no index fornecido
        public TreeNode<ValueType> GetChild(int index)
        {
            if (children[index] != null)
            {
                return children[index];
            }
            return default;
        }

        //Retorna o Nó pai
        public TreeNode<ValueType> GetParent()
        {
            if(parent != null) {  return parent; }
            else { return this; }
        }

        //Imprime a árvore de acordo com a necessidade do exercício
        public void Print()
        {
            Console.WriteLine($"{title}: ");
            Console.WriteLine($"    {description}");
            Console.WriteLine();

            int index, n = children.Count;
            if (this.value.ToString() != "RAIZ") { Console.WriteLine($"0 - voltar"); }

            for ( index = 0; index < n; index++)
            {
                if (this.value.ToString() == "RAIZ") { Console.WriteLine($"{index} - {children[index].title}"); }
                else { Console.WriteLine($"{index + 1} - {children[index].title}"); }
            }
        }

        //Retorna o número de filhos que o nó tem
        public int ChildCount()
        {
            return (children.Count);
        }
    }
}
