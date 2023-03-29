public class StringsDictionary
{
    private const int InitialSize = 10;

    private LinkedList[] _buckets = new LinkedList[InitialSize];
        
    public void Add(string key, string value)
    {
        var wordHash = CalculateHash(key);
        var bucket = wordHash % 10;
        if (_buckets[bucket] == null)
        {
            _buckets[bucket] = new LinkedList();
        }
        _buckets[bucket].Add(new KeyValuePair(key, value));
    }

    public void Remove(string key)
    {
        
    }

    public string Get(string key)
    {
        var wordHash = CalculateHash(key);
        var bucket = wordHash % 10;
        if (_buckets[bucket] == null)
        {
            return null; 
        }
        return _buckets[bucket].GetItemWithKey(key).Value;
    }

    private int CalculateHash(string key)
    {
        var hash = 0;
        for (int i = 0; i < key.Length; i++)
        { 
            hash += Convert.ToInt32(key[i] * Math.Pow(2, i));
        }
        return hash;
    }
}