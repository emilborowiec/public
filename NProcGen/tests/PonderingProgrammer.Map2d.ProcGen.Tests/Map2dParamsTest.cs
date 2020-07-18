using Xunit;

namespace PonderingProgrammer.Map2d.ProcGen.Tests
{
    public class Map2dParamsTest
    {
        [Fact]
        public void TestViolationMessages()
        {
            var pars = new Map2dParams { Width = 3, Height = 3, DesiredCellCount = 5 };
            Assert.Empty(pars.GetValidationErrors());
            pars = new Map2dParams { Width = 1, Height = 0, DesiredCellCount = 10 };
            Assert.Equal(3, pars.GetValidationErrors().Count);
        }
    }
}
