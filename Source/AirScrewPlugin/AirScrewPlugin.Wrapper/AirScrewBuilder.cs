using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirScrewPlugin.Model;

namespace AirScrewPlugin.Wrapper
{
    /// <summary>
    /// Builder
    /// </summary>
    public class AirScrewBuilder
    {
        /// <summary>
        /// Экземпляр класса Kompas3DWrapper.
        /// </summary>
        private readonly Kompas3DWrapper _kompas3DWrapper = new Kompas3DWrapper();

        public void BuildAirScrew(AirScrewParametrs parametrs)
        {
            _kompas3DWrapper.OpenKompas();
            _kompas3DWrapper.CreateDocument3D();
            _kompas3DWrapper.CreatePart();

            // Создание 
            _kompas3DWrapper.InitializationSketchDefinition();
            _kompas3DWrapper.CreateCircle(parametrs.OuterRadius);
            _kompas3DWrapper.CreateExtrusionParam(parametrs.BladeWidth + (parametrs.BladeWidth/100)*20);
            _kompas3DWrapper.CreateLineSed();
            _kompas3DWrapper.CreateExtrusionParam(parametrs.BladeLength);
        }
    }
}
