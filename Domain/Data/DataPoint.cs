namespace Domain.Data
{
    public struct DataPoint
    {
        public int X { get; }

        public int Y { get; }

        public decimal Depth { get; }

        public DataPoint(int x, int y, NonNegativeDecimal depth)
        {
            X = x;
            Y = y;
            Depth = depth.Value;
        }
    }
}
