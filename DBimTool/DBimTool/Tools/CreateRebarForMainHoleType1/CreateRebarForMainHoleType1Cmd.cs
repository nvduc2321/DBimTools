using Autodesk.Revit.Attributes;
using DBimTool.Tools.CreateRebarForMainHoleType1.iservices;
using DBimTool.Tools.CreateRebarForMainHoleType1.models;
using DBimTool.Tools.CreateRebarForMainHoleType1.services;
using DBimTool.Tools.CreateRebarForMainHoleType1.viewModels;
using Microsoft.Extensions.DependencyInjection;
using Nice3point.Revit.Toolkit.External;

namespace DBimTool.Tools.CreateRebarForMainHoleType1
{
	[Transaction(TransactionMode.Manual)]
    public class CreateRebarForMainHoleType1Cmd : ExternalCommand
    {
        public override void Execute()
        {

			using (var tsg = new TransactionGroup(Document, "name transaction group"))
			{
				tsg.Start();
				try
				{
					//--------
					var service = new ServiceCollection();
					service.AddSingleton<CreateRebarForMainHoleType1Cmd>();
					service.AddSingleton<CreateRebarForMainHoleType1ViewModel>();
					service.AddSingleton<CreateRebarForMainHoleType1ElementInstance>();
					service.AddSingleton<IMainHole1BottomSlabService, MainHole1BottomSlabService>();
					var provider = service.BuildServiceProvider();
					var vm = provider.GetService<CreateRebarForMainHoleType1ViewModel>();
					vm.MainView.ShowDialog();
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
