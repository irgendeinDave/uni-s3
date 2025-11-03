namespace ex4;

// Laufzeit und Korrektheit bleiben gleich, da die gleichen Aktionen durchgeführt werden, 
// nur in anderer Reihenfolge
public class Ex1
{
    private int[] arr = new int[1000];

    public void RandomArray()
    {
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = Random.Shared.Next(1000);
        }
    }

    public void SelectionSort()
    {
        int i, j, max;
        for (i = arr.Length - 1; i >= 0; i--)
        {
            max = i;
            for (j = i; j >= 0; j--)
            {
                if (arr[j] > arr[max]) max = j;
            }

            (arr[max], arr[i]) = (arr[i], arr[max]);
        }
    }

    public void InsertionSort()
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minIdx])
                    minIdx = j;
            }

            if (minIdx != i)
                (arr[i], arr[minIdx]) = (arr[minIdx], arr[i]);
        }
    }

    public void BubbleSort()
    {
        bool swapped;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    swapped = true;
                }
            }

            if (!swapped) break; // early exit
        }
    }

    private static int Partition(int[] arr, int f, int l, int iteration)
    {
        int pivot;
        if (iteration == 0) pivot = Random.Shared.Next(arr.Length);
        else pivot = arr[l];
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

    public static void QuickSort(int[] arr, int f, int l, int iteration)
    {
        if (f < l)
        {
            int p = Partition(arr, f, l, iteration);
            QuickSort(arr, f, p - 1, iteration + 1);
            QuickSort(arr, p + 1, l, iteration + 1);
        }
    }
}