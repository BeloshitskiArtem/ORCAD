namespace AirScrewPlugin.Model
{
    using System.Linq;

    /// <summary>
    /// Валидация и запрет некорректых сиволов.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Проверка корректности ввода параметра.
        /// </summary>
        /// <param name="value">Проверяемый параметр.</param>`
        /// <returns>Проверенные символы в виде массива.</returns>
        public static string ParameterCheck(string value)
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
        public static bool ValidateParameter(Parameter parameter, float value)
        {
            return (parameter.MaxValue >= value) && (value >= parameter.MinValue);
        }
    }
}
