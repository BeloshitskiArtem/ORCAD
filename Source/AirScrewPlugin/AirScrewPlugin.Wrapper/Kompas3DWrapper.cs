namespace AirScrewPlugin.Wrapper
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using AirScrewPlugin.Model;
    using Kompas6API5;
    using Kompas6Constants3D;

    /// <summary>
    /// Wrapper.
    /// </summary>
    public class Kompas3DWrapper
    {
        /// <summary>
        /// Объект компаса.
        /// </summary>
        private KompasObject KompasObject { get; set; }

        /// <summary>
        /// 3д документа.
        /// </summary>
        private ksDocument3D Document3D { get; set; }

        /// <summary>
        /// Деталь.
        /// </summary>
        private ksPart Part { get; set; }

        /// <summary>
        /// Эскиз.
        /// </summary>
        private ksEntity Sketch { get; set; }

        /// <summary>
        /// Определение эскиза.
        /// </summary>
        private ksSketchDefinition DefinitionSketch { get; set; }

        /// <summary>
        /// 2д документ.
        /// </summary>
        private ksDocument2D Document2D { get; set; }

        /// <summary>
        /// Сущность Экстра.
        /// </summary>
        private ksEntity EntityExtr { get; set; }

        /// <summary>
        /// Параметр скругления.
        /// </summary>
        private ksEntity ExtrForFillet { get; set; }

        /// <summary>
        /// Определение выдавливания бобышки.
        /// </summary>
        private ksBossExtrusionDefinition ExtrusionDef { get; set; }

        /// <summary>
        /// Параметры экструзии.
        /// </summary>
        private ksExtrusionParam ExtrProp { get; set; }

        /// <summary>
        /// Открытие компаса.
        /// </summary>
        public void OpenKompas()
        {
            Process[] pname = Process.GetProcessesByName("kStudy");
            if (pname.Length != 0)
            {
                KompasObject = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                KompasObject.ActivateControllerAPI();
            }
            else
            {
                KompasObject = null;
                Type type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                KompasObject = (KompasObject)Activator.CreateInstance(type);
                KompasObject.Visible = true;
                KompasObject.ActivateControllerAPI();
            }
        }

        /// <summary>
        /// Создание 3д документа.
        /// </summary>
        public void CreateDocument3D()
        {
            Document3D = (ksDocument3D)KompasObject.Document3D();
            Document3D.Create(false /*видимый*/, true /*деталь*/);
        }

        /// <summary>
        /// Создание детали.
        /// </summary>
        public void CreatePart()
        {
            Part = Document3D.GetPart((short)Part_Type.pTop_Part);
        }

        /// <summary>
        /// Определение эскиза инициализации.
        /// </summary>
        public void CreateSketchOnPlaneXOY()
        {
            Sketch = Part.NewEntity((short)Obj3dType.o3d_sketch);
            DefinitionSketch = Sketch.GetDefinition();
            DefinitionSketch.SetPlane(Part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));
            Sketch.Create();
        }

        /// <summary>
        /// Определение эскиза инициализации.
        /// </summary>
        public void CreateSketchOnPlaneYOZ()
        {
            Sketch = Part.NewEntity((short)Obj3dType.o3d_sketch);
            DefinitionSketch = Sketch.GetDefinition();
            DefinitionSketch.SetPlane(Part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ));
            Sketch.Create();
        }

        /// <summary>
        /// Создание эскиза окружности.
        /// </summary>
        /// <param name="radius">Радиус окружности основания винта.</param>
        public void CreateCircle(float radius)
        {
            Document2D = DefinitionSketch.BeginEdit();
            Document2D.ksCircle(0, 0, radius, 1);
            DefinitionSketch.EndEdit();
        }

        /// <summary>
        /// Построение ромба - основания лопасти.
        /// </summary>
        /// <param name="width">Высота.</param>
        public void CreateRectangleSed(float width)
        {
            Document2D = DefinitionSketch.BeginEdit();
            Document2D.ksLineSeg(-5, -10, -width - 5, width - 10, 1);
            Document2D.ksLineSeg(-5, -15, -width - 5, width - 15, 1);
            Document2D.ksLineSeg(-5, -10, -5, -15, 1);
            Document2D.ksLineSeg(-width - 5, width - 10, -width - 5, width - 15, 1);
            DefinitionSketch.EndEdit();
        }

        /// <summary>
        /// Построение элепса - основания лопасти.
        /// </summary>
        /// <param name="width">Высота.</param>
        public void CreateEllipseSed(float width)
        {
            Document2D = DefinitionSketch.BeginEdit();
            var ellipseParam = (ksEllipseParam)KompasObject.GetParamStruct(22);
            ellipseParam.A = width - 12;
            ellipseParam.B = 4.5;
            ellipseParam.xc = -5 - (width / 2);
            ellipseParam.yc = 5 - (width / 2);
            ellipseParam.angle = 45;
            ellipseParam.style = 1;
            Document2D.ksEllipse(ellipseParam);
            DefinitionSketch.EndEdit();
        }

        /// <summary>
        /// Массив по концентрической сетке.
        /// </summary>
        /// <param name="numberBlade">кол-во лопастей.</param>
        public void CreateArrayBlade(int numberBlade, bool flagForFillet)
        {
            ksEntity EntityExtrCopy = EntityExtr;
            EntityExtr = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_circularCopy);
            ksCircularCopyDefinition CircCopyDef = EntityExtr.GetDefinition();
            CircCopyDef.SetCopyParamAlongDir(numberBlade, 360, true, false);
            CircCopyDef.SetAxis(Part.GetDefaultEntity((short)Obj3dType.o3d_axisOZ));
            ksEntityCollection entCol = CircCopyDef.GetOperationArray();
            entCol.Add(EntityExtrCopy);
            if (flagForFillet)
            {
                entCol.Add(ExtrForFillet);
            }

            EntityExtr.Create();
        }

        /// <summary>
        /// Параметр выдавливания.
        /// </summary>
        /// <param name="value">Значение выдавливания.</param>
        public void CreateExtrusionParam(float value)
        {
            EntityExtr = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            ExtrusionDef = (ksBossExtrusionDefinition)EntityExtr.GetDefinition();
            ExtrProp = (ksExtrusionParam)ExtrusionDef.ExtrusionParam();
            ExtrusionDef.SetSketch(Sketch);
            ExtrProp.direction = (short)Direction_Type.dtNormal;
            ExtrProp.typeNormal = (short)End_Type.etBlind;
            ExtrProp.depthNormal = value;
            EntityExtr.Create();
        }

        /// <summary>
        /// Параметр вырезать выдавливания.
        /// </summary>
        public void CreateCutExtrusionParam()
        {
            EntityExtr = Part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition CutExtrDef = EntityExtr.GetDefinition();
            CutExtrDef.SetSideParam(false, (short)End_Type.etThroughAll, 155, 0, false);
            CutExtrDef.SetSketch(Sketch);
            EntityExtr.Create();
        }

        /// <summary>
        /// Построение скругления.
        /// </summary>
        public void CreateFilletForBlade(float length, float width)
        {
            ExtrForFillet = Part.NewEntity((short)Obj3dType.o3d_fillet);
            ksFilletDefinition filletDef = ExtrForFillet.GetDefinition();
            filletDef.radius = width / 2;
            filletDef.tangent = true;
            ksEntityCollection collection1 = Part.EntityCollection((short)Obj3dType.o3d_edge);
            ksEntityCollection collectionFilletDef = filletDef.array();
            collectionFilletDef.Clear();

            collection1.SelectByPoint(-length, 14, 5);
            collectionFilletDef.Add(collection1.GetByIndex(0));

            ksEntityCollection collection2 = Part.EntityCollection((short)Obj3dType.o3d_edge);
            collection2.SelectByPoint(-length, -width + 11, width + 5);
            collectionFilletDef.Add(collection2.GetByIndex(0));
            ExtrForFillet.Create();
        }

        /// <summary>
        /// Cкругление основания.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        public void CreateFilletForCircle(AirScrewParametrs parameter)
        {
            ExtrForFillet = Part.NewEntity((short)Obj3dType.o3d_fillet);
            ksFilletDefinition filletDef = ExtrForFillet.GetDefinition();
            filletDef.radius = (parameter.OuterRadius - parameter.InnerRadius) / 2;
            filletDef.tangent = true;

            ksEntityCollection collection1 = Part.EntityCollection((short)Obj3dType.o3d_edge);
            ksEntityCollection collection2 = Part.EntityCollection((short)Obj3dType.o3d_edge);
            ksEntityCollection collection3 = Part.EntityCollection((short)Obj3dType.o3d_edge);
            ksEntityCollection collection4 = Part.EntityCollection((short)Obj3dType.o3d_edge);
            ksEntityCollection collectionFilletDef = filletDef.array();
            collectionFilletDef.Clear();

            collection1.SelectByPoint(parameter.InnerRadius, 0, 0);
            collectionFilletDef.Add(collection1.GetByIndex(0));

            collection2.SelectByPoint(parameter.OuterRadius, 0, 0);
            collectionFilletDef.Add(collection2.GetByIndex(0));

            collection3.SelectByPoint(parameter.InnerRadius, 0, parameter.BladeWidth + 10);
            collectionFilletDef.Add(collection3.GetByIndex(0));

            collection4.SelectByPoint(parameter.OuterRadius, 0, parameter.BladeWidth + 10);
            collectionFilletDef.Add(collection4.GetByIndex(0));
            ExtrForFillet.Create();
        }
    }
}