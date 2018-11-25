using System;

namespace Scale
{
    public class Scale<T> where T : IComparable<T> 
    {
        public T Left { get; set; }

        public T Right { get; set; }

        public Scale(T left, T right)
        {
            if (left == null) throw new ArgumentException(nameof(left));
            if (right == null) throw new ArgumentException(nameof(right));

            this.Left = left;
            this.Right = right;
        }

        public T GetHeavier()
        {
            if (Left.Equals(Right))
            {
                return default(T);
            }

            // if Left is greater then Right, then will return 1 
            if (Left.CompareTo(Right) > 0)
            {
                return Left;
            }
            else
            {
                return Right;
            }
        }
    }
}