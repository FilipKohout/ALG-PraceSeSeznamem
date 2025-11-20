namespace ALG_PraceSeSeznamem;

class Program
{
    static LinkedList<DiaryRecord> list = new();
    static LinkedListNode<DiaryRecord>? current;

    static void Main(string[] args)
    {
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
