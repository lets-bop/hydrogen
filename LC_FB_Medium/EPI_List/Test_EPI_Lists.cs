namespace LC_FB_Medium
{
    class Test_EPI_Lists
    {
        public static void Run()
        {      
            // MergeSortedListTests();
            // ReverseSublistTests(); 
            TestPivotList();
        }

        private static void MergeSortedListTests()
        {
            CustomList list1 = CustomList.Create(new int[] {1, 5});
            CustomList list2 = CustomList.Create(new int[] {2, 3, 7});
            CustomList list = MergeSortedLists.Merge(list1, list2);
            CustomList.Print(list);

            list1 = CustomList.Create(new int[] {1});
            list2 = CustomList.Create(null);
            list = MergeSortedLists.Merge(list1, list2);
            CustomList.Print(list);

            list1 = CustomList.Create(null);
            list2 = CustomList.Create(new int[] {1});
            list = MergeSortedLists.Merge(list1, list2);
            CustomList.Print(list);

            list1 = CustomList.Create(new int[] {7,8});
            list2 = CustomList.Create(new int[] {1});
            list = MergeSortedLists.Merge(list1, list2);
            CustomList.Print(list);            
        }

        private static void ReverseSublistTests()
        {
            // Merge Sorted lists
            CustomList list1 = CustomList.Create(new int[] {1, 2, 3, 4, 5, 6, 7});
            ReverseSublist.Execute(list1, 2, 5);
            CustomList.Print(list1);

            list1 = CustomList.Create(new int[] {1}); 
            ReverseSublist.Execute(list1, 0, 5);
            CustomList.Print(list1);

            list1 = CustomList.Create(new int[] {1, 2, 3, 4, 5});
            ReverseSublist.Execute(list1, 0, 3);
            CustomList.Print(list1);   

            list1 = CustomList.Create(new int[] {1, 2, 3, 4, 5});
            ReverseSublist.Execute(list1, 0, 4);
            CustomList.Print(list1);             
        }

        private static void TestPivotList()
        {
            // Merge Sorted lists
            CustomList list1 = CustomList.Create(new int[] {4,4,1,3,5,5,4,7,9});
            PivotList.Execute(list1, 4);
            CustomList.Print(list1);

            list1 = CustomList.Create(new int[] {4,4,1,3,5,5,4,7,9});
            PivotList.Execute(list1, 1);
            CustomList.Print(list1);

            list1 = CustomList.Create(new int[] {4,4,1,3,5,5,4,7,9});
            PivotList.Execute(list1, 9);
            CustomList.Print(list1);           
        }        
    }
}