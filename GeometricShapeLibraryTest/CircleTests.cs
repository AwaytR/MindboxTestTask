using GeometricShapeLibrary;

namespace GeometricShapeLibraryTests
{
    /// <summary>
    /// ������������ ������ Circle.
    /// </summary>
    [TestClass]
    public class CircleTests
    {
        /// <summary>
        /// �������� ������������ � ���������� ��������.
        /// </summary>
        /// <param name="radius">����� �������.</param>
        [TestMethod]
        [DataRow(0)]
        [DataRow(5)]
        [DataRow(10.5)]
        public void Constructor_ValidRadius_Success(double radius)
        {
            var circle = new Circle(radius);

            Assert.AreEqual(radius, circle.Radius);
        }

        /// <summary>
        /// �������� ������������ � ������������� ���������� �������.
        /// </summary>
        /// <param name="radius">����� �������.</param>
        [TestMethod()]
        [DataRow(-1)]
        [DataRow(-5)]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NegativeRadius_ThrowException(double radius)
        {
            var dynamicArray = new Circle(radius);
        }

        /// <summary>
        /// �������� �������� Area.
        /// </summary>
        /// <param name="radius"></param>
        [TestMethod]
        [DataRow(0)]
        [DataRow(5)]
        [DataRow(10.5)]
        public void Area_Success(double radius)
        {
            var circle = new Circle(radius);
            var area = Math.PI * Math.Pow(radius, 2);

            Assert.AreEqual(area, circle.Area);
        }
    }
}