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
    }
}
