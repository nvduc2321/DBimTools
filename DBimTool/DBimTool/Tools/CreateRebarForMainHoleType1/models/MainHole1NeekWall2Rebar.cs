using DBimTool.Utils.Geometries;
using DBimTool.Utils.NumberUtils;
using DBimTool.Utils.RevCurves;
using DBimTool.Utils.RevHoles;
using DBimTool.Utils.RevRebars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.models
{
    public class MainHole1NeekWall2Rebar
    {
        private static double _spacingMm = 200;
        private static double _extentMm = 50;
        public MainHole1NeekWall2 HostInfo { get; set; }
        public RevRebarMesh RebarVerticalNear { get; set; }
        public RevRebarMesh RebarVerticalFar { get; set; }
        public RevRebarMesh RebarHorizontalNear { get; set; }
        public RevRebarMesh RebarHorizontalFar { get; set; }
        public List<Line> LineCenterVertical { get; set; }
        public List<Line> LineCenterHorizontal { get; set; }
        public static MainHole1NeekWall2Rebar Init(RevHole1 revHole1, List<string> diameters)
        {
            try
            {
                var wall = new MainHole1NeekWall2Rebar();
                wall.HostInfo = new MainHole1NeekWall2(revHole1);
                wall.RebarVerticalNear = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = _spacingMm, RevRebars = new List<RevRebar>() };
                wall.RebarVerticalFar = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = _spacingMm, RevRebars = new List<RevRebar>() };
                wall.RebarHorizontalNear = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = _spacingMm, RevRebars = new List<RevRebar>() };
                wall.RebarHorizontalFar = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = _spacingMm, RevRebars = new List<RevRebar>() };
                wall.LineCenterVertical = _initVerticalCenterLineRebar(wall);
                wall.LineCenterHorizontal = _initHorizontalCenterLineRebar(wall);
                wall.RebarVerticalNear.SpacingMmChanged = () =>
                {
                    wall.LineCenterVertical = _initVerticalCenterLineRebar(wall);
                };
                wall.RebarVerticalFar.SpacingMmChanged = () =>
                {
                    wall.LineCenterVertical = _initVerticalCenterLineRebar(wall);
                };
                wall.RebarHorizontalNear.SpacingMmChanged = () =>
                {
                    wall.LineCenterHorizontal = _initHorizontalCenterLineRebar(wall);
                };
                wall.RebarHorizontalFar.SpacingMmChanged = () =>
                {
                    wall.LineCenterHorizontal = _initHorizontalCenterLineRebar(wall);
                };
                return wall;
            }
            catch (Exception)
            {
            }
            return null;
        }
        private static List<Line> _initVerticalCenterLineRebar(MainHole1NeekWall2Rebar wall)
        {
            var results = new List<Line>();
            try
            {
                var result = new List<Line>();
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

                var p11 = p1.MidPoint(p2) - vtz * wall.HostInfo.RevHole1Info.ChieuDayTuongTren + vtx * _extentMm.MmToFoot();
                var p22 = p5.MidPoint(p6) + vtx * _extentMm.MmToFoot();
                var p33 = p7.MidPoint(p8);
                var p44 = p3.MidPoint(p4);
                var lengthMm = p11.Distance(p44).FootToMm();
                var qty = lengthMm.GetQuantityFromSpacing(spacingMm, _extentMm, out double lengthDuMm);
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
                if (wall.HostInfo.Opening == null) return result;
                foreach (var l in result)
                {
                    var ls = l.IntersectLineToLine(wall.HostInfo.Opening.Lines, wall.HostInfo.VtY);
                    if (ls.Any()) results.AddRange(ls);
                }
            }
            catch (Exception)
            {
            }
            return results;
        }
        private static List<Line> _initHorizontalCenterLineRebar(MainHole1NeekWall2Rebar wall)
        {
            var results = new List<Line>();
            try
            {
                var result = new List<Line>();
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

                var p11 = p1.MidPoint(p2) + vtz * _extentMm.MmToFoot();
                var p22 = p5.MidPoint(p6);
                var p33 = p7.MidPoint(p8);
                var p44 = p3.MidPoint(p4) + vtz * _extentMm.MmToFoot();
                var lengthMm = p11.Distance(p22).FootToMm();
                var qty = lengthMm.GetQuantityFromSpacing(spacingMm, _extentMm, out double lengthDuMm);
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
                if (wall.HostInfo.Opening == null) return result;
                foreach (var l in result)
                {
                    var ls = l.IntersectLineToLine(wall.HostInfo.Opening.Lines, wall.HostInfo.VtY);
                    if (ls.Any()) results.AddRange(ls);
                }
            }
            catch (Exception)
            {
            }
            return results;
        }
    }
}
