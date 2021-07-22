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
    class Beam
    {
        //Поля, свойства
        public TSM.Beam beam { get; } = new TSM.Beam();
        public Beam(Point P1, Point P2, String profile, int offset, Position.DepthEnum depth, double depthoffset)
        {
            beam.StartPoint = P1;
            beam.EndPoint = P2;
            beam.Name = "MHP";
            beam.Material.MaterialString = "C245";
            beam.Position.Plane = Position.PlaneEnum.LEFT;
            beam.Profile.ProfileString = profile;
            beam.StartPointOffset.Dx = -offset;
            beam.EndPointOffset.Dx = offset;
            beam.Position.Depth = depth;
            beam.Position.DepthOffset = depthoffset;
            beam.Class = TSM.BooleanPart.BooleanOperativeClassName;
        }
        public Beam(Point P1, Point P2, String profile, int offset, Position.DepthEnum depth, double depthoffset,Position.PlaneEnum plane) : this(P1, P2, profile, offset, depth, depthoffset)
        {
            beam.Position.Plane = plane;
        }
        public void Insert()
        {
            beam.Insert();
        }
        public void Modify()
        {
            beam.Modify();
        }
        public void Delete()
        {
            beam.Delete();
        }
    }
}
