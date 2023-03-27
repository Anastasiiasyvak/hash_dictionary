// namespace heap_ns;
//
// public class Heap
// {
//     public List<int> data = new();
//     private Func<int, int> get_right_child_index = x => x * 2 + 2;
//     
//
// }
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
        var new_node = new LinkedListNode(pair, null);
        if (_first == null)
        {
            _first = new_node;
        }
        else
        {
            var cur_node = _first;
            while (cur_node.Next != null)
            {
                cur_node = cur_node.Next;
            }
            cur_node.Next = new_node;
        }
    }

    public void RemoveByKey(string key)
    {
        var cur_node = _first;
        var prev_node = cur_node;
        while (cur_node.Next != null)
        {
            if (cur_node.Pair.Key == key)
            {
                prev_node.Next = cur_node.Next;
                break;
            }

            prev_node = cur_node;
            cur_node = cur_node.Next;
        }
    }

    public KeyValuePair<string, string>? GetByKey(string key)
    {
        if (_first == null)
        {
            return null;
        }

        var cur_node = _first;
        while (cur_node != null)
        {
            if (cur_node.Pair.Key == key)
            {
                return cur_node.Pair;
            }
            cur_node = cur_node.Next;
        }
        return null;
    }

    public void Print()
    {
        var cur_node = _first;
        while 
        
    }
}