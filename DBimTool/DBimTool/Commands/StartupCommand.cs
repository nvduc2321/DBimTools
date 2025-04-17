using Autodesk.Revit.Attributes;
using DBimTool.ViewModels;
using DBimTool.Views;
using Nice3point.Revit.Toolkit.External;

namespace DBimTool.Commands
{
    /// <summary>
    ///     External command entry point invoked from the Revit interface
    /// </summary>
    [UsedImplicitly]
    [Transaction(TransactionMode.Manual)]
    public class StartupCommand : ExternalCommand
    {
        public override void Execute()
        {
            var viewModel = new DBimToolViewModel();
            var view = new DBimToolView(viewModel);
            view.ShowDialog();
        }
    }
}