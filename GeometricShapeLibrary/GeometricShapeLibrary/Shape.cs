using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricShapeLibrary
{
    /// <summary>
    /// Фигура.
    /// </summary>
    public class Shape
    {
        /// <summary>
        /// Проверка значения длины на не отрицательность.
        /// </summary>
        /// <param name="lineLength">Длина линии.</param>
        /// <exception cref="ArgumentException">В случае, если длина отрицательна.</exception>
        protected void CheckNonNegativelineLength(double lineLength)
        {
            if (lineLength < 0)
            {
                throw new ArgumentException("Ожидается не отрицательное значение длины", nameof(lineLength));
            }
        }

        /// <summary>
        /// Проверка значения длины на положительность.
        /// </summary>
        /// <param name="lineLength">Длина.</param>
        /// <exception cref="ArgumentException">В случае, если длина не положительна.</exception>
        protected void CheckPozitivelineLength(double lineLength)
        {
            if (lineLength <= 0)
            {
                throw new ArgumentException("Ожидается положительное значение длины", 
                    nameof(lineLength));
            }
        }
    }
}
