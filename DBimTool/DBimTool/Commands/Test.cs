using Autodesk.Revit.Attributes;
using Nice3point.Revit.Toolkit.External;
using Autodesk.Revit.UI.Selection;
using DBimTool.Utils.SelectFilters;
using DBimTool.Utils.RevHoles;
using System.Diagnostics;
using Newtonsoft.Json;
using DBimTool.Utils.NumberUtils;
using DBimTool.Utils.RevCurves;
using DBimTool.Tools.CreateRebarForMainHoleType1.models;

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
					var f = Document.GetElement(
						UiDocument.Selection.PickObject(ObjectType.Element, 
						new GenericSelectionFilter(BuiltInCategory.OST_StructuralFoundation))) as FamilyInstance;
					RevHole1 hole = f.GetRevHole1();
                    var d1 = new MainHole1Wall1(hole);
					if (d1 != null) { 
						var l1 = Line.CreateBound(d1.Opening.Center, d1.Opening.Center + d1.VtY * 1000.MmToFoot());
						using (var ts = new Transaction(Document, "name transaction"))
						{
							ts.Start();
							//--------
							Document.CreateCurves(l1);
							//--------
							ts.Commit();
						}
					}
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