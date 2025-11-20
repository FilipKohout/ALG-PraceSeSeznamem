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
            }
            if (string.IsNullOrWhiteSpace(input))
                continue;
            switch (input.ToLower())
            {
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
