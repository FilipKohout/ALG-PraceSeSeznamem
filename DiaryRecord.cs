namespace ALG_PraceSeSeznamem;

public class DiaryRecord
{
    public DateTime Date { get; set; }
    public string Text { get; set; }

    public DiaryRecord(DateTime date, string text)
    {
        Date = date;
        Text = text;
    }
}