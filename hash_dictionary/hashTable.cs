public class StringsDictionary
{
    // private const int InitialSize = 10;
    // private double load_factor = 0.75;
    // private int _count = 0;
    // private LinkedList[] _buckets = new LinkedList[InitialSize]; // _buckets масив зв'язаних списків
    //
    // public void Add(string key, string value)
    // {
    //     var wordHash = CalculateHash(key);
    //     var bucket = wordHash % _buckets.Length;
    //     if (_buckets[bucket] == null)
    //     {
    //         _buckets[bucket] = new LinkedList();
    //         _count++;
    //     }
    //     _buckets[bucket].Add(new KeyValuePair(key, value));
    //
    //     double currentLoadFactor = (double)_count / _buckets.Length;
    //     if (currentLoadFactor > load_factor)
    //     {
    //         Resize();
    //     }
    // }
    //
    // public void Remove(string key)
    // {
    //     var wordHash = CalculateHash(key);
    //     var bucket = wordHash % _buckets.Length;
    //     if (_buckets[bucket] == null)
    //     {
    //         return; 
    //     }
    //     if (_buckets[bucket].RemoveByKey(key))
    //     {
    //         _count--;
    //     }
    // }
    //
    // public string Get(string key)
    // {
    //     var wordHash = CalculateHash(key); 
    //     var bucket = wordHash % _buckets.Length;
    //     if (_buckets[bucket] == null)
    //     {
    //         return null; 
    //     }
    //     return _buckets[bucket].GetItemWithKey(key)?.Value;
    // }
    //
    // private long CalculateHash(string key)
    // {
    //     long hash = 0;
    //     for (int i = 0; i < key.Length; i++)
    //     { 
    //         hash += Convert.ToInt64(key[i] * Math.Pow(2, i));
    //     }
    //     return hash;
    // }
    //
    // private void Resize()
    // {
    //     int newCapacity = _buckets.Length * 2;
    //     var newBuckets = new LinkedList[newCapacity];
    //     foreach (var bucket in _buckets)
    //     {
    //         if (bucket != null)
    //         {
    //             foreach (var pair in bucket)
    //             {
    //                 var wordHash = CalculateHash(pair.Key);
    //                 var newBucketIndex = wordHash % newCapacity;
    //                 if (newBuckets[newBucketIndex] == null)
    //                 {
    //                     newBuckets[newBucketIndex] = new LinkedList();
    //                 }
    //                 newBuckets[newBucketIndex].Add(pair);
    //             }
    //         }
    //     }
    //     _buckets = newBuckets;
    // }

    private const int InitialSize = 10;
    
    private LinkedList[] _buckets = new LinkedList[InitialSize]; // _buckets масив зв'язаних списків
        
    public void Add(string key, string value)
    {
        var wordHash = CalculateHash(key);
        var bucket = wordHash % InitialSize;
        if (_buckets[bucket] == null)
        {
            _buckets[bucket] = new LinkedList();
        }
        _buckets[bucket].Add(new KeyValuePair(key, value));
    }
    
    public void Remove(string key)
    {
        var wordHash = CalculateHash(key);
        var bucket = wordHash % 10; // обчислює індекс бакета 
        if (_buckets[bucket] == null) // перевіряє чи існує вже бакет з таким індексом, якщо ні то немає пари з таким ключем
        {
            return; 
        }
        _buckets[bucket].RemoveByKey(key); // якщо бакет існує то він його remove
    }
    
    public string Get(string key) // Якщо список існує, метод шукає в ньому пару ключ-значення за ключем і повертає знайдене значення
    {
        var wordHash = CalculateHash(key); 
        var bucket = wordHash % 10; // ділимо на кількість бакетів
        if (_buckets[bucket] == null) // ключ не був збережений у словнику тому null
        {
            return null; 
        }
        return _buckets[bucket].GetItemWithKey(key).Value;  //  повертає значення, яке знаходиться в парі ключ-значення у списку,
                                                            // що зберігається в бакеті, що відповідає заданому ключу
        
    }
    
    private long CalculateHash(string key) // рахує наш хеш
    {
        long hash = 0;
        for (int i = 0; i < key.Length; i++)
        { 
            hash += Convert.ToInt64(key[i] * Math.Pow(2, i)); // Convert.ToInt32 щоб перетворити добуток на ціле
                                                              // число перед додаванням до змінної hash
        }
        return hash;
    }
}


