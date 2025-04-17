using System.Runtime.CompilerServices;

namespace DBimTool.Utils.BoundingBoxs
{
    public static class BoundingBoxUtils
    {
        public static double GetHeight(this BoundingBoxXYZ boundingBoxXYZ)
        {
            return Math.Abs(boundingBoxXYZ.Max.Z - boundingBoxXYZ.Min.Z);
        }
    }
}
