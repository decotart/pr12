using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr12
{
    public class Work12
    {
        /// <summary>
        /// Получает среднее геометрическое двух чисел
        /// </summary>
        /// <param name="a">неотрицательное число 1</param>
        /// <param name="b">неотрицательное число 2</param>
        /// <returns>Среднее геометрическое двух чисел</returns>
        /// <exception cref="ArgumentException">Исключение отрицательных чисел</exception>
        public static double GetGeometricalAvearge(double a, double b)
        {
            if (a < 0 || b < 0)
            {
                throw new ArgumentException("Числа не должны быть отрицательными");                
            }
            else
            {
                return Math.Round(Math.Sqrt(a * b), 2);
            }
        }

        /// <summary>
        /// Переставляет цифры сотен и десятков местами
        /// </summary>
        /// <param name="value">Трехзначное число</param>
        /// <returns>Число с переставленными цифрами</returns>
        /// <exception cref="ArgumentException">Исключение не трехзначного числа</exception>
        public static int ChangeDigits(int value)
        {
            if (value > 999 || value < 100)
            {
                throw new ArgumentException("Число должно быть трехзначным");
            }

            int result = (value / 10 % 10 * 100) + (value / 100) * 10 + value % 10;
            return result;
        }
    }
}
