using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableOperations
{
    public class MyMapNode<K,V>
    {
        public int size;
        public LinkedList<Keyvalue<K, V>>[] item;
        
        public MyMapNode(int size)
        {
            this.size = size;
            this.item = new LinkedList<Keyvalue<K,V>>[size];
        }
        public int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<Keyvalue<K, V>> linkedlist = GetLinkedList(position);
            foreach(Keyvalue<K,V> item in linkedlist)
            {
                if(item.key.Equals(key))
                {
                    return item.value;
                }
            }
            return default(V);
        }
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<Keyvalue<K, V>> linkedlist = GetLinkedList(position);
            Keyvalue<K,V> item = new Keyvalue<K, V> { key = key, value = value };
            linkedlist.AddLast(item);

        }
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<Keyvalue<K, V>> linkedlist = GetLinkedList(position);
            bool ispresent = false;
            Keyvalue<K,V> founditem = default(Keyvalue<K,V>);
            foreach (Keyvalue<K, V> item in linkedlist)
            {
                if (item.key.Equals(key))
                {
                    ispresent = true;
                    founditem = item;
                }
            }
            if (ispresent)
            {
                linkedlist.Remove(founditem);
            }
        }
        public LinkedList<Keyvalue<K,V>> GetLinkedList(int position)
        {
            LinkedList<Keyvalue<K,V>> linked = item[position];
            if(linked == null)
            {
                linked = new LinkedList<Keyvalue<K,V>>();
                item[position] = linked;
            }
            return linked;
        }


    }
    public struct Keyvalue<k, v>
    {
        public k key { get; set; }
        public v value { get; set; }
    }
}
