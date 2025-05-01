using DBimTool.Utils.NumberUtils;
using DBimTool.Utils.RevHoles;
using DBimTool.Utils.RevOpenings;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.models
{
    public class MainHole1TopSlab : MainHole1Element
    {
        public MainHole1TopSlab(RevHole1 revHole1Info) : base(revHole1Info)
        {
            VtX = GetVtX();
            VtY = GetVtY();
            VtZ = GetVtZ();
            Origin = GetOrigin();
            Length = GetLength();
            Width = GetWidth();
            Thickness = GetThickness();
            PointControls = GetPointControls();
            Opening = GetOpening();
        }

        public override double GetLength()
        {
            return RevHole1Info.ChieuDaiGa;
        }

        public override RevOpening GetOpening()
        {
            RevOpening result = null;
            try
            {
                var opening = new RevOpeningRect();
                opening.VTX = VtX;
                opening.VTY = VtY;
                opening.VTZ = VtZ;
                opening.Width = RevHole1Info.ChieuDaiCo - RevHole1Info.ChieuDayTuong * 2;
                opening.Height = RevHole1Info.ChieuRongCo - RevHole1Info.ChieuDayTuong * 2;
                opening.Center = Origin 
                    - VtX * (Width / 2 - RevHole1Info.ChieuDayTuong - opening.Width / 2)
                    + VtY * (Length / 2 - RevHole1Info.ChieuDayTuong - opening.Height / 2);
                opening.Lines = opening.GetLinesOnFloor();
                result = opening;
            }
            catch (Exception)
            {
            }
            return result;
        }

        public override XYZ GetOrigin()
        {
            return RevHole1Info.Origin
                - RevHole1Info.VTZ * (RevHole1Info.ChieuCaoCo + RevHole1Info.ChieuDayTuongTren / 2);
        }

        public override List<XYZ> GetPointControls()
        {
            try
            {
                var p1 = Origin - VtX * Width / 2 - VtY * Length / 2 - VtZ * Thickness / 2;
                var p2 = Origin - VtX * Width / 2 + VtY * Length / 2 - VtZ * Thickness / 2;
                var p3 = Origin + VtX * Width / 2 + VtY * Length / 2 - VtZ * Thickness / 2;
                var p4 = Origin + VtX * Width / 2 - VtY * Length / 2 - VtZ * Thickness / 2;

                var p11 = Origin - VtX * Width / 2 - VtY * Length / 2 + VtZ * Thickness / 2;
                var p22 = Origin - VtX * Width / 2 + VtY * Length / 2 + VtZ * Thickness / 2;
                var p33 = Origin + VtX * Width / 2 + VtY * Length / 2 + VtZ * Thickness / 2;
                var p44 = Origin + VtX * Width / 2 - VtY * Length / 2 + VtZ * Thickness / 2;
                return new List<XYZ> { p1, p2, p3, p4, p11, p22, p33, p44 };
            }
            catch (Exception)
            {
            }
            return new List<XYZ>();
        }

        public override double GetThickness()
        {
            return RevHole1Info.ChieuDayTuongTren;
        }

        public override XYZ GetVtX()
        {
            return RevHole1Info.VTX;
        }

        public override XYZ GetVtY()
        {
            return RevHole1Info.VTY;
        }

        public override XYZ GetVtZ()
        {
            return RevHole1Info.VTZ;
        }

        public override double GetWidth()
        {
            return RevHole1Info.ChieuRongGa;
        }
    }
}
