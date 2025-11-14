using System.Diagnostics;

namespace ex4;

// Exercise 2
class Program
{
    private static int[] arr = new int[10];

    private static void RandomArray()
    {
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = Random.Shared.Next(1000);
        }
    }

    private static void BubbleSort()
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

    private static int Partition(int[] arr, int f, int l)
    {
        int pivot = arr[l];
        int i = f - 1;
        for (int j = f; j < l; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }

        (arr[i + 1], arr[l]) = (arr[l], arr[i + 1]);
        return i + 1;
    }

    private static void QuickSort(int[] arr, int f, int l)
    {
        if (f < l)
        {
            int p = Partition(arr, f, l);
            QuickSort(arr, f, p - 1);
            QuickSort(arr, p + 1, l);
        }
    }

    public static class MergeSorterIterative
    {
        public static void MergeSortIterative(int[] a)
        {
            int n = a.Length;
            if (n < 2) return;
            var temp = new int[n];

            for (int width = 1; width < n; width *= 2)
            {
                for (int left = 0; left < n - width; left += 2 * width)
                {
                    int mid = left + width - 1;
                    int right = Math.Min(left + 2 * width - 1, n - 1);
                    Merge(a, temp, left, mid, right);
                }
            }
        }

        private static void Merge(int[] a, int[] temp, int left, int mid, int right)
        {
            int i = left, j = mid + 1, k = left;

            while (i <= mid && j <= right)
            {
                if (a[i] <= a[j]) temp[k++] = a[i++];
                else temp[k++] = a[j++];
            }

            while (i <= mid) temp[k++] = a[i++];
            while (j <= right) temp[k++] = a[j++];

            for (int t = left; t <= right; t++) a[t] = temp[t];
        }
    }

    private static void TestAlgorithms()
    {
        int size = 10_000_000;
        while (true)
        {
            size += 100000;
            arr = new int[size];
            RandomArray();
            var sw = Stopwatch.StartNew();
            MergeSorterIterative.MergeSortIterative(arr);
            // use other methods here to test
            sw.Start();
            Console.WriteLine($"{size} elements sorted in {sw.ElapsedMilliseconds} ms.");
            if (sw.ElapsedMilliseconds >= 60_000)
            {
                break;
            }
        }
    }

    /*static void Main(string[] args)
    {
        //TestAlgorithms();
        var e = new Ex1();
        e.RandomArray();
        e.InsertionSort();
    }*/
}