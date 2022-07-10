namespace CollectionHierarchy
{
    using System;
    using Contracts;
    using Models;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputStrings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int countOfRemoveOp = int.Parse(Console.ReadLine());

            IAddable addCollection = new AddCollection();
            IAddRemovable addRemovableCollection = new AddRemoveCollection();
            IMyList myList = new MyList();

            Adding(addCollection, inputStrings);
            Adding(addRemovableCollection, inputStrings);
            Adding(myList, inputStrings);

            Removing(addRemovableCollection, inputStrings, countOfRemoveOp);
            Removing(myList, inputStrings, countOfRemoveOp);
        }

        private static void Adding(IAddable collection, string[] input)
        {
            foreach (var item in input)
            {
                Console.Write(collection.Add(item) + " ");
            }

            Console.WriteLine();
        }
        private static void Removing(IAddRemovable collection, string[] inputStrings, int countOfRemoveOp)
        {
            for (int i = 0; i < countOfRemoveOp; i++)
            {
                Console.Write(collection.Remove() + " ");
            }

            Console.WriteLine();
        }
    }
}
