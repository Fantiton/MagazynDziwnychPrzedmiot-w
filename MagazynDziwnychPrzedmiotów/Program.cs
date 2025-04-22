// See https://aka.ms/new-console-template for more information
using MagazynDziwnychPrzedmiotów;
using System.Collections;
using System.Net;

List<Storage> storages = new List<Storage>();
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
    Console.WriteLine("23. - Zmień Przedmiot");
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
            //ListFreeStorages();
           break;
        case "14":
            // ListAllStorages();
            break;
        case "15":
            // AddItemToStorage();
            break;
        case "16":
            // DeleteItemIS();
            break;
        case "17":
           // DeleteStorage();
           break;
        case "21":
           // AddItem();
           break;
        case "22":
           // ListItem();
           break;
        case "23":
           // EditItem();
           break;
        case "24":
            //DeleteItem();
           break;
    }

    void AddStorage()
    {
        Console.WriteLine("Nazwij Magazyn: ");

        if(Console.ReadLine() == "e")
        {
            Main();
        }

        string name = Console.ReadLine();

        Console.WriteLine("Podaj pojemność Magazynu: ");

        if (Console.ReadLine() == "e")
        {
            Main();
        }

        int capacity = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj maksymalną wagę zawartości Magazynu: ");

        if (Console.ReadLine() == "e")
        {
            Main();
        }

        float maxContentWeight = float.Parse(Console.ReadLine());

        Storage storage = new Storage(name, capacity, maxContentWeight);
        storages.Add(storage);

        Console.WriteLine($"Dodano Magazyn: {name} {capacity} {maxContentWeight}");
        Main();
    }

    void ListStorage()
    {
        Console.WriteLine("Wybierz Magazyn: ");
        int i = 1;
        foreach (Storage storage in storages)
        {
            Console.WriteLine($"{i}. - {storage.Name}");
            i++;
        }

        if (Console.ReadLine() == "e")
        {
            Main();
        }

        if (int.Parse(Console.ReadLine()) > storages.Count() + 1)
        {
            Console.WriteLine("Nie wybrano dostępnej opcji");
            ListStorage();
        }

        int selectedStorageIndex = int.Parse(Console.ReadLine()) - 1;
        Storage selectedStorage = storages[selectedStorageIndex];
        selectedStorage.ListContent();
        Main();
    }
}

