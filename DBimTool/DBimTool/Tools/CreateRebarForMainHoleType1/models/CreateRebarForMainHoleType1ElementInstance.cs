using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using DBimTool.Utils.SelectFilters;
using DBimTool.Utils.RevHoles;
using DBimTool.Utils.FilterElementsInRevit;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.models
{
    public class CreateRebarForMainHoleType1ElementInstance
    {
        private CreateRebarForMainHoleType1Cmd _cmd;
        public List<RebarBarType> RevDiameters { get; set; }
        public List<string> Diameters { get; set; }
        public MainHole1BottomSlabRebar MainHole1BottomSlabRebar { get; set; }
        public RevHole1 RevHole1Info { get; }
        public CreateRebarForMainHoleType1ElementInstance(CreateRebarForMainHoleType1Cmd cmd)
        {
            _cmd = cmd;
            RevDiameters = _cmd.Document.GetElementsFromClass<RebarBarType>();
            Diameters = RevDiameters.Select(x => x.Name).ToList();
            var f = _cmd.Document.GetElement(_cmd.UiDocument.Selection.PickObject(ObjectType.Element, new GenericSelectionFilter(BuiltInCategory.OST_StructuralFoundation))) as FamilyInstance;
            RevHole1Info = f.GetRevHole1();
            MainHole1BottomSlabRebar = MainHole1BottomSlabRebar.Init(RevHole1Info, Diameters);
        }
    }
}
