﻿using DBimTool.Utils.RevCurves;

namespace DBimTool.Utils.RevFaces
{
    public class FaceCustom
    {
        public XYZ Normal { get; set; }
        public XYZ BasePoint { get; set; }
        public Line BaseLine { get; set; }

        public FaceCustom(XYZ normal, XYZ basePoint)
        {
            Normal = normal;
            BasePoint = basePoint;
        }
        public FaceCustom(XYZ normal, Line baseLine)
        {
            Normal = normal;
            BaseLine = baseLine;
            BasePoint = baseLine.Mid();
        }
        public FaceCustom(XYZ p1, XYZ p2, XYZ p3)
        {
            BasePoint = p1;
            var vt1 = (p2 - p1).Normalize();
            var vt2 = (p3 - p1).Normalize();
            Normal = vt1.CrossProduct(vt2).Normalize();
        }
    }
}
