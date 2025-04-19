#nullable disable
namespace Matrix2dLib;

// immutable 2x2 matrix
public class Matrix2d : IEquatable<Matrix2d>
{
    private int a, b, c, d;
    public Matrix2d(int a, int b, int c, int d)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        this.d = d;
    }
    public Matrix2d() : this(1, 0, 0, 1) { }

    // properties (metody z dużej litery)
    public int A => a;
    public int B => b;
    public int C => c;
    public int D => d;
    public static Matrix2d Id => new Matrix2d();
    public static Matrix2d Zero => new Matrix2d(0, 0, 0, 0);

    // metody
    override public string ToString() => $"[[{a}, {b}], [{c}, {d}]]";

    public static Matrix2d Parse(string matrix)
    {
        if (string.IsNullOrWhiteSpace(matrix))
            throw new FormatException("Input string is null or empty.");

        // Sprawdź, czy format pasuje do oczekiwanego wzorca
        if (!matrix.StartsWith("[[") || !matrix.EndsWith("]]"))
            throw new FormatException("Input string must start with '[[' and end with ']]'.");

        // Usuń zewnętrzne nawiasy
        matrix = matrix.Substring(2, matrix.Length - 4);

        // Podziel na wiersze
        var rows = matrix.Split("], [");
        if (rows.Length != 2)
            throw new FormatException("Input string must contain exactly two rows.");

        try
        {
            // Parsuj elementy wierszy
            var row1 = rows[0].Split(',').Select(int.Parse).ToArray();
            var row2 = rows[1].Split(',').Select(int.Parse).ToArray();

            if (row1.Length != 2 || row2.Length != 2)
                throw new FormatException("Each row must contain exactly two elements.");

            return new Matrix2d(row1[0], row1[1], row2[0], row2[1]);
        }
        catch (Exception ex)
        {
            throw new FormatException("Input string is not in the correct format.");
        }
    }

    #region Equals
    public bool Equals(Matrix2d other)
    {
        if (other is null) return false;
        return a == other.a
            && b == other.b 
            && c == other.c 
            && d == other.d;
    }

    public static bool operator ==(Matrix2d left, Matrix2d right)
        => left.Equals(right);
    public static bool operator !=(Matrix2d left, Matrix2d right)
        => !left.Equals(right);
    #endregion

    #region Artmetic
    public static Matrix2d operator +(Matrix2d left, Matrix2d right)
        => new Matrix2d(
            left.a + right.a, 
            left.b + right.b, 
            left.c + right.c, 
            left.d + right.d
            );
    public static Matrix2d operator -(Matrix2d left, Matrix2d right)
        => new Matrix2d(
            left.a - right.a,
            left.b - right.b,
            left.c - right.c,
            left.d - right.d
            );
    public static Matrix2d operator *(Matrix2d left, Matrix2d right)
        => new Matrix2d(
            left.a * right.a + left.b * right.c,
            left.a * right.b + left.b * right.d,
            left.c * right.a + left.d * right.c,
            left.c * right.b + left.d * right.d
            );
    public static Matrix2d operator *(Matrix2d left, int right)
        => new Matrix2d(
            left.a * right,
            left.b * right,
            left.c * right,
            left.d * right
            );
    public static Matrix2d operator *(int left, Matrix2d right)
        => right * left;

    public static Matrix2d operator -(Matrix2d m)
        => new Matrix2d(-m.a, -m.b, -m.c, -m.d);

    public Matrix2d Transpose(Matrix2d A)
    {
        if (A == null)
            throw new ArgumentNullException();
        return new Matrix2d(A.a, A.c, A.b, A.d);
    }

    public int Det()
    {
        return a * d - b * c;
    }

    public int Determinant(Matrix2d A)
    {
        if (A == null)
            throw new ArgumentNullException();
        return A.a * A.d - A.b * A.c;
    }
    #endregion
    #region Conversion
    // konwersja jawna z Matrix2d do int[,]
    public static explicit operator int[,](Matrix2d m)
        => new int[,] { { m.a, m.b }, { m.c, m.d } };

    // konwersja niejawna z int[,] do Matrix2d
    public static implicit operator Matrix2d(int[,] m)
        => new Matrix2d(m[0, 0], m[0, 1], m[1, 0], m[1, 1]);
    #endregion
}