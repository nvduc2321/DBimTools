using Autodesk.Revit.DB.Structure;
using DBimTool.Tools.CreateRebarForMainHoleType1.iservices;
using DBimTool.Tools.CreateRebarForMainHoleType1.models;
using DBimTool.Utils.Geometries;
using DBimTool.Utils.Messages;
using DBimTool.Utils.NumberUtils;
using DBimTool.Utils.RevitElements;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.services
{
    public class MainHole1Wall4Service : IMainHole1Wall4Service
    {
        private CreateRebarForMainHoleType1Cmd _cmd;
        private CreateRebarForMainHoleType1ElementInstance _elementInstance;
        public MainHole1Wall4Service(
            CreateRebarForMainHoleType1Cmd cmd,
            CreateRebarForMainHoleType1ElementInstance elementInstances)
        {
            _cmd = cmd;
            _elementInstance = elementInstances;
        }
        public void InstallRebarVerticalNear()
        {
            try
            {
                var host = _cmd.Document.CreateHost(BuiltInCategory.OST_StructuralFoundation);
                var wall = _elementInstance.MainHole1Wall4Rebar;
                var cover = _elementInstance.CoverMm.MmToFoot();
                var diameterType = _elementInstance.RevDiameters
                    .FirstOrDefault(x => x.Name == wall.RebarVerticalNear.NameDiameter);
                var diameter = diameterType.BarModelDiameter;
                var normal = wall.HostInfo.VtX;
                foreach (var l in wall.LineCenterVertical)
                {
                    try
                    {
                        var dir = l.Direction.Normalize();
                        var p1 = l.GetEndPoint(0)
                            - wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2)
                            + dir * (cover + diameter / 2);
                        var p2 = l.GetEndPoint(0)
                            + wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2)
                            + dir * (cover + diameter / 2);
                        var p3 = l.GetEndPoint(1)
                            + wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2)
                            - dir * (cover + diameter / 2);
                        var p4 = l.GetEndPoint(1)
                            - wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2)
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
                        {

#if REVIT2024 || REVIT2025
#else
                            rebar.SetSolidInView(view3d, true);
#endif
                        }
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
        public void InstallRebarHorizontalNear()
        {
            try
            {
                var host = _cmd.Document.CreateHost(BuiltInCategory.OST_StructuralFoundation);
                var wall = _elementInstance.MainHole1Wall4Rebar;
                var cover = _elementInstance.CoverMm.MmToFoot();
                var diameterType = _elementInstance.RevDiameters
                    .FirstOrDefault(x => x.Name == wall.RebarHorizontalNear.NameDiameter);
                var diameterTypeVer = _elementInstance.RevDiameters
                    .FirstOrDefault(x => x.Name == wall.RebarVerticalNear.NameDiameter);
                var diameter = diameterType.BarModelDiameter;
                var diameterVer = diameterTypeVer.BarModelDiameter;
                var normal = wall.HostInfo.VtZ;
                foreach (var l in wall.LineCenterHorizontal)
                {
                    try
                    {
                        var dir = l.Direction.Normalize();
                        var p1 = l.GetEndPoint(0)
                            - wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2)
                            + dir * (cover + diameter / 2);
                        var p2 = l.GetEndPoint(0)
                            + wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2 - diameterVer)
                            + dir * (cover + diameter / 2);
                        var p3 = l.GetEndPoint(1)
                            + wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2 - diameterVer)
                            - dir * (cover + diameter / 2);
                        var p4 = l.GetEndPoint(1)
                            - wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2)
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
                        {

#if REVIT2024 || REVIT2025
#else
                            rebar.SetSolidInView(view3d, true);
#endif
                        }
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
        public void InstallRebarVerticalFar()
        {
            try
            {
                var host = _cmd.Document.CreateHost(BuiltInCategory.OST_StructuralFoundation);
                var wall = _elementInstance.MainHole1Wall4Rebar;
                var cover = _elementInstance.CoverMm.MmToFoot();
                var diameterType = _elementInstance.RevDiameters
                    .FirstOrDefault(x => x.Name == wall.RebarVerticalFar.NameDiameter);
                var diameter = diameterType.BarModelDiameter;
                var normal = wall.HostInfo.VtX;
                foreach (var l in wall.LineCenterVertical)
                {
                    try
                    {
                        var dir = l.Direction.Normalize();
                        var p1 = l.GetEndPoint(0)
                            + wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2)
                            + dir * (cover + diameter / 2);
                        var p2 = l.GetEndPoint(0)
                            - wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2)
                            + dir * (cover + diameter / 2);
                        var p3 = l.GetEndPoint(1)
                            - wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2)
                            - dir * (cover + diameter / 2);
                        var p4 = l.GetEndPoint(1)
                            + wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2)
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
                        {

#if REVIT2024 || REVIT2025
#else
                            rebar.SetSolidInView(view3d, true);
#endif
                        }
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
        public void InstallRebarHorizontalFar()
        {
            try
            {
                var host = _cmd.Document.CreateHost(BuiltInCategory.OST_StructuralFoundation);
                var wall = _elementInstance.MainHole1Wall4Rebar;
                var cover = _elementInstance.CoverMm.MmToFoot();
                var diameterType = _elementInstance.RevDiameters
                    .FirstOrDefault(x => x.Name == wall.RebarHorizontalFar.NameDiameter);
                var diameterTypeVer = _elementInstance.RevDiameters
                    .FirstOrDefault(x => x.Name == wall.RebarVerticalFar.NameDiameter);
                var diameter = diameterType.BarModelDiameter;
                var diameterVer = diameterTypeVer.BarModelDiameter;
                var normal = wall.HostInfo.VtZ;
                foreach (var l in wall.LineCenterHorizontal)
                {
                    try
                    {
                        var dir = l.Direction.Normalize();
                        var p1 = l.GetEndPoint(0)
                            + wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2)
                            + dir * (cover + diameter / 2);
                        var p2 = l.GetEndPoint(0)
                            - wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2 - diameterVer)
                            + dir * (cover + diameter / 2);
                        var p3 = l.GetEndPoint(1)
                            - wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2 - diameterVer)
                            - dir * (cover + diameter / 2);
                        var p4 = l.GetEndPoint(1)
                            + wall.HostInfo.VtY * (wall.HostInfo.Thickness / 2 - cover - diameter / 2)
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
                        {

#if REVIT2024 || REVIT2025
#else
                            rebar.SetSolidInView(view3d, true);
#endif
                        }
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
