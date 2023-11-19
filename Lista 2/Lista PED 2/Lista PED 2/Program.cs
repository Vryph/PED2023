using Lista2_PED;

//Setup Lista de Itens -------------------------------------------------------------------------
MyInventoryList<float> itemsList = new MyInventoryList<float>();
itemsList.Append(2.0f, "espada", 1.0f);
itemsList.Append(10.0f, "machado", 3.5f);
itemsList.Append(0.8f, "adaga", 0.5f);
itemsList.Append(0.2f, "punhos", 0.3f);
itemsList.Append(1.5f, "arco", 1.5f);
itemsList.Append(3.0f, "alabarda", 2.5f);
itemsList.Append(0.3f, "estilingue", 2.0f);
itemsList.Append(7.0f, "marreta", 2.5f);
itemsList.Append(2.5f, "pique", 1.0f);
itemsList.Append(1.5f, "cutelo", 0.8f);
int inventoryState = 0;
string order = "crescente", method = "nome", algorithm = "bubble sort";
//Setup Enciclopedia ---------------------------------------------------------------------------
TreeNode<string> treeRoot = new TreeNode<string>("RAIZ", "boas vindas", "Seja bem-vindo à enciclopédia!", null);
treeRoot.AddChild("CATEGORIA", "armas", "A arma correta é essencial para seu sucesso em uma batalha.");
treeRoot.AddChild("CATEGORIA", "habilidades", "Habilidades definem sua capacidade de combate.");
treeRoot.AddChild("CATEGORIA", "consumíveis", "Consumíveis dão vantagens temporárias em batalha.");

treeRoot.GetChild(0).AddChild("ARMA", "punhos", "Quando todos recursos se esgotam, é preciso lutar com as próprias mãos.");
treeRoot.GetChild(0).AddChild("ARMA", "espada", "Com uma lâmina afiada, a espada é uma opção bastante versátil.");
treeRoot.GetChild(0).AddChild("ARMA", "arco", "Ideal para os antissociais, permite atingir os adversários de longe.");

treeRoot.GetChild(1).AddChild("HABILIDADE", "defesa", "Quanto maior a habilidade de defesa, menor o dano tomado ao receber um ataque.");
treeRoot.GetChild(1).AddChild("HABILIDADE", "ataque", "Quanto maior a habilidade de ataque, maior o dano aplicado ao usar uma arma.");

treeRoot.GetChild(2).AddChild("CONSUMÍVEL", "curativo", "Restaura imediatamente um pouco dos seus pontos de vida.");
treeRoot.GetChild(2).AddChild("CONSUMÍVEL", "fruta", "Sacia a fome, evitando a perda de pontos de vida.");
treeRoot.GetChild(2).AddChild("CONSUMÍVEL", "água", "Sacia a sede, evitando a perda de pontos de vida.");

TreeNode<string> selectedNode = treeRoot;



Menu();

void Menu()
{
    selectedNode = treeRoot;

    //Menu Options ----------------------------------------
    Console.Clear();
    Console.WriteLine($"Escolha uma das opcoes dos exercícios: ");
    Console.WriteLine($"1 - Algorítmos de Ordenação");
    Console.WriteLine($"2 - Enciclopédia - Árvores");
    Console.WriteLine($"3 - Grafo de Habilidades");
    string opcao = Console.ReadLine();
    if (opcao == "1") { Sorting(); }
    else if (opcao == "2") { Wiki(); }
    else { opcao = "0"; Menu(); }
}

void Sorting()
{
    Console.Clear();
    switch (inventoryState)
    {
        case < 1:
            Sort();
            itemsList.Print();

            Console.WriteLine(); Console.WriteLine("SELECIONE UMA OPCAO:");
            Console.WriteLine($"0 - mudar algoritmo [{algorithm}]");
            Console.WriteLine($"1 - mudar ordem [{order}]");
            Console.WriteLine($"2 - mudar criterio [{method}]");
            Console.WriteLine($"Aperte Qualquer outra coisa para sair.");
            string option = Console.ReadLine();
            if (option == "0") { inventoryState = 1; }
            else if (option == "1") { inventoryState = 2; }
            else if (option == "2") { inventoryState = 3; }
            else { Menu(); }
            Sorting();
            break;
        case < 2:
            Console.WriteLine(" 0 - bubble sort");
            Console.WriteLine(" 1 - selection sort");
            Console.WriteLine(" 2 - merge sort");
            Console.WriteLine(" 3 - quick sort");
            string option1 = Console.ReadLine();
            if (option1 == "0") { algorithm = "bubble sort" ; }
            else if (option1 == "1") { algorithm = "selection sort"; }
            else if (option1 == "2") { algorithm = "merge sort"; }
            else if (option1 == "3") { algorithm = "quick sort"; }
            inventoryState = 0;
            Sorting();
            break;
        case < 3:
            Console.WriteLine(" 0 - CRESCENTE");
            Console.WriteLine(" 1 - DECRESCENTE");
            string option2 = Console.ReadLine();
            if (option2 == "0") { order = "crescente"; }
            else if (option2 == "1") { order = "decrescente"; }
            inventoryState = 0;
            Sorting();
            break;
        case < 4:
            Console.WriteLine(" 0 - nome");
            Console.WriteLine(" 1 - dano");
            Console.WriteLine(" 2 - cooldown");
            Console.WriteLine(" 3 - dano por segundo");
            string option3 = Console.ReadLine();
            if (option3 == "0") { method = "nome"; }
            else if (option3 == "1") { method = "dano"; }
            else if (option3 == "2") { method = "cooldown"; }
            else if (option3 == "3") { method = "dano por segundo"; }
            inventoryState = 0;
            Sorting();
            break;
        default:
            break;
    }
}


void Sort()
{
    if(algorithm == "bubble sort")
    {
        switch (method)
        {
            case "nome":
                if(order == "crescente") { itemsList.BubbleSort((a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 3); break; }
                else { itemsList.BubbleSort((a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 3); break; }
            case "dano":
                if (order == "crescente") { itemsList.BubbleSort((a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 0); break; }
                else { itemsList.BubbleSort((a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 0); break; }
            case "cooldown":
                if (order == "crescente") { itemsList.BubbleSort((a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 1); break; }
                else { itemsList.BubbleSort((a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 1); break; }
            case "dano por segundo":
                if (order == "crescente") { itemsList.BubbleSort((a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 2); break; }
                else { itemsList.BubbleSort((a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 2); break; }
            default:
                break;
        }
    }
    else if (algorithm == "selection sort")
    {
        switch (method)
        {
            case "nome":
                if (order == "crescente") { itemsList.SelectionSort((a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 3); break; }
                else { itemsList.SelectionSort((a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 3); break; }
            case "dano":
                if (order == "crescente") { itemsList.SelectionSort((a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 0); break; }
                else { itemsList.SelectionSort((a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 0); break; }
            case "cooldown":
                if (order == "crescente") { itemsList.SelectionSort((a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 1); break; }
                else { itemsList.SelectionSort((a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 1); break; }
            case "dano por segundo":
                if (order == "crescente") { itemsList.SelectionSort((a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 2); break; }
                else { itemsList.SelectionSort((a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 2); break; }
            default:
                break;
        }
    }
    else if (algorithm == "merge sort")
    {
        switch (method)
        {
            case "nome":
                if (order == "crescente") { itemsList.MergeSortSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 3); break; }
                else { itemsList.MergeSortSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 3); break; }
            case "dano":
                if (order == "crescente") { itemsList.MergeSortSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 0); break; }
                else { itemsList.MergeSortSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 0); break; }
            case "cooldown":
                if (order == "crescente") { itemsList.MergeSortSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 1); break; }
                else { itemsList.MergeSortSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 1); break; }
            case "dano por segundo":
                if (order == "crescente") { itemsList.MergeSortSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 2); break; }
                else { itemsList.MergeSortSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 2); break; }
            default:
                break;
        }
    }
    else if (algorithm == "quick sort")
    {
        switch (method)
        {
            case "nome":
                if (order == "crescente") { itemsList.QuickSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 3); break; }
                else { itemsList.QuickSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 3); break; }
            case "dano":
                if (order == "crescente") { itemsList.QuickSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 0); break; }
                else { itemsList.QuickSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 0); break; }
            case "cooldown":
                if (order == "crescente") { itemsList.QuickSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 1); break; }
                else { itemsList.QuickSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 1); break; }
            case "dano por segundo":
                if (order == "crescente") { itemsList.QuickSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) > float.Parse(b.ToString()), 2); break; }
                else { itemsList.QuickSort(0, itemsList.Count() - 1, (a, b) => float.Parse(a.ToString()) < float.Parse(b.ToString()), 2); break; }
            default:
                break;
        }
    }
}

void Wiki()
{
    Console.Clear();
    Console.WriteLine("WIKI");

    selectedNode.Print();
    if(selectedNode == treeRoot)
    {
        Console.WriteLine();
        Console.WriteLine("Aperte qualquer outra coisa para voltar ao Menu.");

        string option = Console.ReadLine();
        if(int.TryParse(option, out int index))
        {
            if (index < selectedNode.ChildCount()) { selectedNode = selectedNode.GetChild(index); }
            else { Menu(); }
        }
        else { Menu(); }
    }
    else
    {
        string option = Console.ReadLine();
        if (int.TryParse(option, out int index))
        {
            
            if (index <= selectedNode.ChildCount() && index != 0) { selectedNode = selectedNode.GetChild(index - 1); }
            else { selectedNode = selectedNode.GetParent(); }
        }
        else { selectedNode = selectedNode.GetParent(); }
    }

    Wiki();

}