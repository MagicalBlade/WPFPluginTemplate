using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSG = Tekla.Structures.Geometry3d;
using TSM = Tekla.Structures.Model;
using Tekla.Structures.Model.Operations;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;
using System.Collections;
using System.Windows;
using Tekla.Structures.Catalogs;
using Tekla.Structures.Solid;

namespace WPFPluginTemplate
{
    public class PluginData
    {
        [StructuresField("parametrh1")]
        public double h1;
        [StructuresField("parametrh2")]
        public double h2;
        [StructuresField("anglea1")]
        public double a1;
        [StructuresField("list1")]
        public int  l1;
        [StructuresField("parametrs1")]
        public int s1;
        

    }
    [Plugin("WPFPluginTemplate")]
    [PluginUserInterface("WPFPluginTemplate.MainWindow")]
    [PluginCoordinateSystem(CoordinateSystemType.FROM_FIRST_POINT_AND_GLOBAL)]
    public class WPFPluginTemplite : PluginBase
    {
        //Внутренние поля
        private double _h1 = 100.0;
        private double _h2 = 2.0;
        private double _a1 = 45.0;
        private int _l1 = 0;
        private int _s1 = 0;

        private TSM.Model _Model;
        private PluginData _Data;

        private TSM.Model Model { get => _Model; set => _Model = value; }
        private PluginData Data { get => _Data; set => _Data = value; }

        public WPFPluginTemplite(PluginData data)
        {
            Model = new TSM.Model();
            Data = data;

        }

        public override List<InputDefinition> DefineInput()
        {
            //Основной метод получения данных из теклы.
            List<InputDefinition> PointList = new List<InputDefinition>();
            Picker Picker = new Picker();
            //Выбор детали
            TSM.Part select = (TSM.Part)Picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
            //Указание точек размещения
            ArrayList PickedPoints = Picker.PickPoints(Picker.PickPointEnum.PICK_TWO_POINTS);
            
            PointList.Add(new InputDefinition(PickedPoints));
            PointList.Add(new InputDefinition(select.Identifier));
            ArrayList points = (ArrayList)PointList[0].GetInput();
            //MessageBox.Show(points[0].ToString());
            return PointList;
        }



        public override bool  Run (List<InputDefinition> Input)
        {
            try
            {
                GetValueFromDialog();
                //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                TSM.Beam beam = new TSM.Beam();
                ArrayList points = (ArrayList)Input[0].GetInput();
                //Магия. Выделенную деталь передаем сюда через идентификатор.
                TSM.Part beam1 = (TSM.Part)_Model.SelectModelObject((Tekla.Structures.Identifier)Input[1].GetInput());
                Double WIDTH = 0.0;
                //Получение свойств выделенной детали. В данном случае толщину
                beam1.GetReportProperty("WIDTH", ref WIDTH);
                //Создаем массив из будущих разделок
                string[] faska = new string[] {$"MHP{_h1}*{_a1}*{(int)WIDTH}",$"RT{_h2}*{_h1}*{_a1}*{(int)WIDTH}", $"RT0.01*{_h1}*{_a1}*{(int)WIDTH}" };
                beam.Profile.ProfileString = faska[_l1];
                //Задаем свойства нашей детали-разделки
                beam.StartPoint = new TSG.Point(points[0] as TSG.Point);
                beam.EndPoint = new TSG.Point(points[1] as TSG.Point);

                beam.Position.Plane = TSM.Position.PlaneEnum.LEFT;
                beam.Position.Depth = beam1.Position.Depth;
                //beam.Position.DepthOffset = beam1.Position.DepthOffset + (Math.Abs(WIDTH_Z) - Math.Abs(WIDTH))/2; //изменяем глубину если есть переход на детали
                beam.Position.DepthOffset = beam1.Position.DepthOffset;
                beam.StartPointOffset.Dx = -_s1;
                beam.EndPointOffset.Dx = _s1;
                beam.Name = "MHP";
                beam.Material.MaterialString = "C245";
                beam.Insert();




                //Вырезаем одну деталь из другой
                beam.Class = TSM.BooleanPart.BooleanOperativeClassName;
                TSM.BooleanPart Beam1 = new TSM.BooleanPart();
                Beam1.Father = beam1;
                Beam1.SetOperativePart(beam);
                if (!Beam1.Insert())
                    Console.WriteLine("Insert failed!");

                beam.Delete();  //удаляем разделку, оставляя только вырез

                

            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.ToString());
            }
            return true;
        }

        private void GetValueFromDialog()
        {
            _h1 = Data.h1;
            if (IsDefaultValue(_h1))
                _h1 = 200.0;
            _h2 = Data.h2;
            if (IsDefaultValue(_h2))
                _h2 = 2.0;
            _a1 = Data.a1;
            if (IsDefaultValue(_a1))
                _a1 = 45.0;
            _l1 = Data.l1;
            if (IsDefaultValue(_l1))
                _l1 = 0;
            _s1 = Data.s1;
            if (IsDefaultValue(_s1))
                _s1 = 0;
        }
    }
}
