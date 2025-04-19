using DBimTool.Tools.CreateRebarForMainHoleType1.models;
using DBimTool.Tools.CreateRebarForMainHoleType1.views;
using DBimTool.Utils.NumberUtils;
using DBimTool.Utils.RevCurves;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.viewModels
{
    public partial class CreateRebarForMainHoleType1ViewModel
    {
        private CreateRebarForMainHoleType1Cmd _cmd;
        public CreateRebarForMainHoleType1ElementInstance ElementInstances { get; set; }
        public CreateRebarForMainHoleType1View MainView { get; set; }
        public CreateRebarForMainHoleType1ViewModel(
            CreateRebarForMainHoleType1Cmd cmd,
            CreateRebarForMainHoleType1ElementInstance elementInstances)
        {
            _cmd = cmd;
            ElementInstances = elementInstances;
            MainView = new CreateRebarForMainHoleType1View() { DataContext = this};
        }
        [RelayCommand]
        private void Ok()
        {
            MainView.Close();
            using (var ts = new Transaction(_cmd.Document, "name transaction"))
            {
                ts.Start();

                var axis = Line.CreateBound(ElementInstances.MainHole1BottomSlabRebar.HostInfo.Origin, 
                    ElementInstances.MainHole1BottomSlabRebar.HostInfo.Origin + XYZ.BasisZ * 10000.MmToFoot());
                _cmd.Document.CreateCurves(axis);
                //--------
                foreach (var item in ElementInstances.MainHole1BottomSlabRebar.RebarBotY.RevRebars)
                {
                    _cmd.Document.CreateCurves(item.Lines);
                }
                foreach (var item in ElementInstances.MainHole1BottomSlabRebar.RebarTopY.RevRebars)
                {
                    _cmd.Document.CreateCurves(item.Lines);
                }
                foreach (var item in ElementInstances.MainHole1BottomSlabRebar.RebarBotX.RevRebars)
                {
                    _cmd.Document.CreateCurves(item.Lines);
                }
                foreach (var item in ElementInstances.MainHole1BottomSlabRebar.RebarTopX.RevRebars)
                {
                    _cmd.Document.CreateCurves(item.Lines);
                }
                //--------
                ts.Commit();
            }
        }
        [RelayCommand]
        private void Cancel() 
        {
            MainView.Close();
        }
    }
}
