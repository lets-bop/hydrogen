using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class Test_EPI_Trees
    {
        public static void Run()
        {
            // CustomTreeTest();
            // TestCheckHeightBalanced();
            // TestCheckSymmetric();
            // TestLCA();
            // TestLCAWithParent();
            TestSuccessor();
        }

        private static void TestCheckHeightBalanced()
        {
            CustomTree<int> tree = CustomTree<int>.Build(
                new List<int>() {55, 2, 1, 44, 77, 21, 22, 9, 99, 6, 7}, 
                new List<int>() {22, 44, 2, 55, 1, 21, 77, 9, 6, 99, 7 });            
            Console.WriteLine("CheckHeightBalanced. Expected: False. Result: " + CheckHeightBalanaced.Execute(tree));

            tree = CustomTree<int>.Build(
                new List<int>() {55, 2, 1, 44, 77, 21, 22, 8, 9, 99, 6, 7}, 
                new List<int>() {22, 44, 2, 55, 1, 21, 77, 9, 8, 6, 99, 7 });      
            Console.WriteLine("CheckHeightBalanced. Expected: True. Result: " + CheckHeightBalanaced.Execute(tree));     
        }

        private static void TestCheckSymmetric()
        {
            /*
                                 22
                               /    \
                              44    44
                            /  \   /  \
                           2   21 21   2
                          / \        /  \
                         55  1      1   55            
            */            
            CustomTree<int> tree = CustomTree<int>.Build(
                new List<int>() {55, 2, 1, 44, 21, 22, 21, 44, 1, 2, 55}, 
                new List<int>() {22, 44, 2, 55, 1, 21, 44, 21, 2, 1, 55});
            Console.WriteLine("CheckSymmetric. Expected: True. Result: " + CheckSymmetric.Execute(tree));

            tree = CustomTree<int>.Build(
                new List<int>() {55, 2, 1, 44, 21, 22, 21, 44, 1, 2, 54}, 
                new List<int>() {22, 44, 2, 55, 1, 21, 44, 21, 2, 1, 54});  
            Console.WriteLine("CheckSymmetric. Expected: False. Result: " + CheckSymmetric.Execute(tree));        
        }

        private static void TestLCA()
        {
            /*
                                22
                               /   \
                              44   9
                            /  \    \
                           2   21    6
                          / \  /    /  \
                         55  1 77  99  7

            */            
            CustomTree<int> tree = CustomTree<int>.Build(
                new List<int>() {55, 2, 1, 44, 77, 21, 22, 9, 99, 6, 7}, 
                new List<int>() {22, 44, 2, 55, 1, 21, 77, 9, 6, 99, 7 });
            CustomTree<int>.Node node1 = CustomTree<int>.GetNode(tree.Root, 44);
            CustomTree<int>.Node node2 = CustomTree<int>.GetNode(tree.Root, 7);
            Console.WriteLine("LCA of 44 and 7. Expected: 22. Result: " + LCA.Execute(tree, node1, node2).Data);

            node2 = CustomTree<int>.GetNode(tree.Root, 77);
            Console.WriteLine("LCA of 44 and 77. Expected: 44. Result: " + LCA.Execute(tree, node1, node2).Data);

            node2 = CustomTree<int>.GetNode(tree.Root, 21);
            Console.WriteLine("LCA of 44 and 21. Expected: 44. Result: " + LCA.Execute(tree, node1, node2).Data);

            node2 = CustomTree<int>.GetNode(tree.Root, 44);
            Console.WriteLine("LCA of 44 and 44. Expected: 44. Result: " + LCA.Execute(tree, node1, node2).Data);
        }

        private static void TestLCAWithParent()
        {
            /*
                                22
                               /   \
                              44   9
                            /  \    \
                           2   21    6
                          / \  /    /  \
                         55  1 77  99  7

            */            
            CustomTree<int> tree = CustomTree<int>.Build(
                new List<int>() {55, 2, 1, 44, 77, 21, 22, 9, 99, 6, 7}, 
                new List<int>() {22, 44, 2, 55, 1, 21, 77, 9, 6, 99, 7 });
            CustomTree<int>.Node node1 = CustomTree<int>.GetNode(tree.Root, 44);
            CustomTree<int>.Node node2 = CustomTree<int>.GetNode(tree.Root, 7);
            Console.WriteLine("LCA of 44 and 7. Expected: 22. Result: " + LCAWithParent.Execute(tree, node1, node2).Data);

            node2 = CustomTree<int>.GetNode(tree.Root, 77);
            Console.WriteLine("LCA of 44 and 77. Expected: 44. Result: " + LCAWithParent.Execute(tree, node1, node2).Data);

            node2 = CustomTree<int>.GetNode(tree.Root, 21);
            Console.WriteLine("LCA of 44 and 21. Expected: 44. Result: " + LCAWithParent.Execute(tree, node1, node2).Data);

            node2 = CustomTree<int>.GetNode(tree.Root, 44);
            Console.WriteLine("LCA of 44 and 44. Expected: 44. Result: " + LCAWithParent.Execute(tree, node1, node2).Data);

            node1 = CustomTree<int>.GetNode(tree.Root, 22);
            node2 = CustomTree<int>.GetNode(tree.Root, 22);
            Console.WriteLine("LCA of 22 and 22. Expected: 22. Result: " + LCAWithParent.Execute(tree, node1, node2).Data);
        }

        private static void TestSuccessor()
        {
            /*
                                22
                               /   \
                              44   9
                            /  \    \
                           2   21    6
                          / \  /    /  \
                         55  1 77  99  7

            */
            CustomTree<int> tree = CustomTree<int>.Build(
                new List<int>() {55, 2, 1, 44, 77, 21, 22, 9, 99, 6, 7}, 
                new List<int>() {22, 44, 2, 55, 1, 21, 77, 9, 6, 99, 7 });
            CustomTree<int>.Node node1 = CustomTree<int>.GetNode(tree.Root, 44);
            CustomTree<int>.Node successor = Successor.GetNext(node1);
            if (successor == null) Console.WriteLine("No successor");
            else Console.WriteLine("Successor of 44. Expected: 77. Result: " + successor.Data);

            node1 = CustomTree<int>.GetNode(tree.Root, 77);
            successor = Successor.GetNext(node1);
            if (successor == null) Console.WriteLine("No successor");
            else Console.WriteLine("Successor of 77. Expected: 21. Result: " + successor.Data);

            node1 = CustomTree<int>.GetNode(tree.Root, 21);
            successor = Successor.GetNext(node1);
            if (successor == null) Console.WriteLine("No successor");
            else Console.WriteLine("Successor of 21. Expected: 22. Result: " + successor.Data);
        }

        private static void CustomTreeTest()
        {

            /*
                                22
                               /   \
                              44   9
                            /  \    \
                           2   21    6
                          / \  /    /  \
                         55  1 77  99  7

            */


            CustomTree<int> tree = CustomTree<int>.Build(
                new List<int>() {55, 2, 1, 44, 77, 21, 22, 9, 99, 6, 7}, 
                new List<int>() {22, 44, 2, 55, 1, 21, 77, 9, 6, 99, 7 });

            tree.Print();
        }
    }
}





