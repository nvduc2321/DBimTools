namespace DBimTool.Utils.RevRebars
{
    public class RevRebar
    {
        public int Id { get; set; }
        public string DiameterName { get; set; }
        public double DiameterValue { get; set; }
        public XYZ Normal { get; set; }
        public List<Curve> Lines { get; set; }
    }
}
