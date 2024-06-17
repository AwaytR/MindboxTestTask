using GeometricShapeLibrary;

namespace GeometricShapeLibraryTests
{
    /// <summary>
    /// Тестирование класса Plygon.
    /// </summary>
    [TestClass]
    public class PlygonTests
    {
        /// <summary>
        /// Проверка конструктора с корректным списком длин.
        /// </summary>
        /// <param name="sides">Список длин сторон.</param>
        [TestMethod]
        [DataRow(new double[] { 1, 1, 1 })]
        [DataRow(new double[] { 1, 2, 1, 2 })]
        [DataRow(new double[] { 2, 3, 1, 1, 1 })]
        public void Constructor_ValidSides_Success(double[] sides)
        {
            var listSides = new List<double>(sides);
            var polygon = new Polygon(listSides);

            listSides.Sort();
            listSides.Reverse();

            Assert.AreEqual(listSides, polygon.Sides);
        }

        /// <summary>
        /// Проверка конструктора со слишком малым списком длин.
        /// </summary>
        /// <param name="sides">Список длин сторон.</param>
        [TestMethod()]
        [DataRow(new double[] { })]
        [DataRow(new double[] { 1 })]
        [DataRow(new double[] { 1, 2 })]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_InvalidSidesCount_ThrowException(double[] sides)
        {
            var polygon = new Polygon(new List<double>(sides));
        }

        /// <summary>
        /// Проверка конструктора со списком длин с отрицательными значениями.
        /// </summary>
        /// <param name="sides">Список длин сторон.</param>
        [TestMethod()]
        [DataRow(new double[] { 1, 0, 1 })]
        [DataRow(new double[] { -1, 1, 1, 1 })]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NegativeSide_ThrowException(double[] sides)
        {
            var polygon = new Polygon(new List<double>(sides));
        }

        /// <summary>
        /// Проверка конструктора с некорректным списком длин, который описывает несуществующий многоугольник.
        /// </summary>
        /// <param name="sides">Список длин сторон.</param>
        [TestMethod()]
        [DataRow(new double[] { 5, 1, 1 })]
        [DataRow(new double[] { 1, 10, 1, 1, 1 })]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_NotExistPolygon_ThrowException(double[] sides)
        {
            var polygon = new Polygon(new List<double>(sides));
        }
    }
}