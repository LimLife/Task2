using Task030923.Interfaces;

namespace Task030923.Sorts
{
    public class Bucket : ISort
    {  
        public List<int> Sort(ref List<int> arr)
        {
            var max = arr[0];
            var min = arr[0];

            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
                if (arr[i] < min)
                    min = arr[i];
            }

            List<int>[] bucket = new List<int>[max-min+1];
            for (int i = 0; i < bucket.Length; i++)
                bucket[i] = new List<int>();

            for (int i = 0; i < arr.Count; i++)                        
                bucket[arr[i] - min].Add(arr[i]);
            
            int position = 0;

            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)             
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        arr[position] = bucket[i][j];
                        position++;
                    }              
            }
            return arr;
        }


    }
}
