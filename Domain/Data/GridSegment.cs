using System;

namespace Domain.Data
{
    public struct GridSegment
    {
        public DataPoint TopLeft { get; }

        public DataPoint TopRight { get; }

        public DataPoint BottomLeft { get; }

        public DataPoint BottomRight { get; }

        public GridSegment(DataPoint topLeft, DataPoint topRight, DataPoint bottomLeft, DataPoint bottomRight)
        {
            if (topLeft.X - topRight.X != bottomLeft.X - bottomRight.X ||
               topLeft.Y - bottomLeft.Y != topRight.Y - bottomRight.Y) throw new ArgumentException("Segment must be a rectagle");

            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
        }
    }
}
