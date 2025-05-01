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
        public MainHole1TopSlabRebar MainHole1TopSlabRebar { get; set; }
        public MainHole1Wall1Rebar MainHole1Wall1Rebar { get; set; }
        public MainHole1Wall2Rebar MainHole1Wall2Rebar { get; set; }
        public MainHole1Wall3Rebar MainHole1Wall3Rebar { get; set; }
        public MainHole1Wall4Rebar MainHole1Wall4Rebar { get; set; }
        public MainHole1NeekWall1Rebar MainHole1NeekWall1Rebar { get; set; }
        public MainHole1NeekWall2Rebar MainHole1NeekWall2Rebar { get; set; }
        public MainHole1NeekWall3Rebar MainHole1NeekWall3Rebar { get; set; }
        public MainHole1NeekWall4Rebar MainHole1NeekWall4Rebar { get; set; }
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
            MainHole1TopSlabRebar = MainHole1TopSlabRebar.Init(RevHole1Info, Diameters);
            MainHole1Wall1Rebar = MainHole1Wall1Rebar.Init(RevHole1Info, Diameters);
            MainHole1Wall2Rebar = MainHole1Wall2Rebar.Init(RevHole1Info, Diameters);
            MainHole1Wall3Rebar = MainHole1Wall3Rebar.Init(RevHole1Info, Diameters);
            MainHole1Wall4Rebar = MainHole1Wall4Rebar.Init(RevHole1Info, Diameters);
            MainHole1NeekWall1Rebar = MainHole1NeekWall1Rebar.Init(RevHole1Info, Diameters);
            MainHole1NeekWall2Rebar = MainHole1NeekWall2Rebar.Init(RevHole1Info, Diameters);
            MainHole1NeekWall3Rebar = MainHole1NeekWall3Rebar.Init(RevHole1Info, Diameters);
            MainHole1NeekWall4Rebar = MainHole1NeekWall4Rebar.Init(RevHole1Info, Diameters);
        }
    }
}
