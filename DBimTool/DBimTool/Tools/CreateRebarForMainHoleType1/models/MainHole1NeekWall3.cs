using DBimTool.Utils.RevHoles;
using DBimTool.Utils.RevOpenings;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.models
{
    public class MainHole1NeekWall3 : MainHole1Element
    {
        public MainHole1NeekWall3(RevHole1 revHole1Info) : base(revHole1Info)
        {
            VtX = GetVtX();
            VtY = GetVtY();
            VtZ = GetVtZ();
            Origin = GetOrigin();
            Width = GetWidth();
            Length = GetLength();
            Thickness = GetThickness();
            PointControls = GetPointControls();
            Opening = GetOpening();
        }
        public override RevOpening GetOpening()
        {
            return null;
        }
        public override double GetWidth()
        {
            return RevHole1Info.ChieuDaiCo;
        }
        public override double GetLength()
        {
            return RevHole1Info.ChieuCaoCo;
        }
        public override XYZ GetOrigin()
        {
            return RevHole1Info.Origin
                - RevHole1Info.VTX * (RevHole1Info.ChieuRongGa / 2 - RevHole1Info.ChieuDaiCo / 2)
                - RevHole1Info.VTZ * (RevHole1Info.ChieuCaoCo / 2)
                + RevHole1Info.VTY * (RevHole1Info.ChieuDaiGa / 2 - RevHole1Info.ChieuRongCo + RevHole1Info.ChieuDayTuong / 2);
        }
        public override List<XYZ> GetPointControls()
        {
            var results = new List<XYZ>();
            try
            {
                var p11 = Origin - VtX * Width / 2 - VtY * Thickness / 2 - VtZ * Length / 2;
                var p12 = Origin - VtX * Width / 2 + VtY * Thickness / 2 - VtZ * Length / 2;
                var p13 = Origin + VtX * Width / 2 + VtY * Thickness / 2 - VtZ * Length / 2;
                var p14 = Origin + VtX * Width / 2 - VtY * Thickness / 2 - VtZ * Length / 2;

                var p21 = Origin - VtX * Width / 2 - VtY * Thickness / 2 + VtZ * Length / 2;
                var p22 = Origin - VtX * Width / 2 + VtY * Thickness / 2 + VtZ * Length / 2;
                var p23 = Origin + VtX * Width / 2 + VtY * Thickness / 2 + VtZ * Length / 2;
                var p24 = Origin + VtX * Width / 2 - VtY * Thickness / 2 + VtZ * Length / 2;
                results.Add(p11);
                results.Add(p12);
                results.Add(p13);
                results.Add(p14);

                results.Add(p21);
                results.Add(p22);
                results.Add(p23);
                results.Add(p24);
                return results;
            }
            catch (Exception)
            {
            }
            return results;
        }
        public override double GetThickness()
        {
            return RevHole1Info.ChieuDayTuong;
        }
        public override XYZ GetVtX()
        {
            return -RevHole1Info.VTX;
        }
        public override XYZ GetVtY()
        {
            return -RevHole1Info.VTY;
        }
        public override XYZ GetVtZ()
        {
            return RevHole1Info.VTZ;
        }
    }
}
