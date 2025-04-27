
using DBimTool.Utils.Geometries;

namespace DBimTool.Utils.RevOpenings
{
    public class RevOpeningRect : RevOpening
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public override List<Line> GetLines()
        {
            var results = new List<Line>();
            try
            {
                var p1 = Center - VTX * Width /2 - VTZ * Height / 2;
                var p2 = Center - VTX * Width /2 + VTZ * Height / 2;
                var p3 = Center + VTX * Width /2 + VTZ * Height / 2;
                var p4 = Center + VTX * Width /2 - VTZ * Height / 2;

                results.Add(p1.CreateLine(p2));
                results.Add(p2.CreateLine(p3));
                results.Add(p3.CreateLine(p4));
                results.Add(p4.CreateLine(p1));
                return results;
            }
            catch (Exception)
            {
            }
            return new List<Line>();
        }
    }
}
