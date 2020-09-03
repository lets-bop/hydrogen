public class Stack<Item>
{
    internal class Node
    {
        internal Item item;
        internal Stack<Item> next;

        internal Node(Item item)
        {
            this.item = item;
        }
    }

    private Node top;

    public Item Pop()
    {
        if (this.IsEmpty()) return null;
        Item returnItem = top.item;
        top = top.next;
        return returnItem;
    }

    public void Push(Item item)
    {
        Node node = new Node(item);
        node.next = top;
        top = node;
    }

    public bool IsEmpty()
    {
        return this.top == null;
    }
}