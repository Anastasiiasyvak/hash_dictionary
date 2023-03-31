public class StringsDictionary
{
    private const int InitialSize = 10;
    private double load_factor = 0.75; // максимальне середнє навантаження на кожний бакет
    private int _count = 0; // вираховує кількість ключів які додаються в dictionary 
    private LinkedList[] _buckets = new LinkedList[InitialSize]; // _buckets масив зв'язаних списків
    
    public void Add(string key, string value)
    {
        var wordHash = CalculateHash(key);
        var bucket = wordHash % _buckets.Length;
        if (_buckets[bucket] == null)
        {
            _buckets[bucket] = new LinkedList();
            _count++;
        }
        _buckets[bucket].Add(new KeyValuePair(key, value));
    
        double currentLoadFactor = (double)_count / _buckets.Length;
        if (currentLoadFactor > load_factor)
        {
            Resize(); // збільшення хеш таблиці 
        }
    }
    
    public void Remove(string key)
    {
        var wordHash = CalculateHash(key);
        var bucket = wordHash % _buckets.Length;
        if (_buckets[bucket] == null)
        {
            return; 
        }

        _buckets[bucket].RemoveByKey(key);

    }
    
    public string Get(string key)
    {
        var wordHash = CalculateHash(key); 
        var bucket = wordHash % _buckets.Length;
        if (_buckets[bucket] == null)
        {
            return null; 
        }
        return _buckets[bucket].GetItemWithKey(key).Value;
    }
    
    private long CalculateHash(string key)
    {
        long hash = 0;
        for (int i = 0; i < key.Length; i++)
        { 
            hash += Convert.ToInt64(key[i] * Math.Pow(2, i));
        }
        return hash;
    }
    
    private void Resize()
    {
        int newCapacity = _buckets.Length * 2;
        var newBuckets = new LinkedList[newCapacity];
        foreach (var bucket in _buckets)
        {
            if (bucket != null)
            {
                var current = bucket._first;
                
                
                do // вид while який 100% буде розглядатися 
                {
                    var wordHash = CalculateHash(current.Pair.Key);
                    var newBucketIndex = wordHash % newCapacity;
                    if (newBuckets[newBucketIndex] == null)
                    {
                        newBuckets[newBucketIndex] = new LinkedList();
                    }

                    newBuckets[newBucketIndex].Add(current.Pair);

                    current = current.Next;
                } while (current != null);


            }
        }
        _buckets = newBuckets;
    }
}


