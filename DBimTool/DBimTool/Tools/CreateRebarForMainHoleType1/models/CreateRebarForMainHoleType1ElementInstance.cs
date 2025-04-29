using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using DBimTool.Utils.SelectFilters;
using DBimTool.Utils.RevHoles;
using DBimTool.Utils.FilterElementsInRevit;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.models
{
    public partial class CreateRebarForMainHoleType1ElementInstance : ObservableObject
    {
        private CreateRebarForMainHoleType1Cmd _cmd;
        public List<RebarBarType> RevDiameters { get; set; }
        public List<string> Diameters { get; set; }
        public RevHole1 RevHole1Info { get; }
        public MainHole1BottomSlabRebar MainHole1BottomSlabRebar { get; set; }
        public MainHole1Wall1 MainHole1Wall1 { get; set; }
        public MainHole1Wall2 MainHole1Wall2 { get; set; }
        public MainHole1Wall3 MainHole1Wall3 { get; set; }
        public MainHole1Wall4 MainHole1Wall4 { get; set; }
        [ObservableProperty]
        private double _coverMm = 20;
        public CreateRebarForMainHoleType1ElementInstance(CreateRebarForMainHoleType1Cmd cmd)
        {
            _cmd = cmd;
            RevDiameters = _cmd.Document.GetElementsFromClass<RebarBarType>();
            Diameters = RevDiameters.Select(x => x.Name).ToList();
            var f = _cmd.Document
                .GetElement(
                _cmd.UiDocument.Selection.PickObject(
                    ObjectType.Element, 
                    new GenericSelectionFilter(BuiltInCategory.OST_StructuralFoundation))) 
                as FamilyInstance;
            RevHole1Info = f.GetRevHole1();
            MainHole1BottomSlabRebar = MainHole1BottomSlabRebar.Init(RevHole1Info, Diameters);
            MainHole1Wall1 = new MainHole1Wall1(RevHole1Info);
            MainHole1Wall2 = new MainHole1Wall2(RevHole1Info);
            MainHole1Wall3 = new MainHole1Wall3(RevHole1Info);
            MainHole1Wall4 = new MainHole1Wall4(RevHole1Info);
        }
    }
}
