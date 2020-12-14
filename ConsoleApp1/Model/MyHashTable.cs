using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ConsoleApp1.Model
{
    public class MyHashTable<TKey, TValue> where TKey : IComparable<TKey>
    {
        private const int TABLE_SIZE = 4;

        private Entry[] _entries;
        private int _count;

        private class Entry
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public Entry Next { get; set; }

            public Entry(TKey key, TValue value)
            {
                this.Key = key;
                this.Value = value;
            }
        }

        public MyHashTable()
        {
            _entries = new Entry[TABLE_SIZE];
            _count = 0;
        }

        public void Add(TKey key, TValue value)
        {
            var hashCode = Math.Abs(key.GetHashCode()); // get hashcode
            int indexBucket = hashCode % TABLE_SIZE; // get index of entry

            Entry newEntry = new Entry(key, value); // create new entry     
            Entry existingEntry = _entries[indexBucket]; 
            Entry previosEntry = existingEntry;  

            bool equals = false;
            if (existingEntry != null)
            {
                while (existingEntry != null) // while next value of existing entry is exist keep going
                {
                    if (existingEntry.Key.Equals(newEntry.Key)) // in case of the same existing entry and new
                    {
                        equals = true;
                        break;
                    }

                    if (newEntry.Key.CompareTo(existingEntry.Key) < 0) // newEntry.key < existing.key
                    {
                        newEntry.Next = existingEntry; 
                        break;
                    } 

                    previosEntry = existingEntry;
                    existingEntry = existingEntry.Next;
                }

                if (equals == true)
                {
                    existingEntry = newEntry;
                }
                else if (existingEntry != null && existingEntry.Key.CompareTo(previosEntry.Key) == 0)
                {
                    _entries[indexBucket] = newEntry;
                }
                else
                {
                    previosEntry.Next = newEntry; // add entry to the end  
                }
            }
            else
            {
                _entries[indexBucket] = newEntry; // if bucket is empty add new entry
            }

            _count++;
        }

        public TValue Get(TKey key)
        {
            // find bucket where could be this key
            int index = Math.Abs(key.GetHashCode() % TABLE_SIZE);
            var entry = _entries[index];

            // check each element while there are exist next
            while (entry != null)
            {
                // compare keys of found entry and input key
                if (entry.Key.Equals(key))
                {
                    return entry.Value;
                }

                entry = entry.Next;
            }

            return default;
        }

        public void Remove(TKey key)
        {
            int index = Math.Abs(key.GetHashCode() % TABLE_SIZE);
            var entry = _entries[index];
            var previosEntry = entry;
            while (entry != null)
            {
                if (entry.Key.Equals(key))
                {
                    previosEntry.Next = entry.Next;
                    break;
                }

                previosEntry = entry;
                entry = entry.Next;
            }
        }
    }
}