using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirScrewPlugin.Model
{
    public static class Validator
    {
        /// <summary>
        /// Проверка корректности ввода параметра
        /// </summary>
        /// <param name="value">Проверяемый параметр</param>`
        /// <returns>Проверенные символы в виде массива</returns>
        public static string ParametrCheck(string value)
        {
            const string allowedChars = ".1234567890";
            return new string(value.Where(character =>
           allowedChars.Contains(character)).ToArray());
        }

        /// <summary>
        /// Валидация одного параметра.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        /// <returns>True - проверка прошла, иначе - false.</returns>
        public static bool ValidateParametr(Parametr parametr, float value)
        {
            return (parametr.MaxValue >= value) 
                && (value >= parametr.MinValue);
        }
    }
}
