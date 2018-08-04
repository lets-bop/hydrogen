/*
Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and put.

get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
put(key, value) - Set or insert the value if the key is not already present. When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.

Follow up:
Could you do both operations in O(1) time complexity?

Example:

LRUCache cache = new LRUCache( 2 capacity );

cache.put(1, 1);
cache.put(2, 2);
cache.get(1);       // returns 1
cache.put(3, 3);    // evicts key 2
cache.get(2);       // returns -1 (not found)
cache.put(4, 4);    // evicts key 1
cache.get(1);       // returns -1 (not found)
cache.get(3);       // returns 3
cache.get(4);       // returns 4
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class LRUCache
    {
        private Dictionary<int, LinkedListNode> cache = new Dictionary<int, LinkedListNode>();
        private LinkedListNode head; // add to the head
        private LinkedListNode tail; // remove from tail
        private int capacity = 0;

        private class LinkedListNode
        {
            public int Key;
            public int Value;
            public LinkedListNode Next;
            public LinkedListNode Prev;

            public LinkedListNode(int key, int value)
            {
                this.Key = key;
                this.Value = value;
            }
        }

        public LRUCache(int capacity) 
        {
            cache = new Dictionary<int, LinkedListNode>();
            this.capacity = capacity;
        }
        
        public int Get(int key)
        {
            if (this.cache.ContainsKey(key))
            {
                this.RearrangeNode(key, this.cache[key].Value);
                return this.head.Value;
            }

            else return -1;
        }
        
        public void Put(int key, int value)
        {
            if (capacity == 0) throw new Exception("No puts are allowed as capacity is 0.");

            if (cache.ContainsKey(key))
            {
                LinkedListNode node = this.RearrangeNode(key, value);
                cache[key] = node;
                return;
            }

            LinkedListNode newNode = new LinkedListNode(key, value);

            if (cache.Count >= capacity)
            {
                cache.Remove(tail.Key);

                if (cache.Count == 0)
                {
                    // there was only one element;
                    head = null;
                    tail = null;
                }
                else
                {
                    // remove from tail
                    tail.Prev.Next = tail.Next;
                    tail = tail.Prev;                    
                }
            }

            if (cache.Count == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                // add to the head
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }            

            cache.Add(key, newNode);
        }

        public void Print()
        {
            LinkedListNode iter = head;
            while (iter != null)
            {
                Console.Write(iter.Key + ":" + iter.Value + "\t");
                iter = iter.Next;
            }

            Console.WriteLine();
        }

        private LinkedListNode RearrangeNode(int key, int value)
        {
            if (this.cache.ContainsKey(key))
            {
                LinkedListNode node = this.cache[key];
                node.Value = value;

                if (this.cache.Count != 1)
                {
                    if (node.Prev == null)
                    {
                        // head node
                        node.Next.Prev = null;
                        head = node.Next;
                    }
                    else if (node.Next == null)
                    {
                        // tail node
                        node.Prev.Next = node.Next;
                        tail = node.Prev;
                    }
                    else
                    {
                        // somewhere in the middle
                        node.Next.Prev = node.Prev;
                        node.Prev.Next = node.Next;
                    }

                    node.Prev = null;
                    node.Next = this.head;
                    this.head.Prev = node;
                    this.head = node;
                }

                return node;
            }

            return null;
        }
    }
}