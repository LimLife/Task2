using Task030923.Interfaces;

namespace Task030923.Sorts
{
    public class Counting : ISort
    {
        public List<int> Sort(ref List<int> arr)
        {
            var listPositive = new List<int>();
            var listNegative = new List<int>();

            //Sort into negative and positive.
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] >= 0)
                    listPositive.Add(arr[i]);
                else
                    listNegative.Add(arr[i]);
            }
            var maxPositive = listPositive[0];
            var maxNegative = listNegative[0];
            //Negative arr cast to positive
            for (int i = 0; i < listNegative.Count; i++)
                listNegative[i] *= -1;

            //Find max value from positive array 
            for (int i = 0; i < listPositive.Count; i++)
                if (listPositive[i] > maxPositive)
                    maxPositive = listPositive[i];
            //Find max value from negative array
            for (int i = 0; i < listNegative.Count; i++)
                if (listNegative[i] > maxNegative)
                    maxNegative = listNegative[i];

            //Counting 
            var countPositive = new int[maxPositive + 1];
            var countNegative = new int[maxNegative + 1];
            //Sorting
            for (int i = 0; i < listPositive.Count; i++)
                countPositive[listPositive[i]]+=1;
            for (int i = 0; i < listNegative.Count; i++)
                countNegative[listNegative[i]]+=1;

            int indexPositive = 0;
            int indexNegative = 0;

            for (int i = 0; i < countPositive.Length; i++)
                for (int j = 0; j < countPositive[i]; j++)
                {
                    listPositive[indexPositive] = i;
                    indexPositive++;
                }
            for (int i = countNegative.Length-1; i >= 0; i--)
                for (int j = 0; j < countNegative[i]; j++)
                {
                    listNegative[indexNegative] = i * -1;
                    indexNegative++;
                }

            var result = new List<int>();
            result.AddRange(listNegative);
            result.AddRange(listPositive);
            return result;
        }
    }
}
