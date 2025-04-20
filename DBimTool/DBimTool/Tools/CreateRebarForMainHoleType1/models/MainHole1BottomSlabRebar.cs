using DBimTool.Utils.NumberUtils;
using DBimTool.Utils.RevHoles;
using DBimTool.Utils.RevRebars;
using System.Windows.Forms;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.models
{
    public class MainHole1BottomSlabRebar
    {
        public MainHole1BottomSlab HostInfo { get; set; }
        public RevRebarMesh RebarTopY {  get; set; }
        public RevRebarMesh RebarTopX {  get; set; }
        public RevRebarMesh RebarBotY {  get; set; }
        public RevRebarMesh RebarBotX {  get; set; }
        public static MainHole1BottomSlabRebar Init(RevHole1 revHole1, List<string> diameters)
        {
            try
            {
                var mainHole1BottomSlabRebar = new MainHole1BottomSlabRebar();
                mainHole1BottomSlabRebar.HostInfo = new MainHole1BottomSlab(revHole1);
                mainHole1BottomSlabRebar.RebarTopY = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = 200, RevRebars = new List<RevRebar>()};
                mainHole1BottomSlabRebar.RebarTopX = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = 200, RevRebars = new List<RevRebar>()};
                mainHole1BottomSlabRebar.RebarBotY = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = 200, RevRebars = new List<RevRebar>()};
                mainHole1BottomSlabRebar.RebarBotX = new RevRebarMesh() { NameDiameter = diameters.FirstOrDefault(), SpacingMm = 200, RevRebars = new List<RevRebar>()};
                _generateRebarMeshBotY(mainHole1BottomSlabRebar);
                _generateRebarMeshTopY(mainHole1BottomSlabRebar);
                _generateRebarMeshBotX(mainHole1BottomSlabRebar);
                _generateRebarMeshTopX(mainHole1BottomSlabRebar);
                mainHole1BottomSlabRebar.RebarBotY.SpacingMmChanged = () =>
                {
                    _generateRebarMeshBotY(mainHole1BottomSlabRebar);
                };
                mainHole1BottomSlabRebar.RebarTopY.SpacingMmChanged = () =>
                {
                    _generateRebarMeshTopY(mainHole1BottomSlabRebar);
                };
                mainHole1BottomSlabRebar.RebarBotX.SpacingMmChanged = () =>
                {
                    _generateRebarMeshBotX(mainHole1BottomSlabRebar);
                };
                mainHole1BottomSlabRebar.RebarTopX.SpacingMmChanged = () =>
                {
                    _generateRebarMeshTopX(mainHole1BottomSlabRebar);
                };
                return mainHole1BottomSlabRebar;
            }
            catch (Exception)
            {
            }
            return null;
        }
        private static void _generateRebarMeshBotY(MainHole1BottomSlabRebar mainHole1BottomSlabRebar)
        {
            var result = new List<RevRebar>();
            try
            {
                var spacing = mainHole1BottomSlabRebar.RebarBotY.SpacingMm;
                var vtx = mainHole1BottomSlabRebar.HostInfo.VtX;
                var vty = mainHole1BottomSlabRebar.HostInfo.VtY;
                var vtz = mainHole1BottomSlabRebar.HostInfo.VtZ;
                mainHole1BottomSlabRebar.RebarBotY.RevRebars = new List<RevRebar>();
                var qty = mainHole1BottomSlabRebar.HostInfo.Length.FootToMm().GetQuantityFromSpacing(spacing, 0, out double lengthDuMm);
                for (int i = 0; i < qty; i++)
                {
                    try
                    {
                        var l = Line.CreateBound(mainHole1BottomSlabRebar.HostInfo.PointControls[0] + i * vty * spacing.MmToFoot(),
                            mainHole1BottomSlabRebar.HostInfo.PointControls[3] + i * vty * spacing.MmToFoot());
                        var rb = new RevRebar();
                        rb.Lines = new List<Curve>();
                        rb.Lines.AddRange(new List<Curve>() { l });
                        result.Add(rb);
                        if (i == qty - 1)
                        {
                            if (lengthDuMm * 100 / spacing >= 30)
                            {
                                var ldu = Line.CreateBound(mainHole1BottomSlabRebar.HostInfo.PointControls[0] + vty * (i * spacing.MmToFoot() + lengthDuMm.MmToFoot()),
                                mainHole1BottomSlabRebar.HostInfo.PointControls[3] + vty * (i * spacing.MmToFoot() + lengthDuMm.MmToFoot()));
                                var rbDu = new RevRebar();
                                rbDu.Lines.AddRange(new List<Curve>() { ldu });
                                result.Add(rbDu);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                foreach (var rebar in result)
                {
                    rebar.DiameterName = mainHole1BottomSlabRebar.RebarBotY.NameDiameter;
                    rebar.Normal = vty;
                    mainHole1BottomSlabRebar.RebarBotY.RevRebars.Add(rebar);
                }
            }
            catch (Exception)
            {
            }
        }
        private static void _generateRebarMeshTopY(MainHole1BottomSlabRebar mainHole1BottomSlabRebar)
        {
            var result = new List<RevRebar>();
            try
            {
                var spacing = mainHole1BottomSlabRebar.RebarTopY.SpacingMm;
                var vtx = mainHole1BottomSlabRebar.HostInfo.VtX;
                var vty = mainHole1BottomSlabRebar.HostInfo.VtY;
                var vtz = mainHole1BottomSlabRebar.HostInfo.VtZ;
                mainHole1BottomSlabRebar.RebarTopY.RevRebars = new List<RevRebar>();
                var qty = mainHole1BottomSlabRebar.HostInfo.Length.FootToMm().GetQuantityFromSpacing(spacing, 0, out double lengthDuMm);
                for (int i = 0; i < qty; i++)
                {
                    try
                    {
                        var l = Line.CreateBound(mainHole1BottomSlabRebar.HostInfo.PointControls[4] + i * vty * spacing.MmToFoot(),
                            mainHole1BottomSlabRebar.HostInfo.PointControls[7] + i * vty * spacing.MmToFoot());
                        var rb = new RevRebar();
                        rb.Lines = new List<Curve>();
                        rb.Lines.AddRange(new List<Curve>() { l });
                        result.Add(rb);
                        if (i == qty - 1)
                        {
                            if (lengthDuMm * 100 / spacing >= 30)
                            {
                                var ldu = Line.CreateBound(mainHole1BottomSlabRebar.HostInfo.PointControls[4] + vty * (i * spacing.MmToFoot() + lengthDuMm.MmToFoot()),
                                mainHole1BottomSlabRebar.HostInfo.PointControls[7] + vty * (i * spacing.MmToFoot() + lengthDuMm.MmToFoot()));
                                var rbDu = new RevRebar();
                                rbDu.Lines.AddRange(new List<Curve>() { ldu });
                                result.Add(rbDu);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                foreach (var rebar in result)
                {
                    rebar.DiameterName = mainHole1BottomSlabRebar.RebarTopY.NameDiameter;
                    rebar.Normal = vty;
                    mainHole1BottomSlabRebar.RebarTopY.RevRebars.Add(rebar);
                }
            }
            catch (Exception)
            {
            }
        }
        private static void _generateRebarMeshBotX(MainHole1BottomSlabRebar mainHole1BottomSlabRebar)
        {
            var result = new List<RevRebar>();
            try
            {
                var spacing = mainHole1BottomSlabRebar.RebarBotX.SpacingMm;
                var vtx = mainHole1BottomSlabRebar.HostInfo.VtX;
                var vty = mainHole1BottomSlabRebar.HostInfo.VtY;
                var vtz = mainHole1BottomSlabRebar.HostInfo.VtZ;
                mainHole1BottomSlabRebar.RebarBotX.RevRebars = new List<RevRebar>();
                var qty = mainHole1BottomSlabRebar.HostInfo.Width.FootToMm().GetQuantityFromSpacing(spacing, 0, out double lengthDuMm);
                for (int i = 0; i < qty; i++)
                {
                    try
                    {
                        var l = Line.CreateBound(mainHole1BottomSlabRebar.HostInfo.PointControls[0] + i * vtx * spacing.MmToFoot(),
                            mainHole1BottomSlabRebar.HostInfo.PointControls[1] + i * vtx * spacing.MmToFoot());
                        var rb = new RevRebar();
                        rb.Lines = new List<Curve>();
                        rb.Lines.AddRange(new List<Curve>() { l });
                        result.Add(rb);
                        if (i == qty - 1)
                        {
                            if (lengthDuMm * 100 / spacing >= 30)
                            {
                                var ldu = Line.CreateBound(mainHole1BottomSlabRebar.HostInfo.PointControls[0] + vtx * (i * spacing.MmToFoot() + lengthDuMm.MmToFoot()),
                                mainHole1BottomSlabRebar.HostInfo.PointControls[1] + vtx * (i * spacing.MmToFoot() + lengthDuMm.MmToFoot()));
                                var rbDu = new RevRebar();
                                rbDu.Lines.AddRange(new List<Curve>() { ldu });
                                result.Add(rbDu);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                foreach (var rebar in result)
                {
                    rebar.DiameterName = mainHole1BottomSlabRebar.RebarBotX.NameDiameter;
                    rebar.Normal = vtx;
                    mainHole1BottomSlabRebar.RebarBotX.RevRebars.Add(rebar);
                }
            }
            catch (Exception)
            {
            }
        }
        private static void _generateRebarMeshTopX(MainHole1BottomSlabRebar mainHole1BottomSlabRebar)
        {
            var result = new List<RevRebar>();
            try
            {
                var spacing = mainHole1BottomSlabRebar.RebarTopX.SpacingMm;
                var vtx = mainHole1BottomSlabRebar.HostInfo.VtX;
                var vty = mainHole1BottomSlabRebar.HostInfo.VtY;
                var vtz = mainHole1BottomSlabRebar.HostInfo.VtZ;
                mainHole1BottomSlabRebar.RebarTopX.RevRebars = new List<RevRebar>();
                var qty = mainHole1BottomSlabRebar.HostInfo.Width.FootToMm().GetQuantityFromSpacing(spacing, 0, out double lengthDuMm);
                for (int i = 0; i < qty; i++)
                {
                    try
                    {
                        var l = Line.CreateBound(mainHole1BottomSlabRebar.HostInfo.PointControls[4] + i * vtx * spacing.MmToFoot(),
                            mainHole1BottomSlabRebar.HostInfo.PointControls[5] + i * vtx * spacing.MmToFoot());
                        var rb = new RevRebar();
                        rb.Lines = new List<Curve>();
                        rb.Lines.AddRange(new List<Curve>() { l });
                        result.Add(rb);
                        if (i == qty - 1)
                        {
                            if (lengthDuMm * 100 / spacing >= 30)
                            {
                                var ldu = Line.CreateBound(mainHole1BottomSlabRebar.HostInfo.PointControls[4] + vtx * (i * spacing.MmToFoot() + lengthDuMm.MmToFoot()),
                                mainHole1BottomSlabRebar.HostInfo.PointControls[5] + vtx * (i * spacing.MmToFoot() + lengthDuMm.MmToFoot()));
                                var rbDu = new RevRebar();
                                rbDu.Lines.AddRange(new List<Curve>() { ldu });
                                result.Add(rbDu);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                foreach (var rebar in result)
                {
                    rebar.DiameterName = mainHole1BottomSlabRebar.RebarTopX.NameDiameter;
                    rebar.Normal = vtx;
                    mainHole1BottomSlabRebar.RebarTopX.RevRebars.Add(rebar);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
