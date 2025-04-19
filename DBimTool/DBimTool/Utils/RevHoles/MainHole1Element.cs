using DBimTool.Utils.RevOpenings;

namespace DBimTool.Utils.RevHoles
{
    public abstract class MainHole1Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public XYZ VtX { get; set; }
        public XYZ VtY { get; set; }
        public XYZ VtZ { get; set; }
        public XYZ Origin { get; set; }
        public List<XYZ> PointControls { get; set; }
        public double Thickness { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public RevOpening Opening { get; set; }
        public RevHole1 RevHole1Info { get; set; }
        public MainHole1Element(RevHole1 revHole1Info)
        {
            RevHole1Info = revHole1Info;
        }
        public abstract XYZ GetVtX();
        public abstract XYZ GetVtY();
        public abstract XYZ GetVtZ();
        public abstract XYZ GetOrigin();
        public abstract List<XYZ> GetPointControls();
        public abstract double GetThickness();
        public abstract double GetLength();
        public abstract double GetWidth();
        public abstract RevOpening GetOpening();
    }
}
