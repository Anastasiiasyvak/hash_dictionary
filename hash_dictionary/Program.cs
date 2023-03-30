var dictionary = new StringsDictionary(); // для зберігання пар ключ-значення
string pathtoFile = "/home/nastia/for_new_projects/hash_dictionary/hash_dictionary/our_dictionaryy.txt";
foreach (var line in File.ReadAllLines(pathtoFile))
{
    string[] elements = line.Split(";");
    string key = elements[0];
    string value = String.Join(";", elements[1..]);
    dictionary.Add(key, value);
}

while (true)
{
    Console.Write("Write the word: ");
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
    {
        break;
    }

    var definition = dictionary.Get(input);
    if (definition == null)
    {
        Console.WriteLine("You don't have this word in dictionary");
    }
    else
    {
        Console.WriteLine("Meaning of the word: " + definition);
    }
}

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
            _first = newNode;
            return; // то first стає newNode
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
        if (_first != null && _first.Pair.Key == key) // перевіряє, що ключ першого вузла дорівнює заданому ключу key
                                                      // якщо так перший вузол списку відбільшується, і змінна _first стає посиланням на наступний вузол.
        {
            _first = _first.Next;
        }
        else
        {
            var current = _first;
            while (current.Next != null)
            {
                if (current.Next.Pair.Key == key)
                {
                    current.Next = current.Next.Next;
                    break;
                }

                current = current.Next;
            }
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

