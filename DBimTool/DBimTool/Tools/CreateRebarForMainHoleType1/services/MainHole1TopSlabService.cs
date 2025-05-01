using Autodesk.Revit.DB.Structure;
using DBimTool.Tools.CreateRebarForMainHoleType1.iservices;
using DBimTool.Tools.CreateRebarForMainHoleType1.models;
using DBimTool.Utils.Geometries;
using DBimTool.Utils.Messages;
using DBimTool.Utils.NumberUtils;
using DBimTool.Utils.RevitElements;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.services
{
    public class MainHole1TopSlabService : IMainHole1TopSlabService
    {
        private CreateRebarForMainHoleType1Cmd _cmd;
        private CreateRebarForMainHoleType1ElementInstance _elementInstance;
        public MainHole1TopSlabService(
            CreateRebarForMainHoleType1Cmd cmd,
            CreateRebarForMainHoleType1ElementInstance elementInstance)
        {
            _cmd = cmd;
            _elementInstance = elementInstance;
        }

        public void InstallRebarBotY()
        {
            try
            {
                var host = _cmd.Document.CreateHost(BuiltInCategory.OST_StructuralFoundation);
                var slabRebar = _elementInstance.MainHole1TopSlabRebar;
                var cover = _elementInstance.CoverMm.MmToFoot();
                var diameterType = _elementInstance.RevDiameters
                    .FirstOrDefault(x => x.Name == slabRebar.RebarBotY.NameDiameter);
                var diameter = diameterType.BarModelDiameter;
                var normal = slabRebar.HostInfo.VtX;
                foreach (var l in slabRebar.LineCenterY)
                {
                    try
                    {
                        var dir = l.Direction.Normalize();
                        var p1 = l.GetEndPoint(0)
                            + slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2)
                            + dir * (cover + diameter / 2);
                        var p2 = l.GetEndPoint(0)
                            - slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2)
                            + dir * (cover + diameter / 2);
                        var p3 = l.GetEndPoint(1)
                            - slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2)
                            - dir * (cover + diameter / 2);
                        var p4 = l.GetEndPoint(1)
                            + slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2)
                            - dir * (cover + diameter / 2);
                        var ps = new List<XYZ>() { p1, p2, p3, p4 };
                        var cs = ps.PointsToCurves();
                        var rebar = Rebar.CreateFromCurves(
                            _cmd.Document,
                            RebarStyle.Standard,
                            diameterType,
                            null,
                            null,
                            host,
                            normal,
                            cs,
                            RebarHookOrientation.Left,
                            RebarHookOrientation.Left,
                            true, true);

                        if (_cmd.Document.ActiveView is View3D view3d)
                            rebar.SetSolidInView(view3d, true);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                IO.ShowWarning(ex.Message);
            }
        }
        public void InstallRebarBotX()
        {
            try
            {
                var host = _cmd.Document.CreateHost(BuiltInCategory.OST_StructuralFoundation);
                var slabRebar = _elementInstance.MainHole1TopSlabRebar;
                var cover = _elementInstance.CoverMm.MmToFoot();
                var diameterType = _elementInstance.RevDiameters
                    .FirstOrDefault(x => x.Name == slabRebar.RebarBotX.NameDiameter);
                var diameterTypeBotY = _elementInstance.RevDiameters
                    .FirstOrDefault(x => x.Name == slabRebar.RebarBotY.NameDiameter);
                var diameter = diameterType.BarModelDiameter;
                var diameterBotY = diameterTypeBotY.BarModelDiameter;
                var normal = slabRebar.HostInfo.VtY;
                foreach (var l in slabRebar.LineCenterX)
                {
                    try
                    {
                        var dir = l.Direction.Normalize();
                        var p1 = l.GetEndPoint(0)
                            + slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2)
                            + dir * (cover + diameter / 2);
                        var p2 = l.GetEndPoint(0)
                            - slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2 - diameterBotY)
                            + dir * (cover + diameter / 2);
                        var p3 = l.GetEndPoint(1)
                            - slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2 - diameterBotY)
                            - dir * (cover + diameter / 2);
                        var p4 = l.GetEndPoint(1)
                            + slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2)
                            - dir * (cover + diameter / 2);
                        var ps = new List<XYZ>() { p1, p2, p3, p4 };
                        var cs = ps.PointsToCurves();
                        var rebar = Rebar.CreateFromCurves(
                            _cmd.Document,
                            RebarStyle.Standard,
                            diameterType,
                            null,
                            null,
                            host,
                            normal,
                            cs,
                            RebarHookOrientation.Left,
                            RebarHookOrientation.Left,
                            true, true);

                        if (_cmd.Document.ActiveView is View3D view3d)
                            rebar.SetSolidInView(view3d, true);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                IO.ShowWarning(ex.Message);
            }
        }
        public void InstallRebarTopY()
        {
            try
            {
                var host = _cmd.Document.CreateHost(BuiltInCategory.OST_StructuralFoundation);
                var slabRebar = _elementInstance.MainHole1TopSlabRebar;
                var cover = _elementInstance.CoverMm.MmToFoot();
                var diameterType = _elementInstance.RevDiameters
                    .FirstOrDefault(x => x.Name == slabRebar.RebarTopY.NameDiameter);
                var diameter = diameterType.BarModelDiameter;
                var normal = slabRebar.HostInfo.VtX;
                foreach (var l in slabRebar.LineCenterY)
                {
                    try
                    {
                        var dir = l.Direction.Normalize();
                        var p1 = l.GetEndPoint(0)
                            - slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2)
                            + dir * (cover + diameter / 2);
                        var p2 = l.GetEndPoint(0)
                            + slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2)
                            + dir * (cover + diameter / 2);
                        var p3 = l.GetEndPoint(1)
                            + slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2)
                            - dir * (cover + diameter / 2);
                        var p4 = l.GetEndPoint(1)
                            - slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2)
                            - dir * (cover + diameter / 2);
                        var ps = new List<XYZ>() { p1, p2, p3, p4 };
                        var cs = ps.PointsToCurves();
                        var rebar = Rebar.CreateFromCurves(
                            _cmd.Document,
                            RebarStyle.Standard,
                            diameterType,
                            null,
                            null,
                            host,
                            normal,
                            cs,
                            RebarHookOrientation.Left,
                            RebarHookOrientation.Left,
                            true, true);

                        if (_cmd.Document.ActiveView is View3D view3d)
                            rebar.SetSolidInView(view3d, true);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                IO.ShowWarning(ex.Message);
            }
        }
        public void InstallRebarTopX()
        {
            try
            {
                var host = _cmd.Document.CreateHost(BuiltInCategory.OST_StructuralFoundation);
                var slabRebar = _elementInstance.MainHole1TopSlabRebar;
                var cover = _elementInstance.CoverMm.MmToFoot();
                var diameterType = _elementInstance.RevDiameters
                    .FirstOrDefault(x => x.Name == slabRebar.RebarTopX.NameDiameter);
                var diameterTypeBotY = _elementInstance.RevDiameters
                    .FirstOrDefault(x => x.Name == slabRebar.RebarTopY.NameDiameter);
                var diameter = diameterType.BarModelDiameter;
                var diameterBotY = diameterTypeBotY.BarModelDiameter;
                var normal = slabRebar.HostInfo.VtY;
                foreach (var l in slabRebar.LineCenterX)
                {
                    try
                    {
                        var dir = l.Direction.Normalize();
                        var p1 = l.GetEndPoint(0)
                            - slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2)
                            + dir * (cover + diameter / 2);
                        var p2 = l.GetEndPoint(0)
                            + slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2 - diameterBotY)
                            + dir * (cover + diameter / 2);
                        var p3 = l.GetEndPoint(1)
                            + slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2 - diameterBotY)
                            - dir * (cover + diameter / 2);
                        var p4 = l.GetEndPoint(1)
                            - slabRebar.HostInfo.VtZ * (slabRebar.HostInfo.Thickness / 2 - cover - diameter / 2)
                            - dir * (cover + diameter / 2);
                        var ps = new List<XYZ>() { p1, p2, p3, p4 };
                        var cs = ps.PointsToCurves();
                        var rebar = Rebar.CreateFromCurves(
                            _cmd.Document,
                            RebarStyle.Standard,
                            diameterType,
                            null,
                            null,
                            host,
                            normal,
                            cs,
                            RebarHookOrientation.Left,
                            RebarHookOrientation.Left,
                            true, true);

                        if (_cmd.Document.ActiveView is View3D view3d)
                            rebar.SetSolidInView(view3d, true);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                IO.ShowWarning(ex.Message);
            }
        }
    }
}
