public class StringsDictionary
{
    private const int InitialSize = 10;

    private LinkedList[] _buckets = new LinkedList[InitialSize]; // _buckets масив зв'язаних списків
        
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

    private int CalculateHash(string key) // рахує наш хеш
    {
        var hash = 0;
        for (int i = 0; i < key.Length; i++)
        { 
            hash += Convert.ToInt32(key[i] * Math.Pow(2, i)); // Convert.ToInt32 щоб перетворити добуток на ціле
                                                              // число перед додаванням до змінної hash
        }
        return hash;
    }
}
