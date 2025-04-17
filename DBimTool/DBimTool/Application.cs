using Autodesk.Revit.UI;
using DBimTool.Commands;
using Nice3point.Revit.Toolkit.External;

namespace DBimTool
{
    public class Application : ExternalApplication
    {
        public RibbonPanel PANEL_MAIN_HOLE { get; private set; }
        public override void OnStartup()
        {
            _initTabTool();
            _initPanelCmdMainHoleRebar();
        }
        private void _initTabTool()
        {
            Application.CreateRibbonTab(Properties.Standard.TAB_NAME);
            PANEL_MAIN_HOLE = Application.CreateRibbonPanel(
                Properties.Standard.TAB_NAME,
                Properties.Standard.PANNEL_MAIN_HOLE);
        }
        private void _initPanelCmdMainHoleRebar()
        {
            //create plan view
            PANEL_MAIN_HOLE.AddPushButton<Commands.StartupCommand>("abc")
                .SetImage("/DBimTool;component/Resources/Icons/RibbonIcon16.png")
                .SetLargeImage("/DBimTool;component/Resources/Icons/RibbonIcon32.png");

        }
    }
}