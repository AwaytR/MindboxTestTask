namespace GeometricShapeLibrary
{
    /// <summary>
    /// Круг.
    /// </summary>
    public class Circle: Shape
    {
        /// <summary>
        /// Длина радиуса.
        /// </summary>
        public readonly double Radius;

        /// <summary>
        /// Площадь.
        /// </summary>
        public double Area => Math.PI * Math.Pow(Radius, 2);

        /// <summary>
        /// Создание экземпляра круга с заданным радиусом.
        /// </summary>
        /// <param name="radius">Радиус.</param>
        public Circle(double radius)
        {
            CheckNonNegativelineLength(radius);

            Radius = radius;
        }
    }
}