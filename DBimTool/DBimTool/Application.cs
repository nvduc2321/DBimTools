using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using DBimTool.Commands;
using DBimTool.Tools.CreateRebarForMainHoleType1;
using Nice3point.Revit.Toolkit.External;

namespace DBimTool
{
    public class Application : ExternalApplication
    {
        public RibbonPanel PANEL_MAIN_HOLE { get; private set; }
        public override void OnStartup()
        {
            Application.ControlledApplication.ApplicationInitialized += OnApplicationInitialized;
        }
        private void OnApplicationInitialized(object sender, ApplicationInitializedEventArgs e)
        {
            try
            {
                Application.CreateRibbonTab(Properties.Standard.TAB_NAME);
            }
            catch (Exception)
            {
            }
            PANEL_MAIN_HOLE = Application.CreateRibbonPanel(
                Properties.Standard.TAB_NAME,
                Properties.Standard.PANNEL_MAIN_HOLE);
            _initPanelCmdMainHoleRebar();
        }

        private void _initPanelCmdMainHoleRebar()
        {
            //create plan view
            PANEL_MAIN_HOLE.AddPushButton<CreateRebarForMainHoleType1Cmd>("Create Rebar")
                .SetImage("/DBimTool;component/Resources/Icons/RibbonIcon16.png")
                .SetLargeImage("/DBimTool;component/Resources/Icons/RibbonIcon32.png");

        }
    }
}