using DBimTool.Utils.RevHoles;
using DBimTool.Utils.RevOpenings;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.models
{
    public class MainHole1Wall1 : MainHole1Element
    {
        public MainHole1Wall1(RevHole1 revHole1Info) : base(revHole1Info)
        {
        }

        public override double GetLength()
        {
            throw new NotImplementedException();
        }

        public override RevOpening GetOpening()
        {
            throw new NotImplementedException();
        }

        public override XYZ GetOrigin()
        {
            throw new NotImplementedException();
        }

        public override List<XYZ> GetPointControls()
        {
            throw new NotImplementedException();
        }

        public override double GetThickness()
        {
            throw new NotImplementedException();
        }

        public override XYZ GetVtX()
        {
            throw new NotImplementedException();
        }

        public override XYZ GetVtY()
        {
            throw new NotImplementedException();
        }

        public override XYZ GetVtZ()
        {
            throw new NotImplementedException();
        }

        public override double GetWidth()
        {
            throw new NotImplementedException();
        }
    }
}
