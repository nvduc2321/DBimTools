using DBimTool.Utils.RevHoles;
using DBimTool.Utils.RevOpenings;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.models
{
    public class MainHole1Wall3 : MainHole1Element
    {
        public MainHole1Wall3(RevHole1 revHole1Info) : base(revHole1Info)
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
            RevOpening result = null;
            try
            {
                if (RevHole1Info.HoleCircle3 && RevHole1Info.HoleRect3)
                    return null;
                if (RevHole1Info.HoleCircle3)
                {
                    var opening = new RevOpeningCircle();
                    opening.VTX = VtX;
                    opening.VTY = VtY;
                    opening.VTZ = VtZ;
                    opening.Radius = RevHole1Info.LoMo3_R;
                    opening.Center = Origin - VtZ * (RevHole1Info.ChieuCaoBung / 2 - RevHole1Info.LoMo3_dV - RevHole1Info.LoMo3_R);
                    opening.Lines = opening.GetLines();
                    result = opening;
                }
                if (RevHole1Info.HoleRect3)
                {
                    var opening = new RevOpeningRect();
                    opening.VTX = VtX;
                    opening.VTY = VtY;
                    opening.VTZ = VtZ;
                    opening.Width = RevHole1Info.LoMo3_B;
                    opening.Height = RevHole1Info.LoMo3_H;
                    opening.Center = Origin - VtZ * (RevHole1Info.ChieuCaoBung / 2 - RevHole1Info.LoMo3_dV - RevHole1Info.LoMo3_H / 2);
                    opening.Lines = opening.GetLines();
                    result = opening;
                }
            }
            catch (Exception)
            {

            }
            return result;
        }
        public override double GetWidth()
        {
            return RevHole1Info.ChieuRongGa;
        }
        public override double GetLength()
        {
            return RevHole1Info.ChieuCaoBung;
        }
        public override XYZ GetOrigin()
        {
            return RevHole1Info.Origin
                - RevHole1Info.VTZ * (RevHole1Info.ChieuCaoCo + RevHole1Info.ChieuDayTuongTren + RevHole1Info.ChieuCaoBung / 2)
                - RevHole1Info.VTY * (RevHole1Info.ChieuDaiGa / 2 - RevHole1Info.ChieuDayTuong / 2);
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
