public class UF
{
    int[] cc;

    public UF(int n)
    {
        // O(n) time
        // Initialize the connected components. Each component gets a unique id.
        this.cc = new int[n];
        for (int i = 0; i < n; i++) this.cc[i] = i;
    }

    public void Union(int p, int q) 
    {
        // O(n) time. If union operation is called on n objects, this algorithm takes O(n^2).
        int pid = this.cc[p];
        int qid = this.cc[q];

        while(pid != qid) {
            for (int i = 0; i < this.cc.Length; i++) {
                if (this.cc[i] == pid) this.cc[i] = qid; // change all entries with cc[p] to cc[q].
            }
        }
    }

    public void QuickUnion(int p, int q) 
    {
        // Interpretation: An entry maps to its immediate parent. So the array will be a set of trees (forest),
        // where each tree forms a separate connected component.
        // To merge components containing p and q, make p's root point to q's root. 
        // The defect is that trees can get tall.
        // O(n) time. If union operation is called on n objects, this algorithm takes O(n^2).
        int p_root = this.Root(p);
        int q_root = this.Root(q);

        this.cc[p_root] = q_root;
    }

    public int Root(int p)
    {
        // returns the root of p. i.e. keep looking for an entry which is equal to the array index
        // The defect is that trees can get tall and hence the max time is O(n) time
        while (p != this.cc[p]) p = this.cc[p];
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