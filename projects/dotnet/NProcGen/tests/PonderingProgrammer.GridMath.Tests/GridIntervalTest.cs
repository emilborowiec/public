using System;
using Xunit;

namespace PonderingProgrammer.GridMath.Tests
{
    public class GridIntervalTest
    {
        [Fact]
        public void TestRange()
        {
            var interval = new GridInterval(2, 5);
            Assert.Equal(3, interval.Range);
        }
        
        [Fact]
        public void TestArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new GridInterval(2, 2));
        }

        [Theory]
        [InlineData(-1, false)]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(2, false)]
        public void TestContains(int value, bool expected)
        {
            var interval = new GridInterval(0, 2);
            Assert.Equal(expected, interval.Contains(value));
        }
        
        [Theory]
        [InlineData(-1,3, false)]
        [InlineData(-1,2, false)]
        [InlineData(0,3, false)]
        [InlineData(0,1, true)]
        public void TestContainsInterval(int min, int max, bool expected)
        {
            var interval = new GridInterval(0, 2);
            Assert.Equal(expected, interval.Contains(new GridInterval(min, max)));
        }

        [Theory]
        [InlineData(-10, -3, false)]
        [InlineData(-10, 0, false)]
        [InlineData(-10, 1, true)]
        [InlineData(-10, 3, true)]
        [InlineData(0, 3, true)]
        [InlineData(4, 6, true)]
        [InlineData(0, 13, true)]
        [InlineData(9, 13, true)]
        [InlineData(-10, 13, true)]
        [InlineData(10, 13, false)]
        public void TestOverlaps(int min, int max, bool expected)
        {
            var interval = new GridInterval(0, 10);
            var other = new GridInterval(min, max);
            Assert.Equal(expected, interval.Overlaps(other));
        }
        
        [Theory]
        [InlineData(-2, -1, false)]
        [InlineData(-2, 0, true)]
        [InlineData(0, 10, false)]
        [InlineData(9, 10, false)]
        [InlineData(10, 12, true)]
        [InlineData(12, 32, false)]
        public void TestTouches(int min, int max, bool expected)
        {
            var interval = new GridInterval(0, 10);
            var other = new GridInterval(min, max);
            Assert.Equal(expected, interval.Touches(other));
        }
        

        [Theory]
        [InlineData(2, 4, true)]
        [InlineData(1, 5, true)]
        [InlineData(-3, 3, true)]
        [InlineData(1, 4, false)]
        [InlineData(-2, 3, false)]
        [InlineData(-4, -1, false)]
        public void TestIsEven(int min, int max, bool expected)
        {
            var interval = new GridInterval(min, max);
            Assert.Equal(expected, interval.IsEven());
        }

        [Fact]
        public void TestCenter()
        {
            var interval = new GridInterval(2, 5);
            Assert.Equal(3, interval.Center());
        }

        [Fact]
        public void TestCenterException()
        {
            var interval = new GridInterval(2, 6);
            Assert.Throws<InvalidOperationException>(() => interval.Center());
        }

        [Theory]
        [InlineData(2, 5, 3, 3)]
        [InlineData(2, 6, 3, 4)]
        public void TestCenterOrLowerAndHigher(int min, int max, int centerOrLower, int centerOrHigher)
        {
            var interval = new GridInterval(min, max);
            Assert.Equal(centerOrLower, interval.CenterOrLower());
            Assert.Equal(centerOrHigher, interval.CenterOrHigher());
        }

        [Fact]
        public void TestHalfRange()
        {
            var odd = new GridInterval(2, 5);
            var even = new GridInterval(2, 6);
            Assert.Equal(1, odd.HalfRangeOrLower());
            Assert.Equal(2, odd.HalfRangeOrHigher());
            Assert.Equal(2, even.HalfRangeOrLower());
            Assert.Equal(2, even.HalfRangeOrHigher());
        }

        [Fact]
        public void TestSplitEven()
        {
            var interval = new GridInterval(0, 2);
            var halves = interval.SplitEven();
            Assert.Equal(2, halves.Length);
            Assert.Equal(1, halves[0].Range);
            Assert.Equal(1, halves[1].Range);
            Assert.Equal(0, halves[0].Min);
            Assert.Equal(1, halves[0].MaxExcl);
            Assert.Equal(1, halves[1].Min);
            Assert.Equal(2, halves[1].MaxExcl);
        }

        [Fact]
        public void TestTranslate()
        {
            var interval = new GridInterval(0, 2);
            var translated = interval.Translate(5);
            Assert.Equal(5, translated.Min);
            Assert.Equal(7, translated.MaxExcl);
        }

        [Theory]
        [InlineData(0, 3, IntervalAnchor.Start, 20)]
        [InlineData(0, 3, IntervalAnchor.CenterOrLower, 19)]
        [InlineData(0, 3, IntervalAnchor.CenterOrHigher, 19)]
        [InlineData(0, 3, IntervalAnchor.End, 18)]
        [InlineData(0, 2, IntervalAnchor.Start, 20)]
        [InlineData(0, 2, IntervalAnchor.CenterOrLower, 20)]
        [InlineData(0, 2, IntervalAnchor.CenterOrHigher, 19)]
        [InlineData(0, 2, IntervalAnchor.End, 19)]
        public void TestSetPosition(int min, int max, IntervalAnchor anchor, int expectedMin)
        {
            var interval = new GridInterval(min, max);
            var translated = interval.SetPosition(20, anchor);
            Assert.Equal(expectedMin, translated.Min);
        }

        [Fact]
        public void TestSetMin()
        {
            var i1 = new GridInterval(20, 30);
            var i2 = new GridInterval(0, 4);
            var aligned = i2.SetMin(i1.Min);
            Assert.Equal(20, aligned.Min);
            Assert.Equal(24, aligned.MaxExcl);
        }

        [Fact]
        public void TestSetMax()
        {
            var i1 = new GridInterval(20, 30);
            var i2 = new GridInterval(0, 4);
            var aligned = i2.SetMaxExcl(i1.MaxExcl);
            Assert.Equal(26, aligned.Min);
            Assert.Equal(30, aligned.MaxExcl);
        }

        [Fact]
        public void TestRelate()
        {
            var i1 = new GridInterval(0, 4);
            var i2 = new GridInterval(10, 14);
            var related = i1.Relate(i2, Relation.StartToStart());
            Assert.Equal(10, related.Min);
            related = i1.Relate(i2, Relation.StartToCenterOrLower());
            Assert.Equal(11, related.Min);
            related = i1.Relate(i2, Relation.StartToCenterOrHigher());
            Assert.Equal(12, related.Min);
            related = i1.Relate(i2, Relation.StartToEnd());
            Assert.Equal(13, related.Min);
            related = i1.Relate(i2, Relation.EndToStart());
            Assert.Equal(7, related.Min);
            related = i1.Relate(i2, Relation.EndToCenterOrLower());
            Assert.Equal(8, related.Min);
            related = i1.Relate(i2, Relation.EndToCenterOrHigher());
            Assert.Equal(9, related.Min);
            related = i1.Relate(i2, Relation.EndToEnd());
            Assert.Equal(10, related.Min);
        }
        
        [Theory]
        [InlineData(0, 10, 0.01, 1)]
        [InlineData(0, 10, 0.2, 2)]
        [InlineData(0, 10, 0.5, 5)]
        public void TestFraction(int min, int max, double fraction, int expectedMax)
        {
            var interval = new GridInterval(min, max);
            var result = interval.Fraction(fraction);
            Assert.Equal(expectedMax, result.MaxExcl);
        }
    }
}
