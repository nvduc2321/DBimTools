using DBimTool.Utils.NumberUtils;
using DBimTool.Utils.RevParameters;

namespace DBimTool.Utils.RevHoles
{
    public static class RevHole1Utils
    {
        public static RevHole1 GetRevHole1(this FamilyInstance f)
        {
            try
            {
                var revHole1 = new RevHole1
                {
                    Id = int.Parse(f.Id.ToString()),
                    Name = f.GetParameterValue(Properties.ParameterMainHole1.HOLE_NAME),
                    HoleRect1 = f.GetParameterValue(Properties.ParameterMainHole1.HOLE_RECT_1) == "1" ? true : false,
                    HoleRect2 = f.GetParameterValue(Properties.ParameterMainHole1.HOLE_RECT_2) == "1" ? true : false,
                    HoleRect3 = f.GetParameterValue(Properties.ParameterMainHole1.HOLE_RECT_3) == "1" ? true : false,
                    HoleRect4 = f.GetParameterValue(Properties.ParameterMainHole1.HOLE_RECT_4) == "1" ? true : false,
                    HoleCircle1 = f.GetParameterValue(Properties.ParameterMainHole1.HOLE_CIRCLE_1) == "1" ? true : false,
                    HoleCircle2 = f.GetParameterValue(Properties.ParameterMainHole1.HOLE_CIRCLE_2) == "1" ? true : false,
                    HoleCircle3 = f.GetParameterValue(Properties.ParameterMainHole1.HOLE_CIRCLE_3) == "1" ? true : false,
                    HoleCircle4 = f.GetParameterValue(Properties.ParameterMainHole1.HOLE_CIRCLE_4) == "1" ? true : false,
                    ChieuCaoBung =double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Chieu_cao_bung), System.Globalization.NumberStyles.Number),
                    ChieuCaoCo = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Chieu_cao_co), System.Globalization.NumberStyles.Number),
                    ChieuCaoNapGa = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Chieu_cao_napga), System.Globalization.NumberStyles.Number),
                    ChieuDaiBTLot = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Chieu_dai_BTlot), System.Globalization.NumberStyles.Number),
                    ChieuDaiCo = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Chieu_dai_co), System.Globalization.NumberStyles.Number),
                    ChieuDaiGa = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Chieu_dai_ga), System.Globalization.NumberStyles.Number),
                    ChieuDayTuong = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Chieu_day_Tuong), System.Globalization.NumberStyles.Number),
                    ChieuDayTuongDuoi = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Chieu_day_TuongDuoi), System.Globalization.NumberStyles.Number),
                    ChieuDayTuongTren = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Chieu_day_TuongTren), System.Globalization.NumberStyles.Number),
                    ChieuRongBTLot = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Chieu_rong_BTlot), System.Globalization.NumberStyles.Number),
                    ChieuRongCo = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Chieu_rong_co), System.Globalization.NumberStyles.Number),
                    ChieuRongGa = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Chieu_rong_ga), System.Globalization.NumberStyles.Number),
                    DCongMax = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.D_congMax), System.Globalization.NumberStyles.Number),
                    DayBTLot = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Day_BT_lot), System.Globalization.NumberStyles.Number),
                    DayCoGa = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Day_co_ga), System.Globalization.NumberStyles.Number),
                    GocLoMo1 = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Goc_LoMo1), System.Globalization.NumberStyles.Number),
                    GocLoMo2 = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Goc_LoMo2), System.Globalization.NumberStyles.Number),
                    GocLoMo3 = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Goc_LoMo3), System.Globalization.NumberStyles.Number),
                    GocLoMo4 = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.Goc_LoMo4), System.Globalization.NumberStyles.Number),
                    LoMo1_B = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.LoMo1_B), System.Globalization.NumberStyles.Number),
                    LoMo1_dV = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.LoMo1_dV), System.Globalization.NumberStyles.Number),
                    LoMo1_H = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.LoMo1_H), System.Globalization.NumberStyles.Number),
                    LoMo1_R = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.LoMo1_R), System.Globalization.NumberStyles.Number),
                    LoMo2_dV = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.LoMo2_dV), System.Globalization.NumberStyles.Number),
                    LoMo2_H = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.LoMo2_H), System.Globalization.NumberStyles.Number),
                    LoMo2_R = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.LoMo2_R), System.Globalization.NumberStyles.Number),
                    LoMo3_B = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.LoMo3_B), System.Globalization.NumberStyles.Number),
                    LoMo3_dV = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.LoMo3_dV), System.Globalization.NumberStyles.Number),
                    LoMo3_H = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.LoMo3_H), System.Globalization.NumberStyles.Number),
                    LoMo3_R = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.LoMo3_R), System.Globalization.NumberStyles.Number),
                    LoMo4_B = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.LoMo4_B), System.Globalization.NumberStyles.Number),
                    LoMo4_dV = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.LoMo4_dV), System.Globalization.NumberStyles.Number),
                    LoMo4_H = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.LoMo4_H), System.Globalization.NumberStyles.Number),
                    LoMo4_R = double.Parse(f.GetParameterValue(Properties.ParameterMainHole1.LoMo4_R), System.Globalization.NumberStyles.Number)
                };
                var trs = f.GetTransform();
                revHole1.VTX = trs.OfVector(XYZ.BasisX);
                revHole1.VTY = trs.OfVector(XYZ.BasisY);
                revHole1.VTZ = trs.OfVector(XYZ.BasisZ);
                revHole1.Origin = trs.OfPoint(new XYZ());
                return revHole1;
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
