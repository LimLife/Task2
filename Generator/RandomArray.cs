namespace Task030923.Generator
{
    public class RandomArray
    {
        private readonly int _min;
        private readonly int _max;

        private readonly int _minCapacity;
        private readonly int _maxCapacity;

        private readonly Random _random;
        public RandomArray(int min = -100, int max = 100, int micCapacity = 20, int maxCapacity = 100)
        {
            _min = min;
            _max = max;
            _minCapacity = micCapacity;
            _maxCapacity = maxCapacity;
            _random = new Random();
        }

        public List<int> GetArray()
        {
            var list = new List<int>();
            var elements = _random.Next(_minCapacity, _maxCapacity);
            for (int i = 0; i < elements; i++)
                list.Add(_random.Next(_min, _max));
            return list;
        }


    }
}
