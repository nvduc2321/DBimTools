using DBimTool.Tools.CreateRebarForMainHoleType1.iservices;
using DBimTool.Tools.CreateRebarForMainHoleType1.models;
using DBimTool.Tools.CreateRebarForMainHoleType1.services;
using DBimTool.Tools.CreateRebarForMainHoleType1.views;
using DBimTool.Utils.NumberUtils;
using DBimTool.Utils.RevCurves;
using DBimTool.Utils.SkipWarning;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.viewModels
{
    public partial class CreateRebarForMainHoleType1ViewModel
    {
        private CreateRebarForMainHoleType1Cmd _cmd;
        private IMainHole1BottomSlabService _mainHole1BottomSlabService;
        private IMainHole1TopSlabService _mainHole1TopSlabService;
        public CreateRebarForMainHoleType1ElementInstance ElementInstances { get; set; }
        public CreateRebarForMainHoleType1View MainView { get; set; }
        public CreateRebarForMainHoleType1ViewModel(
            CreateRebarForMainHoleType1Cmd cmd,
            CreateRebarForMainHoleType1ElementInstance elementInstances,
            IMainHole1BottomSlabService mainHole1BottomSlabService,
            IMainHole1TopSlabService mainHole1TopSlabService)
        {
            _cmd = cmd;
            ElementInstances = elementInstances;
            _mainHole1BottomSlabService = mainHole1BottomSlabService;
            _mainHole1TopSlabService = mainHole1TopSlabService;
            MainView = new CreateRebarForMainHoleType1View() { DataContext = this };
        }
        [RelayCommand]
        private void Ok()
        {
            MainView.Close();
            using (var ts = new Transaction(_cmd.Document, "name transaction"))
            {
                ts.SkipAllWarnings();
                ts.Start();
                //--------
                _mainHole1BottomSlabService.InstallRebarTopY();
                _mainHole1BottomSlabService.InstallRebarBotY();
                _mainHole1BottomSlabService.InstallRebarTopX();
                _mainHole1BottomSlabService.InstallRebarBotX();

                _mainHole1TopSlabService.InstallRebarTopY();
                _mainHole1TopSlabService.InstallRebarBotY();
                _mainHole1TopSlabService.InstallRebarTopX();
                _mainHole1TopSlabService.InstallRebarBotX();
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
