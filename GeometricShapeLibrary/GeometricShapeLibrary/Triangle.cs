using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricShapeLibrary
{
    /// <summary>
    /// Треугольник.
    /// </summary>
    public class Triangle: Polygon
    {
        /// <summary>
        /// Площадь.
        /// </summary>
        public double Area => IsRightTriangle() ?
            CalculateRightTriangleArea() :
            CalculateHeronFormulaTriangleArea();

        /// <summary>
        /// Создание экземпляра треугольника с задаными длинами сторон.
        /// </summary>
        /// <param name="sides">Длины сторон.</param>
        /// <exception cref="ArgumentOutOfRangeException">В случае, если передано не три значения.</exception>
        public Triangle(List<double> sides): base(sides)
        {
            if (sides.Count != 3)
            {
                throw new ArgumentOutOfRangeException(nameof(sides), 
                    "Ожидаются длины трёх сторон");
            }
        }

        /// <summary>
        /// Опрделение, прямоугольный ли треугольник.
        /// </summary>
        /// <returns>True если треугольник прямоугольный.</returns>
        public bool IsRightTriangle() => 
            (Math.Pow(Sides[0], 2) == Math.Pow(Sides[1], 2) + Math.Pow(Sides[2], 2));

        /// <summary>
        /// Вычисление площади по формуле Герона.
        /// </summary>
        /// <returns>Площадь.</returns>
        private double CalculateHeronFormulaTriangleArea()
        {
            var semiperimeter = (Sides[0] + Sides[1] + Sides[2]) / 2;

            return (semiperimeter - Sides[0]) * 
                (semiperimeter - Sides[1]) * 
                (semiperimeter - Sides[2]);
        }

        /// <summary>
        /// Вычисление площади для прямоугольного треугольника.
        /// </summary>
        /// <returns>Площадь.</returns>
        private double CalculateRightTriangleArea() 
            => 0.5 * Sides[1] * Sides[2];
    }
}
