using Autodesk.Revit.DB;
using DBimTool.Utils.Geometries;
using DBimTool.Utils.NumberUtils;
using DBimTool.Utils.RevHoles;
using DBimTool.Utils.RevRebars;
using System.Windows.Forms;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.models
{
    public class MainHole1BottomSlabRebar
    {
        private static double _spacingMm = 200;
        private static double _extentMm = 50;
        public MainHole1BottomSlab HostInfo { get; set; }
        public RevRebarMesh RebarTopY {  get; set; }
        public RevRebarMesh RebarTopX {  get; set; }
        public RevRebarMesh RebarBotY {  get; set; }
        public RevRebarMesh RebarBotX {  get; set; }
        public List<Line> LineCenterY { get; set; }
        public List<Line> LineCenterX { get; set; }
        public static MainHole1BottomSlabRebar Init(RevHole1 revHole1, List<string> diameters)
        {
            try
            {
                var mainHole1BottomSlabRebar = new MainHole1BottomSlabRebar();
                mainHole1BottomSlabRebar.HostInfo = new MainHole1BottomSlab(revHole1);
                mainHole1BottomSlabRebar.RebarTopY = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = _spacingMm, RevRebars = new List<RevRebar>()};
                mainHole1BottomSlabRebar.RebarTopX = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = _spacingMm, RevRebars = new List<RevRebar>()};
                mainHole1BottomSlabRebar.RebarBotY = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = _spacingMm, RevRebars = new List<RevRebar>()};
                mainHole1BottomSlabRebar.RebarBotX = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = _spacingMm, RevRebars = new List<RevRebar>()};
                mainHole1BottomSlabRebar.LineCenterY = _generateLineCenterY(mainHole1BottomSlabRebar);
                mainHole1BottomSlabRebar.LineCenterX = _generateLineCenterX(mainHole1BottomSlabRebar);
                mainHole1BottomSlabRebar.RebarBotY.SpacingMmChanged = () =>
                {
                    mainHole1BottomSlabRebar.LineCenterY = _generateLineCenterY(mainHole1BottomSlabRebar);
                };
                mainHole1BottomSlabRebar.RebarTopY.SpacingMmChanged = () =>
                {
                    mainHole1BottomSlabRebar.LineCenterY = _generateLineCenterY(mainHole1BottomSlabRebar);
                };
                mainHole1BottomSlabRebar.RebarBotX.SpacingMmChanged = () =>
                {
                    mainHole1BottomSlabRebar.LineCenterX = _generateLineCenterX(mainHole1BottomSlabRebar);
                };
                mainHole1BottomSlabRebar.RebarTopX.SpacingMmChanged = () =>
                {
                    mainHole1BottomSlabRebar.LineCenterX = _generateLineCenterX(mainHole1BottomSlabRebar);
                };
                return mainHole1BottomSlabRebar;
            }
            catch (Exception)
            {
            }
            return null;
        }
        private static List<Line> _generateLineCenterY(MainHole1BottomSlabRebar mainHole1BottomSlabRebar)
        {
            var result = new List<Line>();
            try
            {
                var spacing = mainHole1BottomSlabRebar.RebarTopY.SpacingMm;
                var vtx = mainHole1BottomSlabRebar.HostInfo.VtX;
                var vty = mainHole1BottomSlabRebar.HostInfo.VtY;
                var vtz = mainHole1BottomSlabRebar.HostInfo.VtZ;
                var p1 = mainHole1BottomSlabRebar.HostInfo.PointControls[0];
                var p2 = mainHole1BottomSlabRebar.HostInfo.PointControls[1];
                var p3 = mainHole1BottomSlabRebar.HostInfo.PointControls[2];
                var p4 = mainHole1BottomSlabRebar.HostInfo.PointControls[3];
                var p5 = mainHole1BottomSlabRebar.HostInfo.PointControls[4];
                var p6 = mainHole1BottomSlabRebar.HostInfo.PointControls[5];
                var p7 = mainHole1BottomSlabRebar.HostInfo.PointControls[6];
                var p8 = mainHole1BottomSlabRebar.HostInfo.PointControls[7];

                var p11 = p1.MidPoint(p5) + vtx * _extentMm.MmToFoot();
                var p22 = p2.MidPoint(p6) + vtx * _extentMm.MmToFoot();
                var p33 = p3.MidPoint(p7);
                var p44 = p4.MidPoint(p8);

                var qty = mainHole1BottomSlabRebar.HostInfo.Width.FootToMm().GetQuantityFromSpacing(spacing, _extentMm, out double lengthDuMm);
                for (int i = 0; i < qty; i++)
                {
                    try
                    {
                        var l = Line.CreateBound(
                            p11 + i * vtx * spacing.MmToFoot(),
                            p22 + i * vtx * spacing.MmToFoot());
                        result.Add(l);
                        if (i == qty - 1)
                        {
                            if (lengthDuMm * 100 / spacing >= 30)
                            {
                                var ldu = Line.CreateBound(
                                    p11 + vtx * (i * spacing.MmToFoot() + lengthDuMm.MmToFoot()),
                                    p22 + vtx * (i * spacing.MmToFoot() + lengthDuMm.MmToFoot()));
                                result.Add(ldu);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
            return result;
        }
        private static List<Line> _generateLineCenterX(MainHole1BottomSlabRebar mainHole1BottomSlabRebar)
        {
            var result = new List<Line>();
            try
            {
                var spacing = mainHole1BottomSlabRebar.RebarTopX.SpacingMm;
                var vtx = mainHole1BottomSlabRebar.HostInfo.VtX;
                var vty = mainHole1BottomSlabRebar.HostInfo.VtY;
                var vtz = mainHole1BottomSlabRebar.HostInfo.VtZ;
                var p1 = mainHole1BottomSlabRebar.HostInfo.PointControls[0];
                var p2 = mainHole1BottomSlabRebar.HostInfo.PointControls[1];
                var p3 = mainHole1BottomSlabRebar.HostInfo.PointControls[2];
                var p4 = mainHole1BottomSlabRebar.HostInfo.PointControls[3];
                var p5 = mainHole1BottomSlabRebar.HostInfo.PointControls[4];
                var p6 = mainHole1BottomSlabRebar.HostInfo.PointControls[5];
                var p7 = mainHole1BottomSlabRebar.HostInfo.PointControls[6];
                var p8 = mainHole1BottomSlabRebar.HostInfo.PointControls[7];

                var p11 = p1.MidPoint(p5) + vty * _extentMm.MmToFoot();
                var p22 = p2.MidPoint(p6);
                var p33 = p3.MidPoint(p7);
                var p44 = p4.MidPoint(p8) + vty * _extentMm.MmToFoot();

                var qty = mainHole1BottomSlabRebar.HostInfo.Length.FootToMm().GetQuantityFromSpacing(spacing, _extentMm, out double lengthDuMm);
                for (int i = 0; i < qty; i++)
                {
                    try
                    {
                        var l = Line.CreateBound(
                            p11 + i * vty * spacing.MmToFoot(),
                            p44 + i * vty * spacing.MmToFoot());
                        result.Add(l);
                        if (i == qty - 1)
                        {
                            if (lengthDuMm * 100 / spacing >= 30)
                            {
                                var ldu = Line.CreateBound(
                                    p11 + vty * (i * spacing.MmToFoot() + lengthDuMm.MmToFoot()),
                                    p44 + vty * (i * spacing.MmToFoot() + lengthDuMm.MmToFoot()));
                                result.Add(ldu);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
