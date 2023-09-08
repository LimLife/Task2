using Task030923.Interfaces;

namespace Task030923.Sorts
{
    public class Bubble:ISort
    {      
        public List<int> Sort(ref List<int> arr)
        {
            for (int i = arr.Count-1; i >0; i--)          
                for (int j = 0; j< i; j++)              
                    if (arr[j] > arr[j + 1])
                        (arr[j + 1],arr[j]) = (arr[j], arr[j + 1]);                                           
            return arr;
        }       
    }
}
