namespace DBimTool.Utils.RevOpenings
{
    public abstract class RevOpening
    {
        public int Id { get; set; }
        public XYZ VTX { get; set; }
        public XYZ VTY { get; set; }
        public XYZ VTZ { get; set; }
        public XYZ Center { get; set; }
        public List<Line> Lines { get; set; }
        public abstract List<Line> GetLines();
        public abstract List<Line> GetLinesOnFloor();
    }
}
