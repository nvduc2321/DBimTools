using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
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
    public class MainHole1TopSlabRebar
    {
        private static double _spacingMm = 200;
        private static double _extentMm = 50;
        public MainHole1TopSlab HostInfo { get; set; }
        public RevRebarMesh RebarTopY { get; set; }
        public RevRebarMesh RebarTopX { get; set; }
        public RevRebarMesh RebarBotY { get; set; }
        public RevRebarMesh RebarBotX { get; set; }
        public List<Line> LineCenterY { get; set; }
        public List<Line> LineCenterX { get; set; }
        public static MainHole1TopSlabRebar Init(RevHole1 revHole1, List<string> diameters)
        {
            try
            {
                var slabRebar = new MainHole1TopSlabRebar();
                slabRebar.HostInfo = new MainHole1TopSlab(revHole1);
                slabRebar.RebarTopY = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = _spacingMm, RevRebars = new List<RevRebar>() };
                slabRebar.RebarTopX = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = _spacingMm, RevRebars = new List<RevRebar>() };
                slabRebar.RebarBotY = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = _spacingMm, RevRebars = new List<RevRebar>() };
                slabRebar.RebarBotX = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = _spacingMm, RevRebars = new List<RevRebar>() };
                slabRebar.LineCenterY = _generateLineCenterY(slabRebar);
                slabRebar.LineCenterX = _generateLineCenterX(slabRebar);
                slabRebar.RebarBotY.SpacingMmChanged = () =>
                {
                    slabRebar.LineCenterY = _generateLineCenterY(slabRebar);
                };
                slabRebar.RebarTopY.SpacingMmChanged = () =>
                {
                    slabRebar.LineCenterY = _generateLineCenterY(slabRebar);
                };
                slabRebar.RebarBotX.SpacingMmChanged = () =>
                {
                    slabRebar.LineCenterX = _generateLineCenterX(slabRebar);
                };
                slabRebar.RebarTopX.SpacingMmChanged = () =>
                {
                    slabRebar.LineCenterX = _generateLineCenterX(slabRebar);
                };
                return slabRebar;
            }
            catch (Exception)
            {
            }
            return null;
        }
        private static List<Line> _generateLineCenterX(MainHole1TopSlabRebar slab)
        {
            var results = new List<Line>();
            var result = new List<Line>();
            try
            {
                var spacing = slab.RebarTopX.SpacingMm;
                var vtx = slab.HostInfo.VtX;
                var vty = slab.HostInfo.VtY;
                var vtz = slab.HostInfo.VtZ;
                var p1 = slab.HostInfo.PointControls[0];
                var p2 = slab.HostInfo.PointControls[1];
                var p3 = slab.HostInfo.PointControls[2];
                var p4 = slab.HostInfo.PointControls[3];
                var p5 = slab.HostInfo.PointControls[4];
                var p6 = slab.HostInfo.PointControls[5];
                var p7 = slab.HostInfo.PointControls[6];
                var p8 = slab.HostInfo.PointControls[7];

                var p11 = p1.MidPoint(p5) + vty * _extentMm.MmToFoot();
                var p22 = p2.MidPoint(p6);
                var p33 = p3.MidPoint(p7);
                var p44 = p4.MidPoint(p8) + vty * _extentMm.MmToFoot();

                var qty = slab.HostInfo.Length.FootToMm().GetQuantityFromSpacing(spacing, _extentMm, out double lengthDuMm);
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
                if (slab.HostInfo.Opening == null) return result;
                foreach (var l in result)
                {
                    var ls = l.IntersectLineToLine(slab.HostInfo.Opening.Lines, slab.HostInfo.VtZ);
                    if (ls.Any()) results.AddRange(ls);
                }
            }
            catch (Exception)
            {
            }
            return results;
        }
        private static List<Line> _generateLineCenterY(MainHole1TopSlabRebar slab)
        {
            var results = new List<Line>();
            var result = new List<Line>();
            try
            {
                var spacing = slab.RebarTopY.SpacingMm;
                var vtx = slab.HostInfo.VtX;
                var vty = slab.HostInfo.VtY;
                var vtz = slab.HostInfo.VtZ;
                var p1 = slab.HostInfo.PointControls[0];
                var p2 = slab.HostInfo.PointControls[1];
                var p3 = slab.HostInfo.PointControls[2];
                var p4 = slab.HostInfo.PointControls[3];
                var p5 = slab.HostInfo.PointControls[4];
                var p6 = slab.HostInfo.PointControls[5];
                var p7 = slab.HostInfo.PointControls[6];
                var p8 = slab.HostInfo.PointControls[7];

                var p11 = p1.MidPoint(p5) + vtx * _extentMm.MmToFoot();
                var p22 = p2.MidPoint(p6) + vtx * _extentMm.MmToFoot();
                var p33 = p3.MidPoint(p7);
                var p44 = p4.MidPoint(p8);

                var qty = slab.HostInfo.Width.FootToMm().GetQuantityFromSpacing(spacing, _extentMm, out double lengthDuMm);
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
                if (slab.HostInfo.Opening == null) return result;
                foreach (var l in result)
                {
                    var ls = l.IntersectLineToLine(slab.HostInfo.Opening.Lines, slab.HostInfo.VtZ);
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
