using DBimTool.Tools.CreateRebarForMainHoleType1.iservices;
using DBimTool.Tools.CreateRebarForMainHoleType1.models;
using DBimTool.Utils.RevCurves;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.services
{
    public class MainHole1BottomSlabService : IMainHole1BottomSlabService
    {
        private CreateRebarForMainHoleType1Cmd _cmd;
        private CreateRebarForMainHoleType1ElementInstance _elementInstance;
        public MainHole1BottomSlabService(
            CreateRebarForMainHoleType1Cmd cmd,
            CreateRebarForMainHoleType1ElementInstance elementInstance)
        {
            _cmd = cmd;
            _elementInstance = elementInstance;
        }
        public void InstallRebarBotX()
        {
            foreach (var item in _elementInstance.MainHole1BottomSlabRebar.RebarBotX.RevRebars)
            {
                _cmd.Document.CreateCurves(item.Lines);
            }
        }

        public void InstallRebarBotY()
        {
            foreach (var item in _elementInstance.MainHole1BottomSlabRebar.RebarBotY.RevRebars)
            {
                _cmd.Document.CreateCurves(item.Lines);
            }
        }

        public void InstallRebarTopX()
        {
            foreach (var item in _elementInstance.MainHole1BottomSlabRebar.RebarTopX.RevRebars)
            {
                _cmd.Document.CreateCurves(item.Lines);
            }
        }

        public void InstallRebarTopY()
        {
            foreach (var item in _elementInstance.MainHole1BottomSlabRebar.RebarTopY.RevRebars)
            {
                _cmd.Document.CreateCurves(item.Lines);
            }
        }
    }
}
