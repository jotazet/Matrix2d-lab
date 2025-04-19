using Matrix2dLib;

namespace Matrix2dTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        [DataRow(1, 2, 3, 4)]
        [DataRow(0, 0, 0, 0)]
        [DataRow(-1, -2, -3, -4)]
        [DataRow(123, 456, 789, 1011)]
        [DataRow(10, 20, 30, 40)]
        public void Konstruktor_WieleArgumentow_PoprawneDane_Ok(int a, int b, int c, int d)
        {
            // Arrange + Act
            var m = new Matrix2d(a, b, c, d);

            // Assert
            Assert.AreEqual(a, m.A);
            Assert.AreEqual(b, m.B);
            Assert.AreEqual(c, m.C);
            Assert.AreEqual(d, m.D);
        }


        [TestMethod]
        public void Konstruktor_BrakArgumentow_PoprawneDane_Ok()
        {
            // Arrange + Act
            var m = new Matrix2d();
            // Assert
            Assert.AreEqual(1, m.A);
            Assert.AreEqual(0, m.B);
            Assert.AreEqual(0, m.C);
            Assert.AreEqual(1, m.D);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4, "[[1, 2], [3, 4]]")]
        [DataRow(0, 0, 0, 0, "[[0, 0], [0, 0]]")]
        [DataRow(-1, -2, -3, -4, "[[-1, -2], [-3, -4]]")]
        [DataRow(123, 456, 789, 1011, "[[123, 456], [789, 1011]]")]
        [DataRow(10, 20, 30, 40, "[[10, 20], [30, 40]]")]
        public void ToString_PrawidlowyFormat_Ok(int a, int b, int c, int d, string expected)
        {
            // Arrange
            var m = new Matrix2d(a, b, c, d);

            // Act
            var result = m.ToString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("[[1, 12], [3, 444]]", 1, 12, 3, 444)]
        [DataRow("[[0, 0], [0, 0]]", 0, 0, 0, 0)]
        [DataRow("[[-1, -2], [-3, -4]]", -1, -2, -3, -4)]
        [DataRow("[[123, 456], [789, 1011]]", 123, 456, 789, 1011)]
        [DataRow("[[10, 20], [30, 40]]", 10, 20, 30, 40)]
        public void Parse_PrawidlowyFormat_Ok(string input, int expectedA, int expectedB, int expectedC, int expectedD)
        {
            // Act
            var result = Matrix2d.Parse(input);

            // Assert
            Assert.AreEqual(expectedA, result.A);
            Assert.AreEqual(expectedB, result.B);
            Assert.AreEqual(expectedC, result.C);
            Assert.AreEqual(expectedD, result.D);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4, 1, 2, 3, 4)]
        [DataRow(0, 0, 0, 0, 0, 0, 0, 0)]
        [DataRow(-1, -2, -3, -4, -1, -2, -3, -4)]
        [DataRow(123, 456, 789, 1011, 123, 456, 789, 1011)]
        [DataRow(10, 20, 30, 40, 10, 20, 30, 40)]
        public void Equals_IdentyczneMacierze_Ok(int a, int b, int c, int d, int e, int f, int g, int h)
        {
            // Arrange
            var m1 = new Matrix2d(a, b, c, d);
            var m2 = new Matrix2d(e, f, g, h);
            // Act
            var result = m1.Equals(m2);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4, 1, 2, 3, 5)]
        [DataRow(0, 0, 0, 0, 0, 0, 1, 0)]
        [DataRow(-1, -2, -3, -4, -1, -2, -3, 4)]
        [DataRow(123, 456, 789, 1011, 123, 456, 789, 1012)]
        [DataRow(10, 20, 30, 40, 10, 20, 30, 50)]
        public void Equals_RozneMacierze_Ok(int a, int b, int c, int d, int e, int f, int g, int h)
        {
            // Arrange
            var m1 = new Matrix2d(a, b, c, d);
            var m2 = new Matrix2d(e, f, g, h);
            // Act
            var result = m1.Equals(m2);
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Id_Property_Ok()
        {
            // Act
            var identityMatrix = Matrix2d.Id;

            // Assert
            Assert.AreEqual(1, identityMatrix.A);
            Assert.AreEqual(0, identityMatrix.B);
            Assert.AreEqual(0, identityMatrix.C);
            Assert.AreEqual(1, identityMatrix.D);
        }

        [TestMethod]
        public void Zero_Property_ZeroMatrix_Ok()
        {
            // Act
            var zeroMatrix = Matrix2d.Zero;

            // Assert
            Assert.AreEqual(0, zeroMatrix.A);
            Assert.AreEqual(0, zeroMatrix.B);
            Assert.AreEqual(0, zeroMatrix.C);
            Assert.AreEqual(0, zeroMatrix.D);
        }

        [TestMethod]
        public void Equals_Null_Falsz()
        {
            // Arrange
            var matrix = new Matrix2d(1, 2, 3, 4);

            // Act
            var result = matrix.Equals(null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OperatorRownosci_DwieTakieSameMacierze_ZwracaTrue()
        {
            // Arrange
            var m1 = new Matrix2d(1, 2, 3, 4);
            var m2 = new Matrix2d(1, 2, 3, 4);

            // Act
            var result = m1 == m2;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorRownosci_DwieRozneMacierze_ZwracaFalse()
        {
            // Arrange
            var m1 = new Matrix2d(1, 2, 3, 4);
            var m2 = new Matrix2d(5, 6, 7, 8);

            // Act
            var result = m1 == m2;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OperatorRownosci_PorownanieZNull_ZwracaFalse()
        {
            // Arrange
            var m1 = new Matrix2d(1, 2, 3, 4);

            // Act
            var result = m1 == null;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OperatorNierownosci_DwieRozneMacierze_ZwracaTrue()
        {
            // Arrange
            var m1 = new Matrix2d(1, 2, 3, 4);
            var m2 = new Matrix2d(5, 6, 7, 8);

            // Act
            var result = m1 != m2;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorNierownosci_DwieTakieSameMacierze_ZwracaFalse()
        {
            // Arrange
            var m1 = new Matrix2d(1, 2, 3, 4);
            var m2 = new Matrix2d(1, 2, 3, 4);

            // Act
            var result = m1 != m2;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OperatorNierownosci_PorownanieZNull_ZwracaTrue()
        {
            // Arrange
            var m1 = new Matrix2d(1, 2, 3, 4);

            // Act
            var result = m1 != null;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4, 5, 6, 7, 8, 6, 8, 10, 12)]
        [DataRow(0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1)]
        [DataRow(-1, -2, -3, -4, 1, 2, 3, 4, 0, 0, 0, 0)]
        public void OperatorDodawania_Macierze_Ok(
            int a1, int b1, int c1, int d1,
            int a2, int b2, int c2, int d2,
            int expectedA, int expectedB, int expectedC, int expectedD)
        {
            // Arrange
            var m1 = new Matrix2d(a1, b1, c1, d1);
            var m2 = new Matrix2d(a2, b2, c2, d2);

            // Act
            var result = m1 + m2;

            // Assert
            Assert.AreEqual(expectedA, result.A);
            Assert.AreEqual(expectedB, result.B);
            Assert.AreEqual(expectedC, result.C);
            Assert.AreEqual(expectedD, result.D);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4, 5, 6, 7, 8, -4, -4, -4, -4)]
        [DataRow(0, 0, 0, 0, 1, 1, 1, 1, -1, -1, -1, -1)]
        [DataRow(-1, -2, -3, -4, 1, 2, 3, 4, -2, -4, -6, -8)]
        public void OperatorOdejmowania_Macierze_Ok(
            int a1, int b1, int c1, int d1,
            int a2, int b2, int c2, int d2,
            int expectedA, int expectedB, int expectedC, int expectedD)
        {
            // Arrange
            var m1 = new Matrix2d(a1, b1, c1, d1);
            var m2 = new Matrix2d(a2, b2, c2, d2);

            // Act
            var result = m1 - m2;

            // Assert
            Assert.AreEqual(expectedA, result.A);
            Assert.AreEqual(expectedB, result.B);
            Assert.AreEqual(expectedC, result.C);
            Assert.AreEqual(expectedD, result.D);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4, 5, 6, 7, 8, 19, 22, 43, 50)]
        [DataRow(0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0)]
        [DataRow(1, 0, 0, 1, 1, 2, 3, 4, 1, 2, 3, 4)]
        public void OperatorMnozenia_Macierze_Ok(
            int a1, int b1, int c1, int d1,
            int a2, int b2, int c2, int d2,
            int expectedA, int expectedB, int expectedC, int expectedD)
        {
            // Arrange
            var m1 = new Matrix2d(a1, b1, c1, d1);
            var m2 = new Matrix2d(a2, b2, c2, d2);

            // Act
            var result = m1 * m2;

            // Assert
            Assert.AreEqual(expectedA, result.A);
            Assert.AreEqual(expectedB, result.B);
            Assert.AreEqual(expectedC, result.C);
            Assert.AreEqual(expectedD, result.D);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4, 2, 2, 4, 6, 8)]
        [DataRow(0, 0, 0, 0, 5, 0, 0, 0, 0)]
        [DataRow(-1, -2, -3, -4, 3, -3, -6, -9, -12)]
        public void OperatorMnozenia_MacierzPrzezSkalar_Ok(
            int a, int b, int c, int d,
            int scalar,
            int expectedA, int expectedB, int expectedC, int expectedD)
        {
            // Arrange
            var m = new Matrix2d(a, b, c, d);

            // Act
            var result = m * scalar;

            // Assert
            Assert.AreEqual(expectedA, result.A);
            Assert.AreEqual(expectedB, result.B);
            Assert.AreEqual(expectedC, result.C);
            Assert.AreEqual(expectedD, result.D);
        }


        [TestMethod]
        [DataRow(2, 1, 2, 3, 4, 2, 4, 6, 8)]
        [DataRow(0, 1, 2, 3, 4, 0, 0, 0, 0)]
        [DataRow(-1, 1, 2, 3, 4, -1, -2, -3, -4)]
        public void OperatorMnozenia_SkalarMacierz_Ok(
            int scalar, int a, int b, int c, int d,
            int expectedA, int expectedB, int expectedC, int expectedD)
        {
            // Arrange
            var matrix = new Matrix2d(a, b, c, d);

            // Act
            var result = scalar * matrix;

            // Assert
            Assert.AreEqual(expectedA, result.A);
            Assert.AreEqual(expectedB, result.B);
            Assert.AreEqual(expectedC, result.C);
            Assert.AreEqual(expectedD, result.D);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4, -1, -2, -3, -4)]
        [DataRow(0, 0, 0, 0, 0, 0, 0, 0)]
        [DataRow(-1, -2, -3, -4, 1, 2, 3, 4)]
        public void OperatorNegacji_Macierz_Ok(
            int a, int b, int c, int d,
            int expectedA, int expectedB, int expectedC, int expectedD)
        {
            // Arrange
            var matrix = new Matrix2d(a, b, c, d);

            // Act
            var result = -matrix;

            // Assert
            Assert.AreEqual(expectedA, result.A);
            Assert.AreEqual(expectedB, result.B);
            Assert.AreEqual(expectedC, result.C);
            Assert.AreEqual(expectedD, result.D);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4, 1, 3, 2, 4)]
        [DataRow(0, 0, 0, 0, 0, 0, 0, 0)]
        [DataRow(-1, -2, -3, -4, -1, -3, -2, -4)]
        public void Transpose_Macierz_Ok(
            int a, int b, int c, int d,
            int expectedA, int expectedB, int expectedC, int expectedD)
        {
            // Arrange
            var matrix = new Matrix2d(a, b, c, d);

            // Act
            var result = matrix.Transpose(matrix);

            // Assert
            Assert.AreEqual(expectedA, result.A);
            Assert.AreEqual(expectedB, result.B);
            Assert.AreEqual(expectedC, result.C);
            Assert.AreEqual(expectedD, result.D);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4, -2)]
        [DataRow(0, 0, 0, 0, 0)]
        [DataRow(2, 3, 4, 5, -2)]
        public void Det_Macierz_Ok(int a, int b, int c, int d, int expectedDet)
        {
            // Arrange
            var matrix = new Matrix2d(a, b, c, d);

            // Act
            var result = matrix.Det();

            // Assert
            Assert.AreEqual(expectedDet, result);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4, -2)]
        [DataRow(0, 0, 0, 0, 0)]
        [DataRow(2, 3, 4, 5, -2)]
        public void Determinant_Macierz_Ok(int a, int b, int c, int d, int expectedDet)
        {
            // Arrange
            var matrix = new Matrix2d(a, b, c, d);

            // Act
            var result = matrix.Determinant(matrix);

            // Assert
            Assert.AreEqual(expectedDet, result);
        }

        [TestMethod]
        [DataRow("[[1, 2], [3, 4]]", 1, 2, 3, 4)]
        [DataRow("[[0, 0], [0, 0]]", 0, 0, 0, 0)]
        [DataRow("[[-1, -2], [-3, -4]]", -1, -2, -3, -4)]
        [DataRow("[[123, 456], [789, 1011]]", 123, 456, 789, 1011)]
        [DataRow("[[10, 20], [30, 40]]", 10, 20, 30, 40)]
        public void Parse_PoprawnyFormat_Ok(string input, int expectedA, int expectedB, int expectedC, int expectedD)
        {
            // Act
            var result = Matrix2d.Parse(input);

            // Assert
            Assert.AreEqual(expectedA, result.A);
            Assert.AreEqual(expectedB, result.B);
            Assert.AreEqual(expectedC, result.C);
            Assert.AreEqual(expectedD, result.D);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void Parse_NullLubPusty_ThrowFormatException(string input)
        {
            // Act + Assert
            Assert.ThrowsException<FormatException>(() => Matrix2d.Parse(input));
        }

        [TestMethod]
        [DataRow("[1, 2], [3, 4]]")]
        [DataRow("[[1, 2], [3, 4]")]
        [DataRow("[[1, 2] [3, 4]]")]
        [DataRow("[[1, 2, 3], [4, 5, 6]]")]
        [DataRow("[[1], [2]]")]
        [DataRow("[[a, b], [c, d]]")]
        public void Parse_NieprawidlowyFormat_ThrowFormatException(string input)
        {
            // Act + Assert
            Assert.ThrowsException<FormatException>(() => Matrix2d.Parse(input));
        }

        [TestMethod]
        public void Transpose_Null_NullReferenceException()
        {
            // Arrange
            Matrix2d matrix = null;

            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(() => matrix.Transpose(matrix));
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4)]
        [DataRow(0, 0, 0, 0)]
        [DataRow(-1, -2, -3, -4)]
        [DataRow(123, 456, 789, 1011)]
        [DataRow(10, 20, 30, 40)]
        public void KonwersjaJawna_Matrix2dDoTablicyInt_Ok(int a, int b, int c, int d)
        {
            // Arrange
            var matrix = new Matrix2d(a, b, c, d);

            // Act
            var array = (int[,])matrix;

            // Assert
            Assert.AreEqual(a, array[0, 0]);
            Assert.AreEqual(b, array[0, 1]);
            Assert.AreEqual(c, array[1, 0]);
            Assert.AreEqual(d, array[1, 1]);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4)]
        [DataRow(0, 0, 0, 0)]
        [DataRow(-1, -2, -3, -4)]
        [DataRow(123, 456, 789, 1011)]
        [DataRow(10, 20, 30, 40)]
        public void KonwersjaNiejawna_TablicaIntDoMatrix2d_Ok(int a, int b, int c, int d)
        {
            // Arrange
            var array = new int[,] { { a, b }, { c, d } };

            // Act
            Matrix2d matrix = array;

            // Assert
            Assert.AreEqual(a, matrix.A);
            Assert.AreEqual(b, matrix.B);
            Assert.AreEqual(c, matrix.C);
            Assert.AreEqual(d, matrix.D);
        }

        [TestMethod]
        public void KonwersjaJawna_TablicaIntDoMatrix2d_NullReferenceException()
        {
            // Arrange
            int[,] array = null;
            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(() => (Matrix2d)array);
        }
    }

}
