using Task030923.Interfaces;

namespace Task030923.Sorts
{
    public class Merge : ISort
    {
        public List<int> Sort(ref List<int> arr) => MergeSort(ref arr, 0, arr.Count - 1);
        private List<int> MergeSort(ref List<int> arr, int left, int right)
        {
            if (left < right)
            {
                var average = (left + right) / 2;
                MergeSort(ref arr, left, average); //left
                MergeSort(ref arr, average + 1, right);//right
                Merging(ref arr, left, average, right);
            }
            return arr;
        }
        private void Merging(ref List<int> arr, int lowIndex, int average, int highIndex)
        {
            int left = lowIndex;
            int right = average + 1;

            var temp = new int[highIndex - lowIndex + 1];

            int index = 0;

            while ((left <= average) && (right <= highIndex))
            {
                if (arr[left] < arr[right])
                {
                    temp[index] = arr[left];
                    left++;
                }
                else
                {
                    temp[index] = arr[right];
                    right++;
                }
                index++;
            }
            for (int i = left; i <= average; i++)
            {
                temp[index] = arr[i];
                index++;
            }
            for (int i = right; i <= highIndex; i++)
            {
                temp[index] = arr[i];
                index++;
            }
            for (int i = 0; i < temp.Length; i++)
            {
                arr[lowIndex] = temp[i];
                lowIndex++;
            }
        }
    }
}
