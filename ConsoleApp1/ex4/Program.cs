namespace ex4;

class Program
{
    private static int[] arr = new int[10];

    private static void randomArray()
    {
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = Random.Shared.Next(1000);
        }
    }

    private static void bubbleSort()
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]); // swap
                }
            }
        }
    }

    static void Main(string[] args)
    {
        randomArray();
        bubbleSort();
        Console.WriteLine(arr);
    }
}