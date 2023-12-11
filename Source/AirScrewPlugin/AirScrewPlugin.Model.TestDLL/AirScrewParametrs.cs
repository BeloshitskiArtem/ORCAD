using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirScrewPlugin.Model
{
    public class AirScrewParametrs
    {
        /// <summary>
        /// Миссив всех параметров с инициализацией пороговых значений
        /// </summary>
       
            /// <summary>
            /// Ширина лопасти
            /// </summary>
            private Parametr _bladeWidth = new Parametr();

            /// <summary>
            /// Длинна лопасти
            /// </summary>
            private Parametr _bladeLength = new Parametr();

            /// <summary>
            /// ВНУТРЕННИЙ радиус
            /// </summary>
            private Parametr _innerRadius = new Parametr();

            /// <summary>
            /// ВНЕШНИЙ радиус
            /// </summary>
            private Parametr _outerRadius = new Parametr();

            /// <summary>
            /// Колличество лопастей
            /// </summary>
            private Parametr _numberOfBlades = new Parametr();

            /// <summary>
            /// Конструктор для дефолтной инциализации и инициализации границ значений
            /// </summary>
            public AirScrewParametrs(float bladeWidth,
                                     float bladeLength,
                                     float innerRadius,
                                     float outerRadius,
                                     float numberOfBlades)
            {
                _bladeWidth.MinValue = 5;
                _bladeWidth.MaxValue = 900;
                BladeWidth = bladeWidth; //150

                _bladeLength.MinValue = 100;
                _bladeLength.MaxValue = 2000;
                BladeLength = bladeLength; //1000;


                _innerRadius.MinValue = BladeLength / 100;
                _innerRadius.MaxValue = BladeLength; //todo: продумать ограничение
                InnerRadius = innerRadius; // 10;


                _outerRadius.MinValue = InnerRadius + InnerRadius / 10;
                _outerRadius.MaxValue = InnerRadius + (InnerRadius / 100) * 150;
                OuterRadius = outerRadius;

                _numberOfBlades.MinValue = 0;
                _numberOfBlades.MaxValue = ((float)6.283 * OuterRadius) / BladeWidth;
                NumberOfBlades = numberOfBlades; // 3;
            }
            public float BladeWidth
            {
                get => _bladeWidth.Value;
                set
                {
                    if (Validator.ValidateParametr(_bladeWidth, value))
                    {
                        this._bladeWidth.Value = value;
                    }
                    else
                    {
                        throw new Exception("Ширина лопасти должна быть задана в следующем диапазоне: [50 - 900]");
                    }
                }
            }
        
            public float BladeLength
            {
                get => _bladeLength.Value;
                set
                {
                    if (Validator.ValidateParametr(_bladeLength, value))
                    {
                        this._bladeLength.Value = value;
                    }
                    else
                    {
                        throw new Exception("Длинна лопасти должна быть задана в следующем диапазоне: [100 - 2000]");
                    }
                }
            }

            public float InnerRadius
            {
                get => _innerRadius.Value;
                set
                {
                    if (Validator.ValidateParametr(_innerRadius, value))
                    {
                        this._innerRadius.Value = value;
                    }
                    else
                    {
                         throw new Exception("Внутренний радиус должен быть задан в следующем диапазоне: [1% от длинны лопасти - длинны лопасти]");
                    }
                }
            }

            public float OuterRadius
            {
                get => _outerRadius.Value;
                set
                {
                    if (Validator.ValidateParametr(_outerRadius, value))
                    {
                        this._outerRadius.Value = value;
                    }
                    else
                    {
                        throw new Exception("Внешний радиус должен быть задан в следующем диапазоне: [Внутренний + 10% - Внутренний + 150%]");
                    }
                }
            }

            public float NumberOfBlades
            {
                get => _numberOfBlades.Value;
                set
                {
                    if (Validator.ValidateParametr(_numberOfBlades, value))
                    {
                        this._numberOfBlades.Value = value;
                    }
                    else
                    {
                        throw new Exception("Кол-во лопастей должно быть в диапазоне: [2 - Внешний радиус / Ширина лопасти]");
                    }
                }
            }
    }
}


