using DBimTool.Utils.Geometries;
using DBimTool.Utils.NumberUtils;
using DBimTool.Utils.RevHoles;
using DBimTool.Utils.RevRebars;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.models
{
    public class MainHole1Wall1Rebar
    {
        public MainHole1Wall1 HostInfo { get; set; }
        public RevRebarMesh RebarVerticalNear { get; set; }
        public RevRebarMesh RebarVerticalFar { get; set; }
        public RevRebarMesh RebarHorizontalNear { get; set; }
        public RevRebarMesh RebarHorizontalFar { get; set; }
        public List<Line> LineCenterVertical { get; set; }
        public List<Line> LineCenterHorizontal { get; set; }
        public static MainHole1Wall1Rebar Init(RevHole1 revHole1, List<string> diameters)
        {
            try
            {
                var wall = new MainHole1Wall1Rebar();
                wall.HostInfo = new MainHole1Wall1(revHole1);
                wall.RebarVerticalNear = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = 200, RevRebars = new List<RevRebar>() };
                wall.RebarVerticalFar = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = 200, RevRebars = new List<RevRebar>() };
                wall.RebarHorizontalNear = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = 200, RevRebars = new List<RevRebar>() };
                wall.RebarHorizontalFar = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = 200, RevRebars = new List<RevRebar>() };
                wall.LineCenterVertical = _initVerticalCenterLineRebar(wall);
                wall.LineCenterHorizontal = _initHorizontalCenterLineRebar(wall);
                _generateRebarVerticalNear(wall);
                _generateRebarVerticalFar(wall);
                _generateRebarHorizontalNear(wall);
                _generateRebarHorizontalFar(wall);
                wall.RebarVerticalNear.SpacingMmChanged = () =>
                {
                    wall.LineCenterVertical = _initVerticalCenterLineRebar(wall);
                    _generateRebarVerticalNear(wall);
                    _generateRebarVerticalFar(wall);
                };
                wall.RebarHorizontalNear.SpacingMmChanged = () =>
                {
                    wall.LineCenterHorizontal = _initHorizontalCenterLineRebar(wall);
                    _generateRebarHorizontalNear(wall);
                    _generateRebarHorizontalFar(wall);
                };
                return wall;
            }
            catch (Exception)
            {
            }
            return null;
        }
        private static void _generateRebarVerticalNear(MainHole1Wall1Rebar wall)
        {
            var result = new List<RevRebar>();
            try
            {
                
            }
            catch (Exception)
            {
            }
        }
        private static void _generateRebarVerticalFar(MainHole1Wall1Rebar wall)
        {
            var result = new List<RevRebar>();
            try
            {
                
            }
            catch (Exception)
            {
            }
        }
        private static void _generateRebarHorizontalNear(MainHole1Wall1Rebar wall)
        {
            var result = new List<RevRebar>();
            try
            {
                
            }
            catch (Exception)
            {
            }
        }
        private static void _generateRebarHorizontalFar(MainHole1Wall1Rebar wall)
        {
            var result = new List<RevRebar>();
            try
            {
                
            }
            catch (Exception)
            {
            }
        }
        private static List<Line> _initVerticalCenterLineRebar(MainHole1Wall1Rebar wall)
        {
            var result = new List<Line>();
            try
            {
                var spacingMm = wall.RebarHorizontalNear.SpacingMm;
                var vtx = wall.HostInfo.VtX;
                var vty = wall.HostInfo.VtY;
                var vtz = wall.HostInfo.VtZ;

                var p1 = wall.HostInfo.PointControls[0];
                var p2 = wall.HostInfo.PointControls[1];
                var p3 = wall.HostInfo.PointControls[2];
                var p4 = wall.HostInfo.PointControls[3];
                var p5 = wall.HostInfo.PointControls[4];
                var p6 = wall.HostInfo.PointControls[5];
                var p7 = wall.HostInfo.PointControls[6];
                var p8 = wall.HostInfo.PointControls[7];

                var p11 = p1.MidPoint(p2);
                var p22 = p5.MidPoint(p6);
                var p33 = p7.MidPoint(p8);
                var p44 = p3.MidPoint(p4);
                var lengthMm = p11.Distance(p44).FootToMm();
                var qty = lengthMm.GetQuantityFromSpacing(spacingMm, 0, out double lengthDuMm);
                for (int i = 0; i < qty; i++)
                {
                    try
                    {
                        var l = Line.CreateBound(p11 + i * vtx * spacingMm.MmToFoot(),
                            p22 + i * vtx * spacingMm.MmToFoot());
                        result.Add(l);
                        if (i == qty - 1)
                        {
                            if (lengthDuMm * 100 / spacingMm >= 30)
                            {
                                var ldu = Line.CreateBound(p11 + vtx * (i * spacingMm.MmToFoot() + lengthDuMm.MmToFoot()),
                                p22 + vtx * (i * spacingMm.MmToFoot() + lengthDuMm.MmToFoot()));
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
        private static List<Line> _initHorizontalCenterLineRebar(MainHole1Wall1Rebar wall)
        {
            var result = new List<Line>();
            try
            {
                var spacingMm = wall.RebarHorizontalNear.SpacingMm;
                var vtx = wall.HostInfo.VtX;
                var vty = wall.HostInfo.VtY;
                var vtz = wall.HostInfo.VtZ;

                var p1 = wall.HostInfo.PointControls[0];
                var p2 = wall.HostInfo.PointControls[1];
                var p3 = wall.HostInfo.PointControls[2];
                var p4 = wall.HostInfo.PointControls[3];
                var p5 = wall.HostInfo.PointControls[4];
                var p6 = wall.HostInfo.PointControls[5];
                var p7 = wall.HostInfo.PointControls[6];
                var p8 = wall.HostInfo.PointControls[7];

                var p11 = p1.MidPoint(p2);
                var p22 = p5.MidPoint(p6);
                var p33 = p7.MidPoint(p8);
                var p44 = p3.MidPoint(p4);
                var lengthMm = p11.Distance(p22).FootToMm();
                var qty = lengthMm.GetQuantityFromSpacing(spacingMm, 0, out double lengthDuMm);
                for (int i = 0; i < qty; i++)
                {
                    try
                    {
                        var l = Line.CreateBound(p11 + i * vtz * spacingMm.MmToFoot(),
                            p44 + i * vtz * spacingMm.MmToFoot());
                        result.Add(l);
                        if (i == qty - 1)
                        {
                            if (lengthDuMm * 100 / spacingMm >= 30)
                            {
                                var ldu = Line.CreateBound(p11 + vtz * (i * spacingMm.MmToFoot() + lengthDuMm.MmToFoot()),
                                p44 + vtz * (i * spacingMm.MmToFoot() + lengthDuMm.MmToFoot()));
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
