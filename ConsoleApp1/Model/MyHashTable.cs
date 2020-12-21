using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

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
            var hashCode = Math.Abs(key.GetHashCode()); 
            int indexBucket = hashCode % TABLE_SIZE; 

            Entry newEntry = new Entry(key, value);      
            Entry existingEntry = _entries[indexBucket]; 
            Entry previosEntry = existingEntry;  

            bool equals = false;
            if (existingEntry != null)
            {
                while (existingEntry != null) 
                {
                    if (existingEntry.Key.Equals(newEntry.Key)) 
                    {
                        equals = true;
                        break;
                    }

                    if (newEntry.Key.CompareTo(existingEntry.Key) < 0) 
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
            Entry previosEntry = null;
            
            while (entry != null)
            {
                if (entry.Key.Equals(key))
                {
                    if (previosEntry == null)
                    {
                        _entries[index] = entry.Next;
                    }
                    else
                    {
                        previosEntry.Next = entry.Next;    
                    }
                    break;
                }

                previosEntry = entry;
                entry = entry.Next;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append("\n");
            
            for (int i = 0; i < _entries.Length; i++)
            {
                var curEntry = _entries[i];
                if (curEntry == null)
                {
                    continue;
                }

                do
                {
                    sb.Append($"Key = [{curEntry.Key}], Value = [{curEntry.Value}] \n");
                    curEntry = curEntry.Next;
                } while (curEntry != null);
            }
            
            sb.Append("]");
            
            return sb.ToString();
        }
    }
}