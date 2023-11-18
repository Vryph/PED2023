using Lista2_PED;

//Setup Lista de Itens
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

Menu();

void Menu()
{
    //Menu Options ----------------------------------------
    Console.Clear();
    Console.WriteLine($"Escolha uma das opcoes dos exercícios: ");
    Console.WriteLine($"1 - Algorítmos de Ordenação");
    Console.WriteLine($"2 - Enciclopédia - Árvores");
    Console.WriteLine($"3 - Grafo de Habilidades");
    string opcao = Console.ReadLine();
    if (opcao == "1") { Sorting(); }
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
}