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
					service.AddSingleton<IMainHole1TopSlabService, MainHole1TopSlabService>();
					service.AddSingleton<IMainHole1Wall1Service, MainHole1Wall1Service>();
					service.AddSingleton<IMainHole1Wall2Service, MainHole1Wall2Service>();
					service.AddSingleton<IMainHole1Wall3Service, MainHole1Wall3Service>();
					service.AddSingleton<IMainHole1Wall4Service, MainHole1Wall4Service>();
					service.AddSingleton<IMainHole1NeekWall1Service, MainHole1NeekWall1Service>();
					service.AddSingleton<IMainHole1NeekWall2Service, MainHole1NeekWall2Service>();
					service.AddSingleton<IMainHole1NeekWall3Service, MainHole1NeekWall3Service>();
					service.AddSingleton<IMainHole1NeekWall4Service, MainHole1NeekWall4Service>();
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
