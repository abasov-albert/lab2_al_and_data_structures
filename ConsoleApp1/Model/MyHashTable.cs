namespace ConsoleApp1.Model
{
    public class MyHashTable<TKey, TValue>
    {
        private const int TABLE_SIZE = 10; 
        
        private Entry[] _buckets;
        private int _count; 

        private class Entry
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public Entry Next { get; set; }

            public Entry(TKey k, TValue v)
            {
                this.Key = k;
                this.Value = v;
            }
        }

        public MyHashTable()
        {
            _buckets = new Entry[TABLE_SIZE];
            _count = 0;
        }
        
        public void Add(TKey k, TValue v)
        {
            var hashCode = k.GetHashCode();
            int indexBucket = (hashCode + 1) % TABLE_SIZE;
            Entry newEntry = new Entry(k, v);
            Entry existingBucket = _buckets[indexBucket];
            Entry currentBucket = existingBucket;
            bool equals = false;
            if (existingBucket != null)
            {
                while (currentBucket.Next != null)
                {
                    if (currentBucket.Equals(newEntry))
                    {
                        equals = true;
                        break;
                    }
                    currentBucket = currentBucket.Next;
                }

                if (equals == true)
                    currentBucket = newEntry;
                else
                    currentBucket.Next = newEntry;
            }
            else
            {
                _buckets[indexBucket] = newEntry;
            }

            _count++;
        }
    }
}