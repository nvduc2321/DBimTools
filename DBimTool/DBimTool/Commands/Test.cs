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
					var slab1 = MainHole1BottomSlabRebar.Init(hole, new List<string>());
					var sn1 = MainHole1Wall1Rebar.Init(hole, new List<string>());
					var sn2 = MainHole1Wall2Rebar.Init(hole, new List<string>());
					var sn3 = MainHole1Wall3Rebar.Init(hole, new List<string>());
					var sn4 = MainHole1Wall4Rebar.Init(hole, new List<string>());

					using (var ts = new Transaction(Document, "name transaction"))
					{
						ts.Start();
						//--------
						Document.CreateCurves(slab1.LineCenterX.Select(x=> x as Curve).ToList());
						Document.CreateCurves(slab1.LineCenterY.Select(x=> x as Curve).ToList());

						Document.CreateCurves(sn1.LineCenterVertical.Select(x=> x as Curve).ToList());
						Document.CreateCurves(sn1.LineCenterHorizontal.Select(x=> x as Curve).ToList());

						Document.CreateCurves(sn2.LineCenterVertical.Select(x => x as Curve).ToList());
						Document.CreateCurves(sn2.LineCenterHorizontal.Select(x => x as Curve).ToList());

						Document.CreateCurves(sn3.LineCenterVertical.Select(x => x as Curve).ToList());
						Document.CreateCurves(sn3.LineCenterHorizontal.Select(x => x as Curve).ToList());

						Document.CreateCurves(sn4.LineCenterVertical.Select(x => x as Curve).ToList());
						Document.CreateCurves(sn4.LineCenterHorizontal.Select(x => x as Curve).ToList());
						//--------
						ts.Commit();
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