using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricShapeLibrary
{
    /// <summary>
    /// Многоугольник.
    /// </summary>
    public class Polygon: Shape
    {
        /// <summary>
        /// Длины сторон.
        /// </summary>
        public readonly List<double> Sides;

        /// <summary>
        /// Создание экземпляра многоугольника с заданными длинами.
        /// </summary>
        /// <param name="sides">Длины сторон.</param>
        /// <exception cref="ArgumentOutOfRangeException">В случае, если передано не три значения.</exception>
        public Polygon(List<double> sides)
        {
            sides.Sort();
            sides.Reverse();

            if (sides.Count < 3)
            {
                throw new ArgumentOutOfRangeException(nameof(sides), 
                    "Ожидается список трёх и более длин сторон");
            }

            foreach (var side in sides)
            {
                CheckPozitivelineLength(side);
            }

            CheckExistPolygon(sides);

            Sides = sides;
        }

        /// <summary>
        /// Проверка существования многоугольника.
        /// </summary>
        /// <param name="sides">Длины сторон.</param>
        /// <exception cref="ArgumentOutOfRangeException">В случае, если многоугольника с задаными длинами не существует.</exception>
        private void CheckExistPolygon(List<double> sides)
        {
            var otherSidesSum = new double();

            foreach (var side in sides.Skip(1))
            {
                otherSidesSum += side;
            }

            if (sides[0] >= otherSidesSum)
            {
                throw new ArgumentOutOfRangeException(nameof(sides), 
                    "Многоугольника с заданными длинами сторон не существует");
            }
        }
    }
}
