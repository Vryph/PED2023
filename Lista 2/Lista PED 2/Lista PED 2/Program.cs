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

Menu();

void Menu()
{
    Sorting();
}

void Sorting()
{
    itemsList.BubbleSort();
    itemsList.Print();
}