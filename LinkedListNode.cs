namespace ALG_PraceSeSeznamem;

public class LinkedListNode<T>
{
    public T Value { get; }
    public LinkedListNode<T> Next { get; internal set; }
    public LinkedListNode<T> Prev { get; internal set; }

    public LinkedListNode(T value)
    {
        Value = value;
    }
}