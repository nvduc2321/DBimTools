using DBimTool.Utils.NumberUtils;
using DBimTool.Utils.RevHoles;
using DBimTool.Utils.RevOpenings;
using System.Windows;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.models
{
    public class MainHole1BottomSlab : MainHole1Element
    {
        public MainHole1BottomSlab(RevHole1 revHole1Info) : base(revHole1Info)
        {
            VtX = GetVtX();
            VtY = GetVtY();
            VtZ = GetVtZ();
            Origin = GetOrigin();
            Length = GetLength();
            Width = GetWidth();
            Thickness = GetThickness();
            PointControls = GetPointControls();
        }

        public override double GetLength()
        {
            return RevHole1Info.ChieuDaiGa + 100.MmToFoot() * 2;
        }

        public override RevOpening GetOpening()
        {
            return null;
        }

        public override XYZ GetOrigin()
        {
            return RevHole1Info.Origin
                - RevHole1Info.VTZ * (RevHole1Info.ChieuCaoCo + RevHole1Info.ChieuDayTuongTren + RevHole1Info.ChieuCaoBung + RevHole1Info.ChieuDayTuongDuoi / 2);
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
            return RevHole1Info.ChieuDayTuongDuoi;
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
            return RevHole1Info.ChieuRongGa + 100.MmToFoot() * 2;
        }
    }
}
