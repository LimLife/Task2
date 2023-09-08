using Task030923.Interfaces;

namespace Task030923.Sorts
{
    public class Quick : ISort
    {
        public List<int> Sort(ref List<int> arr) => QuickSort(ref arr, 0, arr.Count - 1);

        static int Partition(ref List<int> array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    (array[i], array[pivot]) = (array[pivot], array[i]);
                }
            }
            pivot++;
            (array[maxIndex], array[pivot]) = (array[pivot], array[maxIndex]);
            return pivot;
        }
        static List<int> QuickSort(ref List<int> array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
                return array;

            var pivotIndex = Partition(ref array, minIndex, maxIndex);
            QuickSort(ref array, minIndex, pivotIndex - 1);
            QuickSort(ref array, pivotIndex + 1, maxIndex);
            return array;
        }
    }
}
