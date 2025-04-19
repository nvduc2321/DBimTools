namespace DBimTool.Utils.RevOpenings
{
    public abstract class RevOpening
    {
        public int Id { get; set; }
        public XYZ Normal { get; set; }
        public XYZ Center { get; set; }
    }
}
