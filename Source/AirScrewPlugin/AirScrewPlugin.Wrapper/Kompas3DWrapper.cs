using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;

namespace AirScrewPlugin.Wrapper
{
    /// <summary>
    /// Wrapper
    /// </summary>
    public class Kompas3DWrapper
    {
        /// <summary>
        /// Объект компаса
        /// </summary>
        private KompasObject KompasObject { get; set; }

        /// <summary>
        /// 3д документа
        /// </summary>
        private ksDocument3D Document3D { get; set; }

        /// <summary>
        /// Деталь
        /// </summary>
        private ksPart Part { get; set; }

        /// <summary>
        /// Эскиз
        /// </summary>
        private ksEntity Sketch { get; set; }

        /// <summary>
        /// Определение эскиза
        /// </summary>
        private ksSketchDefinition DefinitionSketch { get; set; }

        /// <summary>
        /// 2д документ
        /// </summary>
        private ksDocument2D Document2D { get; set; }

        /// <summary>
        /// Сущность Экстра
        /// </summary>
        private ksEntity EntityExtr { get; set; }

        /// <summary>
        /// Определение выдавливания бобышки
        /// </summary>
        private ksBossExtrusionDefinition ExtrusionDef { get; set; }

        /// <summary>
        /// Параметры экструзии
        /// </summary>
        private ksExtrusionParam ExtrProp { get; set; }   

        /// <summary>
        /// Параметр третьего прямоугольника
        /// </summary>
        private ksRectangleParam ThirdRectangleParam { get; set; }

        /// <summary>
        /// Параметр первого эллипса
        /// </summary>
        private ksEllipseParam FirstEllipseParam { get; set; }

        /// <summary>
        /// Параметр второго эллипса
        /// </summary>
        private ksEllipseParam SecondEllipseParam { get; set; }

        /// <summary>
        /// Параметр третьего эллипса
        /// </summary>
        private ksEllipseParam ThirdEllipseParam { get; set; }

        /// <summary>
        /// Параметр скругления
        /// </summary>
        private ksFilletDefinition FilletDefinition { get; set; }

        /// <summary>
        /// Открытие компаса
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
        /// Создание 3д документа
        /// </summary>
        public void CreateDocument3D()
        {
            Document3D = (ksDocument3D)KompasObject.Document3D();
            Document3D.Create(false /*видимый*/, true /*деталь*/);
        }

        /// <summary>
        /// Создание детали
        /// </summary>
        public void CreatePart()
        {
            Part = Document3D.GetPart((short)Part_Type.pTop_Part);
        }

        /// <summary>
        /// Определение эскиза инициализации
        /// </summary>
        public void InitializationSketchDefinition()
        {
            Sketch = Part.NewEntity((short)Obj3dType.o3d_sketch);
            DefinitionSketch = Sketch.GetDefinition();
            DefinitionSketch.SetPlane(Part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));
            Sketch.Create();
        }

        /// <summary>
        /// Создание внешней окружности
        /// </summary>
        /// <param name="outerRadius">Радиус внешней окружности основания винта</param>
        public void CreateCircle(float outerRadius)
        {
            Document2D = DefinitionSketch.BeginEdit();
            Document2D.ksCircle(0, 0, outerRadius, 1);
            DefinitionSketch.EndEdit();
        }

       /// <summary>
       /// Построение отрезка - основания лопасти
       /// </summary>
        public void CreateLineSed()
        {
            Sketch = Part.NewEntity((short)Obj3dType.o3d_sketch);
            DefinitionSketch = Sketch.GetDefinition();
            DefinitionSketch.SetPlane(Part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ));
            Sketch.Create();

            Document2D = DefinitionSketch.BeginEdit();
            Document2D.ksLineSeg(-5, -10, -25, 15, 1);
            DefinitionSketch.EndEdit();

        }

        /// <summary>
        /// Параметр выдавливания
        /// </summary>
        /// <param name="firstParameter">Значение выдавливания</param>
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
    }
}
