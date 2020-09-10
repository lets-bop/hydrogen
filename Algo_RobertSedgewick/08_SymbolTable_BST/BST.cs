public class BST<Key, Value> where Key : IComparable
{
    internal class Node
    {
        internal Key key;
        internal Value value;
        internal int count; // subtree size/count
        internal Node left, right;
        internal Node(Key key, Value value) {
            this.key = key;
            this.value = value;
        }
    }

    private Node root; // root of the BST

    public Value Get(Key key)
    {
        Node x = root;
        while (x != null) {
            if (x.key.CompareTo(key) == 0) return x.value;
            if (x.key.CompareTo(key) < 0) x = x.right;
            else x = x.left;
        }

        return default(Value);
    }

    public Value Put(Key key, Value value)
    {
        this.root = this.Put(this.root, key, value);
    }

    private Node Put(Node node, Key key, Value value)
    {
        if (node == null) return new Node(key, value);
        if (node.key.CompareTo(key) < 0) node.right = this.Put(node.right, key, value);
        else if (node.key.CompareTo(key) > 0) node.left = this.Put(node.left, key, value);
        else node.value = value;
        node.count = 1 + this.Size(x.left) + this.Size(x.right);
        return node;
    }

    public Key Floor(Key key)
    {
        // Largest key thats smaller than key
        Node x = root;
        Node ret = null;
        while (x != null) {
            if (x.key.CompareTo(key) == 0) return key;
            if (x.key.CompareTo(key) > 0) {
                ret = x;
                x = x.left;
            } else x = x.right;
        }

        if (ret != null) return ret.key;
        return default(Key);
    }

    public Key Ceiling(Key key)
    {
        // Smallest key thats larger than key
    }

    // Number of keys < k
    public int Rank(Key key)
    {
        return this.Rank(this.root, key);
    }

    private int Rank(Node node, Key key)
    {
        if (node == null) return 0;
        if (key.CompareTo(node.key) == 0) return this.Size(node);
        if (key.CompareTo(node.key) < 0) return this.Rank(node.left, key);
        return 1 + this.Size(node.left) + this.Rank(node.right, key);
    }

    public Iterable<Key> Keys()
    {
        Queue<Key> q = new Queue<Key>();
        this.Inorder(this.root, q);
        return q;
    }

    public void DeleteMin()
    {
        this.root = DeleteMin(this.root);
    }

    public void Delete(Key key)
    {
        this.root = this.Delete(this.root, key);
    }

    private int Size(Node x)
    {
        if (x == null) return 0;
        return x.count;
    }

    private void Inorder(Node node, Queue<Key> q)
    {
        if (node == null) return;
        this.Inorder(node.left, q);
        q.Enqueue(node.key);
        this.Inorder(node.right, q);
    }

    private Node DeleteMin(Node node)
    {
        if (node == null) return null;
        if (node.left == null) return node.right;
        node.left = this.DeleteMin(node.left);
        node.count = 1 + this.Size(node.left) + this.Size(node.right);
    }

    private Node Delete(Node node, Key key)
    {
        if (node == null) return null;
        if (node.key.CompareTo(key) < 0) node.right = this.Delete(node.right, key);
        else if (node.key.CompareTo(key) > 0) node.left = this.Delete(node.left, key);
        else {
            // Delete this node
            if (x.left == null) return x.right;
            if (x.right == null) return x.left;

            // replace with successor
            Node x = node;
            node = this.Min(node.right);
            node.right = this.DeleteMin(x.right);
            node.left = x.left;
        }

        // Update size
        node.size = 1 + this.Size(node.left) + this.Size(node.right);
        return node;
    }
}