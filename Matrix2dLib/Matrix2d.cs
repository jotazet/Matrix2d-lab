namespace Matrix2dLib
{
    // immutable 2x2 matrix
    public class Matrix2d
    {
        private int _a, _b, _c, _d;
        public Matrix2d(int a, int b, int c, int d)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }
        public Matrix2d() : this(1, 0, 0, 1) { }

        // properties (metody z dużej litery)
        public int A => _a;
        public int B => _b;
        public int C => _c;
        public int D => _d;
        public static Matrix2d Id => new Matrix2d();
        public static Matrix2d Zero => new Matrix2d(0, 0, 0, 0);

        // methods
        override public string ToString() => $"[[{_a}, {_b}], [{_c}, {_d}]]";
    }
}