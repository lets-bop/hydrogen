using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class Deque
    {
        internal class Node
        {
            internal int Value;
            internal Node Next;
            internal Node Prev;


            internal Node(int value)
            {
                this.Value = value;
            }
        }

        Node Front;
        Node Rear;
        int Size = 0;

        public Deque()
        {
        }

        public bool IsEmpty()
        {
            if (this.Front == null && this.Rear == null) return true;
            return false;
        }

        public int Count()
        {
            return this.Size;
        }

        // Adds the element to the front of the deque.
        public void AddFirst(int element)
        {
            Node node = new Node(element);
            
            this.Size++;

            if (this.Front == null){
                this.Rear = node;
                this.Front = node;
                return;
            }

            this.Front.Next = node;
            node.Prev = this.Front;
            this.Front = node;
        }

        // Retrieves or removes the first element from the deque. Returns null if empty.
        public int PollFirst()
        {
            int retValue;

            if (this.Front == null) throw new Exception("No elements in the queue");

            this.Size--;
            retValue = this.Front.Value;
            Node front = this.Front;
            Node prev = front.Prev;
            front.Prev = null;

            if (prev == null){
                this.Front = null;
                this.Rear = null;
            }
            else{
                prev.Next = null;
                this.Front = prev;          
            }

            return retValue;
        }

        // Retrieves, but does not remove, the first element of this deque, or returns null if this deque is empty.
        public int PeekFirst()
        {
            if (this.Front == null) throw new Exception("No elements in the queue");
            return this.Front.Value;                        
        }

        // Adds the element to the front of the deque.
        public void AddLast(int element)
        {
            Node node = new Node(element);
            this.Size++;

            if (this.Rear == null){
                this.Rear = node;
                this.Front = node;
                return;
            }
            
            node.Next = this.Rear;
            this.Rear.Prev = node;
            this.Rear = node;
        }

        // Retrieves or removes the first element from the deque. Returns null if empty.
        public int PollLast()
        {
            if (this.Rear == null) throw new Exception("No elements in the queue.");

            this.Size--;
            int retValue = this.Rear.Value;
            Node next = this.Rear.Next;
            this.Rear.Next = null;
            if (next == null){
                this.Rear = null;
                this.Front = null;
            }
            else
            {
                this.Rear = next;
                next.Prev = null;
            }

            return retValue;
        }

        // Retrieves, but does not remove, the first element of this deque, or returns null if this deque is empty.
        public int PeekLast()
        {
            if (this.Rear == null) throw new Exception("No elements in the queue");
            return this.Rear.Value;
        }
    }
}