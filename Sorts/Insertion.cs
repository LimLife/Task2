using Task030923.Interfaces;

namespace Task030923.Sorts
{
    public class Insertion : ISort
    {
        public List<int> Sort(ref List<int> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                var key = arr[i];
                var count = i;
                while (count > 0 && arr[count - 1] > key)
                {
                    (arr[count], arr[count - 1]) = (arr[count - 1], arr[count]);
                    count--;
                }
                arr[count] = key;
            }
            return arr;
        }
    }
}
