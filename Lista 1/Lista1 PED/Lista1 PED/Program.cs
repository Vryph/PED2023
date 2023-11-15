using Lista1_PED;

//Setup inventario -----------------------------------------------
MyInventoryList<float> inventoryList = new MyInventoryList<float>();
MyInventoryList<float> lootList = new MyInventoryList<float>();
MyInventoryList<float> allLootList = new MyInventoryList<float>();
allLootList.Append(3.0f, "pedra");
allLootList.Append(1.5f, "machado");
allLootList.Append(0.5f, "joia");
allLootList.Append(0.25f, "fruta");
allLootList.Append(1.0f, "arco");
allLootList.Append(2.0f, "espada");
allLootList.Append(1.5f, "enxada");
allLootList.Append(1.0f, "balde");
allLootList.Append(1.5f, "escudo");
allLootList.Append(0.1f, "flecha");
int inventoryState = 0;
//Setup Hannoi
int hannoiState = 0;
string selectedPiece = "A";
int hannoiCount = 0;
MyStack<string> hannoiTower0 = new MyStack<string>();
MyStack<string> hannoiTower1 = new MyStack<string>();
MyStack<string> hannoiTower2 = new MyStack<string>();

// Inicio Codigo
Menu();

void Menu()
{
    //Clear Minigames --------------------------------------
    inventoryList.Clear();
    lootList.Clear();
    inventoryState = 0;
    hannoiState = 0;
    hannoiCount = 0;
    hannoiTower0.Clear();
    hannoiTower1.Clear();
    hannoiTower2.Clear();
    hannoiTower0.Push("C");
    hannoiTower0.Push("B");
    hannoiTower0.Push("A");

    //Menu Options ----------------------------------------
    Console.Clear();
    Console.WriteLine($"Escolha uma das opcoes dos exercícios: ");
    Console.WriteLine($"1 - Testes das estruturas de dados");
    Console.WriteLine($"2 - Inventário");
    Console.WriteLine($"3 - Torre de Hanoi");
    Console.WriteLine($"4 - Simulador de Boliche");
    string opcao = Console.ReadLine();
    if(opcao == "1") { Testes(); }
    else if(opcao == "2") { Console.Clear();  Inventory(); }
    else if (opcao == "3") { Console.Clear(); Hannoi(); }
    else { opcao = "0";  Menu(); }
}
void Testes() {
    Console.Clear();
    //Teste dos Nodes -------------------------
    MyNode<float> node1 = new MyNode<float>(1f);
    MyNode<float> node2 = new MyNode<float>(2f);
    MyNode<float> node3 = new MyNode<float>(3f);

    node1.InsertAfter(node2);
    node3.InsertBefore(node1);

    Console.WriteLine("Node  2 - 3 - 1");
    Console.Write($"{node1.Previous.Previous.value}  - ");
    Console.Write($"{node1.Previous.value} - ");
    Console.WriteLine($"{node3.Next.value}");

    node3.Detach();

    Console.WriteLine("Node  2 - 1");
    Console.Write($"{node1.Previous.value}  - ");
    Console.WriteLine($"{node2.Next.value}");

    //Teste da Lista ----------------------------
    Console.WriteLine();
    Console.WriteLine();

    MyLinkedList<float> myList = new MyLinkedList<float>();
    myList.Append(1);
    myList.Append(2);
    myList.Append(3);
    myList.Preppend(4);
    myList.Preppend(5);

    Console.WriteLine($"Valor no index 3 = {myList.Get(3)}");
    myList.Print();
    Console.WriteLine($"Contagem da Lista: {myList.Count()}");
    Console.WriteLine();

    myList.Append(3);
    Console.WriteLine($"Existe 2? {myList.Contains(2)}  -  Existe 6? {myList.Contains(6)}");
    Console.WriteLine($"Remover o valor 3 e então o índice 1");
    myList.Print();
    myList.Remove(3);
    myList.Print();
    myList.RemoveAt(1);
    myList.Print();

    Console.WriteLine("Limpando a Lista...");
    myList.Clear();
    myList.Print();

    //Teste da Pilha ---------------------------------------------------------------
    Console.WriteLine();
    Console.WriteLine();

    MyStack<float> myStack = new MyStack<float>();
    myStack.Push(10);
    myStack.Push(20);
    myStack.Push(30);
    Console.WriteLine($"Número de Valores na Pilha {myStack.Count()}");
    Console.WriteLine($"{myStack.Pop()} removido");
    Console.WriteLine($"Topo da Pilha = {myStack.Peek()}");

    Console.WriteLine("Limpando a lista");
    myStack.Clear();
    Console.WriteLine($"Topo da Pilha = {myStack.Peek()}");

    //Teste Fila ---------------------------------------------------------------------
    Console.WriteLine();
    Console.WriteLine();

    MyQueue<float> myQueue = new MyQueue<float>();
    myQueue.Enqueue(5);
    myQueue.Enqueue(10);
    myQueue.Enqueue(15);
    myQueue.Enqueue(30);

    Console.WriteLine($"Número de Valores na Fila = {myQueue.Count()}");
    Console.WriteLine($"Primeiro valor = {myQueue.First()}");
    Console.WriteLine($"Último valor = {myQueue.Last()}");
    myQueue.Dequeue();
    Console.WriteLine($"Dequeue: Primeiro valor = {myQueue.First()}");
    myQueue.Clear();
    Console.WriteLine($"Clear: Primeiro valor = {myQueue.First()}, Último valor = {myQueue.Last()}");

    //Teste de Iteradores
    Console.WriteLine();
    Console.WriteLine();

    //Fim-------------------------
    Console.WriteLine("Aperte Enter para voltar ao Menu.");
    string retorno = "0";
    retorno = Console.ReadLine();
    if(retorno != null) { retorno = "0"; Menu(); }

}

void Inventory()
{
    //Prints loot
    Console.WriteLine("LOOT DISPONIVEL");
    lootList.Print();

    //Prints Inventory
    Console.WriteLine("INVENTARIO");
    Console.WriteLine($"CAPACIDADE:{String.Format("{0 : 0.00}", inventoryList.weight)}/10.00 ({inventoryList.Count()} itens)");
    inventoryList.Print();

    // Options + Input + Explains
    if(inventoryState == 0) // Menu Principal
    {
        Console.WriteLine("Selecione uma opcao");
        Console.WriteLine("0 - Procurar Itens");
        Console.WriteLine("1 - Pegar Item");
        Console.WriteLine("2 - Largar Item");
        Console.WriteLine();
        Console.WriteLine("Aperte qualquer outra coisa para voltar ao menu");

        string option = Console.ReadLine();
        if (option == "0")
        {
            lootList.RandomizeLoot();
            Console.Clear();
            Console.WriteLine("Novos Itens Encontrados");
        }
        else if(option == "1")
        {
            inventoryState = 1;
            Console.Clear();
        }
        else if(option == "2")
        {
            inventoryState = 2;
            Console.Clear();
        }
        else
        {
            Menu();
        }
    }
    else if(inventoryState == 1) //Pegar intens do chao
    {
        Console.WriteLine("Selecione um item para PEGAR, ou -1 para voltar");
        string lootInput = Console.ReadLine();
        if(int.TryParse(lootInput, out _) == true && lootInput != "-1")
        {
            Console.Clear();
            int lootOption = int.Parse(lootInput);
            if (lootList.GetValue(lootOption) != null)
            {
                if (inventoryList.weight + float.Parse(lootList.GetValue(lootOption).ToString()) <= 10.0f)
                {
                    inventoryList.Append(lootList.GetValue(lootOption), lootList.GetName(lootOption));
                    inventoryList.weight += float.Parse(lootList.GetValue(lootOption).ToString());
                    lootList.RemoveAt(lootOption);
                }
                else { Console.WriteLine($"Sem espaco para {lootList.GetName(lootOption)}"); }
            }
            else { Console.WriteLine("OPCAO INVALIDA"); }
        }
        else
        {
            inventoryState = 0;
            Console.Clear();
        }
    }
    else // Tirar Itens do Inventário
    {
        Console.WriteLine("Selecione um item para LARGAR, ou -1 para voltar");
        string inventoryInput = Console.ReadLine();
        if (int.TryParse(inventoryInput, out _) == true && inventoryInput != "-1")
        {
            Console.Clear();
            int inventoryOption = int.Parse(inventoryInput);
            if (inventoryList.GetValue(inventoryOption) != null)
            {
                inventoryList.weight -= float.Parse(inventoryList.GetValue(inventoryOption).ToString());
                inventoryList.RemoveAt(inventoryOption);
            }
            else { Console.WriteLine("OPCAO INVALIDA"); }
        }
        else
        {
            inventoryState = 0;
            Console.Clear();
        }
    }

    Inventory();
}

void Hannoi()
{
    //Print the Towers
    Console.WriteLine("              |");
    Console.WriteLine($"TORRE 0: ---> |{hannoiTower0.PrintTower()}");
    Console.WriteLine("              |");
    Console.WriteLine("              |");
    Console.WriteLine($"TORRE 1: ---> |{hannoiTower1.PrintTower()}");
    Console.WriteLine("              |");
    Console.WriteLine("              |");
    Console.WriteLine($"TORRE 2: ---> |{hannoiTower2.PrintTower()}");
    Console.WriteLine("              |");

    //Opções
    if (hannoiState == 0)
    {
        Console.WriteLine("Digitar um número inexistente te leva-ra ao Menu");
        Console.WriteLine("");
        Console.Write("Selecione uma torre para PEGAR um disco:");
        string option = Console.ReadLine();

        //GameState1 - Selecionar uma Peça -------------------------------------------------------------
        if (option == "0")
        {
            if (hannoiTower0.Peek() != null)
            {
                selectedPiece = hannoiTower0.Pop();
                hannoiState = 1;
                Console.Clear();
            }
            else { Console.Clear(); Console.WriteLine("TORRE VAZIA!"); }
        }
        else if (option == "1")
        {
            if (hannoiTower1.Peek() != null)
            {
                selectedPiece = hannoiTower1.Pop();
                hannoiState = 1;
                Console.Clear();
            }
            else { Console.Clear(); Console.WriteLine("TORRE VAZIA!"); }
        }
        else if (option == "2")
        {
            if (hannoiTower2.Peek() != null)
            {
                selectedPiece = hannoiTower2.Pop();
                hannoiState = 1;
                Console.Clear();
            }
            else { Console.Clear(); Console.WriteLine("TORRE VAZIA!"); }
        }
        else
        {
            Menu();
        }
    }
    else if (hannoiState == 1) //Gamestate 2 - Selecionar Torre ----------------------------------------------
    {
        Console.Write($"Selecione uma torre para SOLTAR o disco ({selectedPiece}): ");
        string option = Console.ReadLine();
        if (option == "0")
        {
            Console.Clear();
            if (selectedPiece == "A")
            {
                hannoiTower0.Push("A");
                hannoiState = 0;
                hannoiCount++;
            }
            else if (selectedPiece == "B")
            {
                if (hannoiTower0.Peek() == "A") { Console.Clear(); Console.WriteLine("MOVIMENTO PROIBIDO: (B) > (A)!"); }
                else
                {
                    hannoiTower0.Push("B");
                    hannoiState = 0;
                    hannoiCount++;
                }
            }
            else
            {
                if (hannoiTower0.Peek() == null)
                {
                    hannoiTower0.Push("C");
                    hannoiState = 0;
                    hannoiCount++;
                }
                else if (hannoiTower0.Peek() == "B") { Console.Clear(); Console.WriteLine("MOVIMENTO PROIBIDO: (C) > (B)!"); }
                else { Console.WriteLine("MOVIMENTO PROIBIDO: (C) > (A)!"); }
            }
        }
        else if (option == "1")
        {
            Console.Clear();
            if (selectedPiece == "A")
            {
                hannoiTower1.Push("A");
                hannoiState = 0;
                hannoiCount++;
            }
            else if (selectedPiece == "B")
            {
                if (hannoiTower1.Peek() == "A") { Console.Clear(); Console.WriteLine("MOVIMENTO PROIBIDO: (B) > (A)!"); }
                else
                {
                    hannoiTower1.Push("B");
                    hannoiState = 0;
                    hannoiCount++;
                }
            }
            else
            {
                if (hannoiTower1.Peek() == null)
                {
                    hannoiTower1.Push("C");
                    hannoiState = 0;
                    hannoiCount++;
                }
                else if (hannoiTower1.Peek() == "B") {  Console.WriteLine("MOVIMENTO PROIBIDO: (C) > (B)!"); }
                else { Console.WriteLine("MOVIMENTO PROIBIDO: (C) > (A)!"); }
            }
        }
        else if (option == "2")
        {
            Console.Clear();
            if (selectedPiece == "A")
            {
                hannoiTower2.Push("A");
                hannoiState = 0;
                hannoiCount++;
            }
            else if (selectedPiece == "B")
            {
                if (hannoiTower2.Peek() == "A") { Console.Clear(); Console.WriteLine("MOVIMENTO PROIBIDO: (B) > (A)!"); }
                else
                {
                    hannoiTower2.Push("B");
                    hannoiState = 0;
                    hannoiCount++;
                }
            }
            else
            {
                if (hannoiTower2.Peek() == null)
                {
                    hannoiTower2.Push("C");
                    hannoiState = 0;
                    hannoiCount++;
                }
                else if (hannoiTower2.Peek() == "B") {  Console.WriteLine("MOVIMENTO PROIBIDO: (C) > (B)!"); }
                else { Console.WriteLine("MOVIMENTO PROIBIDO: (C) > (A)!"); }
            }
        }
        else { Console.Clear();  Console.WriteLine("TORRE INVALIDA!"); }
    }
    else
    {
        string option = "fuieryofhwiahfoihwefiwjioufhweriughiwerhgiwuerhgiuwehrgwherighweirghweihgiwrhgiewhrighweoi";
        Console.Write($"VITORIA EM {hannoiCount} MOVIMENTOS!!! Pressione Enter para voltar ao Menu");
        option = Console.ReadLine();
        if (option != "fuieryofhwiahfoihwefiwjioufhweriughiwerhgiwuerhgiuwehrgwherighweirghweihgiwrhgiewhrighweoi")
        {
            Menu();
        }
    }
    //Ganhou?
    if(hannoiCount >= 0)
    {
        int tower1Count = hannoiTower1.Count();
        int tower2Count = hannoiTower2.Count();
        if(tower1Count == 3 || tower2Count == 3)
        {
            hannoiState = 2;
        }
    }
            Hannoi();

}
    