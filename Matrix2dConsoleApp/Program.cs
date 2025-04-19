using Matrix2dLib;

class Program
{
    static void Main(string[] args)
    {
        // Konstruktor z argumentami
        var m1 = new Matrix2d(1, 2, 3, 4);
        Console.WriteLine($"Macierz m1: {m1}");

        // Konstruktor domyślny (macierz jednostkowa)
        var m2 = new Matrix2d();
        Console.WriteLine($"Macierz m2 (domyślna): {m2}");

        // Właściwości statyczne: Id (macierz jednostkowa) i Zero (macierz zerowa)
        Console.WriteLine($"Macierz jednostkowa (Id): {Matrix2d.Id}");
        Console.WriteLine($"Macierz zerowa (Zero): {Matrix2d.Zero}");

        // Operator dodawania
        var sum = m1 + m2;
        Console.WriteLine($"Suma m1 + m2: {sum}");

        // Operator odejmowania
        var diff = m1 - m2;
        Console.WriteLine($"Różnica m1 - m2: {diff}");

        // Operator mnożenia macierzy
        var product = m1 * m2;
        Console.WriteLine($"Iloczyn m1 * m2: {product}");

        // Operator mnożenia macierzy przez skalar
        var scaled = m1 * 2;
        Console.WriteLine($"Macierz m1 pomnożona przez 2: {scaled}");

        // Operator negacji
        var negated = -m1;
        Console.WriteLine($"Negacja macierzy m1: {negated}");

        // Transpozycja macierzy
        var transposed = m1.Transpose(m1);
        Console.WriteLine($"Transpozycja macierzy m1: {transposed}");

        // Wyznacznik macierzy
        var determinant = m1.Det();
        Console.WriteLine($"Wyznacznik macierzy m1: {determinant}");

        // Wyznacznik macierzy (metoda statyczna)
        var determinantStatic = m1.Determinant(m1);
        Console.WriteLine($"Wyznacznik macierzy m1 (metoda statyczna): {determinantStatic}");

        // Konwersja macierzy na tablicę int[,]
        int[,] array = (int[,])m1;
        Console.WriteLine("Macierz m1 jako tablica int[,]:");
        Console.WriteLine($"[{array[0, 0]}, {array[0, 1]}]");
        Console.WriteLine($"[{array[1, 0]}, {array[1, 1]}]");

        // Konwersja tablicy int[,] na macierz
        var m3 = (Matrix2d)new int[,] { { 5, 6 }, { 7, 8 } };
        Console.WriteLine($"Macierz m3 utworzona z tablicy int[,]: {m3}");

        // Parsowanie macierzy z ciągu znaków
        var parsedMatrix = Matrix2d.Parse("[[9, 10], [11, 12]]");
        Console.WriteLine($"Macierz sparsowana z ciągu znaków: {parsedMatrix}");

        // Porównanie macierzy (operator == i !=)
        Console.WriteLine($"Czy m1 == m2? {m1 == m2}");
        Console.WriteLine($"Czy m1 != m2? {m1 != m2}");

        // Porównanie macierzy (Equals)
        Console.WriteLine($"Czy m1.Equals(m2)? {m1.Equals(m2)}");
    }
}
