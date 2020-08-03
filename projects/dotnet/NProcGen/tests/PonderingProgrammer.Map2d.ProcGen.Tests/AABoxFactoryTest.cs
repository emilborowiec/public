using Xunit;

namespace PonderingProgrammer.Map2d.ProcGen.Tests
{
    public class AABoxFactoryTest
    {
        [Fact]
        public void TestSubdividingEvenSizeInHalf()
        {
            var factory = new AABoxFactory();
            var superBox = new AABox(0, 0, 4, 4);
            var leftHalf = factory.CreateSubBox(superBox, Alignment.LEFT, 0.5, 1);
            Assert.Equal(0, leftHalf.MinX);
            Assert.Equal(2, leftHalf.MaxXExclusive);
            Assert.Equal(2, leftHalf.Width);
            var rightHalf = factory.CreateSubBox(superBox, Alignment.RIGHT, 0.5, 1);
            Assert.Equal(2, rightHalf.MinX);
            Assert.Equal(4, rightHalf.MaxXExclusive);
            Assert.Equal(2, rightHalf.Width);
        }

        [Fact]
        public void TestSubdividingOddSizeInHalf()
        {
            var factory = new AABoxFactory();
            var superBox = new AABox(0, 0, 3, 3);
            var leftHalf = factory.CreateSubBox(superBox, Alignment.LEFT, 0.5, 1);
            Assert.Equal(0, leftHalf.MinX);
            Assert.Equal(1, leftHalf.MaxXExclusive);
            Assert.Equal(1, leftHalf.Width);
            var rightHalf = factory.CreateSubBox(superBox, Alignment.RIGHT, 0.5, 1);
            Assert.Equal(2, rightHalf.MinX);
            Assert.Equal(3, rightHalf.MaxXExclusive);
            Assert.Equal(1, rightHalf.Width);
        }

        [Fact]
        public void TestSubdividingOddSizeInHalfRoundUp()
        {
            var factory = new AABoxFactory();
            var superBox = new AABox(0, 0, 3, 3);
            var leftHalf = factory.CreateSubBox(superBox, Alignment.LEFT, 0.5, 1, true);
            Assert.Equal(0, leftHalf.MinX);
            Assert.Equal(2, leftHalf.MaxXExclusive);
            Assert.Equal(2, leftHalf.Width);
            var rightHalf = factory.CreateSubBox(superBox, Alignment.RIGHT, 0.5, 1, true);
            Assert.Equal(1, rightHalf.MinX);
            Assert.Equal(3, rightHalf.MaxXExclusive);
            Assert.Equal(2, rightHalf.Width);
        }

        [Fact]
        public void TestCreateSubAABox()
        {
            var factory = new AABoxFactory();
            var superEnv = new AABox(0, 0, 100, 200);
            var topHalf = factory.CreateSubBox(superEnv, Alignment.TOP, 1, 0.5);
            Assert.Equal(100, topHalf.Width);
            Assert.Equal(100, topHalf.Height);
            Assert.Equal(0, topHalf.MinX);
            Assert.Equal(0, topHalf.MinY);
            var botRightQuarter = factory.CreateSubBox(superEnv, Alignment.BOTTOM_RIGHT, 0.5, 0.5);
            Assert.Equal(50, botRightQuarter.Width);
            Assert.Equal(100, botRightQuarter.Height);
            Assert.Equal(50, botRightQuarter.MinX);
            Assert.Equal(100, botRightQuarter.MinY);
        }
    }
}
