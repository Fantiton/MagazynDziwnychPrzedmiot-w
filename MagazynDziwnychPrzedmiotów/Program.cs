// See https://aka.ms/new-console-template for more information
using MagazynDziwnychPrzedmiotów;
using System.Collections;
using System.ComponentModel.Design;
using System.Net;

List<Item> freeItems = new List<Item>();
List<Storage> storages = new List<Storage>();

Main();
void Main()
{
    Console.WriteLine("System zarządzania przechowywaniem dziwnych przedmiotów");
    Console.WriteLine();
    Console.WriteLine("11. - Dodaj Magazyn");
    Console.WriteLine("12. - Wyświetl zawartość Magazynu");
    Console.WriteLine("13. - Wyświetl dostepne Magazyny");
    Console.WriteLine("14. - Wyświelt wszystkie Magazyny");
    Console.WriteLine("15. - Dodaj przedmiot do Magazynu");
    Console.WriteLine("16. - Usuń przedmiot w Magazynie");
    Console.WriteLine("17. - Usuń Magazyn");
    Console.WriteLine();
    Console.WriteLine("21. - Dodaj Przedmiot");
    Console.WriteLine("22. - Wypisz Przedmiot");
    Console.WriteLine("23. - Zmień Przedmiot (narazie kaput)");
    Console.WriteLine("23. - Usuń Przedmiot");

    switch (Console.ReadLine())
    {
        case "11":
           AddStorage(); 
           break;
        case "12":
           ListStorage();
           break;
        case "13":
           ListFreeStorages();
           break;
        case "14":
           ListAllStorages();
           break;
        case "15":
           AddItemToStorage();
            break;
        case "16":
           DeleteItemIS();
            break;
        case "17":
           DeleteStorage();
           break;
        case "21":
           AddItem();
           break;
        case "22":
           ListItem();
           break;
        case "23":
           // EditItem();
           break;
        case "24":
            //DeleteItem();
           break;
        default:
            Main();
            break;
    }

    Storage SelectStorage()
    {
        Console.WriteLine("Wybierz Magazyn: ");

        int i = 1;

        foreach (Storage storage in storages)
        {
            Console.WriteLine($"{i}. - {storage.Name}");
            i++;
        }

        string input = Console.ReadLine();

        if (input == "e")
        {
            Main();
        }

        if (int.Parse(input) > storages.Count() + 1)
        {
            Console.WriteLine("Nie wybrano dostępnej opcji");
            SelectStorage();
        }

        int selectedStorageIndex = int.Parse(input) - 1;
        Storage selectedStorage = storages[selectedStorageIndex];
        return selectedStorage;
    }

    int SelectItem(List<Item> items)
    {
        Console.WriteLine("Wybierz Przedmiot: ");
        int i = 1;
        foreach (Item item in items)
        {
            Console.WriteLine($"{i}. - {item.Name}");
            i++;
        }
        string input = Console.ReadLine();
        if (input == "e")
        {
            Main();
        }
        if (int.Parse(input) > items.Count() + 1)
        {
            Console.WriteLine("Nie wybrano dostępnej opcji");
            SelectItem(items);
        }
        int selectedItemIndex = int.Parse(input) - 1;
        return selectedItemIndex;
    }

    void AddStorage()
    {
        Console.WriteLine("Nazwij Magazyn: ");

        string input = Console.ReadLine();

        if (input == "e")
        {
            Main();
        }

        string name = input;

        Console.WriteLine("Podaj pojemność Magazynu: ");

        input = Console.ReadLine();

        if (input.ToString() == "e")
        {
            Main();
        }

        int capacity = int.Parse(input);

        Console.WriteLine("Podaj maksymalną wagę zawartości Magazynu: ");

        input = Console.ReadLine();

        if (input == "e")
        {
            Main();
        }

        float maxContentWeight = float.Parse(input);

        Storage storage = new Storage(name, capacity, maxContentWeight);
        storages.Add(storage);

        Console.WriteLine($"Dodano Magazyn: {name} {capacity} {maxContentWeight}");
        Main();
    }

    void ListStorage()
    {
        Storage selectedStorage = SelectStorage();
        selectedStorage.ListContent();
        Main();
    }

    void ListFreeStorages()
    {
        Console.WriteLine("Dostępne Magazyny: ");
        foreach (Storage storage in storages)
        {
            if (storage.GetItemCount() < storage.GetCapacity())
            {
                Console.WriteLine(storage.Name);
            }
        }
        Main();
    }

    void ListAllStorages()
    {
        Console.WriteLine("Wszystkie Magazyny: ");
        foreach (Storage storage in storages)
        {
            Console.WriteLine(storage.Name);
        }
        Main();
    }

    void AddItemToStorage()
    {
        int selectedItemIndex = SelectItem(freeItems);
        Item selectedItem = freeItems[selectedItemIndex];

        Storage selectedStorage = SelectStorage();

        selectedStorage.Add(selectedItem);
        freeItems.RemoveAt(selectedItemIndex);

        Main();
    }

    void DeleteItemIS()
    {
        Storage selectedStorage = SelectStorage();
        List<Item> selectedStorageContent = selectedStorage.GetContent();

        int selectedItemIndex = SelectItem(selectedStorageContent);
        Item selectedItem = selectedStorageContent[selectedItemIndex];

        selectedStorageContent.RemoveAt(selectedItemIndex);
        freeItems.Add(selectedItem);

        Main();
    }

    void DeleteStorage()
    {
        Console.WriteLine("Wybierz Magazyn: ");
        int i = 1;
        foreach (Storage storage in storages)
        {
            Console.WriteLine($"{i}. - {storage.Name}");
            i++;
        }

        string input = Console.ReadLine();

        if (input == "e")
        {
            Main();
        }

        if (int.Parse(input) > storages.Count() + 1)
        {
            Console.WriteLine("Nie wybrano dostępnej opcji");
            DeleteStorage();
        }

        int selectedStorageIndex = int.Parse(input) - 1;
        Storage selectedStorage = storages[selectedStorageIndex];
        
        List<Item> selectedStorageContent = selectedStorage.GetContent();
        foreach (Item item in selectedStorageContent)
        {
            freeItems.Add(item);
        }

        storages.RemoveAt(selectedStorageIndex);

        Main();
    }

    void AddItem()
    {
        Console.WriteLine("Podaj nazwę przedmiotu: ");

        string input = Console.ReadLine();

        if(input == "e")
        {
            Main();
        }

        string name = input;

        Console.WriteLine("Podaj wagę przedmiotu: ");

        input = Console.ReadLine();

        if (input == "e")
        {
            Main();
        }

        float weight = float.Parse(input);

        Console.WriteLine("Podaj poziom dziwności przedmiotu: ");

        input = Console.ReadLine();

        if (input == "e")
        {
            Main();
        }

        int strangenessLevel = int.Parse(input);

        Console.WriteLine("Czy przedmiot jest kruchy? (true/false): ");

        input = Console.ReadLine();

        if (input == "e")
        {
            Main();
        }

        bool isFragile = bool.Parse(input);

        Item item = new Item(name, weight, strangenessLevel, isFragile);

        freeItems.Add(item);

        Main();
    }

    void ListItem()
    {
        Console.WriteLine("Wybierz Magazyn: ");

        int j = 1;
        foreach (Storage storage in storages)
        {
            Console.WriteLine($"{j}. - {storage.Name}");
            j++;
        }

        string input = Console.ReadLine();

        if (input == "e")
        {
            Main();
        }

        if (int.Parse(input) > storages.Count() + 2)
        {
            Console.WriteLine("Nie wybrano dostępnej opcji");
            ListItem();
        }

        if(int.Parse(input) == storages.Count + 1)
        {
            Console.WriteLine("Wybierz Przedmiot: ");

            int i = 1;

            foreach (Item item in freeItems)
            {
                Console.WriteLine($"{i}. - {item.Name}");
                i++;
            }

            string input2 = Console.ReadLine();

            if (input == "e")
            {
                Main();
            }

            if (int.Parse(input2) > freeItems.Count() + 1)
            {
                Console.WriteLine("Nie wybrano dostępnej opcji");
                ListItem();
            }

            int selectedItemIndex = int.Parse(input2) - 1;
            Item selectedItem = freeItems[selectedItemIndex];
            Console.WriteLine(selectedItem.Description());
            Main();
        }

        int selectedStorageIndex = int.Parse(input) - 1;
        Storage selectedStorage = storages[selectedStorageIndex];
        List<Item> selectedStorageContent = selectedStorage.GetContent();

        Console.WriteLine("Wybierz Przedmiot: ");
        int l = 1;
        foreach (Item item in selectedStorageContent)
        {
            Console.WriteLine($"{l}. - {item.Name}");
            l++;
        }

        string input3 = Console.ReadLine();

        if (input3 == "e")
        {
            Main();
        }

        if (int.Parse(input3) > freeItems.Count() + 1)
        {
            Console.WriteLine("Nie wybrano dostępnej opcji");
            ListItem();
        }

        int selectedItemIndex2 = int.Parse(input3) - 1;
        Item selectedItem2 = selectedStorageContent[selectedItemIndex2];
        Console.WriteLine(selectedItem2.Description());
        Main();

        
    }
}

