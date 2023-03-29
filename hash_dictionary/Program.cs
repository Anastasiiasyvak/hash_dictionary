public class KeyValuePair
{
    public string Key { get; } // get оскільки key value їх значення встановлюється лише в момент створення об'єкту

    public string Value { get; }

    public KeyValuePair(string key, string value)
    {
        Key = key;
        Value = value;
    }
}

public class LinkedListNode
{
    public KeyValuePair Pair { get; }
        
    public LinkedListNode Next { get; set; }

    public LinkedListNode(KeyValuePair pair, LinkedListNode next = null)
    {
        Pair = pair; // ключ значення яка вказує на дані пов'язані з цим вузлом
        Next = next;
    }
}

public class LinkedList
{
    private LinkedListNode _first;

    public void Add(KeyValuePair pair)
    {
        var newNode = new LinkedListNode(pair, null);
        if (_first == null) // якщо список порожній
        {
            _first = newNode; // то first стає newNode
        } 
        var current = _first;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    public void RemoveByKey(string key)
    {
        var current = _first;
        while (current.Next != null)
        {
            if (current.Next.Pair.Key == key)
            {
                current.Next = current.Next.Next;
            }
            current = current.Next;
        }
    }

    public KeyValuePair GetItemWithKey(string key)
    {
        if (_first == null)
        {
            return null;
        }

        var current = _first;
        while (current != null)
        {
            if (current.Pair.Key == key)
            {
                return current.Pair;
            }
            current = current.Next;
        }
        return null;
    }
}