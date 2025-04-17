using Autodesk.Revit.DB.Structure;
using DBimTool.Utils.Compares;
using DBimTool.Utils.Geometries;
using DBimTool.Utils.RevCurves;
using DBimTool.Utils.RevFaces;
using DBimTool.Utils.Solids;
using System.Diagnostics;

namespace DBimTool.Utils.BoundingBoxs
{
    public static class BoxElementUtils
    {
        public static void GenerateCoordinateBeam(this List<FamilyInstance> familyInstances, out XYZ vtxOut, out XYZ vtyOut, out XYZ vtzOut)
        {
            vtxOut = null;
            vtyOut = null;
            vtzOut = null;
            try
            {
                vtxOut = familyInstances
                    .Select(x =>
                    {
                        var transf = x.GetTransform();
                        return transf.OfVector(XYZ.BasisX);
                    })
                    .GroupBy(x => x, new ComparePoint())
                    .OrderBy(x => x.Count())
                    .Select(x => x.ToList())
                    .LastOrDefault()
                .FirstOrDefault()
                    .Normalize();
                vtyOut = familyInstances
                    .Select(x =>
                    {
                        var transf = x.GetTransform();
                        return transf.OfVector(XYZ.BasisY);
                    })
                    .GroupBy(x => x, new ComparePoint())
                    .OrderBy(x => x.Count())
                    .Select(x => x.ToList())
                    .LastOrDefault()
                    .FirstOrDefault()
                    .Normalize();
                vtzOut = vtxOut.CrossProduct(vtyOut).Normalize();
            }
            catch (Exception)
            {
            }
        }
    }
}
