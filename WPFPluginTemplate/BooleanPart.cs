using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using TSM = Tekla.Structures.Model;

namespace WPFPluginTemplate
{
    class BooleanPart
    {
        public TSM.BooleanPart booleanpart { get; } = new TSM.BooleanPart();
        public BooleanPart (Beam beam, ModelObject beam_select)
        {
            //Вырезаем одну деталь из другой
            booleanpart.Father = beam_select;
            booleanpart.SetOperativePart(beam.beam);
            if (!booleanpart.Insert())
                Console.WriteLine("Insert failed!");
            beam.Delete(); //удаляем разделку, оставляя только вырез
        }
    }
}
