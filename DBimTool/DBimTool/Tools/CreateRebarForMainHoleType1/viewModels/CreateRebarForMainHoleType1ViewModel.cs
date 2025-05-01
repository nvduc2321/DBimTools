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
        private IMainHole1Wall1Service _mainHole1Wall1Service;
        private IMainHole1Wall2Service _mainHole1Wall2Service;
        private IMainHole1Wall3Service _mainHole1Wall3Service;
        private IMainHole1Wall4Service _mainHole1Wall4Service;
        public CreateRebarForMainHoleType1ElementInstance ElementInstances { get; set; }
        public CreateRebarForMainHoleType1View MainView { get; set; }
        public CreateRebarForMainHoleType1ViewModel(
            CreateRebarForMainHoleType1Cmd cmd,
            CreateRebarForMainHoleType1ElementInstance elementInstances,
            IMainHole1BottomSlabService mainHole1BottomSlabService,
            IMainHole1TopSlabService mainHole1TopSlabService,
            IMainHole1Wall1Service mainHole1Wall1Service,
            IMainHole1Wall2Service mainHole1Wall2Service,
            IMainHole1Wall3Service mainHole1Wall3Service,
            IMainHole1Wall4Service mainHole1Wall4Service)
        {
            _cmd = cmd;
            ElementInstances = elementInstances;
            _mainHole1BottomSlabService = mainHole1BottomSlabService;
            _mainHole1TopSlabService = mainHole1TopSlabService;
            _mainHole1Wall1Service = mainHole1Wall1Service;
            _mainHole1Wall2Service = mainHole1Wall2Service;
            _mainHole1Wall3Service = mainHole1Wall3Service;
            _mainHole1Wall4Service = mainHole1Wall4Service;
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

                _mainHole1Wall1Service.InstallRebarVerticalNear();
                _mainHole1Wall1Service.InstallRebarHorizontalNear();
                _mainHole1Wall1Service.InstallRebarVerticalFar();
                _mainHole1Wall1Service.InstallRebarHorizontalFar();

                _mainHole1Wall2Service.InstallRebarVerticalNear();
                _mainHole1Wall2Service.InstallRebarHorizontalNear();
                _mainHole1Wall2Service.InstallRebarVerticalFar();
                _mainHole1Wall2Service.InstallRebarHorizontalFar();

                _mainHole1Wall3Service.InstallRebarVerticalNear();
                _mainHole1Wall3Service.InstallRebarHorizontalNear();
                _mainHole1Wall3Service.InstallRebarVerticalFar();
                _mainHole1Wall3Service.InstallRebarHorizontalFar();

                _mainHole1Wall4Service.InstallRebarVerticalNear();
                _mainHole1Wall4Service.InstallRebarHorizontalNear();
                _mainHole1Wall4Service.InstallRebarVerticalFar();
                _mainHole1Wall4Service.InstallRebarHorizontalFar();
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
