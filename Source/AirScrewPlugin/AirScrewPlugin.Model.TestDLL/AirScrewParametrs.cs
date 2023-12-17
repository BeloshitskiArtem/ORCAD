namespace AirScrewPlugin.Model
{
    using System;

    /// <summary>
    /// Класс-контейнер параметров винта.
    /// </summary>
    public class AirScrewParametrs
    {
            /// <summary>
            /// Ширина лопасти.
            /// </summary>
            private readonly Parameter _bladeWidth = new Parameter();

            /// <summary>
            /// Длинна лопасти.
            /// </summary>
            private readonly Parameter _bladeLength = new Parameter();

            /// <summary>
            /// ВНУТРЕННИЙ радиус.
            /// </summary>
            private readonly Parameter _innerRadius = new Parameter();

            /// <summary>
            /// ВНЕШНИЙ радиус.
            /// </summary>
            private readonly Parameter _outerRadius = new Parameter();

            /// <summary>
            /// Колличество лопастей.
            /// </summary>
            private readonly Parameter _numberOfBlades = new Parameter();

            /// <summary>
            /// Конструктор для дефолтной инциализации и инициализации границ значений.
            /// </summary>
            public AirScrewParametrs()
            {
                _bladeWidth.MinValue = 15;
                _bladeWidth.MaxValue = 60;

                _bladeLength.MinValue = 100;
                _bladeLength.MaxValue = 300;

                _innerRadius.MinValue = BladeLength / 10;
                _innerRadius.MaxValue = BladeLength / 2;

                _outerRadius.MinValue = InnerRadius + (InnerRadius / 10);
                _outerRadius.MaxValue = InnerRadius * 2;

                _numberOfBlades.MinValue = 2;
                _numberOfBlades.MaxValue = 15;
            }

            /// <summary>
            /// Свойство для шмрмны лопасти.
            /// </summary>
            public float BladeWidth
            {
                get => _bladeWidth.Value;
                set
                {
                    if (Validator.ValidateParameter(_bladeWidth, value))
                    {
                        this._bladeWidth.Value = value;
                    }
                    else
                    {
                        throw new Exception("Ширина лопасти должна быть задана в следующем диапазоне: [50 - 900]");
                    }
                }
            }

            /// <summary>
            /// Свойство для длинны лопасти.
            /// </summary>
            public float BladeLength
            {
                get => _bladeLength.Value;
                set
                {
                    if (Validator.ValidateParameter(_bladeLength, value))
                    {
                        this._bladeLength.Value = value;
                    }
                    else
                    {
                        throw new Exception("Длинна лопасти должна быть задана в следующем диапазоне: [100 - 2000]");
                    }
                }
            }

            /// <summary>
            /// Свойство для внутреннего радиуса.
            /// </summary>
            public float InnerRadius
            {
                get => _innerRadius.Value;
                set
                {
                    _innerRadius.MinValue = BladeLength / 10;
                    _innerRadius.MaxValue = BladeLength / 2;
                    if (Validator.ValidateParameter(_innerRadius, value))
                    {
                        this._innerRadius.Value = value;
                    }
                    else
                    {
                         throw new Exception("Внутренний радиус должен быть задан в следующем диапазоне: [1% от длинны лопасти - длинны лопасти]");
                    }
                }
            }

            /// <summary>
            /// Свойство для внешнего радиуса.
            /// </summary>
            public float OuterRadius
            {
                get => _outerRadius.Value;
                set
                {
                    _outerRadius.MinValue = InnerRadius + (InnerRadius / 10);
                    _outerRadius.MaxValue = InnerRadius * 2;
                    if (Validator.ValidateParameter(_outerRadius, value))
                    {
                        this._outerRadius.Value = value;
                    }
                    else
                    {
                        throw new Exception("Внешний радиус должен быть задан в следующем диапазоне: [Внутренний + 10% - Внутренний + 150%]");
                    }
                }
            }

            /// <summary>
            /// Свойство для кол-во лопастей.
            /// </summary>
            public float NumberOfBlades
            {
                get => _numberOfBlades.Value;
                set
                {
                    if (Validator.ValidateParameter(_numberOfBlades, value))
                    {
                        this._numberOfBlades.Value = value;
                    }
                    else
                    {
                        throw new Exception("Кол-во лопастей должно быть в диапазоне: [2 - 15]");
                    }
                }
            }
    }
}