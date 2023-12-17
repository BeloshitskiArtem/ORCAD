namespace AirScrewPlugin.Wrapper
{
    using AirScrewPlugin.Model;

    /// <summary>
    /// Builder воздушного винта.
    /// </summary>
    public class AirScrewBuilder
    {
        /// <summary>
        /// Экземпляр класса Kompas3DWrapper.
        /// </summary>
        private readonly Kompas3DWrapper _kompas3DWrapper = new Kompas3DWrapper();

        /// <summary>
        /// Построить винт.
        /// </summary>
        /// <param name="parametrs">Класс-контейнер параметров.</param>
        /// <param name="formOfBlade">Отдельно форма лопасти.</param>
        public void BuildAirScrew(AirScrewParametrs parametrs, int formOfBlade)
        {
            _kompas3DWrapper.OpenKompas();
            _kompas3DWrapper.CreateDocument3D();
            _kompas3DWrapper.CreatePart();

            // Создание
            _kompas3DWrapper.CreateSketchOnPlaneXOY();
            _kompas3DWrapper.CreateCircle(parametrs.OuterRadius);
            _kompas3DWrapper.CreateExtrusionParam(parametrs.BladeWidth + 10);

            // Создание лопастей
            _kompas3DWrapper.CreateSketchOnPlaneYOZ();
            _kompas3DWrapper.CreateRectangleSed(parametrs.BladeWidth, formOfBlade);
            _kompas3DWrapper.CreateExtrusionParam(parametrs.BladeLength);
            _kompas3DWrapper.CreateArrayBlade((int)parametrs.NumberOfBlades);

            // Cоздание вырезания
            _kompas3DWrapper.CreateSketchOnPlaneXOY();
            _kompas3DWrapper.CreateCircle(parametrs.InnerRadius);
            _kompas3DWrapper.CreateCutExtrusionParam();
        }
    }
}
