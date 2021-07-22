using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSG = Tekla.Structures.Geometry3d;
using TSM = Tekla.Structures.Model;
using Tekla.Structures.Dialog;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;
using System.Collections;
using System.Windows;
using Tekla.Structures.Catalogs;

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
        public int l1;
        [StructuresField("list2")]
        public int l2;
        [StructuresField("parametrs1")]
        public int s1;
        [StructuresField("ph1_transition")]
        public double h1_transition;
        [StructuresField("pl1_transition")]
        public double l1_transition;

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
        private int _l2 = 0;
        private int _s1 = 0;
        private double _h1_transition = 100.0;
        private double _l1_transition = 100.0;

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


        public override bool Run (List<InputDefinition> Input)
        {
            try
            {
                GetValueFromDialog();
                //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                ArrayList points = (ArrayList)Input[0].GetInput();
                //Магия. Выделенную деталь передаем сюда через идентификатор.
                TSM.Part beam_select = (TSM.Part)_Model.SelectModelObject((Tekla.Structures.Identifier)Input[1].GetInput());
                Double WIDTH = 0.0;
                //Получение свойств выделенной детали. В данном случае толщину
                beam_select.GetReportProperty("WIDTH", ref WIDTH);
                //Создаем массив из будущих разделок
                string[] faska = new string[] {$"MHP{_h1}*{_a1}*{(int)WIDTH}",$"RT{_h2}*{_h1}*{_a1}*{(int)WIDTH}", $"RT0.01*{_h1}*{_a1}*{(int)WIDTH}" };
                //Создаем нашу деталь разделку
                int[] beam_behind = {1, 1, -1};
                double[,] offset_beam = 
                    { 
                    {beam_select.Position.DepthOffset, beam_select.Position.DepthOffset, beam_select.Position.DepthOffset + beam_behind[(int)beam_select.Position.Depth] * _h1_transition, beam_select.Position.DepthOffset + beam_behind[(int)beam_select.Position.Depth] * _h1_transition },
                    {beam_select.Position.DepthOffset, beam_select.Position.DepthOffset - beam_behind[(int)beam_select.Position.Depth] * 0.5 * _h1_transition, beam_select.Position.DepthOffset, beam_select.Position.DepthOffset + beam_behind[(int)beam_select.Position.Depth] * 0.5 * _h1_transition},
                    {beam_select.Position.DepthOffset, beam_select.Position.DepthOffset - beam_behind[(int)beam_select.Position.Depth] * 0.5 * _h1_transition, beam_select.Position.DepthOffset, beam_select.Position.DepthOffset + beam_behind[(int)beam_select.Position.Depth] * 0.5 * _h1_transition}
                    };
                Beam beam = new Beam(points[0] as TSG.Point, points[1] as TSG.Point, faska[_l1], _s1, beam_select.Position.Depth, offset_beam[_l1, _l2]);
                if (!beam.beam.Insert())
                {
                    MessageBox.Show("Вы не импортировали профили разделок: MHP,");
                    return false;
                }
                beam.Insert();
                double[] offset_up = { -beam_select.Position.DepthOffset - WIDTH * 0.5, -beam_select.Position.DepthOffset - WIDTH, beam_select.Position.DepthOffset};
                double[] offset_down = { -beam_select.Position.DepthOffset + WIDTH * 0.5, -beam_select.Position.DepthOffset, beam_select.Position.DepthOffset - -WIDTH };

                if (_l2 == 1)
                {
                    Beam beam_transition = new Beam(points[1] as TSG.Point, points[0] as TSG.Point, $"TRI_A{_h1_transition}-{_l1_transition}", _s1, TSM.Position.DepthEnum.BEHIND, offset_up[(int)beam_select.Position.Depth], TSM.Position.PlaneEnum.RIGHT);
                    beam_transition.Insert();
                    BooleanPart beam_transition_boolean = new BooleanPart(beam_transition, beam_select);
                }
                else if(_l2 == 2)
                {
                    Beam beam_transition = new Beam(points[1] as TSG.Point, points[0] as TSG.Point, $"TRI_A{_h1_transition}-{_l1_transition}", _s1, TSM.Position.DepthEnum.BEHIND, offset_up[(int)beam_select.Position.Depth], TSM.Position.PlaneEnum.RIGHT);
                    beam_transition.Insert();
                    BooleanPart beam_transition_boolean = new BooleanPart(beam_transition, beam_select);
                    Beam beam_transition_down = new Beam(points[0] as TSG.Point, points[1] as TSG.Point, $"TRI_A{_h1_transition}-{_l1_transition}", _s1, TSM.Position.DepthEnum.FRONT, -offset_down[(int)beam_select.Position.Depth], TSM.Position.PlaneEnum.LEFT);
                    beam_transition_down.beam.Position.Rotation = TSM.Position.RotationEnum.BELOW;
                    beam_transition_down.Insert();
                    BooleanPart beam_transition_boolean_down = new BooleanPart(beam_transition_down, beam_select);
                }
                else if (_l2 == 3)
                {
                    Beam beam_transition_down = new Beam(points[0] as TSG.Point, points[1] as TSG.Point, $"TRI_A{_h1_transition}-{_l1_transition}", _s1, TSM.Position.DepthEnum.FRONT, -offset_down[(int)beam_select.Position.Depth], TSM.Position.PlaneEnum.LEFT);
                    beam_transition_down.beam.Position.Rotation = TSM.Position.RotationEnum.BELOW;
                    beam_transition_down.Insert();
                    BooleanPart beam_transition_boolean_down = new BooleanPart(beam_transition_down, beam_select);
                }
                BooleanPart beam_boolean = new BooleanPart(beam, beam_select);
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

            _l2 = Data.l2;
            if (IsDefaultValue(_l2))
                _l2 = 0;

            _s1 = Data.s1;
            if (IsDefaultValue(_s1))
                _s1 = 0;

            _h1_transition = Data.h1_transition;
            if (IsDefaultValue(_h1_transition))
                _h1_transition = 200.0;

            _l1_transition = Data.l1_transition;
            if (IsDefaultValue(_l1_transition))
                _l1_transition = 200.0;

        }
    }
}
