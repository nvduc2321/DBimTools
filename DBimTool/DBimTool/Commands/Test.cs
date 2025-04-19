using Autodesk.Revit.Attributes;
using Nice3point.Revit.Toolkit.External;
using Autodesk.Revit.UI.Selection;
using DBimTool.Utils.SelectFilters;
using DBimTool.Utils.RevHoles;
using System.Diagnostics;
using Newtonsoft.Json;

namespace DBimTool.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Test : ExternalCommand
    {
        public override void Execute()
        {

			using (var tsg = new TransactionGroup(Document, "name transaction group"))
			{
				tsg.Start();
				try
				{
					//--------
					var f = Document.GetElement(UiDocument.Selection.PickObject(ObjectType.Element, new GenericSelectionFilter(BuiltInCategory.OST_StructuralFoundation)));
                    //--------
                    tsg.Assimilate();
				}
				catch (Autodesk.Revit.Exceptions.OperationCanceledException) { }
				catch (Exception)
				{
					tsg.RollBack();
				}
			}
        }
    }
}