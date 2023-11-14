using Lista1_PED;

//Teste dos Nodes -------------------------
MyNode<float> node1 = new MyNode<float>(1f);
MyNode<float> node2 = new MyNode<float>(2f);
MyNode<float> node3 = new MyNode<float>(3f);

node1.InsertAfter(node2);
node3.InsertBefore(node1);

Console.WriteLine("Node  2 - 3 - 1");
Console.Write($"{ node1.Previous.Previous.value}  - ");
Console.Write($"{node1.Previous.value} - ");
Console.WriteLine($"{node3.Next.value}");

node3.Detach();

Console.WriteLine("Node  2 - 1");
Console.Write($"{node1.Previous.value}  - ");
Console.WriteLine($"{node2.Next.value}");

//Teste da Lista ----------------------------

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

