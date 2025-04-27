using DBimTool.Utils.Compares;
using DBimTool.Utils.Geometries;
using DBimTool.Utils.NumberUtils;
using DBimTool.Utils.RevFaces;

namespace DBimTool.Utils.RevCurves
{
    public static class RevCurveUtils
    {
        public static List<Line> IntersectLineToLine(this Line l, List<Line> ls, XYZ normal)
        {
            try
            {
                var results = new List<Line>();
                var p1 = l.GetEndPoint(0);
                var p2 = l.GetEndPoint(1);
                var ps = new List<XYZ>();
                foreach (var line in ls)
                {
                    var p1C = line.GetEndPoint(0);
                    var p2C = line.GetEndPoint(1);
                    var f = new FaceCustom(normal.CrossProduct(line.Direction()).Normalize(), line.Mid());
                    var p = p1.RayPointToFace(l.Direction(), f);
                    if ((p - p1).Normalize().DotProduct((p - p2).Normalize()).IsGreater(0)) continue;
                    if ((p - p1C).Normalize().DotProduct((p - p2C).Normalize()).IsGreater(0)) continue;
                    ps.Add(p);
                }
                ps = ps.Distinct(new ComparePoint()).ToList();
                if (ps.Any())
                {
                    if (ps.Count % 2 != 0) 
                        ps.RemoveAt(ps.Count - 1);
                    ps.Insert(0, p1);
                    ps.Add(p2);
                    ps = ps.OrderBy(x=>x.DotProduct(l.Direction())).ToList();
                    var qPs = ps.Count();
                    for (int i = 0; i < qPs; i++)
                    {
                        if (i % 2 != 0) continue;
                        var lAdd = ps[i].CreateLine(ps[i + 1]);
                        results.Add(lAdd);
                    }
                }
                else results.Add(l);
                return results;
            }
            catch (Exception)
            {
            }
            return new List<Line>() { l };
        }
        public static XYZ Direction(this Curve c)
        {
            return (c.GetEndPoint(0) - c.GetEndPoint(1)).Normalize();
        }
        public static XYZ Direction(this Line l)
        {
            return (l.GetEndPoint(0) - l.GetEndPoint(1)).Normalize();
        }
        public static XYZ Mid(this Curve c)
        {
            return (c.GetEndPoint(0) + c.GetEndPoint(1)) * 0.5;
        }
        public static XYZ Mid(this Line l)
        {
            return (l.GetEndPoint(0) + l.GetEndPoint(1)) * 0.5;
        }
        public static List<Curve> Copy(this List<Curve> curves, XYZ dirCopy)
        {
            var results = new List<Curve>();
            try
            {
                if (dirCopy.IsSame(XYZ.Zero)) return curves;
                foreach (var item in curves)
                {
                    var p1 = item.GetEndPoint(0) + dirCopy;
                    var p2 = item.GetEndPoint(1) + dirCopy;
                    results.Add(Line.CreateBound(p1, p2));
                }
            }
            catch (Exception)
            {
                return null;
            }
            return results;
        }
        public static CurveLoop ToCurveLoop(this List<Curve> curves)
        {
            var result = new CurveLoop();
            try
            {
                foreach (var item in curves)
                {
                    result.Append(item);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return result;
        }
        public static void CreateCurves(this Document document, List<Curve> curves)
        {
            foreach (var l in curves)
            {
                try
                {
                    var nor = l.Direction().IsParallel(XYZ.BasisZ) ? l.Direction().CrossProduct(XYZ.BasisX) : l.Direction().CrossProduct(XYZ.BasisZ);
                    var plane = Plane.CreateByNormalAndOrigin(nor, l.Mid());
                    var sket = SketchPlane.Create(document, plane);

                    var lModel = document.Create.NewModelCurve(l, sket);
                }
                catch (Exception)
                {
                }
            }
        }
        public static void CreateCurves(this Document document, Curve curve)
        {
            try
            {
                var nor = curve.Direction().IsParallel(XYZ.BasisZ) ? curve.Direction().CrossProduct(XYZ.BasisX) : curve.Direction().CrossProduct(XYZ.BasisZ);
                var plane = Plane.CreateByNormalAndOrigin(nor, curve.Mid());
                var sket = SketchPlane.Create(document, plane);

                document.Create.NewModelCurve(curve, sket);
            }
            catch (Exception)
            {
            }
        }
    }
}
