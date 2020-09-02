public class UF_Weighted
{
    int[] cc;
    int[] sz;

    public UF_Weighted(int n)
    {
        // O(n) time
        // Initialize the connected components. Each component gets a unique id.
        this.sz = new int[n];
        this.cc = new int[n];
        for (int i = 0; i < n; i++) this.cc[i] = i;
    }

    public void QuickUnion(int p, int q) 
    {
        // Interpretation: An entry maps to its immediate parent. So the array will be a set of trees (forest),
        // where each tree forms a separate connected component.
        // To merge components containing p and q, we always connect the root of the smaller tree to the root of the the larger tree.
        // This guarantees that the max depth of any node is at most lg n. Why?
        // If the depth of a tree is increasing by 1, then its size doubles. 
        // And we can double the size at most lg n times before it becomes n.
        // O(lg n) time. If union operation is called on n objects, this algorithm takes O(n ^ lg n).
        int p_root = this.Root(p);
        int q_root = this.Root(q);

        if (this.sz[p_root] > this.sz[q_root]) {
            this.cc[q_root] = p_root;
            this.sz[p_root] += this.sz[q_root];
        }
        else {
            this.cc[p_root] = q_root;
            this.sz[q_root] += this.sz[p_root];
        }
    }

    public int Root(int p)
    {
        // returns the root of p. i.e. keep looking for an entry which is equal to the array index
        // O(lg n) as the depth of the tree can be max lg n
        while (p != this.cc[p]){
            // Path compression by making each entry point to its grand parent
            this.cc[p] = this.cc[this.cc[p]];
            p = this.cc[p];
        }
        
        return p;
    }

    public bool Connected(int p, int q)
    {
        // without quick union.
        // return this.cc[p] == this.cc[q]; // check for valid inputs

        // with quick union-find
        return this.Root(p) == this.Root(q);
    }
}