using GeometricShapeLibrary;

namespace GeometricShapeLibraryTests
{
    /// <summary>
    /// Тестирование класса Triangle.
    /// </summary>
    [TestClass]
    public class TriangleTests
    {
        #region Конструкторы

        /// <summary>
        /// Проверка конструктора с корректным списком длин.
        /// </summary>
        /// <param name="sides">Список длин сторон.</param>
        [TestMethod]
        [DataRow(new double[] { 1, 1, 1 })]
        [DataRow(new double[] { 5, 12, 13 })]
        public void Constructor_ValidSides_Success(double[] sides)
        {
            var listSides = new List<double>(sides);
            var triangle = new Triangle(listSides);

            listSides.Sort();
            listSides.Reverse();

            Assert.AreEqual(listSides, triangle.Sides);
        }

        /// <summary>
        /// Проверка конструктора со слишком большим списком длин.
        /// </summary>
        /// <param name="sides">Список длин сторон.</param>
        [TestMethod()]
        [DataRow(new double[] { 1, 1, 1, 1 })]
        [DataRow(new double[] { 1, 2, 1, 1, 1 })]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_InvalidSidesCount_ThrowException(double[] sides)
        {
            var triangle = new Triangle(new List<double>(sides));
        }

        /// <summary>
        /// Проверка конструктора со списком длин, с не положительными значениями.
        /// </summary>
        /// <param name="sides">Список длин сторон.</param>
        [TestMethod()]
        [DataRow(new double[] { 1, 0, 1 })]
        [DataRow(new double[] { -1, 1, 1 })]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NegativeSide_ThrowException(double[] sides)
        {
            var triangle = new Triangle(new List<double>(sides));
        }

        /// <summary>
        /// Проверка конструктора со списком длин, описывающим не существующий тругольник. 
        /// </summary>
        /// <param name="sides">Список длин сторон.</param>
        [TestMethod()]
        [DataRow(new double[] { 5, 1, 1 })]
        [DataRow(new double[] { 1, 10, 1 })]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_NotExistTriangle_ThrowException(double[] sides)
        {
            var triangle = new Triangle(new List<double>(sides));
        }

        #endregion

        /// <summary>
        /// Проверка метода IsRightTriangle() в случае, когда треугольник прямоугольный.
        /// </summary>
        /// <param name="sides">Список длин сторон.</param>
        [TestMethod]
        [DataRow(new double[] { 5, 4, 3 })]
        [DataRow(new double[] { 5, 12, 13 })]
        public void IsRightTriangle_RightTriangle_Success(double[] sides)
        {
            var triangle = new Triangle(new List<double>(sides));

            Assert.IsTrue(triangle.IsRightTriangle());
        }

        /// <summary>
        /// Проверка метода IsRightTriangle() в случае, когда треугольник не прямоугольный.
        /// </summary>
        /// <param name="sides">Список длин сторон.</param>
        [TestMethod]
        [DataRow(new double[] { 5, 4, 2 })]
        [DataRow(new double[] { 5, 10, 12 })]
        public void IsRightTriangle_NonRightTriangle_Success(double[] sides)
        {
            var triangle = new Triangle(new List<double>(sides));

            Assert.IsFalse(triangle.IsRightTriangle());
        }


        /// <summary>
        /// Проверка свойства Area в случае, когда треугольник прямоугольный.
        /// </summary>
        /// <param name="sides">Список длин сторон.</param>
        [TestMethod]
        [DataRow(new double[] { 5, 4, 3 })]
        [DataRow(new double[] { 5, 12, 13 })]
        public void Area_RightTriangle_Success(double[] sides)
        {
            var triangle = new Triangle(new List<double>(sides));
            var area = 0.5 * sides[1] * sides[2];

            Assert.AreEqual(area, triangle.Area);
        }

        /// <summary>
        /// Проверка свойства Area в случае, когда треугольник не прямоугольный.
        /// </summary>
        /// <param name="sides">Список длин сторон.</param>
        [TestMethod]
        [DataRow(new double[] { 5, 4, 2 })]
        [DataRow(new double[] { 5, 10, 12 })]
        public void Area_NonRightTriangle_Success(double[] sides)
        {
            var listSides = new List<double>(sides);
            var triangle = new Triangle(listSides);

            listSides.Sort();
            listSides.Reverse();

            var semiperimeter = (sides[0] + sides[1] + sides[2]) / 2;

            var area = (semiperimeter - sides[0]) * 
                (semiperimeter - sides[1]) * 
                (semiperimeter - sides[2]);

            Assert.AreEqual(area, triangle.Area);
        }
    }
}