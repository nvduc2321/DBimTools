using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBimTool.Tools.CreateRebarForMainHoleType1.iservices
{
    public interface IMainHole1NeekWall3Service
    {
        public void InstallRebarVerticalNear();
        public void InstallRebarVerticalFar();
        public void InstallRebarHorizontalNear();
        public void InstallRebarHorizontalFar();
    }
}
