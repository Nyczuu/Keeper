using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Core.Tests.Projects
{
    public class BaseProjectTests : BaseTests
    {
        protected string _testName { get { return GeneratePseudoRandomProjectName(); } }

        private string GeneratePseudoRandomProjectName()
        {
            Random random = new Random();
            return $"TestName{random.Next(10000)}";
        }
    }
}
