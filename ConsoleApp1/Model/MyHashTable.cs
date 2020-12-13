using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ConsoleApp1.Model
{
    public class MyHashTable<TKey, TValue>
    {
        private const int TABLE_SIZE = 10;

        private Entry[] _entries;
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
            _entries = new Entry[TABLE_SIZE];
            _count = 0;
        }

        public void Add(TKey k, TValue v)
        {
            var hashCode = Math.Abs(k.GetHashCode()); // get hashcode
            int indexBucket = hashCode % TABLE_SIZE; // get index of entry

            Entry newEntry = new Entry(k, v); // create new entry
            Entry existingEntry = _entries[indexBucket];

            bool equals = false;
            if (existingEntry != null)
            {
                while (existingEntry.Next != null) // while next value of existing entry is exist keep going
                {
                    if (existingEntry.Key.Equals(newEntry.Key)) // in case of the same existing entry and new
                    {
                        equals = true;
                        break;
                    }

                    existingEntry = existingEntry.Next;
                }

                if (equals == true)
                    existingEntry = newEntry;
                else
                    existingEntry.Next = newEntry; // add entry to the end
            }
            else
            {
                _entries[indexBucket] = newEntry; // if bucket is empty add new entry
            }

            _count++;
        }

        public TValue Lookup(TKey k)
        {
            // find bucket where could be this key
            int index = Math.Abs(k.GetHashCode() % TABLE_SIZE);
            var entry = _entries[index];

            if (entry.Next == null)
            {
                
                if (entry.Key.Equals(k))
                {
                    return entry.Value;
                }

                return default;
            }
            
            // check each element while there are exist next
            while (entry.Next != null) 
            {
                // compare keys of found entry and input key
                if (entry.Key.Equals(k))
                {
                    return entry.Value;
                }
                entry = entry.Next;
            }

            return default;
        }
    }
}