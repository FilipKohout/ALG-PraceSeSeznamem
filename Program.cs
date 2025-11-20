namespace ALG_PraceSeSeznamem;

class Program
{
    static LinkedList<DiaryRecord> list = new();
    static LinkedListNode<DiaryRecord>? current;

    static void Main(string[] args)
    {
        HomePage();

        bool running = true;
        bool enteringText = false;
        DiaryRecord? newBuffer = null;

        while (running)
        {
            if (!enteringText)
                CommandList();

            Console.Write("> ");
            string input = Console.ReadLine()?.Trim();

            if (enteringText)
            {
                if (input == "uloz")
                {
                    if (newBuffer != null)
                    {
                        LinkedListNode<DiaryRecord> inserted;
                        if (current == null) 
                            inserted = list.AddLast(newBuffer);
                        else
                            inserted = list.AddAfter(current, newBuffer);

                        current = inserted;
                        Console.WriteLine();
                        Console.WriteLine("Záznam uložen");

                        ShowRecord(current.Value);
                        newBuffer = null;
                    }
                    
                    enteringText = false;
                    Console.WriteLine($"Počet záznamů: {list.Count}");
                    continue;
                }

                if (newBuffer != null)
                {
                    if (string.IsNullOrEmpty(newBuffer.Text))
                        newBuffer.Text = input;
                    else
                        newBuffer.Text += Environment.NewLine + input;
                }
                continue;
            }

            if (string.IsNullOrWhiteSpace(input))
                continue;

            switch (input.ToLower())
            {
                case "predchozi":
                    if (current == null)
                        Console.WriteLine("Žádné záznamy");
                    else if (current.Prev == null)
                        Console.WriteLine("Předchozí neexistuje");
                    else
                    {
                        current = current.Prev;
                        ShowRecord(current.Value);
                    }
                    
                    Console.WriteLine($"Počet záznamů: {list.Count}");
                    break;

                case "dalsi":
                    if (current == null)
                        Console.WriteLine("Žádné záznamy v deníku");
                    else if (current.Next == null)
                        Console.WriteLine("Další neexistuje");
                    else
                    {
                        current = current.Next;
                        ShowRecord(current.Value);
                    }
                    
                    Console.WriteLine($"Počet záznamů: {list.Count}");
                    break;

                case "zacatek":
                    if (list.First == null)
                    {
                        Console.WriteLine("Žádné záznamy");
                        current = null;
                    }
                    else
                    {
                        current = list.First;
                        ShowRecord(current.Value);
                    }
                    
                    Console.WriteLine($"Počet záznamů: {list.Count}");
                    break;

                case "konec":
                    if (list.Last == null)
                    {
                        Console.WriteLine("Žádné záznamy");
                        current = null;
                    }
                    else
                    {
                        current = list.Last;
                        ShowRecord(current.Value);
                    }
                    
                    Console.WriteLine($"Počet záznamů: {list.Count}");
                    break;

                case "novy":
                    DateTime datum;
                    while (true)
                    {
                        Console.Write("Zadejte datum (např. 14.3.2025): ");
                        string d = Console.ReadLine()?.Trim();
                        
                        if (DateTime.TryParse(d, out datum))
                            break;
                        
                        Console.WriteLine("Špatný formát");
                    }

                    Console.WriteLine("Text záznamu (můžete zadat více řádků)");
                    Console.WriteLine("Ukončení příkazem 'uloz'");
                    
                    newBuffer = new DiaryRecord(datum, "");
                    enteringText = true;
                    
                    break;

                case "uloz":
                    Console.WriteLine("Nelze mimo zadávání textu");
                    Console.WriteLine($"Počet záznamů: {list.Count}");
                    
                    break;

                case "smaz":
                    if (current == null)
                    {
                        Console.WriteLine("Žádný smazatelný záznam");
                        Console.WriteLine($"Počet záznamů: {list.Count}");
                    }
                    else
                    {
                        Console.WriteLine("Záznam:");
                        ShowRecord(current.Value);
                        Console.Write("Opravdu chcete smazat tento záznam? (a/n): ");
                        
                        string potv = Console.ReadLine()?.Trim();
                        
                        if (potv == "a") {
                            list.Remove(current);
                            
                            if (list.First != null)
                            {
                                current = list.First;
                                Console.WriteLine("Záznam odstraněn, první záznam:");
                                
                                ShowRecord(current.Value);
                            }
                            else
                            {
                                current = null;
                                Console.WriteLine("Záznam odstraněn, žádné další záznamy");
                                
                                HomePage();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Zrušeno");
                            
                            if (current != null)
                                ShowRecord(current.Value);
                        }
                        Console.WriteLine($"Počet záznamů: {list.Count}");
                    }
                    break;

                case "zavri":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Neplatný příkaz");
                    break;
            }
        }
    }

    static void CommandList()
    {
        Console.WriteLine();
        Console.WriteLine("Příkazy: predchozi | dalsi | zacatek | konec | novy | uloz | smaz | zavri");
        Console.WriteLine("Hello, World!");
    }

    static void ShowRecord(DiaryRecord record)
    {
        Console.WriteLine();
        Console.WriteLine("===== Záznam =====");
        Console.WriteLine($"Datum: {record.Date:yyyy-MM-dd}");
        Console.WriteLine("Text:");
        Console.WriteLine(record.Text);
        Console.WriteLine("==================");
        Console.WriteLine();
    }

    static void HomePage()
    {
        Console.Clear();
        Console.WriteLine("=== Deník (spojový seznam) ===");
        Console.WriteLine("Žádné záznamy, příkaz 'novy' pro přidání záznamu.");
        Console.WriteLine();
    }
}
