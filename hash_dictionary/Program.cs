var dictionary = new StringsDictionary();
foreach (var line in File.ReadAllLines(pathtoFile))
{
    
}

public class KeyValuePair
{
    public string Key { get; }

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
        Pair = pair;
        Next = next;
    }
}

public class LinkedList
{
    private LinkedListNode _first;

    public void Add(KeyValuePair pair)
    {
        var newNode = new LinkedListNode(pair, null);
        if (_first == null)
        {
            _first = newNode;
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