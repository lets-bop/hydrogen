/*
3-node is represented using internal left-leaning links as glue.
     ( a b )                        b
   /    |    \               (red)/    \
(< a) (btw a&b) (>b)            a      > b
                              /   \
                            < a    btw a&b

Search in a red-black BST is exactly the same as a normal BST.
Most other ops (like floor, iteration, selection) are also the same.

*/

public class RedBlackBST<Key, Value> where Key : IComparable
{
    private static bool RED = true;
    private static bool BLACK = false;

    internal class Node
    {
        internal Key key;
        internal Value value;
        internal Node left, right;
        internal bool color;     // color of the parent link

        internal Node(Key key, Value value, bool color)
        {
            this.key = key;
            this.value = value;
            this.color = color;
        }
    }

    private Node Put(Node node, Key key, Value value)
    {
        if (node == null) return new Node(key, value, RED);
        if (node.key.CompareTo(key) < 0) node.right = this.Put(node.right, key, value);
        if (node.key.CompareTo(key) > 0) node.left = this.Put(node.left, key, value);
        else node.value = value;

        // right child red, left child black: rotate left
        // left child, left-left grandchild red: rotate right
        // both left and right child red: flip colors
        if (IsRed(node.right) && !IsRed(node.left)) node = this.RotateLeft(node);
        if (IsRed(node.left) && IsRed(node.left.left)) node = this.RotateLeft(node);
        if (IsRed(node.right) && IsRed(node.left)) node = this.FlipColors(node);
    }

    private bool IsRed(Node x)
    {
        if (x == null) return false; // null links are black
        return x.color == RED;
    }

    private Node RotateLeft(Node x)
    {
        Node r = x.right;                   //           x                          r
        x.right = r.left;                   //          /  \                     /       \
        r.left = x;                         //        < x   r                   x        > r
                                           //             /    \              /    \
                                          //          btw x,r   > r        <x      btw x,r

        // update colors
        r.color = x.color;
        x.color = RED;
        return r;       // the new root
    }

    private Node RotateRight(Node x)
    {
        Node l = x.left;                   //           x                       l
        x.left = l.right;                   //       /       \               /      \
        l.right = x;                       //      l        > x            <l        x
                                           //     /    \                          /     \
                                          //     <l   btw l,x                   btw l,x   >x

        // update colors
        l.color = x.color;
        x.color = RED;
        return r;       // the new root
    }

    private void FlipColors(Node x)
    {
        // recolor to split a temporary 4 node.
        x.color = RED;
        x.left.color = BLACK;
        x.right.color = BLACK;
    }
}