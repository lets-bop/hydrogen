using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class UnionFind
    {
        private Dictionary<int, int> dataToElementIdMap = new Dictionary<int, int>();
        private int[] elements;
        private int[] componentSize;
        int numberOfComponents;

        public UnionFind(int size)
        {
            this.elements = new int[size];
            this.componentSize = new int[size];
            this.numberOfComponents = size;

            for(int i = 0; i < size; i++){
                this.elements[i] = i;
                this.componentSize[i] = 1;
                this.dataToElementIdMap[i] = i;
            }
        }        

        public UnionFind(int[] data)
        {
            if (data == null || data.Length == 0) throw new Exception("Data cannot be null or empty");

            this.elements = new int[data.Length];
            this.componentSize = new int[data.Length];
            this.numberOfComponents = data.Length;

            int i = 0;
            foreach (int d in data){
                this.elements[i] = i;
                this.componentSize[i] = 1;
                this.dataToElementIdMap[d] = i;
                i++;
            }
        }

        public int Find(int data)
        {
            if (!this.dataToElementIdMap.ContainsKey(data)) throw new Exception("Union find was not initialized with this data");
            int elementId = this.dataToElementIdMap[data];
            int root = elementId;

            while (this.elements[root] != root){
                root = this.elements[root];
            }

            // Perform path path compression.
            if (root != elementId){
                while(this.elements[elementId] != root){
                    int parent = this.elements[elementId];
                    this.elements[elementId] = root;
                    elementId = parent;
                }
            }

            return root;
        }

        public void Union(int data1, int data2)
        {
            int root1 = this.Find(data1);
            int root2 = this.Find(data2);

            if (root1 == root2) return;

            // We merge the component with the smaller size with the larger one.
            if(this.componentSize[root1] >= this.componentSize[root2]){
                this.componentSize[root1] += this.componentSize[root2];
                this.elements[root2] = root1;
            }
            else{
                this.componentSize[root2] += this.componentSize[root1];
                this.elements[root1] = root2;                
            }

            this.numberOfComponents--;
        }

        public int NumberOfComponents()
        {
            return this.numberOfComponents;
        }
    }    
}