namespace AirScrewPlugin.Model.Tests
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Автотесты для Параметров.
    /// </summary>
    [TestFixture]
    public class ParametersTests
    {
        /// <summary>
        /// Позитивный тест для AirScrewParametrs.
        /// </summary>
        /// <param name="actualWidth">Ширина лопасти.</param>
        /// <param name="actualLength">Длинна лопасти.</param>
        /// <param name="actualInnerRadius">Внутренний радиус.</param>
        /// <param name="actualOuterRadius">Внешний радиус.</param>
        /// <param name="actualNumberOfBlades">Число лопастей.</param>
        [TestCase(15, 100, 10, 11, 3, TestName = "Позитивный тест AirScrewParametrs)")]
        public void Validate_SetCorrectValueAirScrewParametrs_ReturnsTrue(
                                                                     float actualWidth,
                                                                     float actualLength,
                                                                     float actualInnerRadius,
                                                                     float actualOuterRadius,
                                                                     float actualNumberOfBlades)
        {
            // Arrange
            var expected = new AirScrewParametrs();

            // Act
            expected.BladeWidth = actualWidth;
            expected.BladeLength = actualLength;
            expected.InnerRadius = actualInnerRadius;
            expected.OuterRadius = actualOuterRadius;
            expected.NumberOfBlades = actualNumberOfBlades;

            // Asserts
            Assert.AreEqual(expected.BladeWidth, actualWidth, "Передаваемое значение находится в допустимом диапазоне для параметра");
            Assert.AreEqual(expected.BladeLength, actualLength, "Передаваемое значение находится в допустимом диапазоне для параметра");
            Assert.AreEqual(expected.InnerRadius, actualInnerRadius, "Передаваемое значение находится в допустимом диапазоне для параметра");
            Assert.AreEqual(expected.OuterRadius, actualOuterRadius, "Передаваемое значение находится в допустимом диапазоне для параметра");
            Assert.AreEqual(expected.NumberOfBlades, actualNumberOfBlades, "Передаваемое значение находится в допустимом диапазоне для параметра");
        }

        /// <summary>
        /// Позитивный тест для AirScrewParametrs.
        /// </summary>
        /// <param name="actualWidth">Ширина лопасти.</param>
        /// <param name="actualLength">Длинна лопасти.</param>
        /// <param name="actualInnerRadius">Внутренний радиус.</param>
        /// <param name="actualOuterRadius">Внешний радиус.</param>
        /// <param name="actualNumberOfBlades">Число лопастей.</param>
        [TestCase(61, 301, 151, 301, 16, TestName = "Негативный тест AirScrewParametrs)")]
        public void Validate_SetUncorrectValueAirScrewParametrs_ReturnsTrue(float unCorrectBladeWidth,
                                                                            float unCorrectBladeLength,
                                                                            float unCorrectInnerRadius,
                                                                            float unCorrectOuterRadius,
                                                                            float unCorrectNumberOfBlades)
        {
            var parameters = new AirScrewParametrs();

            string message = "Присвоены неверные значения параметров воздушного винта";

            // Assert
            Assert.Throws<Exception>(() =>
            {
                // Act
                parameters.BladeWidth = unCorrectBladeWidth;
            }, message + " BladeWidth");

            parameters.BladeWidth = 60;

            Assert.Throws<Exception>(() =>
            {
                // Act
                parameters.BladeLength = unCorrectBladeLength;
            }, message + " BladeLength");

            parameters.BladeLength = 300;

            Assert.Throws<Exception>(() =>
            {
                // Act
                parameters.InnerRadius = unCorrectInnerRadius;
            },  message + " InnerRadius");

            parameters.InnerRadius = 150;

            Assert.Throws<Exception>(() =>
            {
                // Act
                parameters.OuterRadius = unCorrectOuterRadius;
            },  message + " OuterRadius");

            parameters.OuterRadius = 300;

            Assert.Throws<Exception>(() =>
            {
                // Act
                parameters.NumberOfBlades = unCorrectNumberOfBlades;
            },  message + " NumberOfBlades");

            parameters.NumberOfBlades = 15;
        }
    }
}
