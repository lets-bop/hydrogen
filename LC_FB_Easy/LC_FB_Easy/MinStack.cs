using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_FB_Easy
{
    /*
        Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

        push(x) -- Push element x onto stack.
        pop() -- Removes the element on top of the stack.
        top() -- Get the top element.
        getMin() -- Retrieve the minimum element in the stack.
 

        Example:

        MinStack minStack = new MinStack();
        minStack.push(-2);
        minStack.push(0);
        minStack.push(-3);
        minStack.getMin();   --> Returns -3.
        minStack.pop();
        minStack.top();      --> Returns 0.
        minStack.getMin();   --> Returns -2.
     * */
    public class MinStack
    {
        Node top;

        public class Node
        {
            public int data;
            public Node prev;
            public int min;

            public Node(int data, int min)
            {
                this.data = data;
                this.min = min;
            }
        }

        public MinStack()
        {
            this.top = null;
        }

        public void Push(int x)
        {
            Node node;
            if (this.top != null && this.top.min < x)
            {
                node = new Node(x, this.top.min);
                node.prev = this.top;
            }
            else
            {
                node = new Node(x, x);
                if (this.top != null) node.prev = this.top;
            }

            this.top = node;
        }

        public void Pop()
        {
            if (this.top == null) return;
            Node delNode = this.top;
            this.top = this.top.prev;
            delNode = null;
        }

        public int Top()
        {
            return this.top.data;
        }

        public int GetMin()
        {
            if (this.top != null) return this.top.min;
            throw new Exception("Not a valid operation.");
        }
    }

}
