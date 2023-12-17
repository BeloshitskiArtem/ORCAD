namespace AirScrewPlugin.Model.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Автотесты для валидатора.
    /// </summary>
    [TestFixture]
    public class ValidatorTest
    {
        /// <summary>
        /// Позитивный тест Validator.ValidateParameter(Parameter, float).
        /// </summary>
        /// <param name="minValue">Нижняя допустимая граница.</param>
        /// <param name="testingValue">Тестируемое значение.</param>
        /// <param name="maxValue">Верхняя допустимая граница.</param>
        [TestCase(10, 15, 20, TestName = "Позитивный тест Validator.ValidateParameter(Parameter, float)")]
        public void Validate_SetCorrectValue_ReturnsTrue(float minValue, float testingValue, float maxValue)
        {
            // Arrange
            var parameter = new Parameter() { MinValue = minValue, MaxValue = maxValue };

            // Act
            var expected = Validator.ValidateParameter(parameter, testingValue);
            var actual = true;

            // Assert
            Assert.AreEqual(expected, actual, "Передаваемое значение находится в допустимом диапазоне для параметра");
        }

        /// <summary>
        /// Негативный тест Validator.ValidateParameter(Parameter, float).
        /// </summary>
        /// <param name="minValue">Нижняя допустимая граница.</param>
        /// <param name="testingValue">Тестируемое значение.</param>
        /// <param name="maxValue">Верхняя допустимая граница.</param>
        [TestCase(10, 55, 20, TestName = "Негативный тест Validator.ValidateParameter(Parameter, float)")]
        public void Validate_SetNotCorrectValue_ReturnsTrue(float minValue, float testingValue, float maxValue)
        {
            // Arrange
            var parameter = new Parameter() { MinValue = minValue, MaxValue = maxValue };

            // Act
            var expected = Validator.ValidateParameter(parameter, testingValue);
            var actual = true;

            // Assert
            Assert.AreNotEqual(expected, actual, "Передаваемое значение НЕ находится в допустимом диапазоне для параметра");
        }

        /// <summary>
        /// Тест запрета записи некорректных сиволов.
        /// </summary>
        /// <param name="stringOnlyNumber">Строка только цифры.</param>
        /// <param name="stringNotOnlyNumber">Строка с буквами.</param>
        [TestCase("1234567890.", "1A2B3C4D5E6F7G8H9K0T.T", TestName = "Тест корректной записи в поле ввода")]
        public void Validate_DoCheckParameter_ReturnsOnlyNumber(string stringOnlyNumber, string stringNotOnlyNumber)
        {
            // Arrange
            string expected = stringOnlyNumber;
            string actual = stringNotOnlyNumber;

            // Act
            actual = Validator.ParameterCheck(actual);

            // Assert
            Assert.AreEqual(expected, actual, "Метод отрабатывает корректно, буквы не записываются");
        }
    }
}