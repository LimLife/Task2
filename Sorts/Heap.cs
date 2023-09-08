using Task030923.Interfaces;

namespace Task030923.Sorts
{
    public class Heap : ISort
    { 
        public List<int> Sort(ref List<int> arr)
        {
            var heapSize = arr.Count;

            for (int i = (heapSize - 1) / 2; i >= 0; i--)
                MaxHeap(ref arr, heapSize, i);
            for (int i = arr.Count-1; i > 0; i--)
            {
                (arr[0], arr[i]) = (arr[i], arr[0]);
                heapSize--;
                MaxHeap(ref arr, heapSize, 0);
            }
            return arr;
        }

        private void MaxHeap(ref List<int> arr, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = index;

            if (left < heapSize && arr[left] > arr[index])
                largest = left;
            if (right < heapSize && arr[right] > arr[largest])
                largest = right;
            if (largest != index)
            {
                (arr[index], arr[largest]) = (arr[largest], arr[index]);
                MaxHeap(ref arr, heapSize, largest);
            }
        }
    }
}
