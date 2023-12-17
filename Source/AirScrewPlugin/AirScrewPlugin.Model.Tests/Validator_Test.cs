using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AirScrewPlugin.Model;


namespace AirScrewPlugin.Model.Tests
{
    /// <summary>
    /// Автотесты для валидатора
    /// </summary>
    [TestFixture]
    class Validator_Test
    {

        [TestCase(10, 15, 20, TestName = "Позитивный тест Validator.ValidateParametr(Parametr, float)")]
        public void Validate_SetCorrectValue_ReturnsTrue(float minValue, float testingValue, float maxValue)
        {
            // Arrange
            var parametr = new Parametr();
            parametr.MinValue = minValue;
            parametr.MaxValue = maxValue;

            // Act
            var expected = Validator.ValidateParametr(parametr, testingValue);
            var actual = true;

            // Assert
            Assert.AreEqual(expected, actual, "Передаваемое значение находится в допустимом диапазоне для параметра");
        }


        [TestCase(10, 55, 20, TestName = "Негативный тест Validator.ValidateParametr(Parametr, float)")]
        public void Validate_SetNotCorrectValue_ReturnsTrue(float minValue, float testingValue, float maxValue)
        {
            // Arrange
            var parametr = new Parametr();
            parametr.MinValue = minValue;
            parametr.MaxValue = maxValue;

            // Act
            var expected = Validator.ValidateParametr(parametr, testingValue);
            var actual = true;

            // Assert
            Assert.AreNotEqual(expected, actual, "Передаваемое значение НЕ находится в допустимом диапазоне для параметра");
        }


        [TestCase("1234567890.", "1A2B3C4D5E6F7G8H9K0T.T", TestName = "Тест корректной записи в поле ввода")]
        public void Validate_DoCheckParametr_ReturnsOnlenumber(string srtingOnleNumber, string stringNotOnliNumber)
        {
            // Arrange
            string expected = srtingOnleNumber;
            string actual = stringNotOnliNumber;

            // Act
            actual = Validator.ParametrCheck(actual);

            // Assert
            Assert.AreEqual(expected, actual, "Метод отрабатывает корректно, буквы не записываются");
        }
    }
}
