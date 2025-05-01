
using DBimTool.Utils.Geometries;

namespace DBimTool.Utils.RevOpenings
{
    public class RevOpeningCircle : RevOpening
    {
        public double Radius { get; set; }

        public override List<Line> GetLines()
        {
            var results = new List<Line>(); 
            try
            {
                var ps = Center - VTX * Radius;
                var pe = Center + VTX * Radius;
                var m1 = Center - VTZ * Radius;
                var m2 = Center + VTZ * Radius;
                var arc1 = Arc.Create(ps, pe, m1);
                var arc2 = Arc.Create(ps, pe, m2);
                var cs1 = arc1.Tessellate().ToList().PointsToCurves().Select(x=> x as Line);
                var cs2 = arc2.Tessellate().ToList().PointsToCurves().Select(x => x as Line);
                if (cs1.Any()) results.AddRange(cs1);
                if (cs2.Any()) results.AddRange(cs2);
                return results;
            }
            catch (Exception)
            {
            }
            return new List<Line>();
        }

        public override List<Line> GetLinesOnFloor()
        {
            throw new NotImplementedException();
        }
    }
}
