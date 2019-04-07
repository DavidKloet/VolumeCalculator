namespace Domain.Data
{
    public struct DataPoint
    {
        public decimal X { get; }

        public decimal Y { get; }

        public decimal Depth { get; }

        public DataPoint(decimal x, decimal y, decimal depth)
        {
            X = x;
            Y = y;
            Depth = depth;
        }
    }
}
