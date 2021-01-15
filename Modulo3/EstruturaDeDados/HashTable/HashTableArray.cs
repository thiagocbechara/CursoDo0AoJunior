using System;

namespace CursoDo0AoJunior.Modulo3.EstruturaDeDados.HashTable
{
    public class HashTableArray
    {
        public HashTableArray(int baseCount = 10)
        {
            bucket = new object[2 ^ baseCount];
        }

        public int Count { get; private set; }
        private object[] bucket;


        private int GenerateKeyIndex(object key)
        {
            var hashKey = key.GetHashCode() & 0x7fffffff;
            var hashIndex = hashKey % bucket.Length;
            return hashIndex;
        }

        public HashTableArray Add(object key, object value)
        {
            if (Count == bucket.Length)
            {
                throw new InvalidOperationException("Hash table is full");
            }
            var hashIndex = GenerateKeyIndex(key);
            bucket[hashIndex] = value;
            return this;
        }

        public object Get(object key)
        {
            var hashIndex = GenerateKeyIndex(key);
            var value = bucket[hashIndex];
            if (value == null)
            {
                throw new ArgumentNullException("Key is not found");
            }
            return value;
        }

        public object Remove(object key)
        {
            var hashIndex = GenerateKeyIndex(key);
            var value = bucket[hashIndex];
            if (value == null)
            {
                throw new ArgumentNullException("Key is not found");
            }
            bucket[hashIndex] = null;
            return value;
        }

        public void Clear()
        {
            bucket = new object[2 ^ bucket.Length];
            Count = 0;
        }
    }
}