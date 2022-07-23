namespace P05._Play_Catch
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            const int maxCountOfExceptions = 3;

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int countOfExceptions = 0;

            while (countOfExceptions < maxCountOfExceptions)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string cmdType = cmdArgs[0];
                string[] cmdParams = cmdArgs.Skip(1).ToArray();

                try
                {
                    switch (cmdType)
                    {
                        case "Replace":
                            Replace(input, cmdParams);
                            break;

                        case "Print":
                            Print(input, cmdParams);
                            break;
                        case "Show":
                            Show(input, cmdParams);
                            break;
                    }
                }
                catch (FormatException)
                {
                    countOfExceptions++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
                catch (IndexOutOfRangeException)
                {
                    countOfExceptions++;
                    Console.WriteLine("The index does not exist!");
                }
            }

            Console.WriteLine(string.Join(", ", input));
        }

        private static void Replace(int[] input, string[] cmdParams)
        {
            int index = int.Parse(cmdParams[0]);
            int element = int.Parse(cmdParams[1]);
            input[index] = element;
        }
        private static void Print(int[] input, string[] cmdParams)
        {
            int firstIndex = int.Parse(cmdParams[0]);
            int secondIndex = int.Parse(cmdParams[1]);

            int[] newArray = new int[secondIndex - firstIndex +1];

            int count = 0;
            for (int i = firstIndex; i <= secondIndex; i++)
            {
                newArray[count] = input[i];
                count++;
            }

            Console.WriteLine(string.Join(", ", newArray));
        }
        private static void Show(int[] input, string[] cmdParams)
        {
            int index = int.Parse(cmdParams[0]);
            Console.WriteLine(input[index]);
        }
    }
}
