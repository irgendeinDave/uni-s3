namespace ex4;

public class MergeAndHeap
{
    
    public static void HeapSort(int[] arr)
    {
        if (arr.Length < 2) return;
        int n = arr.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, i, n);

        for (int end = n - 1; end > 0; end--)
        {
            (arr[0], arr[end]) = (arr[end], arr[0]);
            Heapify(arr, 0, end);
            Console.Write("{");
            foreach (var element in arr)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine("}");
        }
    }

    private static void Heapify(int[] arr, int i, int n)
    {
        while (true)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;

            if (left < n && arr[left] > arr[largest]) largest = left;
            if (right < n && arr[right] > arr[largest]) largest = right;

            if (largest == i) break;

            (arr[i], arr[largest]) = (arr[largest], arr[i]);
            i = largest;
        }
    }
    public static void MergeSort(int[] arr)
    {
        if (arr.Length < 2) return;
        MergeSort(arr, 0, arr.Length - 1);
    }

    private static void MergeSort(int[] arr, int left, int right)
    {
        if (left >= right) return;
        int mid = left + (right - left) / 2;
        MergeSort(arr, left, mid);
        MergeSort(arr, mid + 1, right);
        Merge(arr, left, mid, right);
    }

    private static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++) L[i] = arr[left + i];
        for (int j = 0; j < n2; j++) R[j] = arr[mid + 1 + j];

        int p = 0, q = 0, k = left;
        while (p < n1 && q < n2)
        {
            if (L[p] <= R[q])
            {
                arr[k++] = L[p++];
            }
            else
            {
                arr[k++] = R[q++];
            }
        }
        while (p < n1) arr[k++] = L[p++];
        while (q < n2) arr[k++] = R[q++];
        
        Console.Write("{");
        for (var i = left; i <= right; i++)   
        {
            Console.Write($"{arr[i]} ");
        }
        Console.WriteLine("}");
    }

    public static void Main(String[] args)
    {
        int[] arr = {-5, 13, -32, 7, -3, 17, 23, 12, -35, 19 };
        HeapSort(arr);
    }
}