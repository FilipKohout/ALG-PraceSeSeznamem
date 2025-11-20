namespace ALG_PraceSeSeznamem;

public class LinkedList<T>
{
    public LinkedListNode<T> First { get; private set; }
    public LinkedListNode<T> Last { get; private set; }
    public int Count { get; private set; }

    public LinkedList() { }

    public LinkedListNode<T> AddFirst(T value)
    {
        var node = new LinkedListNode<T>(value);
        
        if (First == null)
            First = Last = node;
        else
        {
            node.Next = First;
            First.Prev = node;
            First = node;
        }
        
        Count++;
        return node;
    }

    public LinkedListNode<T> AddLast(T value)
    {
        var node = new LinkedListNode<T>(value);
        
        if (Last == null)
            First = Last = node;
        else
        {
            Last.Next = node;
            node.Prev = Last;
            Last = node;
        }
        
        Count++;
        return node;
    }

    public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
    {
        if (node == null) return AddLast(value);
        if (node == Last) return AddLast(value);

        var newNode = new LinkedListNode<T>(value);
        var next = node.Next;
        
        node.Next = newNode;
        newNode.Prev = node;
        newNode.Next = next;
        next.Prev = newNode;
        
        Count++;
        return newNode;
    }

    public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
    {
        if (node == null) return AddFirst(value);
        if (node == First) return AddFirst(value);

        var newNode = new LinkedListNode<T>(value);
        var prev = node.Prev;
        
        prev.Next = newNode;
        newNode.Prev = prev;
        newNode.Next = node;
        node.Prev = newNode;
        
        Count++;
        return newNode;
    }

    public void Remove(LinkedListNode<T> node)
    {
        if (node == null) return;

        if (node.Prev != null)
            node.Prev.Next = node.Next;
        else
            First = node.Next;

        if (node.Next != null)
            node.Next.Prev = node.Prev;
        else
            Last = node.Prev;

        node.Next = null;
        node.Prev = null;
        Count--;
    }

    public void RemoveFirst()
    {
        if (First != null) Remove(First);
    }

    public void RemoveLast()
    {
        if (Last != null) Remove(Last);
    }
}